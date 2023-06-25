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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComponentFactory.Krypton.Toolkit;

namespace BigBoxProfile
{
	public partial class MonitorPriorityConfig : KryptonForm
	{

		[DllImport("SetDpi.dll", EntryPoint = "dpi_GetMonitorDPI", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetMonitorDPI(int index);

		[DllImport("SetDpi.dll", EntryPoint = "dpi_GetMonitorID", CallingConvention = CallingConvention.StdCall)]
		public static extern int GetMonitorID(int index);

		public string result = Profile.ActiveProfile.Configuration["monitor"];
		public MonitorPriorityConfig()
		{
			InitializeComponent();
		}


		private void HelpMonitor_Load(object sender, EventArgs e)
		{
			cmb_add.Items.Clear();
			listView_monitor.HeaderStyle = ColumnHeaderStyle.None;
			listView_monitor.Items.Clear();
			listView_monitor.Columns[0].Width = listView_monitor.Width;
			string ActualConfig = Profile.ActiveProfile.Configuration["monitor"];
			var exploded = BigBoxUtils.explode(ActualConfig,",");

			foreach (string exp in exploded)
			{
				listView_monitor.Items.Add(exp);
			}
			Update_txt_result();


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
				/*
				Debug.WriteLine($"TrueName : {ScreenInterrogatory.DeviceFriendlyName(screen)}");

				string MonitorFriendlyName = ScreenInterrogatory.DeviceFriendlyName(screen);
				
				MonitorFriendlyName = MonitorFriendlyName.Replace(" ", "_");

				if(FirstDevice=="") FirstDevice = MonitorFriendlyName;
				*/

				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');

				//string TargetID = ScreenInterrogatory.DeviceTargetID(screen).ToString();
				/*
				Debug.WriteLine($"ID V1 : {TargetID}");
				Debug.WriteLine($"DPI V2 : {GetMonitorDPI(i)}");
				Debug.WriteLine($"ID V2 : {GetMonitorID(i)}");
				*/


				//cmb_add.Items.Add(MonitorFriendlyName);
				cmb_add.Items.Add(DeviceName);
				//cmb_add.Items.Add(TargetID);

				/*
				listView1.Items.Add(new ListViewItem(new[] { screen.Primary ? "main" : "",
						DeviceName
						//,
						//MonitorFriendlyName,
						//TargetID
					}));
				*/

			}

			//textBox1.Text = FirstDevice + ",DISPLAY2,main";
			//label6.Text = "It will use " + FirstDevice + " if availiable, if not it will use DISPLAY2 and if not here. \r\n If none are availiable it will use Main Monitor";
		}

		public void Update_txt_result()
		{
			var liste = BigBoxUtils.GetListViewItems(listView_monitor);
			result = BigBoxUtils.Join(liste, ",");
			txt_result.Text = result;
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
		private void listView_monitor_SelectedIndexChanged(object sender, EventArgs e)
		{
			ListViewItem selectedItem = listView_monitor.SelectedItems.Count > 0 ? listView_monitor.SelectedItems[0] : null;
			if (selectedItem == null || selectedItem.Text == "main")
			{
				btn_up.Enabled = false;
				btn_down.Enabled = false;
				btn_delete.Enabled = false;

			}
			else
			{
				btn_up.Enabled = true;
				btn_down.Enabled = true;
				btn_delete.Enabled = true;
			}
		}

		private void btn_add_Click(object sender, EventArgs e)
		{

			int index = listView_monitor.Items.IndexOf(listView_monitor.FindItemWithText("main"));
			if (index >= 0)
			{
				ListViewItem newItem = new ListViewItem(cmb_add.Text);
				listView_monitor.Items.Insert(index, newItem);
			}
			Update_txt_result();

			//int index_of_main = listView_monitor.Items.IndexOf("main");
			//listView_monitor.Items.Add(cmb_add.Text, listView_monitor.Items.Count- 1);
		}

		private void btn_up_Click(object sender, EventArgs e)
		{
			if (listView_monitor.SelectedItems.Count > 0 && listView_monitor.SelectedItems[0].Index > 0)
			{
				int index = listView_monitor.SelectedItems[0].Index;
				ListViewItem item = listView_monitor.SelectedItems[0];

				// Cloner l'élément sélectionné pour éviter une exception d'ajout multiple
				ListViewItem clonedItem = (ListViewItem)item.Clone();

				// Insérer la copie de l'élément sélectionné avant l'élément précédent
				listView_monitor.Items.Insert(index - 1, clonedItem);

				// Supprimer l'élément sélectionné de son emplacement initial
				listView_monitor.Items.Remove(item);

				// Sélectionner l'élément déplacé
				clonedItem.Selected = true;
			}
			Update_txt_result();
		}

		private void btn_down_Click(object sender, EventArgs e)
		{
			if (listView_monitor.SelectedItems.Count == 1)
			{
				var item = listView_monitor.SelectedItems[0];

				int currentIndex = item.Index;
				int lastIndex = listView_monitor.Items.Count - 1;

				if (currentIndex < lastIndex)
				{
					// check if the item below is not the "main" item
					if (listView_monitor.Items[currentIndex + 1].Text != "main")
					{
						listView_monitor.Items.RemoveAt(currentIndex);
						listView_monitor.Items.Insert(currentIndex + 1, item);
						item.Selected = true;
						listView_monitor.Focus();
					}
				}
			}
			Update_txt_result();
		}

		private void btn_delete_Click(object sender, EventArgs e)
		{
			if (listView_monitor.SelectedItems.Count == 1)
			{
				var item = listView_monitor.SelectedItems[0];
				listView_monitor.Items.Remove(item);
			}
			Update_txt_result();
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
