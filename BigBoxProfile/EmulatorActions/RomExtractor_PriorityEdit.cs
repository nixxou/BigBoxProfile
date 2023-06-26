using BigBoxProfile.RomExtractorUtils;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace BigBoxProfile.EmulatorActions
{
	public partial class RomExtractor_PriorityEdit : KryptonForm
	{
		public RomExtractor_PriorityData priorityData = null;

		private CancellationTokenSource tokenSource_Path;
		private CancellationTokenSource tokenSource_Priority;


		private bool RamDiskPossible = false;
		private bool isDefault = false;

		public RomExtractor_PriorityEdit(RomExtractor_PriorityData priorityData, bool RamDiskPossible)
		{
			this.RamDiskPossible = RamDiskPossible;
			if (priorityData == null)
			{
				this.priorityData = new RomExtractor_PriorityData();
			}
			else
			{
				this.priorityData = priorityData;
			}
			InitializeComponent();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			Thread.Sleep(500);
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			Thread.Sleep(500);
			List<string> PathList = new List<string>();
			foreach (ListViewItem item in list_path.Items) PathList.Add(item.Text);
			List<string> PriorityList = new List<string>();
			foreach (ListViewItem item in list_priority.Items) PriorityList.Add(item.Text);

			RomExtractor_PriorityData resultat = new RomExtractor_PriorityData();
			resultat.CacheSubDir = txt_cacheSubDir.Text.Trim();
			resultat.UseRamdisk = chk_Ramdisk.Checked;
			resultat.DeleteOnExit = chk_deleteOnExit.Checked;
			resultat.MaxSize = int.Parse(num_maxSize.Value.ToString());
			resultat.SmartExtract = chk_SmartExtract.Checked;
			resultat.Paths = PathList;
			resultat.Priority = PriorityList;
			priorityData = resultat;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void RomExtractor_PriorityEdit_Load(object sender, EventArgs e)
		{
			txt_cacheSubDir.Text = priorityData.CacheSubDir;
			chk_Ramdisk.Checked = priorityData.UseRamdisk;
			chk_deleteOnExit.Checked = priorityData.DeleteOnExit;
			num_maxSize.Value = priorityData.MaxSize;
			chk_SmartExtract.Checked = priorityData.SmartExtract;
			foreach (var item in priorityData.Paths)
			{
				list_path.Items.Add(item);
			}
			UpdateFromList(txt_path_res, list_path);
			if (txt_path_res.Text == "Default Options") isDefault = true;

			foreach (var item in priorityData.Priority)
			{
				list_priority.Items.Add(item);
			}
			UpdateFromList(txt_priority_res, list_priority);


			if (RamDiskPossible == false)
			{
				chk_Ramdisk.Checked = false;
				chk_Ramdisk.Enabled = false;
			}
			if (isDefault)
			{
				groupBox1.Enabled = false;

			}
			UpdateGUI();

		}

		private void UpdateGUI()
		{
			if (chk_Ramdisk.Checked)
			{
				chk_deleteOnExit.Checked = true;
				chk_deleteOnExit.Enabled = false;
				num_maxSize.Enabled = true;
			}
			else
			{
				chk_deleteOnExit.Enabled = true;
				num_maxSize.Enabled = false;
			}
		}

		private void UpdateFromTxt(KryptonTextBox textbox, ListView listview, bool updatetxt = true)
		{
			var liste_txt = textbox.Text;
			var liste_array = BigBoxUtils.explode(liste_txt, ",");
			string liste_txt_res = "";
			Invoke(new Action(() =>
			{
				listview.Items.Clear();
			}));

			foreach (var item in liste_array)
			{
				var path_elem = item.Trim();
				liste_txt_res += path_elem + ",";
				Invoke(new Action(() =>
				{
					listview.Items.Add(path_elem);
				}));

			}
			liste_txt_res = liste_txt_res.TrimEnd(',');
			Invoke(new Action(() =>
			{
				if (updatetxt) textbox.Text = liste_txt_res;
			}));



		}

		private void UpdateFromList(KryptonTextBox textbox, ListView listview)
		{
			string liste_txt = "";
			foreach (ListViewItem item in listview.Items)
			{
				liste_txt += item.Text + ",";
			}

			liste_txt = liste_txt.TrimEnd(',');
			Invoke(new Action(() =>
			{
				textbox.Text = liste_txt;
			}));

		}

		private void btn_add_path_Click(object sender, EventArgs e)
		{
			list_path.Items.Add(txt_path.Text);
			UpdateFromList(txt_path_res, list_path);
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
				UpdateFromList(txt_path_res, list_path);
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
				UpdateFromList(txt_path_res, list_path);
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
				UpdateFromList(txt_path_res, list_path);
			}
		}

		private void txt_path_res_TextChanged(object sender, EventArgs e)
		{
			if (tokenSource_Path != null)
			{
				// Annuler la tâche précédente si elle existe
				tokenSource_Path.Cancel();
			}

			tokenSource_Path = new CancellationTokenSource();
			var cancellationToken = tokenSource_Path.Token;

			Task.Delay(500, cancellationToken).ContinueWith(task =>
			{

				if (!task.IsCanceled)
				{
					bool isFocus = false;
					Invoke(new Action(() =>
					{
						isFocus = txt_path_res.Focused;
					}));
					if (isFocus) UpdateFromTxt(txt_path_res, list_path, false);
				}
			}, cancellationToken);
		}

		private void txt_path_res_Leave(object sender, EventArgs e)
		{
			if (tokenSource_Path != null) tokenSource_Path.Cancel();
			UpdateFromTxt(txt_path_res, list_path, false);
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

		private void list_path_DoubleClick(object sender, EventArgs e)
		{
			ListView list = (ListView)sender;

			if (list.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list.SelectedIndices[0];

				string value = list.Items[selectedIndex].Text;
				value = Interaction.InputBox("Edit :", "New value", value);

				if (!string.IsNullOrEmpty(value.Trim()))
				{

					list.Items[selectedIndex].Text = value;

					UpdateFromList(txt_path_res, list);
				}
			}
		}

		private void list_priority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
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

		private void btn_up_priority_Click(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_priority.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = list_priority.SelectedItems[0];
					list_priority.Items.RemoveAt(selectedIndex);
					list_priority.Items.Insert(selectedIndex - 1, item);
					list_priority.Focus();
					list_priority.Items[selectedIndex - 1].Selected = true;
				}
				UpdateFromList(txt_priority_res, list_priority);
			}
		}

		private void btn_down_priority_Click(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_priority.SelectedIndices[0];
				if (selectedIndex < list_priority.Items.Count - 1)
				{
					ListViewItem item = list_priority.SelectedItems[0];
					list_priority.Items.RemoveAt(selectedIndex);
					list_priority.Items.Insert(selectedIndex + 1, item);
					list_priority.Focus();
					list_priority.Items[selectedIndex + 1].Selected = true;
				}
				UpdateFromList(txt_priority_res, list_priority);
			}
		}

		private void btn_delete_priority_Click(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list_priority.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				list_priority.Items.RemoveAt(selectedIndex);
				UpdateFromList(txt_priority_res, list_priority);
			}
		}

		private void btn_add_priority_Click(object sender, EventArgs e)
		{
			list_priority.Items.Add(txt_priority.Text);
			UpdateFromList(txt_priority_res, list_priority);
		}

		private void txt_priority_res_TextChanged(object sender, EventArgs e)
		{
			if (tokenSource_Priority != null)
			{
				// Annuler la tâche précédente si elle existe
				tokenSource_Priority.Cancel();
			}

			tokenSource_Priority = new CancellationTokenSource();
			var cancellationToken = tokenSource_Priority.Token;

			Task.Delay(500, cancellationToken).ContinueWith(task =>
			{

				if (!task.IsCanceled)
				{
					bool isFocus = false;
					Invoke(new Action(() =>
					{
						isFocus = txt_priority_res.Focused;
					}));
					if (isFocus) UpdateFromTxt(txt_priority_res, list_priority, false);
				}
			}, cancellationToken);
		}

		private void list_priority_DoubleClick(object sender, EventArgs e)
		{
			ListView list = (ListView)sender;

			if (list.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list.SelectedIndices[0];

				string value = list.Items[selectedIndex].Text;
				value = Interaction.InputBox("Edit :", "New value", value);

				if (!string.IsNullOrEmpty(value.Trim()))
				{

					list.Items[selectedIndex].Text = value;

					UpdateFromList(txt_priority_res, list);
				}
			}
		}

		private void txt_priority_res_Leave(object sender, EventArgs e)
		{
			if (tokenSource_Priority != null) tokenSource_Priority.Cancel();
			UpdateFromTxt(txt_priority_res, list_priority, false);
		}

		private void chk_Ramdisk_CheckedChanged(object sender, EventArgs e)
		{
			if (chk_Ramdisk.Checked)
			{
				chk_deleteOnExit.Checked = true;
				chk_deleteOnExit.Enabled = false;
				num_maxSize.Enabled = true;
			}
			else
			{
				chk_deleteOnExit.Enabled = true;
				num_maxSize.Enabled = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}
	}
}
