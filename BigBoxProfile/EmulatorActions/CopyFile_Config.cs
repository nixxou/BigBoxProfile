using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class CopyFile_Config : Form
	{
		public string sourceDir = "";
		public string targetDir = "";
		public bool useRamDisk = false;
		public string maxSize = "0";
		public string filter = "";
		public bool deleteOnExit = false;

		public CopyFile_Config(Dictionary<string, string> Options)
		{
			sourceDir = Options.ContainsKey("sourceDir") ? Options["sourceDir"] : "";
			targetDir = Options.ContainsKey("targetDir") ? Options["targetDir"] : "";
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			maxSize = Options.ContainsKey("maxSize") ? Options["maxSize"] : "0";

			if (Options.ContainsKey("useRamDisk") && Options["useRamDisk"] == "yes") useRamDisk = true;
			if (Options.ContainsKey("deleteOnExit") && Options["deleteOnExit"] == "yes") deleteOnExit = true;



			InitializeComponent();

			txt_sourceDir.Text = sourceDir;
			txt_targetDir.Text = targetDir;
			txt_filter.Text = filter;
			num_maxSize.Text = maxSize;
			chk_deleteOnExit.Checked = deleteOnExit;
			chk_useRamDisk.Checked = useRamDisk;
		}



		private void CopyFile_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			sourceDir = txt_sourceDir.Text;
			targetDir = txt_targetDir.Text;
			filter= txt_filter.Text;
			maxSize = num_maxSize.Value.ToString();

			useRamDisk = false;
			if (chk_useRamDisk.Checked) useRamDisk = true;

			deleteOnExit = false;
			if (chk_deleteOnExit.Checked) deleteOnExit = true;

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
	}
}
