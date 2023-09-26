using PS3IsoLauncher;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;

namespace BigBoxProfile
{
	internal static class Program
	{
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			/*
			var forceArg = new string[1];
			forceArg[0] = @"C:\LaunchBox\BigBox.exe";
			args = forceArg;
			*/
			if (args.Length == 1 && args[0] == "--mountvhdx")
			{
				bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
				if (isAdmin)
				{
					VHDXTool.TaskMount();
				}
				return;
			}

			if (args.Length == 1 && args[0] == "--unmountvhdx")
			{
				bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
				if (isAdmin)
				{
					VHDXTool.TaskUnmount();
				}
				return;
			}

			if (args.Length == 0)
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
				if (args.Length == 1 && args[0] == "--register")
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

							/*
							ProfileFileSwitcher profileFileSwitcher = null;
							string file = args[0];
							string dir = Path.GetDirectoryName(file);
							string exe = Path.GetFileName(file);
							string coreexe = Path.Combine(dir, "Core", exe);
							if (File.Exists(coreexe))
							{
								file = coreexe;
							}
							bool isRecovery = false;
							var exceptRecovery = new string[2] { "-recovery", "-recoverybigbox" };
							foreach(var arg in args)
							{
								if (exceptRecovery.Contains(arg)) isRecovery = true;
							}
							if(isRecovery == false)
							{
								if (BigBoxUtils.IsProcessRunning(file, exceptRecovery))
								{
									MessageBox.Show("Already Running");
									return;
								}
								else
								{
									profileFileSwitcher = new ProfileFileSwitcher(args[0]);
								}
							}
							*/
							//MessageBox.Show(BigBoxUtils.ArgsToCommandLine(args));



							bool directlaunch = false;
							if (args.Length >= 2)
							{
								if (args[1].Contains("--profile=") == false) directlaunch = true;
							}
							if (directlaunch)
							{
								var task = BigBoxLauncher.DirectLaunch(args);
								task.Wait();
							}
							else
							{
								/*
								string file = args[0];
								string dir = Path.GetDirectoryName(file);
								string exe = Path.GetFileName(file);
								string coreexe = Path.Combine(dir, "Core", exe);
								if (File.Exists(coreexe))
								{
									file = coreexe;
								}
								if (BigBoxUtils.IsLaunchboxRunning(file))
								{
									MessageBox.Show("BigBox/Launchbox is already Running");
									return;
								}
								*/


								var bigBoxLauncher = new BigBoxLauncher(args);
								bigBoxLauncher.Exec();
							}


						}
						else
						{
							var emulatorLauncher = new EmulatorLauncher(args);
							emulatorLauncher.Exec();
							//MessageBox.Show("ici_debug3");

							int currentProcessId = Process.GetCurrentProcess().Id;
							//MessageBox.Show("ici_debug4");


							Process currentProcess = Process.GetCurrentProcess();
							int parentId = GetParentProcessId(currentProcess.Id);
							//MessageBox.Show("ici_debug5");
							if (parentId != 0)
							{
								Process parentProcess = Process.GetProcessById(parentId);
								IntPtr handle = parentProcess.MainWindowHandle;

								if (handle != IntPtr.Zero)
								{
									SetForegroundWindow(handle);
								}
							}


							// Créez un objet ProcessStartInfo pour configurer le démarrage du processus
							ProcessStartInfo psi = new ProcessStartInfo("taskkill")
							{
								// Spécifiez les arguments de la commande taskkill
								Arguments = "/F /PID " + currentProcessId,

								// Masquez la fenêtre de la console
								CreateNoWindow = true,
								UseShellExecute = false
							};

							// Créez le processus en utilisant Process.Start avec ProcessStartInfo
							Process process = new Process
							{
								StartInfo = psi
							};

							// Exécutez la commande taskkill sans afficher la fenêtre de la console
							process.Start();
							process.WaitForExit();


							//Process.Start("taskkill", "/F /PID " + currentProcessId);

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

		private static int GetParentProcessId(int processId)
		{
			using (System.Management.ManagementObjectSearcher mos = new System.Management.ManagementObjectSearcher(
				$"SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {processId}"))
			{
				using (System.Management.ManagementObjectCollection moc = mos.Get())
				{
					foreach (System.Management.ManagementObject mo in moc)
					{
						return Convert.ToInt32(mo["ParentProcessId"]);
					}
				}
			}

			return 0;
		}
	}


}
