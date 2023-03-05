using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxProfile
{
	public class ConfigurationChangedEventArgs : EventArgs
	{
		public string Key { get; private set; }
		public string Value { get; private set; }
		public ConfigurationChangedEventArgs(string key, string value)
		{
			Key = key;
			Value = value;	
		}
	}

	public class Profile
	{
		public static string PathMainProfileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BigBoxProfile");
		public static string PathMainProfile = Path.Combine(PathMainProfileDir,"main.xml");


		private static Dictionary<string, Profile> _profileList;

		public static event EventHandler ProfileListChanged;

		public static Dictionary<string, Profile> ProfileList
		{
			get { return _profileList; }
			private set
			{
				_profileList = value;
				OnProfileListChanged();
			}
		}

		public static event EventHandler ActiveProfileChanged;

		private static Profile _activeProfile = null;
		public static Profile ActiveProfile
		{
			get { return _activeProfile; }
			private set
			{
				if (_activeProfile != value)
				{
					_activeProfile = value;
					OnActiveProfileChanged();
				}
			}
		}

		public static event EventHandler<ConfigurationChangedEventArgs> ConfigurationChanged;

		private static void OnConfigurationChanged(string key, string value)
		{
			EventHandler<ConfigurationChangedEventArgs> handler = ConfigurationChanged;
			if (handler != null)
			{
				var args = new ConfigurationChangedEventArgs(key, value);
				handler(null, args);
			}
		}



		public string ProfileName { get; private set; }
		public Dictionary<string,string> Configuration { get; private set; }

		static Profile()
		{
			ProfileList = new Dictionary<string, Profile>();
			ProfileListLoad();
			if (ProfileList.ContainsKey("default") == false)
			{
				var default_profile = CreateDefaultProfile("default");
				default_profile.AddProfileToList();
			}
			ActiveProfile = ProfileList["default"];
		}

		private static void OnActiveProfileChanged()
		{
			EventHandler handler = ActiveProfileChanged;
			if (handler != null)
			{
				handler(null, EventArgs.Empty);
			}
		}

		private static void OnProfileListChanged()
		{
			EventHandler handler = ProfileListChanged;
			if (handler != null)
			{
				handler(null, EventArgs.Empty);
			}
		}

		public static Profile CreateDefaultProfile(string name)
		{
			Profile defaultProfile = new Profile(name);
			defaultProfile.Configuration.Add("monitor", "main");
			defaultProfile.Configuration.Add("monitorswitch", "<none>");
			defaultProfile.Configuration.Add("soundcard", "<dontchange>");


			return defaultProfile;
		}

		public static void ProfileListLoad()
		{
			ProfileList.Clear();
			if (!Directory.Exists(PathMainProfileDir)) Directory.CreateDirectory(PathMainProfileDir);
			if (File.Exists(PathMainProfile))
			{
				var data = ConfigurationData.LoadConfigurationDataList(PathMainProfile);
				foreach(var d in data)
				{
					var newProfile = new Profile(d.name);
					newProfile.Configuration = d.Options;
					newProfile.AddProfileToList();

				}
			}
		}

		public static void ProfileListSave()
		{
			List<ConfigurationData> data = new List<ConfigurationData>();
			foreach (var p in ProfileList)
			{
				var newConfigurationData = new ConfigurationData();
				newConfigurationData.name = p.Value.ProfileName;
				newConfigurationData.Options = p.Value.Configuration;
				data.Add(newConfigurationData);
			}
			ConfigurationData.SaveConfigurationDataList(PathMainProfile, data);
		}

		public static string AddProfile(string name)
		{
			Profile newProfile = CreateDefaultProfile(name);
			newProfile.AddProfileToList(true);
			

			return newProfile.ProfileName;

		}

		public static void RemoveProfile(string name)
		{
			if (name == "default") throw new Exception("Can't remove default profile !");
			if (ProfileList.ContainsKey(name))
			{
				ProfileList[name].RemoveProfileToList(true);
				ActiveProfile = ProfileList["default"];
				/*
				ProfileList.Remove(name);
				ActiveProfile = ProfileList["default"];
				ProfileListSave();
				*/
			}
		}

		public static int SetActive(string key)
		{
			if (ProfileList.ContainsKey(key))
			{
				ActiveProfile= ProfileList[key];
				return new List<string>(ProfileList.Keys).IndexOf(key);
			}
			return -1;
		}


		
		public Profile(string profileName)
		{
			profileName = BigBoxUtils.FilterFileName(profileName);
			if (ProfileList.ContainsKey(profileName)) throw (new Exception("A profile with this name already exist"));
			ProfileName = profileName;
			Configuration = new Dictionary<string, string>();
		}

		public void SetOption(string key, string value)
		{
			bool changed = false;
			if (Configuration.ContainsKey(key))
			{
				if (Configuration[key] != value)
				{
					Configuration[key] = value;
					changed = true;
				}
			}
			else
			{
				Configuration.Add(key, value);
				changed = true;
			}
			if (changed)
			{
				OnConfigurationChanged(key, value);
				ProfileListSave();
			}
		}

		private void AddProfileToList(bool save=false)
		{
			ProfileList.Add(this.ProfileName, this);
			OnProfileListChanged();
			if (save)
			{
				ProfileListSave();
			}
		}

		private void RemoveProfileToList(bool save = false)
		{
			if(this.ProfileName == "default") throw new Exception("Can't remove default profile !");
			ProfileList.Remove(this.ProfileName);
			OnProfileListChanged();
			if (save)
			{
				ProfileListSave();
			}
		}









	}
}
