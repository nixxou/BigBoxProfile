using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public partial class HelpMonitor : Form
	{
		public HelpMonitor()
		{
			InitializeComponent();
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void HelpMonitor_Load(object sender, EventArgs e)
		{
			string FirstDevice = "";
			Screen[] screens = Screen.AllScreens;
			Debug.WriteLine($"Nombre d'écrans : {screens.Length}");
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				Debug.WriteLine($"Écran {i + 1}");
				Debug.WriteLine($"Device Name : {screen.DeviceName}");
				Debug.WriteLine($"Working Area : {screen.WorkingArea}");
				Debug.WriteLine($"Bounds : {screen.Bounds}");
				Debug.WriteLine($"Primary : {screen.Primary}");
				Debug.WriteLine($"TrueName : {ScreenInterrogatory.DeviceFriendlyName(screen)}");

				string MonitorFriendlyName = ScreenInterrogatory.DeviceFriendlyName(screen);
				MonitorFriendlyName = MonitorFriendlyName.Replace(" ", "_");

				if(FirstDevice=="") FirstDevice = MonitorFriendlyName;

				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');

				string TargetID = ScreenInterrogatory.DeviceTargetID(screen).ToString();


				listView1.Items.Add(new ListViewItem(new[] { screen.Primary ? "main" : "",
						DeviceName,
						MonitorFriendlyName,
						TargetID
					}));

			}

			textBox1.Text = FirstDevice + ",DISPLAY2,DISPLAY3";
			label6.Text = "It will use " + FirstDevice + " if availiable, if not it will use DISPLAY2 and if not here, use DISPLAY3 \r\n If none are availiable it will use Main Monitor";
		}
	}
}
