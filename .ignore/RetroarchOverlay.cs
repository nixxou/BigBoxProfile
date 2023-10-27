using System.Collections.Generic;
using System.Windows.Forms;
using CliWrap;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text;
using WindowsInput.Native;
using WindowsInput;
using CefSharp.DevTools.DOM;
using System.IO;
using System.Linq;

namespace BigBoxProfile.EmulatorActions
{
	internal class RetroarchOverlay : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public RetroarchOverlay()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "RetroarchOverlay";

		private string _bezelDir = "";
		private string _windowName = "";
		private bool _autoName = false;


		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);



		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);


		[DllImport("user32.dll")]
		public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

		[StructLayout(LayoutKind.Sequential)]
		public struct WINDOWPLACEMENT
		{
			public int length;
			public int flags;
			public int showCmd;
			public POINT minPosition;
			public POINT maxPosition;
			public RECT normalPosition;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct POINT
		{
			public int x;
			public int y;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct RECT
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}

		// Importer les fonctions Windows nécessaires
		[DllImport("user32.dll")]
		private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll")]
		private static extern bool SetCursorPos(int x, int y);

		[DllImport("user32.dll")]
		private static extern bool ClientToScreen(IntPtr hWnd, ref POINT lpPoint);

		[DllImport("user32.dll")]
		private static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

		// Définir des constantes pour les clics de souris
		private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
		private const uint MOUSEEVENTF_LEFTUP = 0x0004;

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new RetroarchOverlay();
		}

		public void Configure()
		{
			var frm = new RetroarchOverlay_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["bezelDir"] = frm.bezelDir;
				Options["windowName"] = frm.windowName;
				if (frm.autoName) Options["autoName"] = "yes";
				else Options["autoName"] = "no";


				Options["filter"] = frm.filter.Trim();
				Options["exclude"] = frm.exclude.Trim();
				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";
				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";
				

				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			
			if (Options.ContainsKey("bezelDir") == false) Options["bezelDir"] = "";
			if (Options.ContainsKey("windowName") == false) Options["windowName"] = "";
			if (Options.ContainsKey("autoName") == false) Options["autoName"] = "no";

			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			

			UpdateConfig();

		}

		public bool IsConfigured()
		{
			
			if (Options.ContainsKey("bezelDir") == false || Options["bezelDir"] == "")
			{
				return false;
			}
			
			return true;
		}

		public override string ToString()
		{
			string description = "";

			/*
			if (IsConfigured())
			{
				if (_asArg) description = "Prefix this to the Arg List : ";
				else description = "Prefix this to the command line : ";
				description += Options["prefix"].ToString();
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_exclude != "") description += $" [Exclude {_exclude}]";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}
			*/
			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		public string[] ModifyExemple(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}
		public string[] Modify(string[] args)
		{

			
			if (IsConfigured() == false)
			{
				return args;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (!filter_found) return args;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return args;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (filter_found) return args;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return args;
					}
				}
			}


			//string exeArg = args[0];
			//var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			//var filteredCmd = BigBoxUtils.ArgsToCommandLine(filteredArgs);

			return args;
			
		}



		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		private void UpdateConfig()
		{
			
			_bezelDir = Options["bezelDir"];
			_windowName = Options["windowName"];
			_autoName = Options["autoName"] == "yes" ? true : false;

			_filter = Options["filter"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			
		}

		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured() == false)
			{
				return;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (!filter_found) return;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (filter_found) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
			}
			/*
			var RetroArchExe = @"I:\LaunchBox\Emulators\RetroArch\retroarch2.exe";
			var RetroarchArg = new List<string>();
			RetroarchArg.Add("-L");
			RetroarchArg.Add(@"I:\LaunchBox\Emulators\RetroArch\cores\wgc_libretro.dll");
			RetroarchArg.Add("-f");
			RetroarchArg.Add(@"C:\Users\Mehdi\Downloads\LibRetro-WindowCast\partials-example.txt");

			var RetroArchOverlay = Cli.Wrap(RetroArchExe)
			.WithArguments(RetroarchArg)
			.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
			.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
			.WithValidation(CommandResultValidation.None)
			.ExecuteAsync();
			*/

			Thread executionThread = new Thread(() =>
			{
				ExecuteRetroarch(_bezelDir, args);
			});
			executionThread.Start();
		}

		public static void ExecuteRetroarch(string bezelDir, string[] args)
		{
			var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
			//Thread.Sleep(3000);
			var emuExe = Path.GetFileName(args[0]);
			var processName = Path.GetFileNameWithoutExtension(args[0]);
			Process emuProcess = null;
			for (int i = 0; i < 100; i++)
			{
				Process[] processes = Process.GetProcessesByName(processName);
				if (processes.Length > 0)
				{
					emuProcess = processes[0];
					if (emuProcess.MainWindowHandle != IntPtr.Zero)
					{
						/*
						string ahk_code2 = $@"
ToggleFakeFullscreen()
{{
    CoordMode Screen, Window
    static WINDOW_STYLE_UNDECORATED := -0xC40000
    id := WinExist(""ahk_exe {emuExe}"")
	WinGet, ltmp, Style, A
	inf[""style""] := ltmp
	WinGetPos, ltmpX, ltmpY, ltmpWidth, ltmpHeight, ahk_id %id%
	inf[""x""] := ltmpX
	inf[""y""] := ltmpY
	inf[""width""] := ltmpWidth
	inf[""height""] := ltmpHeight
	WinSet, Style, %WINDOW_STYLE_UNDECORATED%, ahk_id %id%
	;SysGet, mon, MonitorPrimary
	;SysGet, mon, Monitor, %mon%
	;WinMove, ahk_id %id%,, %monLeft%, %monTop%, % monRight-monLeft, % monBottom-monTop
    
}}

timeout := 2 ; define the timeout in seconds
WinWait, ahk_exe {emuExe},, %timeout% ; wait for the application window within the given timeout
if !ErrorLevel ; check if the window was found
{{
    Sleep 1000
    ToggleFakeFullscreen()
}}
					";


						try
						{
							ahk.ExecRaw(ahk_code2);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message);
						}
						*/

						// La fenêtre principale est disponible
						break;
					}
				}
				Thread.Sleep(100);
				if (i == 99) return;
			}




			//Thread.Sleep(5000);
			if(emuProcess != null )
			{
				const int nChars = 256;
				string windowTitle = string.Empty;
				StringBuilder sb = new StringBuilder(nChars);
				if (GetWindowText(emuProcess.MainWindowHandle, sb, nChars) > 0)
				{
					windowTitle = sb.ToString();

					string BaseRetroarchDir = Directory.GetParent(Directory.GetParent(bezelDir).FullName).FullName;
					if(!File.Exists(Path.Combine(BaseRetroarchDir, "retroarch.exe")))
					{
						BaseRetroarchDir = Directory.GetParent(BaseRetroarchDir).FullName;
					}

					string RetroArchExe = Path.Combine(BaseRetroarchDir, "retroarch2.exe");

					var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
					string filearg = "";
					foreach(var arg in filteredArgs)
					{
						if(File.Exists(arg))
						{
							filearg = arg;
							break;
						}
					}
					string CfgFile = Path.GetFileNameWithoutExtension(filearg) + ".cfg";
					
					string CfgSource = Path.Combine(bezelDir,CfgFile);
					
					if (File.Exists(CfgSource))
					{
						string CfgDest = Path.Combine(BaseRetroarchDir, "config", "WindowCast", "partials-example.cfg");
						File.Copy(CfgSource, CfgDest, true);
					}

					var RetroarchArg = new List<string>();
					RetroarchArg.Add("-L");
					RetroarchArg.Add(Path.Combine(BaseRetroarchDir, "cores","wgc_libretro.dll"));
					RetroarchArg.Add("-f");
					RetroarchArg.Add(@"C:\Users\Mehdi\Downloads\LibRetro-WindowCast\partials-example.txt");

					var RetroArchOverlay = Cli.Wrap(RetroArchExe)
					.WithArguments(RetroarchArg)
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();

					var processNameRetro = "retroarch2";
					Process emuProcessRetro = null;
					for (int i = 0; i < 100; i++)
					{
						Process[] processes = Process.GetProcessesByName(processNameRetro);
						if (processes.Length > 0)
						{
							emuProcessRetro = processes[0];
							if (emuProcessRetro.MainWindowHandle != IntPtr.Zero)
							{
								// La fenêtre principale est disponible
								break;
							}
						}
						Thread.Sleep(100);
						if (i == 99) return;
					}

					/*
					string ahk_code2 = $@"
ToggleFakeFullscreen2()
{{
    CoordMode Screen, Window
    id := WinExist(""ahk_exe {emuExe}"")
	SysGet, mon, MonitorPrimary
	SysGet, mon, Monitor, %mon%
	WinMove, ahk_id %id%,, %monLeft%, %monTop%, % monRight-monLeft, % monBottom-monTop
    
}}

timeout := 2 ; define the timeout in seconds
WinWait, ahk_exe {emuExe},, %timeout% ; wait for the application window within the given timeout
if !ErrorLevel ; check if the window was found
{{
    Sleep 5000
    ToggleFakeFullscreen2()
}}
					";


					try
					{
						ahk.ExecRaw(ahk_code2);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}

					Thread.Sleep(50);
					SetForegroundWindow(emuProcess.MainWindowHandle);
					Thread.Sleep(50);
					SetForegroundWindow(emuProcessRetro.MainWindowHandle);
					Thread.Sleep(50);
					SetForegroundWindow(emuProcess.MainWindowHandle);
					Thread.Sleep(50);
					SetForegroundWindow(emuProcessRetro.MainWindowHandle);
					Thread.Sleep(50);
					PerformMouseClick(emuProcessRetro.MainWindowHandle);
					*/

					//SetForegroundWindow(emuProcess.MainWindowHandle);
					//Thread.Sleep(1000);
					//SetForegroundWindow(emuProcessRetro.MainWindowHandle);

				}


			}


		}

		public static void PerformMouseClick(IntPtr windowHandle)
		{
			// Obtenir les dimensions de la fenêtre
			RECT windowRect;
			GetWindowRect(windowHandle, out windowRect);

			// Calculer les coordonnées du point au milieu de la fenêtre
			int centerX = (windowRect.left + windowRect.right) / 2;
			int centerY = (windowRect.top + windowRect.bottom) / 2;

			// Convertir les coordonnées client en coordonnées écran
			POINT screenPoint;
			screenPoint.x = centerX;
			screenPoint.y = centerY;
			ClientToScreen(windowHandle, ref screenPoint);

			// Déplacer le curseur à la position du clic
			SetCursorPos(screenPoint.x, screenPoint.y);

			// Effectuer le clic de souris
			mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
		}

		public static bool isFullScreen(IntPtr windowHandle)
		{
			WINDOWPLACEMENT placement = new WINDOWPLACEMENT();
			placement.length = Marshal.SizeOf(placement);

			if (GetWindowPlacement(windowHandle, ref placement))
			{
				bool isFullscreen = (placement.showCmd == 3); // 3 represents SW_MAXIMIZE
				return isFullscreen;
			}
			else
			{
				return false;
			}
		}

		public void ExecuteAfter(string[] args)
		{
			/*
			var ResultKillRetroarch = await Cli.Wrap("TASKKILL")
			.WithArguments("\F)
			.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
			.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
			.WithValidation(CommandResultValidation.None)
			.ExecuteAsync();
			*/
		}

		public bool UseM3UContent()
		{
			return false;
		}
	}
}
