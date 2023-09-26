using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class CopyFile : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;
		List<RamDiskLauncher> _RamDisks;
		List<string> _FileToDelete;
		List<string> _FileCached;

		public CopyFile()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
			_RamDisks = new List<RamDiskLauncher>();
			_FileToDelete = new List<string>();
			_FileCached = new List<string>();
		}

		public string ModuleName => "CopyFile";

		private string _sourceDir = "";
		private string _targetDir = "";
		private bool _useRamDisk = false;
		private string _maxSize = "0";
		private string _filter = "";
		private bool _deleteOnExit = false;
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new CopyFile();
		}

		public void Configure()
		{

			var frm = new CopyFile_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (frm.useRamDisk) Options["useRamDisk"] = "yes";
				else Options["useRamDisk"] = "no";

				if (frm.deleteOnExit) Options["deleteOnExit"] = "yes";
				else Options["deleteOnExit"] = "no";

				Options["filter"] = frm.filter.Trim();
				Options["sourceDir"] = frm.sourceDir.Trim();
				Options["targetDir"] = frm.targetDir.Trim();
				Options["maxSize"] = frm.maxSize.Trim();

				Options["exclude"] = frm.exclude.Trim();
				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";
				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				UpdateConfig();
			}


		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("sourceDir") == false) Options["sourceDir"] = "";
			if (Options.ContainsKey("targetDir") == false) Options["targetDir"] = "";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("useRamDisk") == false) Options["useRamDisk"] = "no";
			if (Options.ContainsKey("maxSize") == false) Options["maxSize"] = "0";
			if (Options.ContainsKey("deleteOnExit") == false) Options["deleteOnExit"] = "no";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("sourceDir") == false || Options["sourceDir"] == "")
			{
				return false;
			}
			if (Options.ContainsKey("targetDir") == false || Options["targetDir"] == "")
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
				description = $"Copy from {_sourceDir} to {_targetDir}";
				if (_useRamDisk) description += $" [Ramdisk if size < {_maxSize} MB]";
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_exclude != "") description += $" [Exclude {_exclude}]";
				if (_deleteOnExit == false) description += $" [DELETE=NO]";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

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

			if (IsConfigured() == false)
			{
				return args;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (!filter_found) return args;
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
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (filter_found) return args;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return args;
					}
				}
			}


			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);

			int index = 0;
			foreach (var elem in filteredArgs)
			{
				bool found = false;
				if (elem.Contains(_sourceDir) && !found)
				{
					if (File.Exists(elem))
					{
						found = true;
						string outfile = Path.Combine(_targetDir, Path.GetFileName(elem));
						foreach (var fileCached in _FileCached)
						{
							if (Path.GetFileName(fileCached) == Path.GetFileName(elem))
							{
								outfile = fileCached;
							}
						}
						Console.WriteLine($"Copy {elem} to {outfile}");
						filteredArgs[index] = outfile;
					}
				}
				index++;
			}
			args = BigBoxUtils.AddFirstElementToArg(filteredArgs, exeArg);
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		private void UpdateConfig()
		{
			_sourceDir = Options["sourceDir"];
			_targetDir = Options["targetDir"];
			_filter = Options["filter"];
			_useRamDisk = Options["useRamDisk"] == "yes" ? true : false;
			_maxSize = Options["maxSize"];
			_deleteOnExit = Options["deleteOnExit"] == "yes" ? true : false;
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
		}

		public void ExecuteBefore(string[] args)
		{

			if (IsConfigured() == false)
			{
				return;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (!filter_found) return;
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
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (filter_found) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
			}

			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			foreach (var elem in filteredArgs)
			{
				bool found = false;
				if (elem.Contains(_sourceDir) && !found)
				{
					if (File.Exists(elem))
					{

						found = true;
						string outfile = Path.Combine(_targetDir, Path.GetFileName(elem));
						Console.WriteLine($"Copy {elem} to {outfile}");
						int maxsize = 0;
						int.TryParse(_maxSize, out maxsize);

						RamDiskLauncher ramDisk = new RamDiskLauncher();
						_RamDisks.Add(ramDisk);

						var frm = new CopyFile_Task(elem, outfile, _useRamDisk, _deleteOnExit, maxsize, ramDisk);
						/*
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
						*/

						frm.TopMost = true; // Affiche la fenêtre devant toutes les autres
						frm.ShowDialog();
						frm.Focus(); // Donne le focus à la fenêtre

						//_targetDir = Path.GetDirectoryName(frm.outPath);
						_FileCached.Add(frm.outPath);
						if (ramDisk.RamDriveLetter == '\0')
						{
							if (_deleteOnExit) _FileToDelete.Add(frm.outPath);
						}
					}
				}
			}



		}
		public void ExecuteAfter(string[] args)
		{
			foreach (var ramDisk in _RamDisks)
			{
				ramDisk.UnMount();

			}
			foreach (var fileToDelete in _FileToDelete)
			{
				if (File.Exists(fileToDelete))
				{
					File.Delete(fileToDelete);
				}
			}

		}

		public bool UseM3UContent()
		{
			return true;
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
