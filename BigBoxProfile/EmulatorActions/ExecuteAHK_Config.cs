using CliWrap;
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
		public bool runbeforebackground = false;
		public bool matchAllFilter = false;
		public bool matchAllExclude = false;

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

			if (Options.ContainsKey("runbeforebackground") && Options["runbeforebackground"] == "yes") runbeforebackground = true;

			if (Options.ContainsKey("matchAllFilter") && Options["matchAllFilter"] == "yes") matchAllFilter = true;
			if (Options.ContainsKey("matchAllExclude") && Options["matchAllExclude"] == "yes") matchAllExclude = true;

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
			chk_runbeforebackground.Checked = runbeforebackground;

			chk_filter_matchall.Checked = matchAllFilter;
			if (!commaFilter) chk_filter_matchall.Enabled = false;

			chk_exclude_matchall.Checked = matchAllExclude;
			if (!commaExclude) chk_exclude_matchall.Enabled = false;

		}

		private void ExecuteAHK_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			string errorTxt = "";
			if (!BigBoxUtils.AHKSyntaxCheck(txt_CodeExemple.Text, true, out errorTxt))
			{
				DialogResult dialogResult = MessageBox.Show($"Syntax error : {errorTxt} \n Are you sure you want to save ?", "<<Modify Command Line(Exemple Only)>> Syntax error", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}
			errorTxt = "";
			if (!BigBoxUtils.AHKSyntaxCheck(txt_CodeReal.Text, true, out errorTxt))
			{
				DialogResult dialogResult = MessageBox.Show($"Syntax error : {errorTxt} \n Are you sure you want to save ?", "<<Modify Command Line (Real)>> Syntax error", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}
			errorTxt = "";
			if (!BigBoxUtils.AHKSyntaxCheck(txt_CodeBefore.Text, true, out errorTxt))
			{
				DialogResult dialogResult = MessageBox.Show($"Syntax error : {errorTxt} \n Are you sure you want to save ?", "<<Execute Before>> Syntax error", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}
			errorTxt = "";
			if (!BigBoxUtils.AHKSyntaxCheck(txt_CodeAfter.Text, true, out errorTxt))
			{
				DialogResult dialogResult = MessageBox.Show($"Syntax error : {errorTxt} \n Are you sure you want to save ?", "<<Execute After>> Syntax error", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}

			filter = txt_filter.Text;
			ahkCodeExemple = txt_CodeExemple.Text;
			ahkCodeReal = txt_CodeReal.Text;
			ahkCodeBefore = txt_CodeBefore.Text;
			ahkCodeAfter = txt_CodeAfter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;
			runbeforebackground = chk_runbeforebackground.Checked;

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
	}
}
