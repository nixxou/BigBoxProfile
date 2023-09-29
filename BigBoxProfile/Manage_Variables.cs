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

		}

		private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void Manage_Variables_Load(object sender, EventArgs e)
		{

		}

		private void btn_add_Click(object sender, EventArgs e)
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

			newItem.RegexToMatch = txt_regex.Text;
			newItem.VariableValue = txt_value.Text;

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
			try
			{
				string fileContent = txt_textin.Text;
				RegexOptions options = RegexOptions.Multiline;
				options |= RegexOptions.Singleline;

				Regex regex = new Regex(txt_regex.Text, options);
				fileContent = regex.Replace(fileContent, MatchEvaluator);

				txt_textout.Text = fileContent;

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
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
	}
}
