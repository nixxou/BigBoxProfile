using CefSharp.WinForms;
using CefSharp;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.SchemeHandler;
using System.Net.Http;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.IO;

namespace PauseMenu
{

	public partial class Form1 : Form
	{
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

		[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
		private const int WS_SHOWNORMAL = 1;

		private System.Timers.Timer timerEnd = null;

		private Screen _selectedScreen = null;
		private int _selectedScreenIndex = -1;
		private int _selectedScreenDPI = -1;

		public CustomBrowser chromiumWebBrowser1;

		public Dictionary<string, object> ConfigData = null;

		private MemoryMappedFile mmf_dataOut = null;


		public Form1(Dictionary<string, object> configData)
		{
			ConfigData = configData;

			string Config_selectedMonitor = (string)ConfigData["Monitor"];
			int Config_dpi = int.Parse((string)ConfigData["Dpi"]);
			string HtmlDir = (string)ConfigData["HtmlDir"];
			ArtCustomShemeHandler.ArtOverride = JsonConvert.DeserializeObject<Dictionary<string, string>>((string)ConfigData["ArtOverride"]);
			MyCustomSchemeHandler.AHK_argsPrefix = (string)ConfigData["AHK_argsPrefix"];
			MyCustomSchemeHandler.AHK_gamedataPrefix = (string)ConfigData["AHK_gamedataPrefix"];


			_selectedScreen = null;
			Screen MainScreen = null;
			int MainScreenIndex = -1;
			int MainScreenDpi = -1;
			Screen[] screens = Screen.AllScreens;
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');
				if (Config_selectedMonitor == DeviceName)
				{
					_selectedScreen = screen;
					_selectedScreenIndex = i;
					_selectedScreenDPI = DPIUtils.GetMonitorDPI(i);
				}
				if (screen.Primary)
				{
					MainScreenIndex = i;
					MainScreenDpi = DPIUtils.GetMonitorDPI(i);
					MainScreen = screen;
				}
			}
			if (_selectedScreen == null)
			{
				_selectedScreen = MainScreen;
				_selectedScreenIndex = MainScreenIndex;
				_selectedScreenDPI = MainScreenDpi;
			}

			int SizeWidth = _selectedScreen.Bounds.Width;
			int SizeHeight = _selectedScreen.Bounds.Height;
			if (Config_dpi == 0)
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)_selectedScreenDPI / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)_selectedScreenDPI / 100.0));
			}
			else
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)Config_dpi / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)Config_dpi / 100.0));
			}
			Debug.WriteLine(SizeWidth.ToString() + " - " + SizeHeight.ToString());

			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			this.Location = new Point(_selectedScreen.Bounds.Left, _selectedScreen.Bounds.Top);



			this.Width = SizeWidth;
			this.Height = SizeHeight;

			fakebrowser_txt.Width = this.Width;
			fakebrowser_txt.Height = this.Height;
			fakebrowser_txt.Location = new Point(0, 0);

			this.chromiumWebBrowser1 = new CustomBrowser();
			this.chromiumWebBrowser1.ParentForm = this;
			this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;

			var settings = new CefSettings();
			settings.RegisterScheme(new CefCustomScheme
			{
				SchemeName = "localfolder",
				DomainName = "cefsharp",
				SchemeHandlerFactory = new CustomFolderSchemeHandlerFactory(
					rootFolder: HtmlDir,
					hostName: "cefsharp",
					defaultPage: "index.html" // will default to index.html
				)
			});
			settings.CefCommandLineArgs.Add("disable-web-security");
			settings.CefCommandLineArgs.Add("--disable-web-security");
			settings.CefCommandLineArgs.Add("--allow-file-access-from-files");
			settings.CefCommandLineArgs.Add("allow-file-access-from-files");
			Cef.Initialize(settings);

			//this.chromiumWebBrowser1.IsBrowserInitializedChanged += (a, b) => { chromiumWebBrowser1.ShowDevTools(); };

			this.chromiumWebBrowser1.Location = fakebrowser_txt.Location;
			this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
			//this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;
			this.chromiumWebBrowser1.Height = this.Height;
			this.chromiumWebBrowser1.Width = this.Width;
			this.chromiumWebBrowser1.TabIndex = fakebrowser_txt.TabIndex;

			this.chromiumWebBrowser1.LoadHtml((string)ConfigData["HtmlContent"], "localfolder://cefsharp/index.html");

			this.Controls.Remove(this.fakebrowser_txt);
			this.Controls.Add(this.chromiumWebBrowser1);
			this.chromiumWebBrowser1.Refresh();
			chromiumWebBrowser1.LifeSpanHandler = new CefAHKIntercept();

			this.Refresh();

			this.BringToFront();
			this.TopMost = true;
			this.Activate();
			chromiumWebBrowser1.Focus();

			timer1.Enabled = true;
			//if (_config._forcefullActivation)
			//{
				this.LostFocus += timer1_Tick;
			//}
			SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

		}
		private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
		{
			string Config_selectedMonitor = (string)ConfigData["Monitor"];
			int Config_dpi = int.Parse((string)ConfigData["Dpi"]);
			

			_selectedScreen = null;
			Screen MainScreen = null;
			int MainScreenIndex = -1;
			int MainScreenDpi = -1;
			Screen[] screens = Screen.AllScreens;
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');
				if (Config_selectedMonitor == DeviceName)
				{
					_selectedScreen = screen;
					_selectedScreenIndex = i;
					_selectedScreenDPI = DPIUtils.GetMonitorDPI(i);
				}
				if (screen.Primary)
				{
					MainScreenIndex = i;
					MainScreenDpi = DPIUtils.GetMonitorDPI(i);
					MainScreen = screen;
				}
			}
			if (_selectedScreen == null)
			{
				_selectedScreen = MainScreen;
				_selectedScreenIndex = MainScreenIndex;
				_selectedScreenDPI = MainScreenDpi;
			}

			int SizeWidth = _selectedScreen.Bounds.Width;
			int SizeHeight = _selectedScreen.Bounds.Height;
			if (Config_dpi == 0)
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)_selectedScreenDPI / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)_selectedScreenDPI / 100.0));
			}
			else
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)Config_dpi / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)Config_dpi / 100.0));
			}
			Debug.WriteLine(SizeWidth.ToString() + " - " + SizeHeight.ToString());

			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			this.Location = new Point(_selectedScreen.Bounds.Left, _selectedScreen.Bounds.Top);



			this.Width = SizeWidth;
			this.Height = SizeHeight;

			fakebrowser_txt.Width = this.Width;
			fakebrowser_txt.Height = this.Height;
			fakebrowser_txt.Location = new Point(0, 0);


			this.Refresh();

			this.BringToFront();
			this.TopMost = true;
			this.Activate();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (Form.ActiveForm == null)
			{
				this.BringToFront();
				this.TopMost = true;
				this.Activate();


				//SystemParametersInfo((uint)0x2001, 0, 0, 0x0002 | 0x0001);
				//ShowWindowAsync(this.Handle, WS_SHOWNORMAL);
				//SetForegroundWindow(this.Handle);
				//SystemParametersInfo((uint)0x2001, 200000, 200000, 0x0002 | 0x0001);
				//chromiumWebBrowser1.Focus();
				timer1.Interval = 1000;
				//if (!_config._forcefullActivation) timer1.Enabled = false;
			}
		}

		public void SetAHKCodeToExecute(string code)
		{
			/*
			// Créez le MemoryMappedFile une seule fois
			if (mmf_dataOut != null) { mmf_dataOut.Dispose(); mmf_dataOut = null; }
			byte[] DataBytes = Encoding.UTF8.GetBytes(code);
			mmf_dataOut = MemoryMappedFile.CreateOrOpen($"PauseMenu_OutInstance{Program.InstanceID}", DataBytes.Length);
			using (MemoryMappedViewAccessor accessor = mmf_dataOut.CreateViewAccessor())
			{
				accessor.WriteArray(0, DataBytes, 0, DataBytes.Length);
			}
			*/
			using (NamedPipeServerStream server = new NamedPipeServerStream("monTubeNomme"))
			{
				server.WaitForConnection();
				using (StreamWriter writer = new StreamWriter(server))
				{
					writer.WriteLine(code);
					// Écrire les données réelles ici
				}
			}

			//MessageBox.Show(code);
			//_config.ahkCodeToExecute = code;
		}
	}

}
