using BigBoxProfile.EmulatorActions;
using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{

	
	
	public partial class Manage_Variables : KryptonForm
	{
		public string result = "";

		private VariableData _testData = new VariableData();
		public Manage_Variables(string variablesData)
		{


			InitializeComponent();

			if (!String.IsNullOrEmpty(variablesData))
			{
				var priority_arr = BigBoxUtils.explode(variablesData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new VariableData(p);
					lv_priority.Items.Add(new ListViewItem(pObj.ToStringArray()));
				}
			}
			UpdateTestLabel();

		}

		public void UpdateGui()
		{

			if (radio_arg.Checked || radio_cmd.Checked)
			{
				txt_regex.Enabled = true;
				txt_value.Enabled = true;
				txt_fallback.Enabled = true;
				txt_file.Visible = false;
				groupBox1.Visible = true;
				groupahk.Visible = false;
			}
			if(radio_file.Checked)
			{
				txt_regex.Enabled = true;
				txt_value.Enabled = true;
				txt_fallback.Enabled = true;
				txt_file.Visible = true;
				groupBox1.Visible = true;
				groupahk.Visible = false;
			}
			if (radio_ahk.Checked)
			{
				txt_regex.Enabled = false;
				txt_value.Enabled = false;
				txt_fallback.Enabled = false;
				txt_file.Visible = false;
				groupBox1.Visible = false;
				groupahk.Visible = true;
			}

		}

		private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Manage_Variables_Load(object sender, EventArgs e)
		{
			UpdateGui();
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			if (radio_ahk.Checked)
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
			}




			VariableData newItem = new VariableData();
			newItem.VariableName = txt_variableName.Text;
			if (radio_arg.Checked)
			{
				newItem.SourceData = "arg";
			}
			if (radio_cmd.Checked)
			{
				newItem.SourceData = "cmd";
			}
			if (radio_file.Checked)
			{
				newItem.SourceData = txt_file.Text;
			}
			if (radio_ahk.Checked)
			{
				newItem.SourceData = "ahk";
			}

			newItem.RegexToMatch = txt_regex.Text;
			newItem.VariableValue = txt_value.Text;
			newItem.FallbackValue = txt_fallback.Text;
			newItem.ahkCode = txt_ahk.Text;

			ListViewItem item = new ListViewItem(newItem.ToStringArray());
			lv_priority.Items.Add(item);

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

		private void btn_ok_Click(object sender, EventArgs e)
		{
			string priority = "";
			result = "";
			if(lv_priority.Items.Count> 0)
			{
				foreach (ListViewItem item in lv_priority.Items)
				{
					priority += item.SubItems[0].Text + "|||";
				}
				priority = priority.Trim('|').Trim('|').Trim('|').Trim('|').Trim('|').Trim('|');
				result = priority;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_testReplace_Click(object sender, EventArgs e)
		{

			if (rtest_simple.Checked)
			{
				try
				{
					RegexOptions options = RegexOptions.Multiline;
					options |= RegexOptions.IgnoreCase;
					options |= RegexOptions.Singleline;
					Regex regex = new Regex(txt_regex.Text, options);
					Match match = regex.Match(txt_textin.Text);
					bool foundMatch = match.Success;
					if (foundMatch)
					{
						txt_textout.Text = regex.Replace(txt_textin.Text, MatchEvaluator);
					}
					else
					{
						txt_textout.Text = txt_fallback.Text;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
			if (rtest_variable.Checked)
			{
				string[] args = BigBoxUtils.CommandLineToArgs(txt_fakecmdline.Text);
				string result  = txt_textin.Text;
				Dictionary<string, VariableData> variablesDictionary = new Dictionary<string, VariableData>();
				/*
				if (!String.IsNullOrEmpty(_variablesData))
				{
					var priority_arr = BigBoxUtils.explode(_variablesData, "|||");
					foreach (var p in priority_arr)
					{
						var pObj = new VariableData(p);
						if (!variablesDictionary.ContainsKey(pObj.VariableName))
						{
							variablesDictionary.Add(pObj.VariableName, pObj);
						}
					}
				}
				*/
				variablesDictionary.Add(_testData.VariableName, _testData);
				if (variablesDictionary.Count > 0)
				{
					int currentLoopVariable = 0;
					int maxLoopVariable = 10;
					bool foundVariable = true;
					while (foundVariable)
					{
						foundVariable = false;
						currentLoopVariable++;
						foreach (var v in variablesDictionary)
						{
							if (result.ToLower().Contains(v.Key.ToLower()))
							{
								foundVariable = true;
								result = v.Value.ReplaceVariable(result, args);
							}
						}
						if (currentLoopVariable > maxLoopVariable) break;
					}
				}
				txt_textout.Text = result;
			}
			if (rtest_full.Checked)
			{
				string[] args = BigBoxUtils.CommandLineToArgs(txt_fakecmdline.Text);
				string result = txt_textin.Text;

				Dictionary<string, VariableData> variablesDictionary = new Dictionary<string, VariableData>();
				if (lv_priority.Items.Count > 0)
				{
					foreach (ListViewItem item in lv_priority.Items)
					{
						var pObj = new VariableData(item.SubItems[0].Text);
						if (!variablesDictionary.ContainsKey(pObj.VariableName))
						{
							variablesDictionary.Add(pObj.VariableName, pObj);
						}
					}
				}

				if (variablesDictionary.Count > 0)
				{
					int currentLoopVariable = 0;
					int maxLoopVariable = 10;
					bool foundVariable = true;
					while (foundVariable)
					{
						foundVariable = false;
						currentLoopVariable++;
						foreach (var v in variablesDictionary)
						{
							if (result.ToLower().Contains(v.Key.ToLower()))
							{
								foundVariable = true;
								result = v.Value.ReplaceVariable(result, args);
							}
						}
						if (currentLoopVariable > maxLoopVariable) break;
					}
				}
				txt_textout.Text = result;
			}

		}

		private string MatchEvaluator(Match match)
		{
			GroupCollection groups = match.Groups;

			string replaceWith = txt_value.Text;
			for (int i = 1; i <= groups.Count; i++)
			{
				replaceWith = replaceWith.Replace($"\\{i}", groups[i].Value);
			}

			return replaceWith;
		}

		private void lv_priority_DoubleClick(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count == 1)
			{
				ListViewItem item = lv_priority.SelectedItems[0];
				var vdItem = new VariableData(item.SubItems[0].Text);

				var frm = new Manage_Variables_PopupEdit(vdItem);
				var result = frm.ShowDialog();

				if (result == DialogResult.OK)
				{
					if (frm.vdData != null)
					{
						int index = lv_priority.SelectedItems[0].Index;
						var newItem = new ListViewItem(frm.vdData.ToStringArray());
						lv_priority.Items.Remove(item);
						lv_priority.Items.Insert(index, newItem);
					}

				}
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

		private void btn_up_priority_Click(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count == 1 && lv_priority.SelectedItems[0].Index > 0)
			{
				int index = lv_priority.SelectedItems[0].Index;
				ListViewItem item = lv_priority.SelectedItems[0];

				// Cloner l'élément sélectionné pour éviter une exception d'ajout multiple
				ListViewItem clonedItem = (ListViewItem)item.Clone();

				// Insérer la copie de l'élément sélectionné avant l'élément précédent
				lv_priority.Items.Insert(index - 1, clonedItem);

				// Supprimer l'élément sélectionné de son emplacement initial
				lv_priority.Items.Remove(item);

				// Sélectionner l'élément déplacé
				clonedItem.Selected = true;
			}
		}

		private void btn_down_priority_Click(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count == 1 && lv_priority.SelectedItems[0].Index >= 0)
			{
				int selectedIndex = lv_priority.SelectedIndices[0];
				if (selectedIndex < lv_priority.Items.Count - 1)
				{
					ListViewItem item = lv_priority.SelectedItems[0];
					lv_priority.Items.RemoveAt(selectedIndex);
					lv_priority.Items.Insert(selectedIndex + 1, item);
					lv_priority.Focus();
					lv_priority.Items[selectedIndex + 1].Selected = true;
				}
			}

		}

		private void btn_delete_priority_Click(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count == 1 && lv_priority.SelectedItems[0].Index >= 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = lv_priority.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				lv_priority.Items.RemoveAt(selectedIndex);
			}
		}

		private void lv_priority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count > 0)
			{
				btn_up_priority.Enabled = true;
				btn_down_priority.Enabled = true;
				btn_delete_priority.Enabled = true;

			}
			else
			{
				btn_up_priority.Enabled = false;
				btn_down_priority.Enabled = false;
				btn_delete_priority.Enabled = false;
			}
		}

		private void txt_variableName_TextChanged(object sender, EventArgs e)
		{
			_testData.VariableName = txt_variableName.Text;
			UpdateTestLabel();
		}

		private void radio_arg_CheckedChanged(object sender, EventArgs e)
		{
			if(radio_arg.Checked)
			{
				_testData.SourceData = "arg";
				UpdateTestLabel();
				UpdateGui();
			}
		}

		private void radio_cmd_CheckedChanged(object sender, EventArgs e)
		{
			if(radio_cmd.Checked)
			{
				_testData.SourceData = "cmd";
				UpdateTestLabel();
				UpdateGui();
			}
		}

		private void radio_file_CheckedChanged(object sender, EventArgs e)
		{
			if (radio_file.Checked)
			{
				_testData.SourceData = txt_file.Text;
				UpdateTestLabel();
				UpdateGui();
			}
		}


		private void radio_ahk_CheckedChanged(object sender, EventArgs e)
		{
			if (radio_ahk.Checked)
			{
				_testData.SourceData = "ahk";
				UpdateTestLabel();
				UpdateGui();
			}
		}

		private void txt_file_TextChanged(object sender, EventArgs e)
		{
			if(_testData.SourceData != "arg" && _testData.SourceData != "cmd")
			{
				_testData.SourceData = txt_file.Text;
				UpdateTestLabel();
			}
		}

		private void txt_regex_TextChanged(object sender, EventArgs e)
		{
			_testData.RegexToMatch = txt_regex.Text;
			UpdateTestLabel();
		}

		private void txt_value_TextChanged(object sender, EventArgs e)
		{
			_testData.VariableValue = txt_value.Text;
			UpdateTestLabel();
		}

		private void txt_fallback_TextChanged(object sender, EventArgs e)
		{
			_testData.FallbackValue = txt_fallback.Text;
			UpdateTestLabel();
		}

		private void test_label_Click(object sender, EventArgs e)
		{

		}

		private void UpdateTestLabel()
		{
			if (rtest_simple.Checked)
			{
				txt_fakecmdline.Visible = false;
				lbl_fakecmd.Visible = false;
				test_label.Text = $"Simple Regex test" + "\r\n"
					+ "It's just to test your regex to quickly see if something is wrong" + "\r\n"
					+ "Will test your 'text in' bellow against the regex you setup on the right side "
					+ $"({ToStringShort(_testData.RegexToMatch, 20)})" + "\r\n"
					+ $"if match it will show the 'Replace With' ({ToStringShort(_testData.VariableValue, 20)}) inside the text out" + "\r\n";

			}

			if (rtest_variable.Checked)
			{
				test_label.Text = $"Variable test" + "\r\n"
					+ "It's for testing only the current variable you are setting up (the one on the right side input form)" + "\r\n"
					+ $"So in the 'text in', you put your somewhere inside your variable name ({ToStringShort(_testData.VariableName, 20)})" + "\r\n"
					+ $"And the variable should be replaced" + "\r\n" + "\r\n";
				if(radio_arg.Checked || radio_cmd.Checked)
				{
					txt_fakecmdline.Visible = true;
					lbl_fakecmd.Visible = true;
					test_label.Text += $"Since you are using {_testData.SourceData} as source, you must enter a command line that will be used as source";
				}
				else
				{
					txt_fakecmdline.Visible = false;
					lbl_fakecmd.Visible = false;
					test_label.Text += $"the content of the file {_testData.SourceData} will be used as source";
				}

			}
			if (rtest_full.Checked)
			{
				test_label.Text = $"Registered Variable test" + "\r\n"
					+ "Test text in against all variables registered" + "\r\n" + "\r\n" + "\r\n";
				if (radio_arg.Checked || radio_cmd.Checked)
				{
					txt_fakecmdline.Visible = true;
					lbl_fakecmd.Visible = true;
					test_label.Text += $"Since you are using {_testData.SourceData} as source, you must enter a command line that will be used as source";
				}
				else
				{
					txt_fakecmdline.Visible = false;
					lbl_fakecmd.Visible = false;
					test_label.Text += $"the content of the file {_testData.SourceData} will be used as source";
				}


			}
		}

		public static string ToStringShort(string input, int maxLength)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}

			if (input.Length <= maxLength)
			{
				return input;
			}
			else
			{
				return input.Substring(0, maxLength) + "...";
			}
		}

		private void rtest_simple_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTestLabel();
		}

	}
}
