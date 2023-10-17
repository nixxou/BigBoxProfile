using CefSharp.SchemeHandler;
using CefSharp.WinForms;
using CefSharp;
using CliWrap;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using System.IO.MemoryMappedFiles;
using BigBoxProfile.RomExtractorUtils;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;

namespace BigBoxProfile
{
	internal class BigBoxUtils
	{

		public static string DataHtmlDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BigBoxProfile", "html");
		public static bool CefInitialized = false;

		private static bool _gameInfoPulled = false;
		private static string _gameInfoJSON = @"
{
  ""Title"": """",
  ""Platform"": """",
  ""GameApplicationPath"": """",
  ""EmulatorApplicationPath"": """",
  ""GameCommandLine"": """",
  ""EmulatorCommandLine"": """",
  ""EmulatorPlatformCommandLine"": """",
  ""BackgroundImagePath"": """",
  ""ClearLogoImagePath"": """",
  ""FrontImagePath"": """",
  ""ManualPath"": """",
  ""VideoPath"": """",
  ""ScreenshotImagePath"": """",
  ""ReleaseDateFormated"": """",
  ""ReleaseDate"": """",
  ""ClearLogoImagesFolder"": """",
  ""MusicFolder"": """",
  ""Cart3DImagePath"": """",
  ""CartFrontImagePath"": """",
  ""Box3DImagePath"": """",
  ""RootFolder"": """",
  ""BezelImagePath"": """",
  ""PlatformBackgroundImagePath"": """",
  ""PlatformClearLogo"": """",
  ""CustomFields"": {}
}
";
		public static string GameInfoJSON
		{
			get
			{
				if (_gameInfoPulled)
				{
					return _gameInfoJSON;
				}
				else
				{
					getGameData();
					return _gameInfoJSON;
				}
			}
			private set
			{
				_gameInfoJSON = value;
			}
		}

		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

		[DllImport("kernel32.dll")]
		private static extern bool SuspendThread(IntPtr hThread);

		[DllImport("kernel32.dll")]
		private static extern int ResumeThread(IntPtr hThread);

		[DllImport("kernel32.dll")]
		private static extern int CloseHandle(IntPtr hObject);


		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		private static extern bool CreateSymbolicLink(string symlinkFileName, string targetFileName, int flags);

		// Constante pour le type de lien symbolique
		private const int SYMBOLIC_LINK_FLAG_FILE = 0x0;
		private const int SYMBOLIC_LINK_FLAG_DIRECTORY = 0x1;


		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
		//static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
		static extern bool CreateHardLink(
		  string lpFileName,
		  string lpExistingFileName,
		  IntPtr lpSecurityAttributes
		);

		[DllImport("shell32.dll", SetLastError = true)]
		static extern IntPtr CommandLineToArgvW([MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);


		[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out ulong lpFreeBytesAvailable, out ulong lpTotalNumberOfBytes, out ulong lpTotalNumberOfFreeBytes);

		public static void getGameData()
		{
			if(_gameInfoPulled) return;
			string jsonResumeData = _gameInfoJSON;
			try
			{
				using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("LaunchboxJsonResumeData"))
				{
					using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
					{
						long length = accessor.Capacity;
						byte[] jsonDataBytes = new byte[length];
						accessor.ReadArray(0, jsonDataBytes, 0, (int)length);
						jsonResumeData = Encoding.UTF8.GetString(jsonDataBytes).TrimEnd('\0');
					}
				}
			}
			catch { }
			GameInfoJSON = jsonResumeData;
			_gameInfoPulled = true;
		}

		public static void MakeLink(string source, string target)
		{
			if (!File.Exists(source)) return;
			if (File.Exists(target)) return;

			CreateHardLink(target, source, IntPtr.Zero);
		}

		public static bool CreateSoftlink(string sourceFilePath, string targetFilePath)
		{
			// Vérifier si le fichier source existe
			if (!File.Exists(sourceFilePath))
			{
				return false;
			}

			// Créer le lien symbolique
			try
			{
				if (File.Exists(targetFilePath))
				{
					// Supprimer le fichier existant s'il existe déjà
					File.Delete(targetFilePath);
				}

				// Appeler la fonction CreateSymbolicLink pour créer le lien symbolique
				bool success = CreateSymbolicLink(targetFilePath, sourceFilePath, SYMBOLIC_LINK_FLAG_FILE);

				return success;
			}
			catch (Exception)
			{
				// Gérer les erreurs éventuelles lors de la création du lien symbolique
				return false;
			}
		}

		public static bool IsSoftlink(string filePath)
		{
			// Vérifier si le fichier existe
			if (!File.Exists(filePath))
			{
				return false;
			}

			// Obtenir les attributs du fichier
			FileAttributes attributes = File.GetAttributes(filePath);

			// Vérifier si le fichier est un lien symbolique
			return (attributes & FileAttributes.ReparsePoint) == FileAttributes.ReparsePoint;
		}


		public static void RegisterApp()
		{
			var r = new RegisteryManager(Profile.PathMainProfileDir, Assembly.GetEntryAssembly().Location);
			r.FixRegistery();

			/*

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
			*/
		}

		public static void UnregisterApp()
		{
			/*
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
			*/
			var r = new RegisteryManager(Profile.PathMainProfileDir, Assembly.GetEntryAssembly().Location);
			r.DeleteAllDebuggerKeys();
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
				if (dir == "html") continue;

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

		public static Dictionary<string, int> GetMonitorsTagDictionary()
		{
			var result = new Dictionary<string, int>();
			string FirstDevice = "";
			Screen[] screens = Screen.AllScreens;
			Debug.WriteLine($"Nombre d'écrans : {screens.Length}");
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				//string MonitorFriendlyName = ScreenInterrogatory.DeviceFriendlyName(screen);
				//MonitorFriendlyName = MonitorFriendlyName.Replace(" ", "_");
				//if (FirstDevice == "") FirstDevice = MonitorFriendlyName;
				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');
				//string TargetID = ScreenInterrogatory.DeviceTargetID(screen).ToString();
				if (screen.Primary) result.Add("main", i);
				//result.Add(MonitorFriendlyName, i);
				result.Add(DeviceName, i);
				//result.Add(TargetID, i);


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

		public static bool IsValidPath(string path)
		{
			try
			{
				string fullpath = Path.GetFullPath(path);
			}
			catch
			{
				return false;
			}
			return true;
		}

		public static string[] ArgsToAbsoluteArgs(string[] args)
		{
			List<string> newArgs = new List<string>();
			for (int i = 0; i < args.Length; i++)
			{
				string arg = args[i];



				if (IsValidPath(arg))
				{

					string filePath = arg;

					if (!Path.IsPathRooted(filePath))
					{
						filePath = Path.GetFullPath(filePath);
					}

					if (File.Exists(filePath))
					{
						arg = filePath;
					}
					else if (Directory.Exists(filePath))
					{
						arg = filePath;
					}

				}
				newArgs.Add(arg);
			}
			return newArgs.ToArray();


		}

		public static string[] CommandLineToArgs(string commandLine, bool addfakeexe = true)
		{
			string executableName;
			return CommandLineToArgs(commandLine, out executableName, addfakeexe);
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

		public static string[] ArgsWithoutFirstElement(string[] args)
		{
			string[] filteredArgs;
			if (args.Length > 1)
			{
				filteredArgs = new string[args.Length - 1];

				for (int i = 1; i < args.Length; i++)
				{
					filteredArgs[i - 1] = args[i];
				}
			}
			else
			{
				filteredArgs = new string[0];
			}
			return filteredArgs;
		}

		public static string HaveLaunchboxM3U(string[] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				string arg = args[i];
				if (arg.ToLower().EndsWith(".m3u"))
				{

					string nomRepertoire = Path.GetDirectoryName(arg);
					if (String.IsNullOrEmpty(nomRepertoire)) continue;
					string nomSousRepertoire = Path.GetDirectoryName(nomRepertoire);
					if (String.IsNullOrEmpty(nomSousRepertoire)) continue;
					string nomSousSousRepertoire = Path.GetDirectoryName(nomSousRepertoire);
					if (String.IsNullOrEmpty(nomSousSousRepertoire)) continue;
					if (Path.GetFileName(nomSousRepertoire) != "Temp" && Path.GetFileName(nomSousSousRepertoire) != "Metadata") continue;
					string newM3UFile = Path.Combine(nomSousSousRepertoire, "Temp2", Path.GetFileName(nomRepertoire), Path.GetFileName(arg));


					if (arg.StartsWith(@"\\"))
					{
						string serverName = arg.Split('\\')[2];
						try
						{
							Ping ping = new Ping();
							PingReply reply = ping.Send(serverName);

							if (reply.Status != IPStatus.Success)
							{
								Console.WriteLine("The server is not reachable.");
								continue;
							}
						}
						catch (PingException)
						{

						}
					}
					if (File.Exists(arg))
					{
						return arg;
					}
				}
			}
			return "";
		}

		public static List<string> GetLaunchboxM3UContent(string m3uFile)
		{
			List<string> m3udata = new List<string>();
			using (StreamReader lecteur = new StreamReader(m3uFile))
			{
				string ligne;
				while ((ligne = lecteur.ReadLine()) != null)
				{
					if (!String.IsNullOrEmpty(ligne)) m3udata.Add(ligne);
				}
			}
			return m3udata;
		}

		public static string GetLaunchboxM3UNewPath(string m3uFile)
		{
			string nomRepertoire = Path.GetDirectoryName(m3uFile);
			string nomSousRepertoire = Path.GetDirectoryName(nomRepertoire);
			string nomSousSousRepertoire = Path.GetDirectoryName(nomSousRepertoire);
			string newM3UFile = Path.Combine(nomSousSousRepertoire, "Temp2", Path.GetFileName(nomRepertoire), Path.GetFileName(m3uFile));
			return newM3UFile;
		}



		public static string[] AddFirstElementToArg(string[] args, string argument)
		{
			string[] argsNonVides = Array.FindAll(args, s => !string.IsNullOrEmpty(s));

			string[] newArgs = new string[argsNonVides.Length + 1]; // créer une nouvelle instance de tableau avec une taille plus grande
			Array.Copy(argsNonVides, 0, newArgs, 1, argsNonVides.Length); // copier tous les éléments de args dans la nouvelle instance à partir de l'index 1
			newArgs[0] = argument; // définir le premier élément comme étant votre nouvelle valeur
			return newArgs;
		}

		public static string[] RemplaceFileInArg(string[] args, string searchFor, string remplace)
		{
			List<string> ModdedArg = new List<string>();
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i].ToLower().Trim() == searchFor.ToLower().Trim())
				{
					ModdedArg.Add(remplace);
				}
				else ModdedArg.Add(args[i]);
			}
			return ModdedArg.ToArray();
		}

		public static int CountFileInArg(string[] args, string searchFor)
		{
			int countMatch = 0;
			for (int i = 0; i < args.Length; i++)
			{
				if (args[i].ToLower().Trim() == searchFor.ToLower().Trim())
				{
					countMatch++;
				}
			}
			return countMatch;
		}


		public static string checkInstalled(string findByName)
		{
			string displayName;
			string InstallPath;
			string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

			//64 bits computer
			RegistryKey key64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
			RegistryKey key = key64.OpenSubKey(registryKey);

			if (key != null)
			{
				foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
				{
					displayName = subkey.GetValue("DisplayName") as string;
					if (displayName != null && displayName.Contains(findByName))
					{
						InstallPath = subkey.GetValue("InstallLocation", ".").ToString();

						return InstallPath; //or displayName


					}
				}
				key.Close();
			}
			RegistryKey key32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
			key = key32.OpenSubKey(registryKey);
			if (key != null)
			{
				foreach (RegistryKey subkey in key.GetSubKeyNames().Select(keyName => key.OpenSubKey(keyName)))
				{
					displayName = subkey.GetValue("DisplayName") as string;
					if (displayName != null && displayName.Contains(findByName))
					{

						InstallPath = subkey.GetValue("InstallLocation").ToString();

						return InstallPath; //or displayName

					}
				}
				key.Close();
			}
			return null;
		}

		public static string GetTaskName(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			//MessageBox.Show(cmd);
			string taskName = "";
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(cmd);
				byte[] hashBytes = md5.ComputeHash(inputBytes);
				string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
				taskName = "RunAdmin_" + hashString;
			}
			return taskName;
		}

		public static string GetTaskName(string cmd)
		{
			return GetTaskName(BigBoxUtils.CommandLineToArgs(cmd));

		}

		public static bool CheckTaskExist(string taskName, string ExePath = "")
		{
			using (TaskService taskService = new TaskService())
			{
				var task = taskService.GetTask(taskName);
				if ( task == null)
				{
					return false;
				}
				else
				{
					if(ExePath == "")
					{
						return true;
					}
					else
					{
						var actions = task.Definition.Actions;

						foreach (var action in actions)
						{
							if (action is ExecAction execAction)
							{
								if(execAction.Path.ToLower() == ExePath.ToLower())
								{
									return true;
								}
							}
						}
						return false;
					}
				}
			}
		}

		public static bool CheckTaskExist(string[] args)
		{
			return CheckTaskExist(GetTaskName(args));
		}

		public static void RegisterTask(string[] args, string optionTask = "")
		{
			//var _ramDiskManager = new RamDiskManager(1000);
			string RamDiskManagerExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "RamDiskManager.exe");
			string taskName = GetTaskName(args);

			using (TaskService taskService = new TaskService())
			{
				if (taskService.GetTask(taskName) == null)
				{
					string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");

					if (optionTask != "TaskRunNormal" && optionTask != "TaskRunHidden") optionTask = JustRunExe;

					List<string> arguments = new List<string>();
					arguments.Add(optionTask);
					arguments.AddRange(args);


					//string taskRegExe = @"C:\Users\Mehdi\source\repos\BigBoxProfile\TaskRegForRunAsAdmin\bin\Debug\TaskRegForRunAsAdmin.exe";
					string taskRegExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TaskRegForRunAsAdmin.exe");
					//MessageBox.Show(taskRegExe);
					//string exePath = Assembly.GetEntryAssembly().Location;
					string exePath = taskRegExe;
					string exeDir = Path.GetDirectoryName(exePath);
					ProcessStartInfo startInfo = new ProcessStartInfo();
					startInfo.FileName = exePath;
					startInfo.Arguments = BigBoxUtils.ArgsToCommandLine(arguments.ToArray());
					startInfo.WorkingDirectory = exeDir;
					startInfo.Verb = "runas";
					//Process.Start(startInfo);
					var TaskProcess = System.Threading.Tasks.Task.Run(() => Process.Start(startInfo));
					TaskProcess.Wait();


				}
			}
		}

		public static void RegisterTask(string cmd, string optionTask = "")
		{
			var args = BigBoxUtils.CommandLineToArgs(cmd);
			RegisterTask(args, optionTask);
		}

		public static void DeleteTask(string taskName)
		{
			using (TaskService ts = new TaskService())
			{
				// Find the task in the root folder using its name
				var task = ts.FindTask(taskName);

				if (task != null)
				{
					ts.RootFolder.DeleteTask(taskName);
				}
			}
		}

		public static void SimpleRegisterTask(string taskName, string executable, string arguments)
		{

			var UsersRights = TaskLogonType.InteractiveToken;
			//UsersRights = TaskLogonType.S4U;
			using (TaskService ts = new TaskService())
			{
				TaskDefinition td = ts.NewTask();
				td.RegistrationInfo.Description = "Task as admin";
				td.Principal.RunLevel = TaskRunLevel.Highest;
				td.Principal.LogonType = UsersRights;
				// Create an action that will launch Notepad whenever the trigger fires
				td.Actions.Add(executable, arguments, null);
				// Register the task in the root folder
				ts.RootFolder.RegisterTaskDefinition(taskName, td, TaskCreation.CreateOrUpdate, Environment.GetEnvironmentVariable("USERNAME"), null, UsersRights, null);
			}

		}

		public static void ExecuteTask(string taskName, int delay = 2000)
		{
			string new_cmd = $@" /I /run /tn ""{taskName}""";
			var args = BigBoxUtils.CommandLineToArgs(new_cmd, false);



			var TaskRun = System.Threading.Tasks.Task.Run(() =>

			Cli.Wrap("schtasks")
			.WithArguments(args)
			.WithValidation(CommandResultValidation.None)
			.ExecuteAsync()
			);
			TaskRun.Wait();

			
			TaskService ts = new TaskService();
			Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskName);
			Microsoft.Win32.TaskScheduler.RunningTaskCollection instances = task.GetInstances();

			//Code a enlever si execution sans attente
			int nbrun = delay / 100;
			if(instances.Count == 0)
			{
				//MessageBox.Show("icil");
				instances = task.GetInstances();
				Thread.Sleep(100);
				int i = 0;
				while (instances.Count == 0)
				{
					i++;
					instances = task.GetInstances();
					Thread.Sleep(100);
					if (i > nbrun) break;
				}
			}
			while (instances.Count == 1)
			{
				instances = task.GetInstances();
				Thread.Sleep(100);
			}
			
			
			
			/*
			Thread.Sleep(delay);

			TaskService ts = new TaskService();
			Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskName);
			Microsoft.Win32.TaskScheduler.RunningTaskCollection instances = task.GetInstances();
			while (instances.Count == 1)
			{
				instances = task.GetInstances();
				Thread.Sleep(100);
			}
			*/
			
		}

		public static void ExecuteTask(string[] args, int delay = 1000, bool registerIfNeeded = true, string optionTask = "")
		{
			string taskName = GetTaskName(args);
			if (CheckTaskExist(taskName))
			{
				ExecuteTask(taskName, delay);
			}
			else
			{
				if (registerIfNeeded)
				{
					RegisterTask(args, optionTask);
					Thread.Sleep(1000);
					ExecuteTask(taskName, delay);
				}
			}

		}

		public static bool IsLaunchboxRunning(string executablePath)
		{
			var exceptArguments = new string[2] { "-recovery", "-recoverybigbox" };

			string processName = System.IO.Path.GetFileNameWithoutExtension(executablePath);

			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				try
				{
					bool isLaunchboxOrBigbox = false;
					var executableName = Path.GetFileName(process.MainModule.FileName);
					var executableDir = Path.GetDirectoryName(process.MainModule.FileName);

					if (executableName.StartsWith("launchbox_", StringComparison.OrdinalIgnoreCase)) isLaunchboxOrBigbox = true;
					if (string.Equals(executableName, "launchbox.exe", StringComparison.OrdinalIgnoreCase)) isLaunchboxOrBigbox = true;
					if (executableName.StartsWith("bigbox_", StringComparison.OrdinalIgnoreCase)) isLaunchboxOrBigbox = true;
					if (string.Equals(executableName, "bigbox.exe", StringComparison.OrdinalIgnoreCase)) isLaunchboxOrBigbox = true;

					if (isLaunchboxOrBigbox && string.Equals(executableDir, Path.GetDirectoryName(executablePath), StringComparison.OrdinalIgnoreCase))
					{
						if (exceptArguments != null && exceptArguments.Length > 0)
						{
							bool shouldSkip = false;
							foreach (string exceptArgument in exceptArguments)
							{
								if (process.StartInfo.Arguments.Contains(exceptArgument))
								{
									shouldSkip = true;
									break;
								}
							}
							if (shouldSkip)
							{
								continue;
							}
						}

						return true;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Erreur lors de l'accès au processus : {ex.Message}");
				}

			}

			return false;
		}

		public static bool EmptyFolder(string pathName)
		{
			bool errors = false;
			DirectoryInfo dir = new DirectoryInfo(pathName);

			foreach (FileInfo fi in dir.EnumerateFiles())
			{
				try
				{
					fi.IsReadOnly = false;
					fi.Delete();

					//Wait for the item to disapear (avoid 'dir not empty' error).
					while (fi.Exists)
					{
						System.Threading.Thread.Sleep(10);
						fi.Refresh();
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine(e.Message);
					errors = true;
				}
			}

			foreach (DirectoryInfo di in dir.EnumerateDirectories())
			{
				try
				{
					EmptyFolder(di.FullName);
					di.Delete();

					//Wait for the item to disapear (avoid 'dir not empty' error).
					while (di.Exists)
					{
						System.Threading.Thread.Sleep(10);
						di.Refresh();
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine(e.Message);
					errors = true;
				}
			}

			return !errors;
		}
		public static int GetDiskSize(long desiredSizeMB)
		{
			const long NTFSOverheadBytes = 12_582_912; // Espace réservé par NTFS en octets
			const long ClusterSizeBytes = 4_096; // Taille d'un cluster en octets

			long usableSizeBytes = desiredSizeMB * 1_048_576; // Conversion de Mo en octets
			long usableClusters = usableSizeBytes / ClusterSizeBytes;
			long totalClusters = usableClusters + NTFSOverheadBytes / ClusterSizeBytes;
			long diskSizeBytes = totalClusters * ClusterSizeBytes;

			return (int)(diskSizeBytes / 1024 / 1024);
		}

		public static string GetCommandLineInfo(Process process)
		{
			if (process is null || process.Id < 1)
			{
				return "";
			}

			string query =
				$@"SELECT CommandLine
           FROM Win32_Process
           WHERE ProcessId = {process.Id}";

			using (var searcher = new ManagementObjectSearcher(query))
			using (var collection = searcher.Get())
			{
				var managementObject = collection.OfType<ManagementObject>().FirstOrDefault();

				return managementObject != null ? (string)managementObject["CommandLine"] : "";
			}
		}

		// <summary>
		/// Creates a relative path from one file or folder to another.
		/// </summary>
		/// <param name="fromPath">Contains the directory that defines the start of the relative path.</param>
		/// <param name="toPath">Contains the path that defines the endpoint of the relative path.</param>
		/// <returns>The relative path from the start directory to the end path or <c>toPath</c> if the paths are not related.</returns>
		/// <exception cref="ArgumentNullException"></exception>
		/// <exception cref="UriFormatException"></exception>
		/// <exception cref="InvalidOperationException"></exception>
		public static String MakeRelativePath(String fromPath, String toPath)
		{
			if (String.IsNullOrEmpty(fromPath)) throw new ArgumentNullException("fromPath");
			if (String.IsNullOrEmpty(toPath)) throw new ArgumentNullException("toPath");

			Uri fromUri = new Uri(fromPath);
			Uri toUri = new Uri(toPath);

			if (fromUri.Scheme != toUri.Scheme) { return toPath; } // path can't be made relative.

			Uri relativeUri = fromUri.MakeRelativeUri(toUri);
			String relativePath = Uri.UnescapeDataString(relativeUri.ToString());

			if (toUri.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
			{
				relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
			}

			return relativePath;
		}

		public static IEnumerable<String> FindAccessableFiles(string path, string file_pattern, bool recurse)
		{
			IEnumerable<String> emptyList = new string[0];

			if (File.Exists(path))
				return new string[] { path };

			if (!Directory.Exists(path))
				return emptyList;

			var top_directory = new DirectoryInfo(path);

			// Enumerate the files just in the top directory.
			var files = top_directory.EnumerateFiles(file_pattern);
			var filesLength = files.Count();
			var filesList = Enumerable
					  .Range(0, filesLength)
					  .Select(i =>
					  {
						  string filename = null;
						  try
						  {
							  var file = files.ElementAt(i);
							  filename = file.FullName;
						  }
						  catch (UnauthorizedAccessException)
						  {
						  }
						  catch (InvalidOperationException)
						  {
							  // ran out of entries
						  }
						  return filename;
					  })
					  .Where(i => null != i);

			if (!recurse)
				return filesList;

			var dirs = top_directory.EnumerateDirectories("*");
			var dirsLength = dirs.Count();
			var dirsList = Enumerable
				.Range(0, dirsLength)
				.SelectMany(i =>
				{
					string dirname = null;
					try
					{
						var dir = dirs.ElementAt(i);
						dirname = dir.FullName;
						return FindAccessableFiles(dirname, file_pattern, recurse);
					}
					catch (UnauthorizedAccessException)
					{
					}
					catch (InvalidOperationException)
					{
						// ran out of entries
					}

					return emptyList;
				});

			return Enumerable.Concat(filesList, dirsList);
		}

		/*
		public static string[] RemoveFilter(string[] args, string filters)
		{
			if (filters != "")
			{
				List<string> newArg = new List<string>();
				var liste_filter = BigBoxUtils.explode(filters.ToLower(), ",");
				foreach (var arg in args)
				{
					bool filter_found = false;
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (arg.ToLower().Trim() == filter.Trim())
						{
							filter_found = true;
							break;
						}
					}
					if (!filter_found)
					{
						newArg.Add(arg);
					}

				}
				return newArg.ToArray();
			}
			return args;
		}
		*/
		
		public static string[] MakeFilterListToRemove(string filters, bool commaFilter)
		{
			List<string> filterList = new List<string>();
			if (filters != "")
			{
				if (commaFilter)
				{
					var liste_filter = BigBoxUtils.explode(filters.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						filterList.Add(filter.Trim());
					}
				}
				else
				{
					filterList.Add(filters.ToLower().Trim());
				}
			}
			return filterList.ToArray();
		}

		public static string ReadAllTextLockedFile(string filePath)
		{
			if (!File.Exists(filePath)) return "";
			using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			using (StreamReader reader = new StreamReader(stream))
			{
				return reader.ReadToEnd();
			}

		}

		public static void CefInit()
		{
			if(CefInitialized) return;
			if (!Directory.Exists(DataHtmlDir)) Directory.CreateDirectory(DataHtmlDir);
			if (!Directory.Exists(Path.Combine(DataHtmlDir,"tmp"))) Directory.CreateDirectory(Path.Combine(DataHtmlDir, "tmp"));


			var settings = new CefSettings();
			settings.RegisterScheme(new CefCustomScheme
			{
				SchemeName = "localfolder",
				DomainName = "cefsharp",
				SchemeHandlerFactory = new CustomFolderSchemeHandlerFactory(
					rootFolder: DataHtmlDir,
					hostName: "cefsharp",
					defaultPage: "index.html" // will default to index.html
				)
			});
			settings.CefCommandLineArgs.Add("disable-web-security");
			settings.CefCommandLineArgs.Add("--disable-web-security");
			settings.CefCommandLineArgs.Add("--allow-file-access-from-files");
			settings.CefCommandLineArgs.Add("allow-file-access-from-files");
			Cef.Initialize(settings);
			CefInitialized = true;


		}

		public static string AHKGetPrefix()
		{
			return @"
class JSON
{
	class parse extends JSON.functor
	{
		call(self, ByRef param_string, param_reviver:="""")
		{
			this.rev := isObject(param_reviver) ? param_reviver : false
			; Object keys(and array indices) are temporarily stored in arrays so that
			; we can enumerate them in the order they appear in the string instead
			; of alphabetically. Skip if no reviver function is specified.
			this.keys := this.rev ? {} : false

			static quot := chr(34), bashq := ""\"" quot
				, json_value := quot ""{[01234567890-tfn""
				, json_value_or_array_closing := quot ""{[]01234567890-tfn""
				, object_key_or_object_closing := quot ""}""

			key := """"
			is_key := false
			root := {}
			stack := [root]
			next := json_value
			pos := 0

			while ((ch := subStr(param_string, ++pos, 1)) != """") {
				if inStr("" `t`r`n"", ch) {
					continue
				}
				if !inStr(next, ch, 1) {
					this.parseError(next, param_string, pos)
				}

				holder := stack[1]
				is_array := holder.IsArray

				if inStr("",:"", ch) {
					next := (is_key := !is_array && ch == "","") ? quot : json_value

				} else if (inStr(""}]"", ch)) {
					objRemoveAt(stack, 1)
					next := stack[1]==root ? """" : stack[1].IsArray ? "",]"" : "",}""

				} else {
					if (inStr(""{["", ch)) {
					; Check if Array() is overridden and if its return value has
					; the 'IsArray' property. If so, Array() will be called normally,
					; otherwise, use a custom base object for arrays
					static json_array := func(""Array"").isBuiltIn || ![].IsArray ? {IsArray: true} : 0

					; sacrifice readability for minor(actually negligible) performance gain
						(ch == ""{"")
							? ( is_key := true
							  , value := {}
							  , next := object_key_or_object_closing )
						; ch == ""[""
							: ( value := json_array ? new json_array : []
							  , next := json_value_or_array_closing )

						ObjInsertAt(stack, 1, value)

						if (this.keys) {
							this.keys[value] := []
						}
					} else {
						if (ch == quot) {
							i := pos
							while (i := inStr(param_string, quot,, i+1)) {
								value := strReplace(subStr(param_string, pos+1, i-pos-1), ""\\"", ""\u005c"")

								static tail := A_AhkVersion<""2"" ? 0 : -1
								if (subStr(value, tail) != ""\"") {
									break
								}
							}

							if (!i) {
								this.parseError(""'"", param_string, pos)
							}

							value := strReplace(value, ""\/"",  ""/"")
							, value := strReplace(value, bashq, quot)
							, value := strReplace(value, ""\b"", ""`b"")
							, value := strReplace(value, ""\f"", ""`f"")
							, value := strReplace(value, ""\n"", ""`n"")
							, value := strReplace(value, ""\r"", ""`r"")
							, value := strReplace(value, ""\t"", ""`t"")

							pos := i ; update pos

							i := 0
							while (i := inStr(value, ""\"",, i+1)) {
								if (!(subStr(value, i+1, 1) == ""u"")) {
									this.parseError(""\"", param_string, pos - strLen(subStr(value, i+1)))
								}

								uffff := Abs(""0x"" subStr(value, i+2, 4))
								if (A_IsUnicode || uffff < 0x100) {
									value := subStr(value, 1, i-1) chr(uffff) subStr(value, i+6)
								}
							}

							if (is_key) {
								key := value, next := "":""
								continue
							}

						} else {
							value := subStr(param_string, pos, i := regExMatch(param_string, ""[\]\},\s]|$"",, pos)-pos)

							if value is number
							{
								if value is integer
								{
									value += 0
								}
							}
							else if (value == ""true"" || value == ""false"") {
								value := %value% + 0
							} else if (value == ""null"") {
								value := """"
							} else {
								; we can do more here to pinpoint the actual culprit
								; but that's just too much extra work.
								this.parseError(next, text, pos, i)
							}
							pos += i - 1
						}
						next := holder == root ? """" : is_array ? "",]"" : "",}""
					} ; If inStr(""{["", ch) { ... } else

					is_array? key := objPush(holder, value) : holder[key] := value

					if (this.keys && this.keys.hasKey(holder)) {
						this.keys[holder].Push(key)
					}
				}
			} ; while ( ... )
			return this.rev ? this.walk(root, """") : root[""""]
		}

		parseError(param_expect, ByRef param_string, pos, param_length:=1)
		{
			static quot := chr(34), qurly := quot ""}""

			line := strSplit(subStr(param_string, 1, pos), ""`n"", ""`r"").length()
			col := pos - inStr(param_string, ""`n"",, -(strLen(param_string)-pos+1))
			msg := format(""{1}`n`nLine:`t{2}`nCol:`t{3}`nChar:`t{4}""
				, (param_expect == """")     ?	""Extra data""
				: (param_expect == ""'"")    ?	""Unterminated string starting at""
				: (param_expect == ""\"")    ?	""Invalid \escape""
				: (param_expect == "":"")    ?	""Expecting ':' delimiter""
				: (param_expect == quot)   ?	""Expecting object key enclosed in double quotes""
				: (param_expect == qurly)  ?	""Expecting object key enclosed in double quotes or object closing '}'""
				: (param_expect == "",}"")   ?	""Expecting ',' delimiter or object closing '}'""
				: (param_expect == "",]"")   ?	""Expecting ',' delimiter or array closing ']'""
				: inStr(param_expect, ""]"") ?	""Expecting JSON value or array closing ']'""
				:								""Expecting JSON value(string, number, true, false, null, object or array)""
			, line, col, pos)

			static offset := A_AhkVersion < ""2"" ? -3 : -4
			throw Exception(msg, offset, subStr(param_string, pos, param_length))
		}

		walk(param_holder, param_key)
		{
			value := param_holder[param_key]
			if (isObject(value)) {
				for i, k in this.keys[value] {
					; check if objhasKey(value, k) ??
					v := this.walk(value, k)
					if (v != JSON.Undefined) {
						value[k] := v
					} else {
						objDelete(value, k)
					}
				}
			}
			return this.rev.call(param_holder, param_key, value)
		}
	}


	class stringify extends JSON.functor
	{
		call(self, param_value, param_replacer:="""", space:="""")
		{
			this.rep := isObject(param_replacer) ? param_replacer : """"

			this.gap := """"
			if (space) {
				if space is integer
				{
					loop, % ((n := Abs(space))>10 ? 10 : n) {
						this.gap .= "" ""
					}
				} else {
					this.gap := subStr(space, 1, 10)
				}
				this.indent := ""`n""
			}
			return this.str({"""": param_value}, """")
		}

		str(param_holder, param_key)
		{
			param_value := param_holder[param_key]

			if (this.rep) {
				param_value := this.rep.call(param_holder, param_key, objhasKey(param_holder, param_key) ? param_value : JSON.Undefined)
			}

			if isObject(param_value) {
			; Check object type, skip serialization for other object types such as
			; ComObject, Func, BoundFunc, FileObject, RegExMatchObject, Property, etc.
				static type := A_AhkVersion<""2"" ? """" : func(""Type"")
				if (type ? type.call(param_value) == ""Object"" : objGetCapacity(param_value) != """") {
					if (this.gap) {
						stepback := this.indent
						this.indent .= this.gap
					}

					is_array := param_value.IsArray
					; Array() is not overridden, rollback to old method of
					; identifying array-like objects. Due to the use of a for-loop
					; sparse arrays such as '[1,,3]' are detected as objects({}).
					if (!is_array) {
						for i in param_value {
							is_array := i == A_Index
						}
						until (!is_array)
					}

					str := """"
					if (is_array) {
						loop, % param_value.length() {
							if (this.gap) {
								str .= this.indent
							}
							v := this.str(param_value, A_Index)
							str .= (v != """") ? v "","" : ""null,""
						}
					} else {
						colon := this.gap ? "": "" : "":""
						for k in param_value {
							v := this.str(param_value, k)
							if (v != """") {
								if (this.gap) {
									str .= this.indent
								}
								str .= this.quote(k) colon v "",""
							}
						}
					}

					if (str != """") {
						str := rTrim(str, "","")
						if (this.gap) {
							str .= stepback
						}
					}

					if (this.gap) {
						this.indent := stepback
					}
					return is_array ? ""["" str ""]"" : ""{"" str ""}""
				}
			} else {
				; is_number ? param_value : ""param_value""
				return objGetCapacity([param_value], 1) == """" ? param_value : this.quote(param_value)
			}
		}

		quote(param_string)
		{
			static quot := chr(34), bashq := ""\"" quot

			if (param_string != """") {
				param_string := strReplace(param_string,  ""\"", ""\\"")
				; , param_string := strReplace(param_string,  ""/"",  ""\/"") ; optional in ECMAScript
				, param_string := strReplace(param_string, quot, bashq)
				, param_string := strReplace(param_string, ""`b"", ""\b"")
				, param_string := strReplace(param_string, ""`f"", ""\f"")
				, param_string := strReplace(param_string, ""`n"", ""\n"")
				, param_string := strReplace(param_string, ""`r"", ""\r"")
				, param_string := strReplace(param_string, ""`t"", ""\t"")

				static rx_escapable := A_AhkVersion<""2"" ? ""O)[^\x20-\x7e]"" : ""[^\x20-\x7e]""
				while regExMatch(param_string, rx_escapable, m) {
					param_string := strReplace(param_string, m.Value, format(""\u{1:04x}"", ord(m.Value)))
				}
			}
			return quot param_string quot
		}
	}

	class test extends JSON.functor
	{
		call(self, param_string:="""")
		{
			if (isObject(param_string) || param_string == """") {
				return false
			}

			try {
				JSON.parse(param_string)
			} catch error {
				return false
			}
			return true
		}
	}


	; For use with reviver and replacer functions since AutoHotkey does not
	; have an 'undefined' type. Returning blank("""") or 0 won't work since these
	; can't be distnguished from actual JSON values. This leaves us with objects.
	; Replacer() - the caller may return a non-serializable AHK objects such as
	; ComObject, Func, BoundFunc, FileObject, RegExMatchObject, and Property to
	; mimic the behavior of returning 'undefined' in JavaScript but for the sake
	; of code readability and convenience, it's better to do 'return JSON.Undefined'.
	; Internally, the property returns a ComObject with the variant type of VT_EMPTY.
	Undefined[]
	{
		get {
			static empty := {}, vt_empty := ComObject(0, &empty, 1)
			return vt_empty
		}
	}

	class functor
	{
		__call(param_method, ByRef param_args, param_extargs*)
		{
			; When casting to call(), use a new instance of the ""function object""
			; so as to avoid directly storing the properties(used across sub-methods)
			; into the ""function object"" itself.
			if isObject(param_method) {
				return (new this).call(param_method, param_args, param_extargs*)
			} else if (param_method == """") {
				return (new this).call(param_args, param_extargs*)
			}
		}
	}
}

ChangeObjToString(obj)
{
	if (!IsObject(obj))
		return obj
	str := ""`n{""
	for key, value in obj
		str .= ""`n"" key "": "" ChangeObjToString(value) "",""
	return str ""`n}""
}

gameDataJson =
(
" + BigBoxUtils.GameInfoJSON + @"
)

if(Json.test(gameDataJson)){
	gameData := JSON.parse(gameDataJson,true)
}
else{
	gameData := {}
}
gameDataString := ChangeObjToString(gameData)

Array(items*) {
	items.base := ArrayEx
	return items
}

class ArrayEx
{
	join(sep := "","") {
		for k, v in this {
			out .= sep v
		}
		return SubStr(out, StrLen(sep)+1)
	}
}
returnvalue := """"
Args := []
OriginalArgs := []

";

		}

		public static bool AHKSyntaxCheck(string ahkCode, bool addPrefix, out string errorTxt)
		{
			errorTxt = "";
			string ahk_code = ahkCode;
			if (addPrefix)
			{
				ahk_code = AHKGetPrefix() + "\n" + ahkCode;
			}

			string currentDir = Path.GetFullPath(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
			string ahkExe = Path.Combine(currentDir, "AutoHotkeyU32.exe");
			if (!File.Exists(ahkExe)) return true;


			// Obtenez le chemin du répertoire temporaire
			string tempDirectory = Path.GetTempPath();
			string tempFileName = Path.GetRandomFileName() + ".ahk";
			string tempFilePath = Path.Combine(tempDirectory, tempFileName);

			if (File.Exists(tempFilePath)) File.Delete(tempFilePath);
			try
			{
				// Create a temporary file to store the AHK code

				File.WriteAllText(tempFilePath, ahk_code);

				// Create a process to run AutoHotkey and capture standard error
				Process process = new Process();
				process.StartInfo.FileName = ahkExe;
				process.StartInfo.Arguments = $"/iLib nul /ErrorStdOut \"{tempFilePath}\"";
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

				process.Start();

				// Read and print the standard error output
				errorTxt = process.StandardError.ReadToEnd();

				int index = errorTxt.IndexOf("\n");
				if(index != -1) errorTxt = errorTxt.Substring(index);

				process.WaitForExit();

				// Delete the temporary file
				File.Delete(tempFilePath);

				// Check if the exit code is 0 (indicating successful syntax check)
				if (process.ExitCode == 0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static Process FindProcessEmulator(string[] args)
		{
			if (args.Length == 0) return null;
			string emuPath = args[0];
			string processName = Path.GetFileNameWithoutExtension(emuPath);

			var currentProcessHandle = Process.GetCurrentProcess().Id;
			Process FoundProcess = null;
			foreach (var p in Process.GetProcessesByName(processName).Where(p => p.MainWindowTitle != ""))
			{
				var parent = ParentProcessUtilities.GetParentProcess(p.Id);
				if(parent != null)
				{
					if(parent.Id == currentProcessHandle)
					{
						FoundProcess = p;
						return FoundProcess;
						break;
					}
					else
					{
						var grandParent = ParentProcessUtilities.GetParentProcess(parent.Id);
						if(grandParent != null)
						{
							if (grandParent.Id == currentProcessHandle)
							{
								FoundProcess = p;
								return FoundProcess;
								break;
							}
						}
					}
				}
			}
			

			foreach (var p in Process.GetProcessesByName(processName).Where(p => 1 == 1))
			{
				var parent = ParentProcessUtilities.GetParentProcess(p.Id);
				if (parent != null)
				{
					if (parent.Id == currentProcessHandle)
					{
						FoundProcess = p;
						return FoundProcess;
						break;
					}
					else
					{
						var grandParent = ParentProcessUtilities.GetParentProcess(parent.Id);
						if (grandParent != null)
						{
							if (grandParent.Id == currentProcessHandle)
							{
								FoundProcess = p;
								return FoundProcess;
								break;
							}
						}
					}
				}
			}
			if (FoundProcess == null) FoundProcess = Process.GetProcessesByName(processName).Where(p => p.MainWindowTitle != "").FirstOrDefault();
			if (FoundProcess == null) FoundProcess = Process.GetProcessesByName(processName).FirstOrDefault();

			return FoundProcess;

		}


		public static void PauseProcess(int processId)
		{
			Process process = Process.GetProcessById(processId);
			foreach (ProcessThread thread in process.Threads)
			{
				IntPtr hThread = OpenThread(0x0002, false, thread.Id); // THREAD_SUSPEND_RESUME
				if (hThread != IntPtr.Zero)
				{
					SuspendThread(hThread);
					CloseHandle(hThread);
				}
			}
		}

		public static void ResumeProcess(int processId)
		{
			Process process = Process.GetProcessById(processId);
			foreach (ProcessThread thread in process.Threads)
			{
				IntPtr hThread = OpenThread(0x0002, false, thread.Id); // THREAD_SUSPEND_RESUME
				if (hThread != IntPtr.Zero)
				{
					int suspendCount = 0;
					do
					{
						suspendCount = ResumeThread(hThread);
					} while (suspendCount > 0);
					CloseHandle(hThread);
				}
			}
		}

		public static string GuessRomPath(string[] Args, string[] OriginalArgs)
		{
			string initialRomPath = "";
			if(GameInfoJSON != "")
			{
				Dictionary<string, object> gameData = JsonConvert.DeserializeObject<Dictionary<string, object>>(GameInfoJSON);
				if (gameData != null)
				{
					if (gameData.ContainsKey("GameApplicationPath"))
					{
						initialRomPath = (string)gameData["GameApplicationPath"];
					}
				}
			}
			if (string.IsNullOrEmpty(initialRomPath))
			{
				foreach (string arg in Args)
				{
					if (arg.ToLower().Trim().Contains(initialRomPath.ToLower().Trim()))
					{
						return Path.GetFullPath(initialRomPath);
					}
				}
				string initialRomFile = Path.GetFileName(initialRomPath).ToLower().Trim();
				foreach (string arg in Args)
				{
					if (arg.ToLower().Trim().EndsWith(initialRomFile))
					{
						if (File.Exists(arg))
						{
							return Path.GetFullPath(arg);
						}
						else
						{
							if (arg.Contains("="))
							{
								string[] parties = arg.Split(new char[] { '=' }, 2);
								if (parties.Length == 2)
								{
									string valeurApresPremierEgal = parties[1];
									if (File.Exists(valeurApresPremierEgal)) return valeurApresPremierEgal;
								}
							}
						}
					}
				}
			}
			var FilteredArgs = new List<string>(Args.ToArray());
			if(Args.Length > 0)
			{
				FilteredArgs.RemoveAt(0);
				foreach (string oarg in OriginalArgs)
				{
					if (FilteredArgs.Contains(oarg))
					{
						FilteredArgs.Remove(oarg);
					}
				}
			}
			string biggestFileName = "";
			long biggestFileSize = -1;
			foreach(var farg in FilteredArgs)
			{
				try{
					if (File.Exists(farg))
					{
						long taille = new FileInfo(farg).Length;
						if (taille > biggestFileSize)
						{
							biggestFileName = Path.GetFullPath(farg);
							biggestFileSize = taille;
						}

					}
					else
					{
						if (farg.Contains("="))
						{
							string[] parties = farg.Split(new char[] { '=' }, 2);
							if (parties.Length == 2)
							{
								string valeurApresPremierEgal = parties[1];
								if (File.Exists(valeurApresPremierEgal))
								{
									long taille = new FileInfo(farg).Length;
									if (taille > biggestFileSize)
									{
										biggestFileName = Path.GetFullPath(farg);
										biggestFileSize = taille;
									}
								}
							}
						}

					}
				}
				catch { }

			}
			if (biggestFileName != "") return biggestFileName;

			return Path.GetFullPath(initialRomPath);
		}

		public static bool Base64Decode(string base64txt, out string result)
		{
			try
			{
				byte[] data = Convert.FromBase64String(base64txt);
				result = System.Text.Encoding.UTF8.GetString(data);
				return true;
			}
			catch (FormatException)
			{
				result = "";
				return false;
			}
		}
	}

}
