using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace BigBoxProfile
{
	internal class BigBoxUtils
	{
		public static void RegisterApp()
		{

			RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options", true);
			RegistryKey subkey = key.CreateSubKey("BigBox.exe");
			subkey.SetValue("Debugger", Assembly.GetEntryAssembly().Location);
		}

		public static void UnregisterApp()
		{
			DeleteRegistryKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Image File Execution Options\BigBox.exe");
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




	}
}
