using ComponentFactory.Krypton.Toolkit;
using HidSharp.Utility;
using SharpDX;
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
	public partial class MultiConfigReplace_Config : KryptonForm
	{
		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public bool matchAllFilter = false;
		public bool matchAllExclude = false;
		public string variablesData = "";
		public string selectedFile = "";
		public string content = "";

		public MultiConfigReplace_Config(Dictionary<string, string> Options)
		{

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;
			if (Options.ContainsKey("matchAllFilter") && Options["matchAllFilter"] == "yes") matchAllFilter = true;
			if (Options.ContainsKey("matchAllExclude") && Options["matchAllExclude"] == "yes") matchAllExclude = true;

			variablesData = Options.ContainsKey("variablesData") ? Options["variablesData"] : "";
			selectedFile = Options.ContainsKey("selectedFile") ? Options["selectedFile"] : "";
			content = Options.ContainsKey("content") ? Options["content"] : "";

			InitializeComponent();


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

			txt_file.Text = selectedFile;
			txt_content.Text = content;

			UpdateGUI();

		}

		private void UpdateGUI()
		{
			listBox1.Items.Clear();
			if (!String.IsNullOrEmpty(variablesData))
			{
				var priority_arr = BigBoxUtils.explode(variablesData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new VariableData(p);
					listBox1.Items.Add(pObj.VariableName);
				}
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;
			matchAllFilter = chk_filter_matchall.Checked;
			matchAllExclude = chk_exclude_matchall.Checked;

			selectedFile = txt_file.Text;
			content = txt_content.Text;

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

		private void MultiConfigReplace_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_manageVariables_Click(object sender, EventArgs e)
		{
			var frm = new Manage_Variables(variablesData);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				variablesData = frm.result;
				UpdateGUI();
			}
		}

		private void btn_file_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					// Obtenez le chemin complet du fichier sélectionné
					txt_file.Text = openFileDialog.FileName;

				}
			}
		}

		private void chk_filter_matchall_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_exclude_matchall_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
