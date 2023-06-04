using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class FakeFullScreen_Config : Form
	{

		//public string result = "";
		public string filter = "";
		public string targetType = "";
		public string target = "";
		public string regex = "";
		public string timeout = "0";
		public string wait = "0";


		public FakeFullScreen_Config(Dictionary<string, string> Options)
		{
			//result = Options.ContainsKey("disposition") ? Options["disposition"] : "";
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			targetType = Options.ContainsKey("targetType") ? Options["targetType"] : "Emulator Exe";
			target = Options.ContainsKey("target") ? Options["target"] : "";
			regex = Options.ContainsKey("regex") ? Options["regex"] : "";
			timeout = Options.ContainsKey("timeout") ? Options["timeout"] : "5";
			wait = Options.ContainsKey("wait") ? Options["wait"] : "0";


			InitializeComponent();

			txt_filter.Text = filter;
			txt_target.Text = target;
			txt_regex.Text = regex;
			num_timeout.Text = timeout;
			num_waitbefore.Text = wait;

			var index = cmb_targetType.Items.IndexOf(targetType);
			if (index >= 0) cmb_targetType.SelectedIndex = index;

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if(txt_regex.Text != "" && !IsValidRegex(txt_regex.Text))
			{
				MessageBox.Show("Invalid Regex");
				return;
			}

			//result = cmb_DispositionList.SelectedItem.ToString();
			filter = txt_filter.Text;
			targetType = cmb_targetType.SelectedItem.ToString();
			target = txt_target.Text;
			regex= txt_regex.Text;
			timeout = num_timeout.Text;
			wait = num_waitbefore.Text;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void FakeFullScreen_Config_Load(object sender, EventArgs e)
		{

		}

		private void cmb_targetType_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedType = cmb_targetType.SelectedItem.ToString();
			if(selectedType == "Emulator Exe")
			{
				txt_target.Enabled= false;
				txt_regex.Enabled= false;
			}
			if (selectedType == "Custom Exe")
			{
				txt_target.Enabled = true;
				txt_regex.Enabled = false;
			}
			if (selectedType == "Regex")
			{
				txt_target.Enabled = false;
				txt_regex.Enabled = true;
			}

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

		private void num_timeout_ValueChanged(object sender, EventArgs e)
		{

		}

		private void num_waitbefore_ValueChanged(object sender, EventArgs e)
		{

		}

		private void txt_filter_TextChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void txt_target_TextChanged(object sender, EventArgs e)
		{

		}

		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void txt_regex_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
