using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{


	public partial class ExecuteAHK_Config : KryptonForm
	{
		public string filter = "";
		public string ahkCodeExemple = "";
		public string ahkCodeReal = "";
		public string ahkCodeBefore = "";
		public string ahkCodeAfter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;

		public ExecuteAHK_Config(Dictionary<string, string> Options)
		{
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			ahkCodeExemple = Options.ContainsKey("ahkCodeExemple") ? Options["ahkCodeExemple"] : "";
			ahkCodeReal = Options.ContainsKey("ahkCodeReal") ? Options["ahkCodeReal"] : "";
			ahkCodeBefore = Options.ContainsKey("ahkCodeBefore") ? Options["ahkCodeBefore"] : "";
			ahkCodeAfter = Options.ContainsKey("ahkCodeAfter") ? Options["ahkCodeAfter"] : "";

			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";
			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;

			InitializeComponent();

			txt_filter.Text = filter;
			txt_CodeExemple.Text = ahkCodeExemple;
			txt_CodeReal.Text = ahkCodeReal;
			txt_CodeBefore.Text = ahkCodeBefore;
			txt_CodeAfter.Text = ahkCodeAfter;

			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;

		}

		private void ExecuteAHK_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			ahkCodeExemple = txt_CodeExemple.Text;
			ahkCodeReal = txt_CodeReal.Text;
			ahkCodeBefore = txt_CodeBefore.Text;
			ahkCodeAfter = txt_CodeAfter.Text;
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
		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaExclude = chk_exclude_comma.Checked;
			btn_manage_exclude.Enabled = commaExclude;
		}
	}
}
