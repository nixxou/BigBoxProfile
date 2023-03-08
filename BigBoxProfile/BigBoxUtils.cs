using Microsoft.Win32;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BigBoxProfile
{
	internal class BigBoxUtils
	{

		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
		//static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
		static extern bool CreateHardLink(
		  string lpFileName,
		  string lpExistingFileName,
		  IntPtr lpSecurityAttributes
		);

		[DllImport("shell32.dll", SetLastError = true)]
		static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);



		public static void MakeLink(string source, string target)
		{
			if (!File.Exists(source)) return;
			if (File.Exists(target)) return;

			CreateHardLink(target, source, IntPtr.Zero);
		}

		public static void RegisterApp()
		{

			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);
			RegistryKey subkey = key.CreateSubKey("BigBox.exe");
			subkey.SetValue("Debugger", Assembly.GetEntryAssembly().Location);

			foreach (var dir in Directory.GetDirectories(Profile.PathMainProfileDir, "*"))
			{
				string ExeName = Path.GetFileName(dir);
				if (ExeName != "")
				{
					key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);
					subkey = key.CreateSubKey(ExeName);
					subkey.SetValue("Debugger", Assembly.GetEntryAssembly().Location);
				}
			}
		}

		public static void UnregisterApp()
		{
			DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\BigBox.exe");

			foreach (var dir in Directory.GetDirectories(Profile.PathMainProfileDir, "*"))
			{
				string ExeName = Path.GetFileName(dir);
				string RegPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName;
				if (ExeName != "")
				{
					List<string> subKeys;
					Dictionary<string, string> values;
					GetSubKeysAndValues(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName, out subKeys, out values);
					if (subKeys.Count() == 0 && values.Count() == 1 && values.ContainsKey("Debugger"))
					{
						DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName);
					}

				}
			}
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



		public static void RegisterExec()
		{
			string exePath = Assembly.GetEntryAssembly().Location;
			string exeDir = Path.GetDirectoryName(exePath);
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = exePath;
			startInfo.Arguments = "--register";
			startInfo.WorkingDirectory = exeDir;
			startInfo.Verb = "runas";
			Process.Start(startInfo);
		}

		public static void UnregisterExec()
		{
			string exePath = Assembly.GetEntryAssembly().Location;
			string exeDir = Path.GetDirectoryName(exePath);
			ProcessStartInfo startInfo = new ProcessStartInfo();
			startInfo.FileName = exePath;
			startInfo.Arguments = "--unregister";
			startInfo.WorkingDirectory = exeDir;
			startInfo.Verb = "runas";
			Process.Start(startInfo);
		}

		public static bool IsAppRegistered()
		{
			string debuggerValue = CheckRegistryValue(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\BigBox.exe", "Debugger");
			if (debuggerValue != null && debuggerValue == Assembly.GetEntryAssembly().Location) return true;
			return false;
		}

		public static bool IsGamesRegistered()
		{
			foreach (var dir in Directory.GetDirectories(Profile.PathMainProfileDir, "*"))
			{
				string ExeName = Path.GetFileName(dir);
				string RegPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName;
				if (ExeName != "")
				{
					string debuggerValue = CheckRegistryValue(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\" + ExeName, "Debugger");
					if (debuggerValue == null || debuggerValue != Assembly.GetEntryAssembly().Location) return false;

				}
			}
			return true;

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

		public static string FilterFileName(string name)
		{
			string title = name;
			title = Regex.Replace(title, @"\p{S}", "");
			title = Regex.Replace(title, "[^A-Za-z0-9 -]", "");
			title = title.Trim().Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Replace("  ", " ").Trim().ToLower();
			return title;

		}

		public static string[] explode(string input, string delimiter)
		{
			string[] result;

			if (input.Contains(delimiter))
			{
				result = input.Split(new string[] { delimiter }, StringSplitOptions.None);
			}
			else
			{
				result = new string[] { input };
			}

			return result;
		}

		public static string Join(string[] arr, string delimiter)
		{
			if (arr == null || arr.Length == 0)
			{
				return string.Empty;
			}

			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < arr.Length; i++)
			{
				sb.Append(arr[i]);

				if (i < arr.Length - 1)
				{
					sb.Append(delimiter);
				}
			}

			return sb.ToString();
		}

		public static string[] GetListViewItems(System.Windows.Forms.ListView listView)
		{
			List<string> items = new List<string>();

			foreach (ListViewItem item in listView.Items)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(item.Text);
				for (int i = 1; i < item.SubItems.Count; i++)
				{
					sb.Append(",");
					sb.Append(item.SubItems[i].Text);
				}
				items.Add(sb.ToString());
			}

			return items.ToArray();
		}

		public static bool UseMonitorDisposition(string key)
		{
			var cfg = Path.Combine(Profile.PathMainProfileDir, "disposition_" + key + ".xml");
			if (File.Exists(cfg))
			{
				return MonitorSwitcher.LoadDisplaySettings(cfg);
			}
			return false;
		}

		public static Dictionary<string,int> GetMonitorsTagDictionary()
		{
			var result = new Dictionary<string,int>();
			string FirstDevice = "";
			Screen[] screens = Screen.AllScreens;
			Debug.WriteLine($"Nombre d'écrans : {screens.Length}");
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				string MonitorFriendlyName = ScreenInterrogatory.DeviceFriendlyName(screen);
				MonitorFriendlyName = MonitorFriendlyName.Replace(" ", "_");
				if (FirstDevice == "") FirstDevice = MonitorFriendlyName;
				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');
				string TargetID = ScreenInterrogatory.DeviceTargetID(screen).ToString();
				if (screen.Primary) result.Add("main", i);
				result.Add(MonitorFriendlyName, i);
				result.Add(DeviceName, i);
				result.Add(TargetID, i);


			}
			return result;
		}

		public static int GetMonitorIDFromPriorityList(string priorityList)
		{
			var dic = GetMonitorsTagDictionary();
			var exploded = BigBoxUtils.explode(priorityList, ",");
			foreach (string exp in exploded)
			{
				var key = exp.Trim();
				if (dic.ContainsKey(key))
				{
					return dic[key];
				}
			}

			return -1;

		}
		public static void ModifierParametrePrimaryMonitorIndex(string cheminFichierXml, int nouvelleValeur)
		{
			// Chargement du fichier XML
			XmlDocument doc = new XmlDocument();
			doc.Load(cheminFichierXml);

			// Recherche de l'élément <PrimaryMonitorIndex>
			XmlNode nodePrimaryMonitorIndex = doc.SelectSingleNode("//PrimaryMonitorIndex");

			// Modification de la valeur de l'élément
			if (nodePrimaryMonitorIndex != null)
			{
				nodePrimaryMonitorIndex.InnerText = nouvelleValeur.ToString();
			}

			// Sauvegarde des modifications dans le fichier XML
			doc.Save(cheminFichierXml);
		}

		public static List<string> GetEmulatorsNames(string filePath)
		{
			// Créer une liste pour stocker les noms d'exécutable
			List<string> executableNames = new List<string>();

			// Charger le fichier XML
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(filePath);

			// Récupérer tous les éléments avec la balise "ApplicationPath"
			XmlNodeList applicationPathNodes = xmlDoc.GetElementsByTagName("ApplicationPath");

			// Ajouter chaque nom d'exécutable à la liste
			foreach (XmlNode node in applicationPathNodes)
			{
				string path = node.InnerText;
				string executableName = Path.GetFileName(path);
				executableNames.Add(executableName);
			}

			// Enlever les doublons et trier la liste par ordre alphabétique
			List<string> uniqueExecutableNames = executableNames.Distinct().OrderBy(name => name).ToList();

			// Retourner la liste des noms d'exécutable uniques et triés
			return uniqueExecutableNames;
		}



		public static string ArgsToCommandLine(string[] arguments)
		{
			var sb = new StringBuilder();
			foreach (string argument in arguments)
			{
				bool needsQuoting = argument.Any(c => char.IsWhiteSpace(c) || c == '\"');
				if (!needsQuoting)
				{
					sb.Append(argument);
				}
				else
				{
					sb.Append('\"');
					foreach (char c in argument)
					{
						int backslashes = 0;
						while (backslashes < argument.Length && argument[backslashes] == '\\')
						{
							backslashes++;
						}
						if (c == '\"')
						{
							sb.Append('\\', backslashes * 2 + 1);
							sb.Append(c);
						}
						else if (c == '\0')
						{
							sb.Append('\\', backslashes * 2);
							break;
						}
						else
						{
							sb.Append('\\', backslashes);
							sb.Append(c);
						}
					}
					sb.Append('\"');
				}
				sb.Append(' ');
			}
			return sb.ToString().TrimEnd();
		}

		public static string[] CommandLineToArgs(string commandLine, bool addfakeexe = true)
		{
			string executableName;
			return CommandLineToArgs(commandLine, out executableName,addfakeexe);
		}
		public static string[] CommandLineToArgs(string commandLine, out string executableName, bool addfakeexe = true)
		{
			if (addfakeexe) commandLine = "test.exe " + commandLine;
			int argCount;
			IntPtr result;
			string arg;
			IntPtr pStr;
			result = CommandLineToArgvW(commandLine, out argCount);
			if (result == IntPtr.Zero)
			{
				throw new System.ComponentModel.Win32Exception();
			}
			else
			{
				try
				{
					// Jump to location 0*IntPtr.Size (in other words 0).  
					pStr = Marshal.ReadIntPtr(result, 0 * IntPtr.Size);
					executableName = Marshal.PtrToStringUni(pStr);
					// Ignore the first parameter because it is the application   
					// name which is not usually part of args in Managed code.   
					string[] args = new string[argCount - 1];
					for (int i = 0; i < args.Length; i++)
					{
						pStr = Marshal.ReadIntPtr(result, (i + 1) * IntPtr.Size);
						arg = Marshal.PtrToStringUni(pStr);
						args[i] = arg;
					}
					return args;
				}
				finally
				{
					Marshal.FreeHGlobal(result);
				}
			}
		}


	}
}
