using CliWrap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public class EmulatorLauncher
	{
		Profile SelectedProfile = null;
		bool useAlternativeLaunch = false;
		string LaunchFromDir;
		string ExeFileFull;
		string ExeFile;
		string NewExe;
		string Dir;
		string[] Args;

		public static string BigBoxFolder = "";

		private static Form form;

		[DllImport("user32.dll")]
		private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		private const uint SWP_NOACTIVATE = 0x0010;
		private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
		private static readonly IntPtr HWND_TOP = new IntPtr(0);
		private const int SWP_NOMOVE = 0x0002;
		private const int SWP_NOSIZE = 0x0001;
		const int SW_SHOWMAXIMIZED = 3;

		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		public EmulatorLauncher(string[] args)
		{
			string selectedProfile = "default";
			var p = ParentProcessUtilities.GetParentProcess();
			if (p != null)
			{
				string process_name = p.ProcessName;
				if (process_name.ToLower().Contains("bigbox") || process_name.ToLower().Contains("launchbox"))
				{
					BigBoxFolder = Path.GetDirectoryName(BigBoxUtils.GetCommandLineInfo(p));
					var parentBigBoxProfileProcess = ParentProcessUtilities.GetParentProcess(p.Id);
					if (parentBigBoxProfileProcess != null)
					{
						string parentCmdLine = BigBoxUtils.GetCommandLineInfo(parentBigBoxProfileProcess);
						var parentsCmdArgs = BigBoxUtils.CommandLineToArgs(parentCmdLine);


						foreach (var arg in parentsCmdArgs)
						{
							string prefix = "--profile=";
							if (arg.StartsWith(prefix))
							{
								string profileName = arg.Substring(prefix.Length).ToLower().Trim();
								if (Profile.ProfileList.ContainsKey(profileName))
								{
									selectedProfile = profileName;
									break;
								}

							}
						}

					}
				}
			}
			SelectedProfile = Profile.ProfileList[selectedProfile];

			LaunchFromDir = Environment.CurrentDirectory;
			ExeFileFull = args[0];
			Dir = Path.GetDirectoryName(ExeFileFull);
			ExeFile = Path.GetFileName(ExeFileFull);
			NewExe = Path.Combine(Dir, Path.GetFileNameWithoutExtension(ExeFileFull) + "_.exe");
			Args = args;



		}

		public void ExecutePrelaunch()
		{

		}

		public void ExecutePostlaunch()
		{
			var targetProcess = Process.GetProcessesByName("BigBox").FirstOrDefault(p => p.MainWindowTitle != "");
			if (targetProcess != null)
			{
				SetForegroundWindow(targetProcess.MainWindowHandle);
			}
		}

		public async Task ExecuteJustRun()
		{
			try
			{
				string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");
				//JustRunExe = @"C:\LaunchBox\Emulators\SimpleFowarder.exe";

				var ResultRPCS = await Cli.Wrap(JustRunExe)
					.WithArguments(Args)
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}


		public async Task ExecuteWithLink()
		{

			try
			{

				BigBoxUtils.MakeLink(ExeFileFull, NewExe);
				var ResultRPCS = await Cli.Wrap(NewExe)
					.WithArguments(BigBoxUtils.ArgsWithoutFirstElement(Args))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();
				File.Delete(NewExe);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Execute()
		{
			Task task;
			if (useAlternativeLaunch) task = ExecuteWithLink();
			else task = ExecuteJustRun();
			task.Wait();
		}

		public void Exec()
		{
			Emulator emulator = null;
			if (SelectedProfile == null)
			{
				if (Emulator.Exist("default", ExeFile))
				{
					var default_emulator = new Emulator("default", ExeFile);
					if (default_emulator.ApplyWithoutLaunchbox)
					{
						emulator = default_emulator;
						SelectedProfile = Profile.ProfileList["default"];
					}
				}
			}
			else
			{
				if (Emulator.Exist(SelectedProfile.ProfileName, ExeFile))
				{
					emulator = new Emulator(SelectedProfile.ProfileName, ExeFile);
				}
			}



			if (emulator == null)
			{
				Execute();
			}
			else
			{

				//var argstring = BigBoxUtils.ArgsToCommandLine(Args);
				//MessageBox.Show(argstring);

				if (SelectedProfile.Configuration.ContainsKey("delay_emulator") && SelectedProfile.Configuration["delay_emulator"] != "")
				{
					int delay_emulator = 0;
					int.TryParse(SelectedProfile.Configuration["delay_emulator"], out delay_emulator);
					if (delay_emulator > 0)
					{
						Thread formThread = new Thread(ShowFormInBackground);
						formThread.Start();
						Thread.Sleep((delay_emulator * 1000));
					}

				}






				ExecutePrelaunch();

				string m3uFile = BigBoxUtils.HaveLaunchboxM3U(Args);
				if (String.IsNullOrEmpty(m3uFile))
				{
					List<string> FilterToRemove = new List<string>();
					foreach (var module in emulator._selectedModules)
					{
						if (module.IsConfigured())
						{
							module.ExecuteBefore(Args);
							Args = module.ModifyReal(Args);
							foreach (var f in module.FiltersToRemoveOnFinalPass())
							{
								FilterToRemove.Add(f);
							}

						}

					}


					var OriginalArg = Args;
					List<string> finalFilteredArg = new List<string>();
					foreach (var arg in Args)
					{
						if (!FilterToRemove.Contains(arg.ToLower().Trim()))
						{
							finalFilteredArg.Add(arg.ToLower().Trim());
						}
					}
					Args = finalFilteredArg.ToArray();

					Execute();
					Thread.Sleep(1000);
					Args = OriginalArg;

					for (int i = emulator._selectedModules.Count - 1; i >= 0; i--)
					{
						var module = emulator._selectedModules[i];
						if (module.IsConfigured())
						{
							module.ExecuteAfter(Args);
						}
					}

				}
				else
				{
					string m3uNew = BigBoxUtils.GetLaunchboxM3UNewPath(m3uFile);
					List<string> m3uFileListOriginal = BigBoxUtils.GetLaunchboxM3UContent(m3uFile);
					string m3uFirstFile = m3uFileListOriginal.First();
					List<string> m3uFileListNew = new List<string>();

					int nbM3U = BigBoxUtils.CountFileInArg(Args, m3uFile);
					var ArgsWithFirstFileInsteadOfM3U = BigBoxUtils.RemplaceFileInArg(Args, m3uFile, m3uFirstFile);
					var ArgsWithFirstFileInsteadOfM3U_Copy = new string[ArgsWithFirstFileInsteadOfM3U.Length];
					ArgsWithFirstFileInsteadOfM3U.CopyTo(ArgsWithFirstFileInsteadOfM3U_Copy, 0);

					List<string> FilterToRemove = new List<string>();
					foreach (var module in emulator._selectedModules)
					{
						if (module.IsConfigured())
						{
							foreach (var f in module.FiltersToRemoveOnFinalPass())
							{
								FilterToRemove.Add(f);
							}
						}
					}

					foreach (var module in emulator._selectedModules)
					{
						if (module.IsConfigured() && module.UseM3UContent() == false)
						{
							module.ExecuteBefore(ArgsWithFirstFileInsteadOfM3U);
							ArgsWithFirstFileInsteadOfM3U = module.ModifyReal(ArgsWithFirstFileInsteadOfM3U);
							//Si il y a une modification du fichier passé en paramettre, on accepte pas la modif et on restaure
							if (BigBoxUtils.CountFileInArg(ArgsWithFirstFileInsteadOfM3U, m3uFirstFile) != nbM3U)
							{
								ArgsWithFirstFileInsteadOfM3U = new string[ArgsWithFirstFileInsteadOfM3U_Copy.Length];
								ArgsWithFirstFileInsteadOfM3U_Copy.CopyTo(ArgsWithFirstFileInsteadOfM3U, 0);
							}
						}
					}
					Args = BigBoxUtils.RemplaceFileInArg(ArgsWithFirstFileInsteadOfM3U, m3uFirstFile, m3uNew);

					foreach (var fileInM3U in m3uFileListOriginal)
					{
						//MessageBox.Show("fileInM3U : " + fileInM3U);
						var ForgedArgList = new List<string>();
						ForgedArgList.Add(Args[0]);
						ForgedArgList.Add(fileInM3U);
						if (Args.Length > 2)
						{
							for (int i = 1; i < Args.Length; i++)
							{
								if (Args[i] != m3uNew)
								{
									ForgedArgList.Add(Args[i]);
								}
							}
						}
						var ForgedArg = ForgedArgList.ToArray();

						foreach (var module in emulator._selectedModules)
						{
							if (module.IsConfigured() && module.UseM3UContent() == true)
							{
								module.ExecuteBefore(ForgedArg);
								ForgedArg = module.ModifyReal(ForgedArg);
							}
						}
						m3uFileListNew.Add(ForgedArg[1]);
					}

					string directoryPath = Path.GetDirectoryName(m3uNew);
					if (!Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
					}
					File.WriteAllLines(m3uNew, m3uFileListNew.ToArray());

					var OriginalArg = Args;
					List<string> finalFilteredArg = new List<string>();
					foreach (var arg in Args)
					{
						if (!FilterToRemove.Contains(arg.ToLower().Trim()))
						{
							finalFilteredArg.Add(arg.ToLower().Trim());
						}
					}
					Args = finalFilteredArg.ToArray();
					Execute();
					Thread.Sleep(1000);
					Args = OriginalArg;

					File.Delete(m3uNew);

					for (int i = emulator._selectedModules.Count - 1; i >= 0; i--)
					{
						var module = emulator._selectedModules[i];
						if (module.IsConfigured())
						{
							module.ExecuteAfter(Args);
						}
					}



					//MessageBox.Show(M3UFile);
				}

				/*
				Si M3U


				*/


				//MessageBox.Show("ici_debug1");

			}
			ExecutePostlaunch();

			//MessageBox.Show("ici_debug2");

		}

		private static void ShowFormInBackground()
		{
			form = new Form
			{
				Width = 300,
				Height = 200,
				Text = "Background Form",
				FormBorderStyle = FormBorderStyle.None,
				Opacity = 0, // Make the form completely transparent
				ShowInTaskbar = false // Hide the form from the taskbar
			};

			//SetWindowPos(form.Handle, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
			// Show the form in the background
			SetWindowPos(form.Handle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOACTIVATE);

			Application.Run(form);
		}



	}
}
