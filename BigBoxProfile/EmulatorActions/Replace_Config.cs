using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class Replace_Config : KryptonForm
	{
		public string search = "";
		public string replacewith = "";
		public bool useregex = false;
		public bool casesensitive = false;

		public string filter = "";
		public bool asArg = false;

		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;


		public Replace_Config(Dictionary<string, string> Options)
		{
			search = Options.ContainsKey("search") ? Options["search"] : "";
			replacewith = Options.ContainsKey("replacewith") ? Options["replacewith"] : "";

			useregex = false;
			if (Options.ContainsKey("useregex"))
			{
				if (Options["useregex"] == "yes") useregex = true;

			}

			casesensitive = false;
			if (Options.ContainsKey("casesensitive"))
			{
				if (Options["casesensitive"] == "yes") casesensitive = true;

			}

			if (Options.ContainsKey("as_arg"))
			{
				if (Options["as_arg"] == "yes") asArg = true;
				else asArg = false;
			}
			else asArg = true;


			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;

			InitializeComponent();
			txt_search.Text = search;
			txt_replacewith.Text = replacewith;
			chk_casesensitive.Checked = casesensitive;
			chk_useregex.Checked = useregex;

			txt_filter.Text = filter;
			if (asArg) radio_arg.Checked = true;
			else radio_cmd.Checked = true;

			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (chk_useregex.Checked && !IsValidRegex(txt_search.Text))
			{
				MessageBox.Show("Invalid Regex !");
				return;
			}

			filter = txt_filter.Text;
			asArg = false;
			if (radio_arg.Checked) asArg = true;

			search = txt_search.Text;
			replacewith = txt_replacewith.Text;
			useregex = chk_useregex.Checked;
			casesensitive = chk_casesensitive.Checked;

			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;


			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private bool IsValidRegex(string pattern)
		{
			try
			{
				new Regex(pattern);
				return true;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


		private void Replace_Config_Load(object sender, EventArgs e)
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
