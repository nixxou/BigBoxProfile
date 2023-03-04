using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxProfile
{
	public class Profile
	{
		const string PathMainProfile = @"BigBoxProfile_Config/main.xml";

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
			return defaultProfile;
		}

		public static void ProfileListLoad()
		{
			ProfileList.Clear();
			if (!Directory.Exists("BigBoxProfile_Config")) Directory.CreateDirectory("BigBoxProfile_Config");
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
