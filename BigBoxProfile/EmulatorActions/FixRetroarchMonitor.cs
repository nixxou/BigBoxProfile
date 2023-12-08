using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class FixRetroarchMonitor : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public FixRetroarchMonitor()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "FixRetroarchMonitor";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new FixRetroarchMonitor();
		}

		public void Configure()
		{
			MessageBox.Show("No config needed");

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{

		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "Force retroarch to use primary monitor";


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

		public static string LocateRetroarchConfig(string[] args)
		{
			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);

			string PathConfig = "";

			foreach (var arg in filteredArgs)
			{
				if (arg.Trim().StartsWith("--config="))
				{
					PathConfig = arg.Trim().Substring(9);
					if (File.Exists(PathConfig))
					{
						return PathConfig;
					}
				}
			}

			for (int i = 0; i < filteredArgs.Length; i++)
			{
				if (filteredArgs[i] == "-c" && i < filteredArgs.Length - 1 && !string.IsNullOrEmpty(filteredArgs[i + 1]))
				{
					PathConfig = filteredArgs[i + 1];
					if (File.Exists(PathConfig))
					{
						return PathConfig;
					}
				}
			}

			string currDir = String.IsNullOrEmpty(EmulatorLauncher.WorkingDirExe) ? Environment.CurrentDirectory : EmulatorLauncher.WorkingDirExe;
			PathConfig = Path.Combine(currDir, "retroarch.cfg");
			if (File.Exists(PathConfig))
			{
				return PathConfig;
			}

			PathConfig = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "retroarch.cfg");
			if (File.Exists(PathConfig))
			{
				return PathConfig;
			}

			return "";
		}

		public string[] ModifyReal(string[] args)
		{
			/*
			string configFile = null;
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "-c" && i < args.Length - 1 && !string.IsNullOrEmpty(args[i + 1]))
				{
					configFile = args[i + 1];
					break;
				}
			}

			string configFilePath = Path.Combine(Environment.CurrentDirectory, "retroarch.cfg");
			if (configFile != null)
			{
				configFilePath = Path.IsPathRooted(configFile) ? configFile : Path.Combine(Environment.CurrentDirectory, configFile);
			}
			*/

			string configFilePath = LocateRetroarchConfig(args);

			if (configFilePath != "" && File.Exists(configFilePath))
			{
				int main_monitor_number = 0;
				Screen[] screens = Screen.AllScreens;
				Debug.WriteLine($"Nombre d'écrans : {screens.Length}");
				for (int i = 0; i < screens.Length; i++)
				{
					Screen screen = screens[i];
					if (screen.Primary) main_monitor_number = i + 1;
				}

				string[] configLines = File.ReadAllLines(configFilePath);

				for (int i = 0; i < configLines.Length; i++)
				{
					string line = configLines[i];
					if (line.TrimStart().StartsWith("#"))
					{
						line = line.Substring(1).TrimStart();
					}

					if (line.TrimStart().StartsWith("video_monitor_index"))
					{
						line = "video_monitor_index = " + main_monitor_number;
						configLines[i] = line;
						break;
					}
				}
				File.WriteAllLines(configFilePath, configLines);
			}

			args = ModifyExemple(args);
			return args;
		}

		public void ExecuteBefore(string[] args)
		{

		}
		public void ExecuteAfter(string[] args)
		{

		}

		public bool UseM3UContent()
		{
			return false;
		}

		public string[] FiltersToRemoveOnFinalPass()
		{
			List<string> emptylist = new List<string>();
			return emptylist.ToArray();
		}

	}
}
