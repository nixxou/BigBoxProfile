using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace BigBoxProfile.EmulatorActions
{
	public partial class ChangeRomPath_Config : KryptonForm
	{
		public string hight_priority = "";
		public string low_priority = "";
		public string filter = "";

		public ChangeRomPath_Config(Dictionary<string, string> Options)
		{
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			hight_priority = Options.ContainsKey("hight_priority") ? Options["hight_priority"] : "";
			low_priority = Options.ContainsKey("low_priority") ? Options["low_priority"] : "";

			InitializeComponent();
			txt_filter.Text = filter;

			list_hightpriority.HeaderStyle = ColumnHeaderStyle.None;
			//list_hightpriority.Items.Clear();
			list_hightpriority.Columns[0].Width = list_hightpriority.Width;

			list_lowpriority.HeaderStyle = ColumnHeaderStyle.None;
			//list_lowpriority.Items.Clear();
			list_lowpriority.Columns[0].Width = list_lowpriority.Width;

			list_hightpriority.Items.Clear();
			if (hight_priority != "")
			{
				var arr = BigBoxUtils.explode(hight_priority, "|||");
				foreach(var item in arr )
				{
					list_hightpriority.Items.Add(item);
				}
			}
			list_lowpriority.Items.Clear();
			if (low_priority != "")
			{
				var arr = BigBoxUtils.explode(low_priority, "|||");
				foreach (var item in arr)
				{
					list_lowpriority.Items.Add(item);
				}
			}



		}

		private void ChangeRomPath_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_add_hightpriority_Click(object sender, EventArgs e)
		{
			string directory = txt_hightpriority.Text;
			bool isValid = true;
			bool doublon = false;

			// Check if the directory is a duplicate
			foreach (ListViewItem item in list_hightpriority.Items)
			{
				if (item.Text == directory)
				{
					doublon = true;
					break;
				}
			}

			isValid = false;
			string directoryToCheck = directory;
			if (directory.StartsWith(@"\\"))
			{
				directoryToCheck = @"Z:\" + directory.Substring(2);
			}
			// Check if the directory is valid
			if (Path.IsPathRooted(directoryToCheck))
			{
				isValid = true;
			}

			// Add the item if everything is ok
			if (doublon)
			{
				MessageBox.Show("This item already exists in the list!");
			}
			else if (isValid)
			{
				list_hightpriority.Items.Add(directory);
			}
			else
			{
				MessageBox.Show("The specified directory is not valid!");
			}
		}

		private void btn_up_hightpriority_Click(object sender, EventArgs e)
		{
			if (list_hightpriority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_hightpriority.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = list_hightpriority.SelectedItems[0];
					list_hightpriority.Items.RemoveAt(selectedIndex);
					list_hightpriority.Items.Insert(selectedIndex - 1, item);
					list_hightpriority.Focus();
					list_hightpriority.Items[selectedIndex - 1].Selected = true;
				}
			}
		}

		private void btn_down_hightpriority_Click(object sender, EventArgs e)
		{
			if (list_hightpriority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_hightpriority.SelectedIndices[0];
				if (selectedIndex < list_hightpriority.Items.Count - 1)
				{
					ListViewItem item = list_hightpriority.SelectedItems[0];
					list_hightpriority.Items.RemoveAt(selectedIndex);
					list_hightpriority.Items.Insert(selectedIndex + 1, item);
					list_hightpriority.Focus();
					list_hightpriority.Items[selectedIndex + 1].Selected = true;
				}
			}
		}

		private void btn_delete_hightpriority_Click(object sender, EventArgs e)
		{
			if (list_hightpriority.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list_hightpriority.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				list_hightpriority.Items.RemoveAt(selectedIndex);
			}
		}

		private void list_hightpriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_hightpriority.SelectedItems.Count > 0)
			{
				btn_up_hightpriority.Enabled = true;
				btn_down_hightpriority.Enabled = true;
				btn_delete_hightpriority.Enabled = true;

			}
			else
			{
				btn_up_hightpriority.Enabled = false;
				btn_down_hightpriority.Enabled = false;
				btn_delete_hightpriority.Enabled = false;
			}
		}

		private void btn_add_lowpriority_Click(object sender, EventArgs e)
		{
			string directory = txt_lowpriority.Text;
			bool isValid = true;
			bool doublon = false;

			// Check if the directory is a duplicate
			foreach (ListViewItem item in list_lowpriority.Items)
			{
				if (item.Text == directory)
				{
					doublon = true;
					break;
				}
			}

			isValid = false;
			string directoryToCheck = directory;
			if (directory.StartsWith(@"\\"))
			{
				directoryToCheck = @"Z:\" + directory.Substring(2);
			}
			// Check if the directory is valid
			if (Path.IsPathRooted(directoryToCheck))
			{
				isValid = true;
			}

			// Add the item if everything is ok
			if (doublon)
			{
				MessageBox.Show("This item already exists in the list!");
			}
			else if (isValid)
			{
				list_lowpriority.Items.Add(directory);
			}
			else
			{
				MessageBox.Show("The specified directory is not valid!");
			}
		}

		private void list_lowpriority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_lowpriority.SelectedItems.Count > 0)
			{
				btn_up_lowpriority.Enabled = true;
				btn_down_lowpriority.Enabled = true;
				btn_delete_lowpriority.Enabled = true;

			}
			else
			{
				btn_up_lowpriority.Enabled = false;
				btn_down_lowpriority.Enabled = false;
				btn_delete_lowpriority.Enabled = false;
			}
		}

		private void btn_delete_lowpriority_Click(object sender, EventArgs e)
		{
			if (list_lowpriority.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list_lowpriority.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				list_lowpriority.Items.RemoveAt(selectedIndex);
			}
		}

		private void btn_up_lowpriority_Click(object sender, EventArgs e)
		{
			if (list_lowpriority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_lowpriority.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = list_lowpriority.SelectedItems[0];
					list_lowpriority.Items.RemoveAt(selectedIndex);
					list_lowpriority.Items.Insert(selectedIndex - 1, item);
					list_lowpriority.Focus();
					list_lowpriority.Items[selectedIndex - 1].Selected = true;
				}
			}
		}

		private void btn_down_lowpriority_Click(object sender, EventArgs e)
		{
			if (list_lowpriority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_lowpriority.SelectedIndices[0];
				if (selectedIndex < list_lowpriority.Items.Count - 1)
				{
					ListViewItem item = list_lowpriority.SelectedItems[0];
					list_lowpriority.Items.RemoveAt(selectedIndex);
					list_lowpriority.Items.Insert(selectedIndex + 1, item);
					list_lowpriority.Focus();
					list_lowpriority.Items[selectedIndex + 1].Selected = true;
				}
			}
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


		private void btn_ok_Click(object sender, EventArgs e)
		{
			string directory = txt_filter.Text;
			string directoryToCheck = txt_filter.Text;
			if (directory.StartsWith(@"\\"))
			{
				directoryToCheck = @"Z:\" + directory.Substring(2);
			}
			if (Path.IsPathRooted(directoryToCheck))
			{
				filter = txt_filter.Text;
				hight_priority = ConcatenateListViewItems(list_hightpriority);
				low_priority = ConcatenateListViewItems(list_lowpriority);

				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			else
			{
				MessageBox.Show("The specified directory is not valid !");
			}





		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void groupBox1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}
	}
}
