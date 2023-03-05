﻿using CliWrap;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BigBoxProfile
{
	public class BigBoxLauncher
	{
		public Profile SelectedProfile { get; private set; }
		public List<string> Args;

		public string LaunchFromDir;
		public string FileOriginal;
		public string FileNew;
		public string FileDir;

		public bool restoreSwitch = false;
		public string restoreSoundCard = "";


		public BigBoxLauncher(string[] args)
		{
			var newArgs = new List<string>();
			newArgs = args.ToList();
			newArgs.RemoveAt(0);
			int keytodelete = -1;
			int index = 0;
			foreach (var arg in newArgs)
			{
				string prefix = "--profile=";
				if (arg.StartsWith(prefix))
				{
					string profileName = arg.Substring(prefix.Length).ToLower().Trim();
					if (Profile.ProfileList.ContainsKey(profileName))
					{
						SelectedProfile = Profile.ProfileList[profileName];
						keytodelete = index;
						break;
					}

				}
				index++;
			}
			if (keytodelete >= 0) newArgs.RemoveAt(keytodelete);
			else SelectedProfile = Profile.ProfileList["default"];
			Args = newArgs;

			LaunchFromDir = Environment.CurrentDirectory;
			string file = args[0];
			string dir = Path.GetDirectoryName(file);
			string exe = Path.GetFileName(file);
			string coreexe = Path.Combine(dir, "Core", exe);
			if (File.Exists(coreexe))
			{
				file = coreexe;
				dir = Path.GetDirectoryName(file);
				exe = Path.GetFileName(file);
			}
			string exeWithoutFilename = Path.GetFileNameWithoutExtension(file);
			string newExe = Path.Combine(dir, exeWithoutFilename + "_" + SelectedProfile.ProfileName + ".exe");
			FileOriginal = file;
			FileNew = newExe;
			FileDir = dir;
		}

		public void ExecutePrelaunchAction()
		{

			if (SelectedProfile.Configuration["monitorswitch"] != "<none>")
			{
				
				if(MonitorSwitcher.SaveDisplaySettings(Path.Combine(Profile.PathMainProfileDir, "dispositionrestore.xml")))
				{
					if (BigBoxUtils.UseMonitorDisposition(SelectedProfile.Configuration["monitorswitch"]))
					{
						restoreSwitch = true;
					}
				}
			}
			
			if (SelectedProfile.Configuration["soundcard"] != "<dontchange>")
			{
				restoreSoundCard = SoundCardUtils.GetMainCards();
				if (!SoundCardUtils.SetDefaultMic(SelectedProfile.Configuration["soundcard"]))
				{
					restoreSoundCard = "";
				}
			}

			string BigBoxSettingsFile = Path.Combine(FileDir, "..", "Data", "BigBoxSettings.xml");
			if (File.Exists(BigBoxSettingsFile))
			{
				int MonitorToSwitch = BigBoxUtils.GetMonitorIDFromPriorityList(SelectedProfile.Configuration["monitor"]);
				BigBoxUtils.ModifierParametrePrimaryMonitorIndex(BigBoxSettingsFile, MonitorToSwitch);
			}
			

			

		}

		public void ExecuteRestoreActions()
		{
			if(restoreSwitch)
			{
				MonitorSwitcher.LoadDisplaySettings(Path.Combine(Profile.PathMainProfileDir, "dispositionrestore.xml"));

			}
			if(restoreSoundCard != "")
			{
				SoundCardUtils.SetDefaultMic(restoreSoundCard);
			}
		}


		public async Task ExecuteBigBox()
		{
			try
			{

				BigBoxUtils.MakeLink(FileOriginal, FileNew);

				//MessageBox.Show("execute " + newExe);
				var ResultRPCS = await Cli.Wrap(FileNew)
					.WithArguments(Args)
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();


				File.Delete(FileNew);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Exec()
		{
			ExecutePrelaunchAction();
			var task = ExecuteBigBox();
			task.Wait();
			Thread.Sleep(1000);
			ExecuteRestoreActions();
		}


	}
}
