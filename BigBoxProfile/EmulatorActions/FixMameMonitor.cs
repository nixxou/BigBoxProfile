using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class FixMameMonitor : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public FixMameMonitor()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "FixMameMonitor";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new FixMameMonitor();
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
			string description = "Force Mame to use primary monitor";


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
			string currDir = String.IsNullOrEmpty(EmulatorLauncher.WorkingDirExe) ? Environment.CurrentDirectory : EmulatorLauncher.WorkingDirExe;
			string configFilePath = Path.Combine(currDir, "mame.ini");
			if (File.Exists(configFilePath))
			{
				string DeviceNameMain = "";

				int main_monitor_number = 0;
				Screen[] screens = Screen.AllScreens;
				Debug.WriteLine($"Nombre d'écrans : {screens.Length}");
				for (int i = 0; i < screens.Length; i++)
				{
					Screen screen = screens[i];
					if (screen.Primary)
					{
						main_monitor_number = i + 1;
						DeviceNameMain = screen.DeviceName;
					}
				}

				string[] configLines = File.ReadAllLines(configFilePath);

				for (int i = 0; i < configLines.Length; i++)
				{
					string line = configLines[i];
					if (line.TrimStart().StartsWith("#"))
					{
						line = line.Substring(1).TrimStart();
					}

					if (line.TrimStart().StartsWith("screen "))
					{
						line = "screen                    " + DeviceNameMain;
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
