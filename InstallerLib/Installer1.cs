using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallerLib
{
	[RunInstaller(true)]
	public partial class Installer1 : System.Configuration.Install.Installer
	{
		public Installer1()
		{


		}

		public override void Install(System.Collections.IDictionary stateSaver)
		{
			bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (isAdmin)
			{
				RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);
				RegistryKey subkey = key.CreateSubKey("BigBox.exe");
				
				subkey.SetValue("Debugger", Path.Combine(Context.Parameters["Path"].TrimEnd('\\'),"BigBoxProfile.exe"));
			}

			base.Install(stateSaver);
		}

		public override void Uninstall(System.Collections.IDictionary stateSaver)
		{
			string PathMainProfileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BigBoxProfile");
			bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (isAdmin)
			{
				DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\BigBox.exe");
				foreach(var dir in Directory.GetDirectories(PathMainProfileDir, "*"))
				{
					string ExeName = Path.GetFileName(dir);
					string RegPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName;
					if (ExeName != "")
					{
						List<string> subKeys;
						Dictionary<string, string> values;
						GetSubKeysAndValues(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName, out subKeys, out values);

						if(subKeys.Count() == 0 && values.Count()==1 && values.ContainsKey("Debugger"))
						{
							DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName);
						}

					}
				}
			}

			base.Uninstall(stateSaver);
		}

		public static void GetSubKeysAndValues(string registryKeyPath, out List<string> subKeys, out Dictionary<string, string> values)
		{
			subKeys = new List<string>();
			values = new Dictionary<string, string>();

			using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath))
			{
				if (key != null)
				{
					subKeys.AddRange(key.GetSubKeyNames());
					foreach (string valueName in key.GetValueNames())
					{
						object value = key.GetValue(valueName);
						if (value != null)
						{
							values.Add(valueName, value.ToString());
						}
					}
				}
			}
		}


		static void DeleteRegistryKey(string keyName)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true);

			if (key != null)
			{
				// Supprimer toutes les sous-clés récursivement
				foreach (string subKeyName in key.GetSubKeyNames())
				{
					DeleteRegistryKey(keyName + "\\" + subKeyName);
				}

				// Supprimer la clé
				Registry.LocalMachine.DeleteSubKey(keyName);
			}
		}

		static bool CheckRegistryKey(string keyName)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, false);

			return (key != null);
		}

		static string CheckRegistryValue(string keyName, string valueName)
		{
			RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, false);

			if (key != null)
			{
				string value = (string)key.GetValue(valueName);
				if (value != null)
				{
					return value;
				}
			}

			return null;
		}
	}
}
