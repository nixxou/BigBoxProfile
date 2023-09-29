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



		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(txt_variableName.Text) || String.IsNullOrEmpty(txt_regex.Text) || String.IsNullOrEmpty(txt_value.Text))
			{
				MessageBox.Show("You must fill the form");
				return;
			}
			if (radio_file.Checked && txt_file.Text == "")
			{
				MessageBox.Show("You must select a file");
				return;
			}
			if (!IsValidRegex(txt_regex.Text))
			{
				MessageBox.Show("Invalid Regex");
				return;
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
			if (radio_file.Checked)
			{
				vdData.SourceData = txt_file.Text;
			}
			vdData.RegexToMatch = txt_regex.Text;
			vdData.VariableValue = txt_value.Text;


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
	}
}
