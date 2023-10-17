using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Handler;
using CefSharp.SchemeHandler;
using CefSharp.Web;
using CefSharp.WinForms;
using Microsoft.Win32;
using MonitorSwitcherGUI;
using Newtonsoft.Json;
using SharpDX;


namespace BigBoxProfile.EmulatorActions
{

	public partial class PauseMenu_Show : Form
	{

		public CustomBrowser chromiumWebBrowser1;

		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

		[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
		private const int WS_SHOWNORMAL = 1;



		private PauseMenu _config = null;
		private string[] _args = null;

		private System.Timers.Timer timerEnd = null;
		private Screen _selectedScreen = null;
		private int _selectedScreenIndex = -1;
		private int _selectedScreenDPI = -1;

		public PauseMenu_Show(PauseMenu pauseMenu, string[] args)
		{
			_args = args;
			_config = pauseMenu;

			

			_selectedScreen = null;
			Screen MainScreen = null;
			int MainScreenIndex = -1;
			int MainScreenDpi = -1;
			Screen[] screens = Screen.AllScreens;
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');
				if(_config._selectedMonitor == DeviceName)
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
			if (_config._dpi == 0)
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)_selectedScreenDPI / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)_selectedScreenDPI / 100.0));
			}
			else
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)_config._dpi / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)_config._dpi / 100.0));
			}
			Debug.WriteLine(SizeWidth.ToString() + " - " + SizeHeight.ToString());

			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			this.Location = new Point(_selectedScreen.Bounds.Left, _selectedScreen.Bounds.Top);


			
			this.Width = SizeWidth;
			this.Height = SizeHeight;
			//this.BackColor = Color.LimeGreen;
			//this.TransparencyKey = Color.LimeGreen;

			//this.WindowState = FormWindowState.Maximized;


			fakebrowser_txt.Width = this.Width;
			fakebrowser_txt.Height = this.Height;
			fakebrowser_txt.Location = new Point(0, 0);

			

			// Gestion de l'échelle DPI
			//this.AutoScaleMode = AutoScaleMode.Dpi;
			//this.AutoScroll = true;
			//this.AutoScaleDimensions = new SizeF(96F, 96F); // Réglez cette valeur sur la résolution DPI de référence (96 DPI par défaut)


			this.chromiumWebBrowser1 = new CustomBrowser();
			this.chromiumWebBrowser1.ParentForm = this;
			this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
			
			BigBoxUtils.CefInit();
			

			if(_config._showDevTools) this.chromiumWebBrowser1.IsBrowserInitializedChanged += (a,b) => { chromiumWebBrowser1.ShowDevTools(); };

			Dictionary<string, VariableData> variablesDictionary = new Dictionary<string, VariableData>();
			if (!String.IsNullOrEmpty(_config._variablesData))
			{
				var priority_arr = BigBoxUtils.explode(_config._variablesData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new VariableData(p);
					if (!variablesDictionary.ContainsKey(pObj.VariableName))
					{
						variablesDictionary.Add(pObj.VariableName, pObj);
					}
				}
			}

			string htmlContent = File.ReadAllText(_config._htmlFile);

			if (_config._includeSpecialVariable)
			{
				htmlContent = htmlContent.Replace("{{GAMEDATA}}", _config.specialVariableGameData);
				htmlContent = htmlContent.Replace("{{ARGSDATA}}", _config.specialVaribaleArgsData);
			}

			if (variablesDictionary.Count > 0)
			{
				int currentLoopVariable = 0;
				int maxLoopVariable = 10;
				bool foundVariable = true;
				while (foundVariable)
				{
					foundVariable = false;
					currentLoopVariable++;
					foreach (var v in variablesDictionary)
					{
						if (htmlContent.ToLower().Contains(v.Key.ToLower()))
						{
							foundVariable = true;
							htmlContent = v.Value.ReplaceVariable(htmlContent, _args);
						}
					}
					if (currentLoopVariable > maxLoopVariable) break;
				}
			}

			
			this.chromiumWebBrowser1.Location = fakebrowser_txt.Location;
			this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
			//this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;
			this.chromiumWebBrowser1.Height = this.Height;
			this.chromiumWebBrowser1.Width = this.Width;
			this.chromiumWebBrowser1.TabIndex = fakebrowser_txt.TabIndex;

			this.chromiumWebBrowser1.LoadHtml(htmlContent, "localfolder://cefsharp/index.html");

			//this.chromiumWebBrowser1.LoadHtml("Hello world", "localfolder://cefsharp/index.html");

			this.Controls.Remove(this.fakebrowser_txt);
			this.Controls.Add(this.chromiumWebBrowser1);
			this.chromiumWebBrowser1.Refresh();
			chromiumWebBrowser1.LifeSpanHandler = new CefAHKIntercept();

			this.Refresh();

			this.BringToFront();
			this.TopMost = true;
			this.Activate();
			chromiumWebBrowser1.Focus();
			

			/*
			var timerWeb = new System.Timers.Timer(1000);
			timerWeb.Enabled = true;
			timerWeb.Elapsed += (sender, e) =>
			{
				timerWeb.Stop();
				this.Invoke(new Action(() =>
				{
					

				}));
			};
			*/

			timer1.Enabled = true;
			if (_config._forcefullActivation)
			{
				this.LostFocus += timer1_Tick;
			}
			SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

			if (_config._delayAutoClose > 0)
			{
				timerEnd = new System.Timers.Timer(_config._delayAutoClose);
				timerEnd.Enabled = true;
				timerEnd.Elapsed += (sender, e) =>
				{
					timerEnd.Stop();
					this.Invoke(new Action(() =>
					{
						this.Close();
					}));
				};
			}
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
				chromiumWebBrowser1.Focus();
				timer1.Interval = 1000;
				if (!_config._forcefullActivation) timer1.Enabled = false;
			}
		}

		private void PauseMenu_Show_Load(object sender, EventArgs e)
		{
			_config.tempDisableHotkey = false;




		}
		/*protected override void OnPaintBackground(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.LimeGreen, e.ClipRectangle);
		}*/

		private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
		{
			_selectedScreen = null;
			Screen MainScreen = null;
			int MainScreenIndex = -1;
			int MainScreenDpi = -1;
			Screen[] screens = Screen.AllScreens;
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');
				if (_config._selectedMonitor == DeviceName)
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
			if (_config._dpi == 0)
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)_selectedScreenDPI / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)_selectedScreenDPI / 100.0));
			}
			else
			{
				SizeWidth = (int)Math.Floor((double)SizeWidth * ((double)_config._dpi / 100.0));
				SizeHeight = (int)Math.Floor((double)SizeHeight * ((double)_config._dpi / 100.0));
			}
			this.Location = new Point(_selectedScreen.Bounds.Left, _selectedScreen.Bounds.Top);
			this.FormBorderStyle = FormBorderStyle.None;
			this.Width = SizeWidth;
			this.Height = SizeHeight;
			fakebrowser_txt.Width = this.Width;
			fakebrowser_txt.Height = this.Height;
			fakebrowser_txt.Location = new Point(0, 0);
			//this.WindowState = FormWindowState.Maximized;
			this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;
			this.chromiumWebBrowser1.Refresh();
		}

		private void timer1_Tick_1(object sender, EventArgs e)
		{

		}

		private void PauseMenu_Show_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				if (chromiumWebBrowser1 != null)
				{
					chromiumWebBrowser1.Dispose();
				}

			}
			catch { }

			if(timer1 != null)
			{
				timer1.Enabled = false;
				timer1.Stop();
			}
			if(timerEnd != null)
			{
				timerEnd.Enabled = false;
				timerEnd.Stop();
				
			}	
		}

		public void SetAHKCodeToExecute(string code)
		{
			_config.ahkCodeToExecute = code;
		}
	}
}
