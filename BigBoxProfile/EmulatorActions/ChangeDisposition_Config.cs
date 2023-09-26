using ComponentFactory.Krypton.Toolkit;
using Microsoft.VisualBasic;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;


namespace BigBoxProfile.EmulatorActions
{
	public partial class ChangeDisposition_Config : KryptonForm
	{

		public string result = "";
		public string filter = "";
		public string filterInsideFile = "";

		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;

		public ChangeDisposition_Config(Dictionary<string, string> Options)
		{
			result = Options.ContainsKey("disposition") ? Options["disposition"] : "";
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;

			

			filterInsideFile = Options.ContainsKey("filterInsideFile") ? Options["filterInsideFile"] : "";

			InitializeComponent();
			ReloadCmb();
			txt_filter.Text = filter;
			txt_filter_inside_file.Text = filterInsideFile;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;
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
			if (cmb_DispositionList.SelectedIndex == -1)
			{
				MessageBox.Show("You should select a monitor disposition in the combo box");
				return;
			}
			result = cmb_DispositionList.SelectedItem.ToString();
			filter = txt_filter.Text;
			filterInsideFile = txt_filter_inside_file.Text;

			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;

			removeFilter = chk_filter_remove.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void chk_filter_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaFilter = chk_filter_comma.Checked;
			btn_manage_filter.Enabled = commaFilter;
		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaExclude = chk_exclude_comma.Checked;
			btn_manage_exclude.Enabled = commaExclude;
		}

		private void button1_Click_1(object sender, EventArgs e)
		{

		}

		private void btn_manage_filter_Click(object sender, EventArgs e)
		{
			var frm = new Manage_Items(txt_filter.Text);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				txt_filter.Text = frm.TxtValue;
			}
		}

		private void btn_manage_exclude_Click(object sender, EventArgs e)
		{
			var frm = new Manage_Items(txt_exclude.Text);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				txt_exclude.Text = frm.TxtValue;
			}
		}
	}
}
