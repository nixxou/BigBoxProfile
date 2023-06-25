using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComponentFactory.Krypton.Toolkit;

namespace BigBoxProfile.EmulatorActions
{
	
	public partial class Prefix_Config : KryptonForm
	{
		public string result = "";
		public string filter = "";
		public bool asArg = false;
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public Prefix_Config(Dictionary<string, string> Options)
		{
			result = Options.ContainsKey("prefix") ? Options["prefix"] : "";

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
			txt_option.Text = result;
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
			
			filter = txt_filter.Text;
			asArg = false;
			if(radio_arg.Checked) asArg= true;

			result = txt_option.Text;
			if (asArg) result = result.Trim();

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

		private void Prefix_Config_Load(object sender, EventArgs e)
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