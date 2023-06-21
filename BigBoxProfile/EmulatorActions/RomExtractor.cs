﻿using BigBoxProfile.RomExtractorUtils;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace BigBoxProfile.EmulatorActions
{
	internal class RomExtractor : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public RomExtractor()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "RomExtractor";

		private string _cachedir = "";
		private int _cacheMaxSize = 0;
		private string _filter = "";
		private string _excludeFilter = "";
		private string _standaloneExtensions = "gb, gbc, gba, agb, nes, fds, smc, sfc, n64, z64, v64, ndd, md, smd, gen, iso, chd, gg, gcm, 32x, bin";
		private string _metadataExtensions = "nfo, txt, dat, xml, json, htc, hts";
		private List<RomExtractor_PriorityData> _priority = new List<RomExtractor_PriorityData>();
		private Dictionary<string,string> _extractDone= new Dictionary<string,string>();



		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new RomExtractor();
		}

		public void Configure()
		{
			var frm = new RomExtractor_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["cachedir"] = frm.cachedir.Trim();
				Options["cacheMaxSize"] = frm.cacheMaxSize.Trim();
				Options["filter"] = frm.filter.Trim();
				Options["excludeFilter"] = frm.excludeFilter.Trim();
				Options["standaloneExtensions"] = frm.standaloneExtensions.Trim();
				Options["metadataExtensions"] = frm.metadataExtensions.Trim();
				Options["priority"] = frm.priority.Trim();
				UpdateConfig();
			}
			


		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("cachedir") == false) Options["cachedir"] = "";
			if (Options.ContainsKey("cacheMaxSize") == false) Options["cacheMaxSize"] = "0";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("excludeFilter") == false) Options["excludeFilter"] = "";
			if (Options.ContainsKey("standaloneExtensions") == false) Options["standaloneExtensions"] = "gb, gbc, gba, agb, nes, fds, smc, sfc, n64, z64, v64, ndd, md, smd, gen, iso, chd, gg, gcm, 32x, bin";
			if (Options.ContainsKey("metadataExtensions") == false) Options["metadataExtensions"] = "nfo, txt, dat, xml, json, htc, hts";
			if (Options.ContainsKey("priority") == false) Options["priority"] = "";
			UpdateConfig();


		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("priority") == false || Options["priority"] == "")
			{
				return false;
			}
			if (Options.ContainsKey("cachedir") == false || Options["cachedir"] == "")
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				description = $"Extract to {_cachedir}";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		public string[] ModifyExemple(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}
		public string[] Modify(string[] args)
		{

			return args;
		}



		public string[] ModifyReal(string[] args)
		{
			if (_extractDone.Count == 0) return args;

			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			var newarg = new string[filteredArgs.Length];
			int index = 0;
			foreach (var elem in filteredArgs)
			{
				if (_extractDone.ContainsKey(elem))
				{
					newarg[index] = _extractDone[elem];
				}
				else newarg[index] = elem;
				index++;
			}
			args = BigBoxUtils.AddFirstElementToArg(newarg, exeArg);
			return args;
		}

		private void UpdateConfig()
		{
			_cachedir = Options["cachedir"];

			int cacheMaxSize = 0;
			try
			{
				int.TryParse(Options["cacheMaxSize"], out cacheMaxSize);
			}
			catch { }
			_cacheMaxSize= cacheMaxSize;
			_filter = Options["filter"];
			_excludeFilter = Options["excludeFilter"];
			_standaloneExtensions = Options["standaloneExtensions"];
			_metadataExtensions = Options["metadataExtensions"];

			if (!String.IsNullOrEmpty(Options["priority"]))
			{
				var priority_arr = BigBoxUtils.explode(Options["priority"], "|||");
				foreach(var p in priority_arr)
				{
					//var pObj = new RomExtractor_PriorityData(p);
					_priority.Add(new RomExtractor_PriorityData(p));
				}
			}

		}

		public void ExecuteBefore(string[] args)
		{
			//Thread.Sleep(8000);
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd.ToLower().Trim().Contains(_filter.ToLower().Trim()))
			{
				return;
			}
			if(_excludeFilter != "" && cmd.ToLower().Trim().Contains(_excludeFilter.ToLower().Trim()))
			{
				return;
			}
			if(!Directory.Exists(_cachedir))
			{
				return;
			}

			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			string archiveFilePath = "";
			foreach (var elem in filteredArgs)
			{
				if (elem.Contains(_filter) && archiveFilePath=="")
				{
					if (File.Exists(elem))
					{
						string ext = Path.GetExtension(elem).ToLower();
						if(ext == ".rar" || ext == ".zip" || ext == ".7z")
						{
							archiveFilePath = elem;
						}
					}
				}
			}

			if (archiveFilePath == "") return;
			RomExtractor_PriorityData SelectedPriority = _priority.First();
			foreach(var p in _priority)
			{
				if (p.Paths[0] == "Default Options") continue;
				foreach(var path in p.Paths)
				{
					if (archiveFilePath.Contains(path))
					{
						SelectedPriority = p;
						break;
					}
				}

			}

			List<string> PrioritySubDirFullList = new List<string>();
			foreach(var p in _priority)
			{
				if (p.CacheSubDir != "" && !PrioritySubDirFullList.Contains(p.CacheSubDir)) PrioritySubDirFullList.Add(p.CacheSubDir);
			}

			var frm = new RomExtractor_Task(archiveFilePath, SelectedPriority, _cachedir, _cacheMaxSize, _standaloneExtensions, _metadataExtensions, PrioritySubDirFullList.ToArray());
			var targetProcess = Process.GetProcessesByName("LaunchBox").FirstOrDefault(p => p.MainWindowTitle != "");
			if (targetProcess == null) targetProcess = Process.GetProcessesByName("BigBox").FirstOrDefault(p => p.MainWindowTitle != "");
			if (targetProcess != null)
			{
				var screen = Screen.FromHandle(targetProcess.MainWindowHandle);
				int x = screen.Bounds.Left + (screen.Bounds.Width - frm.Width) / 2;
				int y = screen.Bounds.Top + (screen.Bounds.Height - frm.Height) / 2;
				// Définir la position de la fenêtre
				frm.StartPosition = FormStartPosition.Manual;
				frm.Location = new Point(x, y);
			}

			frm.TopMost = true; // Affiche la fenêtre devant toutes les autres
			frm.ShowDialog();
			frm.Focus(); // Donne le focus à la fenêtre

			_extractDone.Add(archiveFilePath, frm.OutFile);

			//MessageBox.Show($"Load {archiveFilePath} on {_cachedir} with {SelectedPriority.Serialize()}");


		}


		public void ExecuteAfter(string[] args)
		{

		}

		public bool UseM3UContent()
		{
			return false;
		}
	}
}
