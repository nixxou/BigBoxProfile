using BrightIdeasSoftware;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace BigBoxProfile
{
	public partial class Manage_Variables_PopupEdit : Form
	{
		public VariableData vdData = null;
		public Manage_Variables_PopupEdit(VariableData vdItem)
		{
			InitializeComponent();

			txt_variableName.Text = vdItem.VariableName;
			if(vdItem.SourceData == "arg")
			{
				radio_arg.Checked = true;
				radio_cmd.Checked = radio_file.Checked = false;
			}
			else
			{
				if(vdItem.SourceData == "cmd")
				{
					radio_cmd.Checked = true;
					radio_arg.Checked = radio_file.Checked = false;
				}
				else
				{
					radio_file.Checked = true;
					radio_arg.Checked = radio_cmd.Checked = false;
					txt_file.Text = vdItem.SourceData;
				}
			}

			txt_regex.Text = vdItem.RegexToMatch;
			txt_value.Text = vdItem.VariableValue;
			txt_ahk.Text = vdItem.ahkCode;
			UpdateGui();

		}

		public void UpdateGui()
		{

			if (radio_arg.Checked || radio_cmd.Checked)
			{
				txt_regex.Visible = true;
				txt_value.Visible = true;
				txt_fallback.Visible = true;
				txt_file.Visible = false;
				labelAHK.Visible = false;
				txt_ahk.Visible = false;
			}
			if (radio_file.Checked)
			{
				txt_regex.Visible = true;
				txt_value.Visible = true;
				txt_fallback.Visible = true;
				txt_file.Visible = true;
				labelAHK.Visible = false;
				txt_ahk.Visible = false;
			}
			if (radio_ahk.Checked)
			{
				txt_regex.Visible = false;
				txt_value.Visible = false;
				txt_fallback.Visible = false;
				txt_file.Visible = false;
				labelAHK.Visible = true;
				txt_ahk.Visible = true;
			}

		}


		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (radio_ahk.Enabled)
			{
				if (String.IsNullOrEmpty(txt_variableName.Text))
				{
					MessageBox.Show("You must fill the form");
					return;
				}
				string errorTxt = "";
				if (!BigBoxUtils.AHKSyntaxCheck(txt_ahk.Text, true, out errorTxt))
				{
					DialogResult dialogResult = MessageBox.Show($"AHK Syntax error : {errorTxt} \n Are you sure you want to save ?", "AHK Syntax error", MessageBoxButtons.YesNo);
					if (dialogResult == DialogResult.No)
					{
						return;
					}
				}
			}
			else
			{
				if (String.IsNullOrEmpty(txt_variableName.Text) || String.IsNullOrEmpty(txt_value.Text))
				{
					MessageBox.Show("You must fill the form");
					return;
				}
				if (radio_file.Checked && txt_file.Text == "")
				{
					MessageBox.Show("You must select a file");
					return;
				}
				if (!IsValidRegex(txt_regex.Text) || txt_regex.Text == "")
				{
					MessageBox.Show("Invalid Regex");
					return;
				}
			}


			vdData = new VariableData();
			vdData.VariableName = txt_variableName.Text;
			if (radio_arg.Checked)
			{
				vdData.SourceData = "arg";
			}
			if (radio_cmd.Checked)
			{
				vdData.SourceData = "cmd";
			}
			if (radio_ahk.Checked)
			{
				vdData.SourceData = "ahk";
			}
			if (radio_file.Checked)
			{
				vdData.SourceData = txt_file.Text;
			}
			vdData.RegexToMatch = txt_regex.Text;
			vdData.VariableValue = txt_value.Text;
			vdData.FallbackValue = txt_fallback.Text;
			vdData.ahkCode = txt_ahk.Text;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private static bool IsValidRegex(string pattern)
		{
			if (string.IsNullOrWhiteSpace(pattern)) return false;

			try
			{
				Regex.Match("", pattern);
			}
			catch (ArgumentException)
			{
				return false;
			}

			return true;
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

		private void radio_file_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGui();
		}

		private void radio_cmd_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGui();
		}

		private void radio_arg_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGui();
		}

		private void radio_ahk_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGui();
		}
	}
}
