using ComponentFactory.Krypton.Toolkit;
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
	public partial class RetroarchOverlay_Config : KryptonForm
	{
		public string bezelDir = "";
		public string windowName = "";
		public bool autoName = false;

		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;


		public RetroarchOverlay_Config(Dictionary<string, string> Options)
		{
			bezelDir = Options.ContainsKey("bezelDir") ? Options["bezelDir"] : "";
			windowName = Options.ContainsKey("windowName") ? Options["windowName"] : "";

			if (Options.ContainsKey("autoName"))
			{
				if (Options["autoName"] == "yes") autoName = true;
				else autoName = false;
			}
			else autoName = false;

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";
			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;

			InitializeComponent();
			txt_bezeldir.Text = bezelDir;
			txt_windowName.Text = windowName;

			if (autoName) chk_useautoname.Checked = true;
			else chk_useautoname.Checked = true;

			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
		}

		private void btn_bezeldir_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txt_bezeldir.Text = fbd.SelectedPath;
				}
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			bezelDir = txt_bezeldir.Text;
			windowName = txt_windowName.Text;
			autoName = false;
			if(chk_useautoname.Checked) autoName = true;

			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;

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
