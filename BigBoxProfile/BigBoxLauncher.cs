using CliWrap;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BigBoxProfile
{
	public class BigBoxLauncher
	{

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		// Constants for the nCmdShow parameter of the ShowWindow function.
		const int SW_MAXIMIZE = 3;

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int Left;        // coordonnée X du coin supérieur gauche
			public int Top;         // coordonnée Y du coin supérieur gauche
			public int Right;       // coordonnée X du coin inférieur droit
			public int Bottom;      // coordonnée Y du coin inférieur droit

			public int Width => Right - Left; // Largeur de la fenêtre
			public int Height => Bottom - Top; // Hauteur de la fenêtre
		}

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);


		public Profile SelectedProfile { get; private set; }
		public List<string> Args;

		public string[] OriginalArgs;

		public string LaunchFromDir;
		public string FileOriginal;
		public string FileNew;
		public string FileDir;

		public bool restoreSwitch = false;
		public string restoreSoundCard = "";

		public bool IsLaunchbox = false;

		public bool PreventRun = false;
		ProfileFileSwitcher profileFileSwitcher;


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

			if (exeWithoutFilename.ToLower() == "launchbox") IsLaunchbox = true;

			string newExe = Path.Combine(dir, exeWithoutFilename + "_" + SelectedProfile.ProfileName + ".exe");
			FileOriginal = file;
			FileNew = newExe;
			FileDir = dir;

			profileFileSwitcher = new ProfileFileSwitcher(file);
			if (profileFileSwitcher.Active)
			{
				if (BigBoxUtils.IsLaunchboxRunning(file))
				{
					PreventRun = true;
				}
			}

		}

		public void ExecutePrelaunchAction()
		{

			if (IsLaunchbox == false || (IsLaunchbox && SelectedProfile.Configuration.ContainsKey("launchbox") && SelectedProfile.Configuration["launchbox"] == "yes"))
			{
				if (SelectedProfile.Configuration["monitorswitch"] != "<none>")
				{

					if (MonitorSwitcher.SaveDisplaySettings(Path.Combine(Profile.PathMainProfileDir, "dispositionrestore.xml")))
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
                    if (restoreSoundCard != SelectedProfile.Configuration["soundcard"] && !String.IsNullOrEmpty(restoreSoundCard))
                    {
                        for(int i = 0; i < 10; i++)
						{
							if (SoundCardUtils.GetSoundCards().Contains(restoreSoundCard))
							{
								break;
							}
							else
							{
								Thread.Sleep(1000);
							}
						}


                    }
					if (!SoundCardUtils.SetDefaultMic(SelectedProfile.Configuration["soundcard"]))
					{
						restoreSoundCard = "";
					}
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
			if (IsLaunchbox == false || (IsLaunchbox && SelectedProfile.Configuration.ContainsKey("launchbox") && SelectedProfile.Configuration["launchbox"] == "yes"))
			{

				if (restoreSwitch)
				{
					MonitorSwitcher.LoadDisplaySettings(Path.Combine(Profile.PathMainProfileDir, "dispositionrestore.xml"));

				}
				if (restoreSoundCard != "")
				{
					SoundCardUtils.SetDefaultMic(restoreSoundCard);
				}

			}
		}


		public async Task ExecuteBigBox()
		{
			try
			{
				string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");

				if (IsLaunchbox == false)
				{
					var ResultRPCS2 = await Cli.Wrap(JustRunExe)
						.WithArguments(FileOriginal)
						.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
						.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
						.WithValidation(CommandResultValidation.None)
						.ExecuteAsync();

				}
				else
				{

					var ResultRPCS2 = Cli.Wrap(JustRunExe)
						.WithArguments(FileOriginal)
						.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
						.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
						.WithValidation(CommandResultValidation.None)
						.ExecuteAsync();

					bool didAction = false;
					while (didAction == false && Process.GetProcessesByName("LaunchBox").Length > 0)
					{
						var targetProcess = Process.GetProcessesByName("LaunchBox").FirstOrDefault(p => p.MainWindowTitle != "");
						if (targetProcess != null)
						{
							didAction = true;

							var screen = Screen.FromHandle(targetProcess.MainWindowHandle);
							int screenIndex = Array.IndexOf(Screen.AllScreens, screen);

							double screenBaseWidth = screen.Bounds.Width;
							double screenBaseHeight = screen.Bounds.Height;

							bool maximize = false;
							//if (SelectedProfile.Configuration.ContainsKey("maximize_launchbox") && SelectedProfile.Configuration["maximize_launchbox"] == "yes") maximize = true;



							int MonitorToSwitch = BigBoxUtils.GetMonitorIDFromPriorityList(SelectedProfile.Configuration["monitor"]);
							//MessageBox.Show(MonitorToSwitch.ToString());

							if (screenIndex != MonitorToSwitch)
							{
								if (maximize == false)
								{
									ShowWindow(targetProcess.MainWindowHandle, 9);
								}
								// Get the base size of the window at launch.
								var rect = new RECT();
								GetWindowRect(targetProcess.MainWindowHandle, out rect);
								var baseWidth = rect.Width;
								var baseHeight = rect.Height;

								Console.WriteLine($"Base window size: {baseWidth} x {baseHeight}");

								// Move the window to the second screen.
								var screens = Screen.AllScreens;
								if (MonitorToSwitch >= 0)
								{
									var secondScreen = screens[MonitorToSwitch];
									var resolutionRatio = (double)secondScreen.WorkingArea.Width / screenBaseWidth; // Assuming 1920x1080 is the base resolution.
									var newWidth = (int)(baseWidth * resolutionRatio);
									var newHeight = (int)(baseHeight * resolutionRatio);
									var newLocation = new Point(secondScreen.Bounds.X + 10, secondScreen.Bounds.Y + 10); // Change the values according to your needs.
									MoveWindow(targetProcess.MainWindowHandle, newLocation.X, newLocation.Y, newWidth, newHeight, true);
								}

							}

						}
						Thread.Sleep(1000);
					}
					await ResultRPCS2;

				}

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Exec()
		{

			if (PreventRun)
			{

				var w = new Form() { Size = new Size(0, 0) };
				Task.Delay(TimeSpan.FromSeconds(3))
					.ContinueWith((t) => w.Close(), TaskScheduler.FromCurrentSynchronizationContext());

				MessageBox.Show(w, "Launchbox/BigBox is already running");

				return;
			}
			if (profileFileSwitcher.Active)
			{
				profileFileSwitcher.OpenProfile(SelectedProfile.ProfileName);
			}

			ExecutePrelaunchAction();
			var task = ExecuteBigBox();
			task.Wait();

			profileFileSwitcher.CloseProfile(SelectedProfile.ProfileName);

			if (SelectedProfile.Configuration["restore"] == "yes")
			{
				Thread.Sleep(1000);
				ExecuteRestoreActions();
			}
		}

		public static async Task DirectLaunch(string[] args)
		{

			string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");

			var ResultRPCS2 = await Cli.Wrap(JustRunExe)
				.WithArguments(args)
				.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
				.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
				.WithValidation(CommandResultValidation.None)
				.ExecuteAsync();
		}

		public static async Task TestExec(string[] args)
		{
			try
			{

				string FileName = args[0];

				string dir = Path.GetDirectoryName(FileName);
				string exeWithoutFilename = Path.GetFileNameWithoutExtension(FileName);
				string newExe = Path.Combine(dir, exeWithoutFilename + "_.exe");


				BigBoxUtils.MakeLink(FileName, newExe);


				string[] newArgs = new string[args.Length - 1];
				Array.Copy(args, 1, newArgs, 0, args.Length - 1);


				var ResultRPCS = await Cli.Wrap(newExe)
					.WithArguments(newArgs)
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();


				File.Delete(newExe);


			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}




	}
}
