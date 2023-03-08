﻿using BigBoxProfile.EmulatorActions;
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

		private List<ConfigurationData> _options = new List<ConfigurationData>();
		public List<IEmulatorAction> _modules = new List<IEmulatorAction>();
		public List<IEmulatorAction> _selectedModules = new List<IEmulatorAction>();

		public Emulator(string profileName,string fileNameEmulator)
		{
			ProfileName = profileName;
			FileNameEmulator= fileNameEmulator;
			FileNameConfig = Path.Combine(Profile.PathMainProfileDir, FileNameEmulator, ProfileName + ".xml");


			_modules.Add(new Prefix());
			_modules.Add(new Suffix());
			_modules.Add(new Replace());

			List<ConfigurationData> loadedModules = ConfigurationData.LoadConfigurationDataList(FileNameConfig);
			foreach (var module in loadedModules)
			{
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
			ConfigurationData.SaveConfigurationDataList(FileNameConfig, _options);
		}
	}
}
