﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;

namespace BigBoxProfile.EmulatorActions
{
	internal class ExecuteAHK : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public ExecuteAHK()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "ExecuteAHK";

		private string _filter = "";
		private string _ahkCodeExemple = "";
		private string _ahkCodeReal = "";
		private string _ahkCodeBefore = "";
		private string _ahkCodeAfter = "";

		private bool _runbeforebackground = false;

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new ExecuteAHK();
		}

		public void Configure()
		{

			var frm = new ExecuteAHK_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["filter"] = frm.filter.Trim();
				Options["ahkCodeExemple"] = frm.ahkCodeExemple.Trim();
				Options["ahkCodeReal"] = frm.ahkCodeReal.Trim();
				Options["ahkCodeBefore"] = frm.ahkCodeBefore.Trim();
				Options["ahkCodeAfter"] = frm.ahkCodeAfter.Trim();

				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				if (frm.matchAllFilter) Options["matchAllFilter"] = "yes";
				else Options["matchAllFilter"] = "no";

				if (frm.matchAllExclude) Options["matchAllExclude"] = "yes";
				else Options["matchAllExclude"] = "no";

				if (frm.runbeforebackground) Options["runbeforebackground"] = "yes";
				else Options["runbeforebackground"] = "no";



				UpdateConfig();
			}


		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("ahkCodeExemple") == false) Options["ahkCodeExemple"] = "";
			if (Options.ContainsKey("ahkCodeReal") == false) Options["ahkCodeReal"] = "";
			if (Options.ContainsKey("ahkCodeBefore") == false) Options["ahkCodeBefore"] = "";
			if (Options.ContainsKey("ahkCodeAfter") == false) Options["ahkCodeAfter"] = "";
			if (Options.ContainsKey("runbeforebackground") == false) Options["runbeforebackground"] = "no";

			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			if (Options.ContainsKey("matchAllFilter") == false) Options["matchAllFilter"] = "no";
			if (Options.ContainsKey("matchAllExclude") == false) Options["matchAllExclude"] = "no";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				string matchall = "";
				string matchallexclude = "";
				if (_matchAllFilter) matchall = "[matchall=on]";
				if (_matchAllExclude) matchallexclude = "[matchall=on]";

				description = "Execute user definited ahk code";
				if (_filter != "") description += $" [Only if command line contains {_filter}]{matchall}";
				if (_exclude != "") description += $" [Exclude {_exclude}]{matchallexclude}";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		private string[] AhkExecute(string[] args, string code)
		{
            if (!EmulatorLauncher.UseAhkExe)
            {
				var ahk_session = new AutoHotkey.Interop.AutoHotkeyEngine();

				string code_prefix_gamedata = "";
				string code_prefix_args = "";
				if (code.Contains("#includegamedata"))
				{
					code = code.Replace("#includegamedata", "");
					code_prefix_gamedata = BigBoxUtils.AHKGetPrefix();
				}
				else code_prefix_gamedata = BigBoxUtils.AHKGetArgPrefix();


				code = code.Replace("#includeargs", "");
				code_prefix_args += "Args := []\n";
				code_prefix_args += "OriginalArgs := []\n";
				int i = 0;
				foreach (var arg in args)
				{
					ahk_session.SetVar($"arg{i}", arg);
					code_prefix_args += $@"Args.Insert({i}, arg{i})";
					code_prefix_args += "\n";
					i++;
				}

				code_prefix_args += "\n";
				if (EmulatorLauncher.OriginalArgs != null)
				{
					int y = 0;
					foreach (var arg in EmulatorLauncher.OriginalArgs)
					{
						ahk_session.SetVar($"originalarg{y}", arg);
						code_prefix_args += $@"OriginalArgs.Insert({y}, originalarg{y})";
						code_prefix_args += "\n";
						y++;
					}
				}

				code = code_prefix_gamedata + "\n" + code_prefix_args + "\n" + code;
				code += "\n";
				code += @"resultatfinal := Args.join(""|||"")";
				code += "\n";

				try
				{
					ahk_session.ExecRaw(code);
					string resultatfinal = ahk_session.GetVar("resultatfinal");
					args = BigBoxUtils.explode(resultatfinal, "|||");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			else
			{
				try
				{
					code = BigBoxUtils.GetAHKCode(code, args, true);
					string currentDir = Path.GetFullPath(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
					string ahkExe = Path.Combine(currentDir, "AutoHotkeyU32.exe");
					string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".ahk");
					string tempFileRes = tempFilePath + ".res.txt";
					code += "\n";
					code += @"resultatfinal := Args.join(""|||"")";
					code += "\n";
					code += @"FileAppend, %resultatfinal%, " + tempFileRes;
					code += "\n";
					File.WriteAllText(tempFilePath, code);
					if (File.Exists(tempFilePath))
					{
						Process process = new Process();
						process.StartInfo.FileName = ahkExe;
						process.StartInfo.Arguments = tempFilePath;
						process.StartInfo.UseShellExecute = false;
						process.StartInfo.CreateNoWindow = true;

						// Démarrer le processus
						process.Start();
						process.WaitForExit();

						File.Delete(tempFilePath);
					}
					string resultatfinal = "";
					if (File.Exists(tempFileRes))
					{
						resultatfinal = File.ReadAllText(tempFileRes);
						File.Delete(tempFileRes);
					}
					args = BigBoxUtils.explode(resultatfinal, "|||");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}

			return args;
		}

		public string[] ModifyExemple(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return args;
					if (_matchAllFilter && nbFilter > nbFilterFound) return args;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return args;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found) return args;
					if (_matchAllExclude && nbFilter > nbFilterFound) return args;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return args;
					}
				}
			}


			if (_ahkCodeExemple != "") return AhkExecute(args, _ahkCodeExemple);
			return args;
		}
		public string[] Modify(string[] args)
		{

			return args;
		}



		public string[] ModifyReal(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return args;
					if (_matchAllFilter && nbFilter > nbFilterFound) return args;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return args;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found) return args;
					if (_matchAllExclude && nbFilter > nbFilterFound) return args;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return args;
					}
				}
			}

			if (_ahkCodeReal != "") return AhkExecute(args, _ahkCodeReal);
			return args;
		}

		private void UpdateConfig()
		{
			_filter = Options["filter"];
			_ahkCodeExemple = Options["ahkCodeExemple"];
			_ahkCodeReal = Options["ahkCodeReal"];
			_ahkCodeBefore = Options["ahkCodeBefore"];
			_ahkCodeAfter = Options["ahkCodeAfter"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
			_matchAllFilter = Options["matchAllFilter"] == "yes" ? true : false;
			_matchAllExclude = Options["matchAllExclude"] == "yes" ? true : false;

			_runbeforebackground = Options["runbeforebackground"] == "yes" ? true : false;
		}

		public void ExecuteBefore(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return;
					if (_matchAllFilter && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found)
					{
						return;
					}
					if (_matchAllExclude && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
			}

			//if (_ahkCodeBefore != "") AhkExecute(args, _ahkCodeBefore);
			if (_ahkCodeBefore != "")
			{
				if(_runbeforebackground) Task.Run(() => AhkExecute(args, _ahkCodeBefore));
				else AhkExecute(args, _ahkCodeBefore);
			}

		}
		public void ExecuteAfter(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return;
					if (_matchAllFilter && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found)
					{
						return;
					}
					if (_matchAllExclude && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
			}

			if (_ahkCodeAfter != "") AhkExecute(args, _ahkCodeAfter);
		}

		public bool UseM3UContent()
		{
			return false;
		}

		public string[] FiltersToRemoveOnFinalPass()
		{
			List<string> emptylist = new List<string>();
			if (_removeFilter)
			{
				return BigBoxUtils.MakeFilterListToRemove(_filter, _commaFilter);
			}
			return emptylist.ToArray();
		}
	}
}
