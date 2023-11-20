using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class CopyFile_Config : KryptonForm
	{
		public string sourceDir = "";
		public string targetDir = "";
		public bool useRamDisk = false;
		public string maxSize = "0";
		public bool deleteOnExit = false;

		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public bool matchAllFilter = false;
		public bool matchAllExclude = false;

		public CopyFile_Config(Dictionary<string, string> Options)
		{
			sourceDir = Options.ContainsKey("sourceDir") ? Options["sourceDir"] : "";
			targetDir = Options.ContainsKey("targetDir") ? Options["targetDir"] : "";
			maxSize = Options.ContainsKey("maxSize") ? Options["maxSize"] : "0";

			if (Options.ContainsKey("useRamDisk") && Options["useRamDisk"] == "yes") useRamDisk = true;
			if (Options.ContainsKey("deleteOnExit") && Options["deleteOnExit"] == "yes") deleteOnExit = true;


			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";
			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;
			if (Options.ContainsKey("matchAllFilter") && Options["matchAllFilter"] == "yes") matchAllFilter = true;
			if (Options.ContainsKey("matchAllExclude") && Options["matchAllExclude"] == "yes") matchAllExclude = true;

			InitializeComponent();
			UpdateInstalled();

			txt_sourceDir.Text = sourceDir;
			txt_targetDir.Text = targetDir;
			num_maxSize.Text = maxSize;
			chk_deleteOnExit.Checked = deleteOnExit;
			chk_useRamDisk.Checked = useRamDisk;

			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;

			chk_filter_matchall.Checked = matchAllFilter;
			if (!commaFilter) chk_filter_matchall.Enabled = false;

			chk_exclude_matchall.Checked = matchAllExclude;
			if (!commaExclude) chk_exclude_matchall.Enabled = false;
		}



		private void CopyFile_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			sourceDir = txt_sourceDir.Text;
			targetDir = txt_targetDir.Text;
			maxSize = num_maxSize.Value.ToString();

			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;

			useRamDisk = false;
			if (chk_useRamDisk.Checked) useRamDisk = true;

			deleteOnExit = false;
			if (chk_deleteOnExit.Checked) deleteOnExit = true;

			removeFilter = chk_filter_remove.Checked;

			matchAllFilter = chk_filter_matchall.Checked;
			matchAllExclude = chk_exclude_matchall.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_source_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txt_sourceDir.Text = fbd.SelectedPath;
				}
			}
		}

		private void btn_target_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txt_targetDir.Text = fbd.SelectedPath;
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			UpdateInstalled();
		}

		private void UpdateInstalled()
		{
			if (RamDiskLauncher.isDriverInstalled())
			{
				label_Imdisk_false.Visible = false;
				label_Imdisk_true.Visible = true;
				chk_useRamDisk.Enabled = true;
				num_maxSize.Enabled = true;
			}
			else
			{
				label_Imdisk_false.Visible = true;
				label_Imdisk_true.Visible = false;
				chk_useRamDisk.Enabled = false;
				num_maxSize.Enabled = false;
			}
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			var linkLabel = (LinkLabel)sender;
			System.Diagnostics.Process.Start(linkLabel.Text);
		}

		private void chk_useRamDisk_CheckedChanged(object sender, EventArgs e)
		{
			if (chk_useRamDisk.Checked)
			{
				chk_deleteOnExit.Checked = true;
				chk_deleteOnExit.Enabled = false;

			}
			else
			{
				chk_deleteOnExit.Enabled = true;
			}
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

		private void chk_filter_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaFilter = chk_filter_comma.Checked;
			btn_manage_filter.Enabled = commaFilter;
			chk_filter_matchall.Enabled = chk_filter_comma.Checked;
			if (!chk_filter_comma.Checked) chk_filter_matchall.Checked = false;

		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaExclude = chk_exclude_comma.Checked;
			btn_manage_exclude.Enabled = commaExclude;
			chk_exclude_matchall.Enabled = chk_exclude_comma.Checked;
			if (!chk_exclude_comma.Checked) chk_exclude_matchall.Checked = false;
		}

		private void kryptonLinkLabel1_LinkClicked(object sender, EventArgs e)
		{
			var linkLabel = (KryptonLinkLabel)sender;
			System.Diagnostics.Process.Start(linkLabel.Text);
		}

		private void chk_exclude_matchall_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
