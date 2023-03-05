﻿using AudioDeviceCmdlets;
using CoreAudioApi;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorSwitcherGUI;


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
			UpdateCmbListProfile();
			//InitializeCmbSoundCard();
			//InitializeCmbMonitorSwitch();

			UpdateProfileConfigurationTxt();

			Profile.ActiveProfileChanged += Profile_ActiveProfileChanged;
			Profile.ProfileListChanged += Profile_ProfileListChanged;
			Profile.ConfigurationChanged += Profile_ConfigurationChanged;

		}

		private void Profile_ConfigurationChanged(object sender, ConfigurationChangedEventArgs e)
		{
			Debug.WriteLine("ConfigurationChanged");
			if (e.Key == "monitor")			 txt_monitorpriority.Text = e.Value.ToString();
			if (e.Key == "monitorswitch")	 txt_monitorswitch.Text = e.Value.ToString();
			if (e.Key == "soundcard")		 txt_soundcard.Text = e.Value.ToString();
		}

		private void Profile_ProfileListChanged(object sender, EventArgs e)
		{
			Debug.WriteLine("Profile_ProfileListChanged");
			UpdateCmbListProfile();
		}

		private void Profile_ActiveProfileChanged(object sender, EventArgs e)
		{

			string selected = Profile.ActiveProfile.ProfileName;
			var index = cmb_listProfiles.Items.IndexOf(selected);
			if (index >= 0) cmb_listProfiles.SelectedIndex = index;

			Debug.WriteLine("activeProfileChanged");
			UpdateProfileConfigurationTxt();

		}

		public void UpdateProfileConfigurationTxt()
		{
			txt_monitorpriority.Text = Profile.ActiveProfile.Configuration["monitor"];
			txt_monitorswitch.Text = Profile.ActiveProfile.Configuration["monitorswitch"];
			txt_soundcard.Text = Profile.ActiveProfile.Configuration["soundcard"];
		}
		/*
		public void InitializeCmbSoundCard()
		{
			cmb_primarysoundcard.Items.Clear();
			cmb_primarysoundcard.Items.Add("<dontchange>");
			foreach(var soundcard in SoundCardUtils.GetSoundCards())
			{
				cmb_primarysoundcard.Items.Add($"{soundcard}");
			}
			string selected = Profile.ActiveProfile.Configuration["soundcard"];
			var index = cmb_primarysoundcard.Items.IndexOf(selected);
			if(index >= 0) cmb_primarysoundcard.SelectedIndex = index;
		}

		public void InitializeCmbMonitorSwitch()
		{
			cmb_monitorswitch.Items.Clear();
			cmb_monitorswitch.Items.Add("<none>");


			string selected = Profile.ActiveProfile.Configuration["monitorswitch"];
			var index = cmb_monitorswitch.Items.IndexOf(selected);
			if (index >= 0) cmb_monitorswitch.SelectedIndex = index;

		}
		*/
		public void UpdateCmbListProfile()
		{
			cmb_listProfiles.Items.Clear();
			foreach (var p in Profile.ProfileList)
			{
				cmb_listProfiles.Items.Add(p.Value.ProfileName);
			}
			string selected = Profile.ActiveProfile.ProfileName;
			var index = cmb_listProfiles.Items.IndexOf(selected);
			if (index >= 0) cmb_listProfiles.SelectedIndex = index;
		}

		public void UpdateProfileConfiguration()
		{
			var config = Profile.ActiveProfile.Configuration;
			if (config != null)
			{
				if (config["monitor"] != txt_monitorpriority.Text) txt_monitorpriority.Text = config["monitor"];
			}



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


		}

		private void cmb_listProfiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selected = cmb_listProfiles.GetItemText(cmb_listProfiles.SelectedItem);
			if(selected != Profile.ActiveProfile.ProfileName)
			{
				Profile.SetActive(selected);
			}

		}

		private void btn_editPriority_Click(object sender, EventArgs e)
		{
			var frm = new MonitorPriorityConfig();
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Profile.ActiveProfile.SetOption("monitor", frm.result);
			}

		}
		private void btn_editSoundcard_Click(object sender, EventArgs e)
		{
			var frm = new SoundCardConfig();
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Profile.ActiveProfile.SetOption("soundcard", frm.result);
			}
		}



		private void button5_Click(object sender, EventArgs e)
		{
			//SoundCardUtils.SetDefaultMic(cmb_primarysoundcard.GetItemText(cmb_primarysoundcard.SelectedItem));

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			MonitorSwitcher.SaveDisplaySettings("zog.xml");
		}

		private void button10_Click(object sender, EventArgs e)
		{

		}

		private void button4_Click_1(object sender, EventArgs e)
		{

		}


	}
}
