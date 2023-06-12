using BigBoxProfile.EmulatorActions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BigBoxProfile
{
	public class Emulator
	{
		public string FileNameEmulator;
		public string ProfileName;
		public string FileNameConfig;
		public bool IsRegistered = false;
		public bool ApplyWithoutLaunchbox = false;

		private List<ConfigurationData> _options = new List<ConfigurationData>();
		public List<IEmulatorAction> _modules = new List<IEmulatorAction>();
		public List<IEmulatorAction> _selectedModules = new List<IEmulatorAction>();

		public Dictionary<string, string> OptionsEmulator { get; set; } = new Dictionary<string, string>();

		public Emulator(string profileName,string fileNameEmulator)
		{
			ProfileName = profileName;
			FileNameEmulator= fileNameEmulator;
			FileNameConfig = Path.Combine(Profile.PathMainProfileDir, FileNameEmulator, ProfileName + ".xml");


			_modules.Add(new Prefix());
			_modules.Add(new Suffix());
			_modules.Add(new Replace());
			_modules.Add(new ChangeExe());
			_modules.Add(new FixRetroarchMonitor());
			_modules.Add(new FixMameMonitor());

			//_modules.Add(new ChangeDisposition());
			_modules.Add(new UseFileContent());
			_modules.Add(new ChangeRomPath());
			_modules.Add(new CopyFile());

			_modules.Add(new ChangeDisposition());
			_modules.Add(new FakeFullScreen());
			_modules.Add(new RunAsAdminTask());
			_modules.Add(new ExecuteAHK());

			_modules.Add(new ExecutePrePostCmdAsAdmin());

			//_modules.Add(new RomExtractor());


			

			List<ConfigurationData> loadedModules = ConfigurationData.LoadConfigurationDataList(FileNameConfig);
			foreach (var module in loadedModules)
			{
				
				if (module.name == "OptionsEmulator")
				{
					OptionsEmulator = module.Options;
					if (OptionsEmulator.ContainsKey("ApplyWithoutLaunchbox") && OptionsEmulator["ApplyWithoutLaunchbox"] == "yes" && profileName.ToLower() == "default")
					{
						ApplyWithoutLaunchbox = true;
					}
				}


				if (module.name == "Prefix")
				{
					var obj = new Prefix();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
					
				}
				if (module.name == "Suffix")
				{
					var obj = new Suffix();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "Replace")
				{
					var obj = new Replace();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "ChangeExe")
				{
					var obj = new ChangeExe();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				/*
				if (module.name == "ChangeDisposition")
				{
					var obj = new ChangeDisposition();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				*/
				if (module.name == "UseFileContent")
				{
					var obj = new UseFileContent();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "ChangeRomPath")
				{
					var obj = new ChangeRomPath();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}

				if (module.name == "CopyFile")
				{
					var obj = new CopyFile();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}

				if (module.name == "FixRetroarchMonitor")
				{
					var obj = new FixRetroarchMonitor();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "FixMameMonitor")
				{
					var obj = new FixMameMonitor();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "ChangeDisposition")
				{
					var obj = new ChangeDisposition();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}

				if (module.name == "FakeFullScreen")
				{
					var obj = new FakeFullScreen();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}

				if (module.name == "RunAsAdminTask")
				{
					var obj = new RunAsAdminTask();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "ExecuteAHK")
				{
					var obj = new ExecuteAHK();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				if (module.name == "ExecutePrePostCmdAsAdmin")
				{
					var obj = new ExecutePrePostCmdAsAdmin();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				/*
				if (module.name == "RomExtractor")
				{
					var obj = new RomExtractor();
					obj.LoadConfiguration(module.Options);
					_selectedModules.Add(obj);
				}
				*/

			}
			
		}

		public static bool Exist(string profileName, string fileNameEmulator)
		{
			if (Profile.ProfileList.ContainsKey(profileName))
			{
				string pathFn = Path.Combine(Profile.PathMainProfileDir,fileNameEmulator);
				if (Directory.Exists(pathFn))
				{
					if(File.Exists(Path.Combine(pathFn,profileName + ".xml")))
					{
						return true;
					}
				}
			}
			return false;

		}

		public void SaveOptions()
		{
			_options.Clear();
			foreach (var module in _selectedModules)
			{
				var emulationActionOption = new ConfigurationData();
				emulationActionOption.name = module.ModuleName;
				emulationActionOption.Options = module.Options;
				_options.Add(emulationActionOption);
			}

			if (ApplyWithoutLaunchbox)
			{
				OptionsEmulator["ApplyWithoutLaunchbox"] = "yes";
			}
			else
			{
				OptionsEmulator["ApplyWithoutLaunchbox"] = "no";
			}

			var emulationActionOptionEmulator = new ConfigurationData();
			emulationActionOptionEmulator.name = "OptionsEmulator";
			emulationActionOptionEmulator.Options = OptionsEmulator;
			_options.Add(emulationActionOptionEmulator);

			ConfigurationData.SaveConfigurationDataList(FileNameConfig, _options);
		}
	}
}
