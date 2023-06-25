using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public partial class Manage_Items : Form
	{
		public string TxtValue = "";
		public Manage_Items(string value)
		{
			InitializeComponent();
			TxtValue = value.Trim();
			StringToList(TxtValue, list_path);
		}

		private void Manage_Items_Load(object sender, EventArgs e)
		{

		}

		private string ListToString(ListView listview)
		{
			string liste_txt = "";
			foreach (ListViewItem item in listview.Items)
			{
				liste_txt += item.Text + ",";
			}

			liste_txt = liste_txt.TrimEnd(',');
			return liste_txt;
		}

		private void StringToList(string input, ListView listview)
		{
			var liste_txt = input;
			var liste_array = BigBoxUtils.explode(liste_txt, ",");
			listview.Items.Clear();


			foreach (var item in liste_array)
			{
				var path_elem = item.Trim();
				if(path_elem != "")
				{

					listview.Items.Add(path_elem);
				}
			}
		}

		private void btn_add_path_Click(object sender, EventArgs e)
		{
			list_path.Items.Add(txt_path.Text);
			TxtValue = ListToString(list_path);
		}

		private void btn_up_path_Click(object sender, EventArgs e)
		{
			if (list_path.SelectedItems.Count > 0)
			{
				int selectedIndex = list_path.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = list_path.SelectedItems[0];
					list_path.Items.RemoveAt(selectedIndex);
					list_path.Items.Insert(selectedIndex - 1, item);
					list_path.Focus();
					list_path.Items[selectedIndex - 1].Selected = true;
				}
				TxtValue = ListToString(list_path);
			}
		}

		private void btn_down_path_Click(object sender, EventArgs e)
		{
			if (list_path.SelectedItems.Count > 0)
			{
				int selectedIndex = list_path.SelectedIndices[0];
				if (selectedIndex < list_path.Items.Count - 1)
				{
					ListViewItem item = list_path.SelectedItems[0];
					list_path.Items.RemoveAt(selectedIndex);
					list_path.Items.Insert(selectedIndex + 1, item);
					list_path.Focus();
					list_path.Items[selectedIndex + 1].Selected = true;
				}
				TxtValue = ListToString(list_path);
			}
		}

		private void btn_delete_path_Click(object sender, EventArgs e)
		{
			if (list_path.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list_path.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				list_path.Items.RemoveAt(selectedIndex);
				TxtValue = ListToString(list_path);
			}
		}

		private void list_path_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_path.SelectedItems.Count > 0)
			{
				btn_up_path.Enabled = true;
				btn_down_path.Enabled = true;
				btn_delete_path.Enabled = true;

			}
			else
			{
				btn_up_path.Enabled = false;
				btn_down_path.Enabled = false;
				btn_delete_path.Enabled = false;
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			Thread.Sleep(500);
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			Thread.Sleep(500);
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
