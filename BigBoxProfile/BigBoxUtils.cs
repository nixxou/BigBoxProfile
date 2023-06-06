using BigBoxProfile.EmulatorActions;
using CliWrap;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
			catch {
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



		public static string[] AddFirstElementToArg(string[] args,string argument)
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

		public static bool CheckTaskExist(string taskName)
		{
			using (TaskService taskService = new TaskService())
			{
				if (taskService.GetTask(taskName) == null)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		public static bool CheckTaskExist(string[] args)
		{
			return CheckTaskExist(GetTaskName(args));
		}

		public static void RegisterTask(string[] args,string optionTask = "")
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

		public static void ExecuteTask(string taskName,int delay=1000)
		{
			string new_cmd = $@" /run /tn ""{taskName}""";
			var args = BigBoxUtils.CommandLineToArgs(new_cmd, false);

			var TaskRun = System.Threading.Tasks.Task.Run(() =>
			Cli.Wrap("schtasks")
			.WithArguments(args)
			.WithValidation(CommandResultValidation.None)
			.ExecuteAsync()
			);
			TaskRun.Wait();

			Thread.Sleep(delay);

			TaskService ts = new TaskService();
			Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskName);
			Microsoft.Win32.TaskScheduler.RunningTaskCollection instances = task.GetInstances();
			while (instances.Count == 1)
			{
				instances = task.GetInstances();
				Thread.Sleep(100);
			}
		}

		public static void ExecuteTask(string[] args, int delay=1000,bool registerIfNeeded = true, string optionTask="")
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

	}

}
