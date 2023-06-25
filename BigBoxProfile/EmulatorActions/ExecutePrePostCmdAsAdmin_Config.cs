using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ListView = System.Windows.Forms.ListView;

namespace BigBoxProfile.EmulatorActions
{
	public partial class ExecutePrePostCmdAsAdmin_Config : KryptonForm
	{
		public string filter = "";
		public string commandList = "";
		public bool onStart = true;
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;

		public ExecutePrePostCmdAsAdmin_Config(Dictionary<string, string> Options)
		{
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			commandList = Options.ContainsKey("commandList") ? Options["commandList"] : "";
			if (Options.ContainsKey("onStart") && Options["onStart"] == "yes") onStart = true;
			else onStart = false;

			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;

			InitializeComponent();
		}

		private void radio_start_CheckedChanged(object sender, EventArgs e)
		{
			if (radio_start.Checked)
			{
				radio_exit.Checked = false;
			}
		}

		private void radio_exit_CheckedChanged(object sender, EventArgs e)
		{
			if (radio_exit.Checked)
			{
				radio_start.Checked = false;
			}
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			string cmd = txt_cmd.Text.Trim();
			if (!String.IsNullOrEmpty(cmd))
			{
				var args = BigBoxUtils.CommandLineToArgs(txt_arg.Text);
				List<string> arguments = new List<string>();
				arguments.Add(cmd);
				arguments.AddRange(args);
				string true_cmd = BigBoxUtils.ArgsToCommandLine(arguments.ToArray());
				list_cmd.Items.Add(true_cmd);
			}

			/*
			string cmd = txt_cmd.Text.Trim();
			var args = BigBoxUtils.CommandLineToArgs(cmd);


			if (IsFileAnExecutable(cmd) && args[0] != cmd)
			{
				cmd = "\"" + cmd + "\"";  // Ajouter des guillemets autour de la chaîne
				args = BigBoxUtils.CommandLineToArgs(cmd);
			}

			if (!IsFileAnExecutable(args[0].Trim('\"')))
			{
				MessageBox.Show("File " + args[0].Trim('\"') + "not found");
				return;

			}
			
			if(!String.IsNullOrEmpty(cmd) )
			{
				list_cmd.Items.Add(cmd);
				txt_cmd.Text = "";
			}
			*/

		}

		private void btn_up_Click(object sender, EventArgs e)
		{
			if (list_cmd.SelectedItems.Count > 0)
			{
				int selectedIndex = list_cmd.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = list_cmd.SelectedItems[0];
					list_cmd.Items.RemoveAt(selectedIndex);
					list_cmd.Items.Insert(selectedIndex - 1, item);
					list_cmd.Focus();
					list_cmd.Items[selectedIndex - 1].Selected = true;
				}
			}
		}

		private void btn_down_Click(object sender, EventArgs e)
		{
			if (list_cmd.SelectedItems.Count > 0)
			{
				int selectedIndex = list_cmd.SelectedIndices[0];
				if (selectedIndex < list_cmd.Items.Count - 1)
				{
					ListViewItem item = list_cmd.SelectedItems[0];
					list_cmd.Items.RemoveAt(selectedIndex);
					list_cmd.Items.Insert(selectedIndex + 1, item);
					list_cmd.Focus();
					list_cmd.Items[selectedIndex + 1].Selected = true;
				}
			}
		}

		private void btn_delete_Click(object sender, EventArgs e)
		{
			if (list_cmd.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list_cmd.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				list_cmd.Items.RemoveAt(selectedIndex);
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in list_cmd.Items)
			{
				string cmd = item.Text;
				if (!BigBoxUtils.CheckTaskExist(cmd))
				{
					MessageBox.Show("Register task for : " + cmd);
					BigBoxUtils.RegisterTask(cmd, "TaskRunNormal");
				}
			}
			var res = ConcatenateListViewItems(list_cmd);
			MessageBox.Show(res);

		}

		public static string ConcatenateListViewItems(ListView listView)
		{
			string separator = "|||";
			StringBuilder sb = new StringBuilder();

			foreach (ListViewItem item in listView.Items)
			{
				sb.Append(item.Text);
				sb.Append(separator);
			}

			// Remove the last separator from the string
			if (sb.Length > 0)
			{
				sb.Length -= separator.Length;
			}

			return sb.ToString();
		}

		private void list_cmd_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_cmd.SelectedItems.Count > 0)
			{
				btn_up.Enabled = true;
				btn_down.Enabled = true;
				btn_delete.Enabled = true;

			}
			else
			{
				btn_up.Enabled = false;
				btn_down.Enabled = false;
				btn_delete.Enabled = false;
			}
		}

		private void ExecutePrePostCmdAsAdmin_Config_Load(object sender, EventArgs e)
		{
			list_cmd.HeaderStyle = ColumnHeaderStyle.None;
			list_cmd.Columns[0].Width = list_cmd.Width;
			UpdateGUI();

		}

		private void UpdateGUI()
		{
			list_cmd.Items.Clear();
			var cmdlist = BigBoxUtils.explode(commandList, "|||");
			foreach (var cmd in cmdlist)
			{
				if (!String.IsNullOrEmpty(cmd.Trim())) list_cmd.Items.Add(cmd);
			}
			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;

			if (onStart)
			{
				radio_start.Checked = true;
				radio_exit.Checked = false;
			}
			else
			{
				radio_start.Checked = false;
				radio_exit.Checked = true;
			}

		}


		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void txt_filter_TextChanged(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in list_cmd.Items)
			{
				string cmd = item.Text;
				if (!BigBoxUtils.CheckTaskExist(BigBoxUtils.GetTaskName(cmd)))
				{
					MessageBox.Show("Register task for : " + cmd);
					BigBoxUtils.RegisterTask(cmd, "TaskRunNormal");
				}
			}
			commandList = ConcatenateListViewItems(list_cmd);
			if (radio_start.Checked) onStart = true;
			else onStart = false;
			filter = txt_filter.Text;
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

		private void btn_searchFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog1 = new OpenFileDialog
			{
				DefaultExt = "exe",
				Filter = "exe files (*.exe)|*.exe",
				FilterIndex = 2
			};

			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				txt_cmd.Text = openFileDialog1.FileName;
			}
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
