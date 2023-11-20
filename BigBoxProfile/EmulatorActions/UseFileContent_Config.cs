using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace BigBoxProfile.EmulatorActions
{
	public partial class UseFileContent_Config : KryptonForm
	{
		public string filter = "";
		public bool usefile = false;
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public bool matchAllFilter = false;
		public bool matchAllExclude = false;

		public UseFileContent_Config(Dictionary<string, string> Options)
		{
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			if (Options.ContainsKey("usefile"))
			{
				if (Options["usefile"] == "yes") usefile = true;
				else usefile = false;
			}
			else usefile = true;

			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;
			if (Options.ContainsKey("matchAllFilter") && Options["matchAllFilter"] == "yes") matchAllFilter = true;
			if (Options.ContainsKey("matchAllExclude") && Options["matchAllExclude"] == "yes") matchAllExclude = true;

			InitializeComponent();


			if (usefile) radio_usefile.Checked = true;
			else radio_usedir.Checked = true;

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

		private void UseFileContent_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			usefile = false;
			if (radio_usefile.Checked) usefile = true;

			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
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
