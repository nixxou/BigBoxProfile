using BigBoxProfile.RomExtractorUtils;
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

namespace BigBoxProfile.EmulatorActions
{
	public partial class RomExtractor_Config : Form
	{
		public string cachedir = "";
		public string cacheMaxSize = "0";
		public string filter = "";
		public string excludeFilter = "";
		public string standaloneExtensions = "";
		public string metadataExtensions = "";
		public List<RomExtractor_PriorityData> priorityList = new List<RomExtractor_PriorityData>();
		public string priority = "";
		public bool RamDiskPossible = false;

		public bool commaFilter = false;
		public bool commaExclude = false;

		public RomExtractor_Config(Dictionary<string, string> Options)
		{
			cachedir = Options.ContainsKey("cachedir") ? Options["cachedir"] : "";
			cacheMaxSize = Options.ContainsKey("cacheMaxSize") ? Options["cacheMaxSize"] : "0";

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			excludeFilter = Options.ContainsKey("excludeFilter") ? Options["excludeFilter"] : "";
			standaloneExtensions = Options.ContainsKey("standaloneExtensions") ? Options["standaloneExtensions"] : "gb, gbc, gba, agb, nes, fds, smc, sfc, n64, z64, v64, ndd, md, smd, gen, iso, chd, gg, gcm, 32x, bin";
			metadataExtensions = Options.ContainsKey("metadataExtensions") ? Options["metadataExtensions"] : "nfo, txt, dat, xml, json, htc, hts";

			priority = Options.ContainsKey("priority") ? Options["priority"] : "";
			if (Options.ContainsKey("priority") && !String.IsNullOrEmpty(Options["priority"]) )
			{
				var priority_arr = BigBoxUtils.explode(Options["priority"], "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new RomExtractor_PriorityData(p);
					priorityList.Add(new RomExtractor_PriorityData(p));
				}
			}

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;

			InitializeComponent();
		}

		private void RomExtractor_Config_Load(object sender, EventArgs e)
		{
			txt_cachedir.Text = cachedir;
			num_cacheMaxSize.Value = int.Parse(cacheMaxSize);
			txt_filter.Text = filter;
			txt_excludeFilter.Text = excludeFilter;
			txt_standaloneExtensions.Text = standaloneExtensions;
			txt_metadataExtensions.Text = metadataExtensions;

			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;

			lv_priority.Items.Clear();
			if (priorityList.Count() == 0)
			{
				var DefaultPriority = new RomExtractor_PriorityData();
				DefaultPriority.Paths.Add("Default Options");
				priorityList.Add(DefaultPriority);
			}

			foreach(var p in priorityList)
			{
				ListViewItem item = new ListViewItem(p.ToStringArray());
				lv_priority.Items.Add(item);
			}

			lv_priority.Columns[0].Width = 0;
			UpdateGUI();
			UpdateInstalled();
		}

		private void UpdateGUI()
		{

		}

		private void UpdateInstalled()
		{
			if (RamDiskLauncher.isDriverInstalled())
			{
				RamDiskPossible = true;
				label_Imdisk_false.Visible = false;
				label_Imdisk_true.Visible = true;
			}
			else
			{
				RamDiskPossible = false;
				label_Imdisk_false.Visible = true;
				label_Imdisk_true.Visible = false;
			}
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			cachedir = txt_cachedir.Text;

			if (String.IsNullOrEmpty(cachedir)){
				MessageBox.Show("You must define cache directory");
				return;
			}
			if (!Directory.Exists(cachedir))
			{
				MessageBox.Show($"{cachedir} do not exist");
				return;
			}



			cacheMaxSize = num_cacheMaxSize.Value.ToString();
			filter = txt_filter.Text;
			excludeFilter = txt_excludeFilter.Text;
			standaloneExtensions = txt_standaloneExtensions.Text;
			metadataExtensions = txt_metadataExtensions.Text;

			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;

			priorityList = new List<RomExtractor_PriorityData> { new RomExtractor_PriorityData() };
			priority = "";
			foreach (ListViewItem item in lv_priority.Items)
			{
				priorityList.Add(new RomExtractor_PriorityData(item.SubItems[0].Text));
				priority += item.SubItems[0].Text + "|||";

			}
			priority = priority.Trim('|').Trim('|').Trim('|').Trim('|').Trim('|').Trim('|');
			

			

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_add_Click(object sender, EventArgs e)
		{
			var frm = new RomExtractor_PriorityEdit(null, RamDiskPossible);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				ListViewItem item = new ListViewItem(frm.priorityData.ToStringArray());
				lv_priority.Items.Add(item);
			}
		}

		private void btn_cachedir_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txt_cachedir.Text = fbd.SelectedPath;
				}
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

		private void btn_up_priority_Click(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count ==1 && lv_priority.SelectedItems[0].Index > 1)
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
			if (lv_priority.SelectedItems.Count == 1 && lv_priority.SelectedItems[0].Index > 0)
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
			if (lv_priority.SelectedItems.Count == 1 && lv_priority.SelectedItems[0].Index > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = lv_priority.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				lv_priority.Items.RemoveAt(selectedIndex);
			}
		}

		private void lv_priority_DpiChangedAfterParent(object sender, EventArgs e)
		{

		}

		private void lv_priority_DoubleClick(object sender, EventArgs e)
		{
			if (lv_priority.SelectedItems.Count == 1)
			{
				var priorityData = new RomExtractor_PriorityData(lv_priority.SelectedItems[0].SubItems[0].Text);
				ListViewItem item = lv_priority.SelectedItems[0];

				var frm = new RomExtractor_PriorityEdit(priorityData, RamDiskPossible);
				var result = frm.ShowDialog();
				
				if (result == DialogResult.OK)
				{
					var priorityDataArray = frm.priorityData.ToStringArray();
					for (int j = 0; j < priorityDataArray.Length; j++)
					{
						if (j < item.SubItems.Count)
						{
							item.SubItems[j].Text = priorityDataArray[j];
						}
					}
				}
			}
		}

		private void chk_filter_comma_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{

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
			var frm = new Manage_Items(txt_excludeFilter.Text);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				txt_excludeFilter.Text = frm.TxtValue;
			}
		}
	}
}
