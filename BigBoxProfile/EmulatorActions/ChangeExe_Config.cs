﻿using System;
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
	public partial class ChangeExe_Config : Form
	{
		public string newexe = "";
		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;

		public ChangeExe_Config(Dictionary<string, string> Options)
		{
			newexe = Options.ContainsKey("newexe") ? Options["newexe"] : "";
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;


			InitializeComponent();
			txt_option.Text = newexe;
			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
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

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (txt_option.Text == "")
			{
				MessageBox.Show("You have to enter a new exe name");
				return;
			}
			newexe = txt_option.Text;
			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void ChangeExe_Config_Load(object sender, EventArgs e)
		{

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