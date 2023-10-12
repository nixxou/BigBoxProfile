using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.Web;
using CefSharp.WinForms;
using Microsoft.Win32;
using Newtonsoft.Json;


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



		private bool ForcefullActivation = false;



		public PauseMenu_Show(bool forcefullActivation)
		{

			ForcefullActivation = forcefullActivation;




			InitializeComponent();

			this.Location = new Point(0, 0);
			this.FormBorderStyle = FormBorderStyle.None;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;

			fakebrowser_txt.Width = this.Width;
			fakebrowser_txt.Height = this.Height;
			fakebrowser_txt.Location = this.Location;

			this.chromiumWebBrowser1 = new CustomBrowser();
			this.chromiumWebBrowser1.ParentForm = this;
			this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
			BigBoxUtils.CefInit();

			//this.chromiumWebBrowser1.IsBrowserInitializedChanged += (a,b) => { chromiumWebBrowser1.ShowDevTools(); };


			string htmlContent = File.ReadAllText(Path.Combine(BigBoxUtils.DataHtmlDir, @"index.html"));
			string jsonFrom = @"<script id=""jsonGameData"" type=""text/plain"">{}</script>";
			string jsonTo = @"<script id=""jsonGameData"" type=""text/plain"">" + BigBoxUtils.GameInfoJSON + @"</script>";
			htmlContent = htmlContent.Replace(jsonFrom, jsonTo);
			/*
			try
			{
				using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting("LaunchboxJsonGameData"))
				{
					using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
					{
						long length = accessor.Capacity;
						byte[] jsonDataBytes = new byte[length];
						accessor.ReadArray(0, jsonDataBytes, 0, (int)length);
						string jsonData = Encoding.UTF8.GetString(jsonDataBytes).TrimEnd('\0');


						
						var dynamicObject = JsonConvert.DeserializeObject<dynamic>(jsonData);
						MessageBox.Show((string)dynamicObject.ClearLogoImagePath);
						File.Copy((string)dynamicObject.ClearLogoImagePath, Path.Combine(BigBoxUtils.DataHtmlDir, @"clearlogo.png"));

					}
				}
			}
			catch { }
			*/

			this.chromiumWebBrowser1.LoadHtml(htmlContent, "localfolder://cefsharp/index.html");


			//this.chromiumWebBrowser1 = new ChromiumWebBrowser("localfolder://cefsharp/");




			this.chromiumWebBrowser1.Location = fakebrowser_txt.Location;
			this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
			this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;

			this.chromiumWebBrowser1.TabIndex = fakebrowser_txt.TabIndex;
			this.Controls.Remove(this.fakebrowser_txt);
			this.Controls.Add(this.chromiumWebBrowser1);
			chromiumWebBrowser1.LifeSpanHandler = new CefAHKIntercept();


			this.BringToFront();
			this.TopMost = true;
			this.Activate();
			timer1.Enabled = true;
			if (ForcefullActivation)
			{
				this.LostFocus += timer1_Tick;
			}
			SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//timer1.Interval = 2000;
			this.BringToFront();
			this.TopMost = true;
			this.Activate();
			SystemParametersInfo((uint)0x2001, 0, 0, 0x0002 | 0x0001);
			ShowWindowAsync(this.Handle, WS_SHOWNORMAL);
			SetForegroundWindow(this.Handle);
			SystemParametersInfo((uint)0x2001, 200000, 200000, 0x0002 | 0x0001);
			if (!ForcefullActivation) timer1.Enabled = false;
		}

		private void PauseMenu_Show_Load(object sender, EventArgs e)
		{





		}

		private void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
		{
			this.Activate();
			this.Location = new Point(0, 0);
			this.FormBorderStyle = FormBorderStyle.None;
			this.Width = Screen.PrimaryScreen.Bounds.Width;
			this.Height = Screen.PrimaryScreen.Bounds.Height;
			fakebrowser_txt.Width = this.Width;
			fakebrowser_txt.Height = this.Height;
			fakebrowser_txt.Location = this.Location;
			//this.WindowState = FormWindowState.Maximized;
			this.chromiumWebBrowser1.Size = fakebrowser_txt.Size;
			this.chromiumWebBrowser1.Refresh();
		}
	}

	public class CefAHKIntercept : ILifeSpanHandler
	{
		// Load new URL (when clicking a link with target=_blank) in the same frame
		public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
		{
			if (targetUrl.StartsWith("ahk:"))
			{

				string code_base64 = targetUrl.Substring(4);
				byte[] data = Convert.FromBase64String(code_base64);
				string decodedString = System.Text.Encoding.UTF8.GetString(data);
				var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();

				var customBrowser = (CustomBrowser)chromiumWebBrowser;
				customBrowser.ParentForm.Invoke(new Action(() =>
				{
					customBrowser.ParentForm.Close();
				}));
				Thread.Sleep(200);
				ahk.ExecRaw(decodedString);

				newBrowser = null;
				return true;
			}
			else
			{
				browser.MainFrame.LoadUrl(targetUrl);
				newBrowser = null;
				return true;
			}


		}


		// If you don't implement all of the interface members in the custom class
		// you will find:
		// Error CS0535	'MyCustomLifeSpanHandler' does not implement interface member 'ILifeSpanHandler.OnAfterCreated(IWebBrowser, IBrowser)'

		public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			// throw new NotImplementedException();
			return true;
		}

		public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			// throw new NotImplementedException();
		}

		public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			// throw new NotImplementedException();
		}

	}
}
