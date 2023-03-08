using Microsoft.VisualBasic;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace BigBoxProfile.EmulatorActions
{
	public partial class ChangeDisposition_Config : Form
	{

		public string result = "";

		public ChangeDisposition_Config(Dictionary<string, string> Options)
		{
			result = Options.ContainsKey("disposition") ? Options["disposition"] : "";
			InitializeComponent();
			ReloadCmb();

		}


		private void ChangeDisposition_Config_Load(object sender, EventArgs e)
		{
			ReloadCmb();
		}

		private void ReloadCmb()
		{
			cmb_DispositionList.Items.Clear();
			cmb_DispositionList.Items.Add("<none>");


			foreach (var disposition in Directory.GetFiles(Profile.PathMainProfileDir, "disposition_*.xml"))
			{
				string disposition_name = Path.GetFileNameWithoutExtension(disposition);
				disposition_name = disposition_name.Remove(0, 12);

				cmb_DispositionList.Items.Add($"{disposition_name}");
			}
			var index = cmb_DispositionList.Items.IndexOf(result);
			if (index >= 0) cmb_DispositionList.SelectedIndex = index;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string name = Interaction.InputBox("Disposition Name :", "Name", "");

			string truename = BigBoxUtils.FilterFileName(name);
			string filename = Path.Combine(Profile.PathMainProfileDir, "disposition_" + truename + ".xml");
			if (System.IO.File.Exists(filename))
			{
				MessageBox.Show("Name already exist");

			}
			else
			{
				if (!string.IsNullOrEmpty(truename.Trim()))
				{
					MonitorSwitcher.SaveDisplaySettings(filename);
					ReloadCmb();
				}
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			result = cmb_DispositionList.SelectedItem.ToString();
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
