using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class CopyFile : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public CopyFile()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "CopyFile";

		private string _sourceDir = "";
		private string _targetDir = "";
		private bool _useRamDisk = false;
		private string _maxSize = "0";
		private string _filter = "";
		private bool _deleteOnExit = false;

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
				if(_useRamDisk) description += $" [Ramdisk if size < {_maxSize} MB]";
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
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
		}

		public void ExecuteBefore(string[] args)
		{

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
						var frm = new CopyFile_Task(elem,outfile);

						var targetProcess = Process.GetProcessesByName("LaunchBox").FirstOrDefault(p => p.MainWindowTitle != "");
						if(targetProcess == null) targetProcess = Process.GetProcessesByName("BigBox").FirstOrDefault(p => p.MainWindowTitle != "");
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
					
						//frm.CopyFileWithProgress(elem, outfile);
					}
				}
			}



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
