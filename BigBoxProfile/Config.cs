using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public partial class Config : Form
	{
		public Config()
		{
			InitializeComponent();
		}

		private void Config_Load(object sender, EventArgs e)
		{
			UpdateRegisterStatus();
			UpdateCmbListProfile("default");
			Profile.ActiveProfileChanged += Profile_ActiveProfileChanged;
			Profile.ProfileListChanged += Profile_ProfileListChanged;

		}

		private void Profile_ProfileListChanged(object sender, EventArgs e)
		{
			Debug.WriteLine("Profile_ProfileListChanged");
			UpdateCmbListProfile(Profile.ActiveProfile.ProfileName);
		}

		private void Profile_ActiveProfileChanged(object sender, EventArgs e)
		{
			Debug.WriteLine("activeProfileChanged");
			string selected = cmb_listProfiles.GetItemText(cmb_listProfiles.SelectedItem);

			if (selected != Profile.ActiveProfile.ProfileName) UpdateCmbListProfile(Profile.ActiveProfile.ProfileName);

		}

		public void UpdateCmbListProfile(string selected)
		{
			cmb_listProfiles.Items.Clear();
			int index = 0;
			int index_default = -1;
			foreach (var p in Profile.ProfileList)
			{
				cmb_listProfiles.Items.Add(p.Value.ProfileName);
				if (p.Value.ProfileName == selected) index_default = index;
				index++;
			}
			if(index != -1) cmb_listProfiles.SelectedIndex = index_default;
		}

		public void UpdateRegisterStatus()
		{
			if (BigBoxUtils.IsAppRegistered())
			{
				label_status.Text = "Active !";
				btn_register.Text = "Disable";
			}
			else
			{
				label_status.Text = "Inactive !";
				btn_register.Text = "Enable";
			}
		}

		private void btn_register_Click(object sender, EventArgs e)
		{
			if (BigBoxUtils.IsAppRegistered())
			{
				BigBoxUtils.UnregisterExec();
			}
			else
			{
				BigBoxUtils.RegisterExec();
			}
			MessageBox.Show("Done !");
			UpdateRegisterStatus();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string name = Interaction.InputBox("Entrez votre nom :", "Saisie de nom", "");

			if (!string.IsNullOrEmpty(name.Trim()))
			{
				string truename = Profile.AddProfile(name.Trim());
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var selectedTxt = Profile.ActiveProfile.ProfileName;
			if(selectedTxt == "default")
			{
				MessageBox.Show("Can't remove Default profile !");
				return;
			}
			Profile.RemoveProfile(selectedTxt);


		}

		private void button9_Click(object sender, EventArgs e)
		{
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

			}
			var xxx = ScreenInterrogatory.GetAllMonitorsData();


		}

		private void cmb_listProfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = cmb_listProfiles.GetItemText(cmb_listProfiles.SelectedItem);
			if(selected != Profile.ActiveProfile.ProfileName)
			{
				Profile.SetActive(selected);
			}

		}
		/*

private void cmb_listProfiles_SelectedIndexChanged(object sender, EventArgs e)
{
Debug.WriteLine(cmb_listProfiles.SelectedIndex);
}
*/
	}
}
