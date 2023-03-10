using CliWrap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	internal static class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			
			/*
			var forceArg = new string[1];
			forceArg[0] = @"C:\LaunchBox\BigBox.exe";
			args = forceArg;
			*/

			if (args.Length== 0)
			{

				/*
				if (!BigBoxUtils.IsAppRegistered() || !BigBoxUtils.IsGamesRegistered())
				{
					MessageBox.Show("You need Admin right to register the App or Games");
					BigBoxUtils.RegisterExec();
				}
				*/

				var registeryManager = new RegisteryManager(Profile.PathMainProfileDir, Assembly.GetEntryAssembly().Location);
				if (registeryManager.CheckIfActionIsNeeded())
				{
					MessageBox.Show("You need Admin right to register the App or Games");
					BigBoxUtils.RegisterExec();
				}
				

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Config());
			}
			else
			{
				if(args.Length== 1 && args[0] == "--register")
				{
					bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
					if (isAdmin)
					{
						BigBoxUtils.RegisterApp();
					}
					else
					{
						MessageBox.Show("The command --register must be send with Admin privilege");
					}
					return;
				}
				if (args.Length == 1 && args[0] == "--unregister")
				{
					bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
					if (isAdmin)
					{
						BigBoxUtils.UnregisterApp();
					}
					else
					{
						MessageBox.Show("The command --unregister must be send with Admin privilege");
					}
					return;
				}

				if (args.Length >= 1)
				{
					if (File.Exists(args[0]))
					{
						if (args[0].EndsWith("BigBox.exe") || args[0].EndsWith("LaunchBox.exe"))
						{
							//MessageBox.Show("exec here ! " + BigBoxUtils.ArgsToCommandLine(args));

							/*
							bool skip = false;
							var p = ParentProcessUtilities.GetParentProcess();
							if (p != null)
							{
								string process_name = p.ProcessName;
								if(process_name.ToLower()=="launchbox" || process_name.ToLower()=="bigbox") skip = true;
							}
							if (!skip)
							{
								var bigBoxLauncher = new BigBoxLauncher(args);
								bigBoxLauncher.Exec();
							}

							*/

							bool directlaunch = false;
							if(args.Length >= 2)
							{
								if (args[1].Contains("--profile=")==false) directlaunch= true;
							}
							if (directlaunch)
							{
								var task = BigBoxLauncher.DirectLaunch(args);
								task.Wait();
							}
							else
							{
								var bigBoxLauncher = new BigBoxLauncher(args);
								bigBoxLauncher.Exec();
							}


						}
						else
						{
							var emulatorLauncher = new EmulatorLauncher(args);
							emulatorLauncher.Exec();

							/*
							MessageBox.Show("ici");
							var task = BigBoxLauncher.TestExec(args);
							task.Wait();
							*/

						}
					}

				}


				
			}


		}
	}


}
