using BigBoxProfile.HID;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace BigBoxProfile.EmulatorActions
{
	public partial class RetroarchFixSiden_Config : KryptonForm
	{

		private CancellationTokenSource tokenSource_Priority;

		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public string priority = "SidenBlue,SidenRed,SidenBlack,SidenPlayer2";
		public bool forceDefaultNoFilter = false;
		public bool forceDefaultNoMatch = false;




		public RetroarchFixSiden_Config(Dictionary<string, string> Options)
		{

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;

			priority = Options.ContainsKey("priority") ? Options["priority"] : "SidenBlue,SidenRed,SidenBlack,SidenPlayer2";

			if (Options.ContainsKey("forceDefaultNoFilter") && Options["forceDefaultNoFilter"] == "yes") forceDefaultNoFilter = true;
			if (Options.ContainsKey("forceDefaultNoMatch") && Options["forceDefaultNoMatch"] == "yes") forceDefaultNoMatch = true;


			InitializeComponent();

			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;

			txt_priority_res.Text = priority;
			chk_forceDefaultNoFilter.Checked = forceDefaultNoFilter;
			chk_forceDefaultNoMatch.Checked = forceDefaultNoMatch;
			
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;

			priority = txt_priority_res.Text;

			forceDefaultNoFilter = chk_forceDefaultNoFilter.Checked;
			forceDefaultNoMatch = chk_forceDefaultNoMatch.Checked;

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
		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaExclude = chk_exclude_comma.Checked;
			btn_manage_exclude.Enabled = commaExclude;
		}

		private void btn_add_priority_Click(object sender, EventArgs e)
		{
			list_priority.Items.Add(txt_priority.Text);
			UpdateFromList(txt_priority_res, list_priority);
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

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void btn_showMouse_Click(object sender, EventArgs e)
		{
			txt_showMouse.Text = "";
			var mouseList = MouseIndexRetroarch.ListMouse();
			foreach(var item in mouseList)
			{
				string Line = $"{item.Index} : {item.Name} : {item.Path}\r\n";
				txt_showMouse.Text += Line;
			}
		}

		private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void txt_showMouse_TextChanged(object sender, EventArgs e)
		{

		}

		private void infoLabel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label12_Paint(object sender, PaintEventArgs e)
		{

		}

		private void RetroarchFixSiden_Config_Load(object sender, EventArgs e)
		{
			UpdateFromTxt(txt_priority_res, list_priority, false);
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

		private void txt_priority_res_Leave(object sender, EventArgs e)
		{
			if (tokenSource_Priority != null) tokenSource_Priority.Cancel();
			UpdateFromTxt(txt_priority_res, list_priority, false);

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

		private void chk_forceDefaultNoMatch_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
