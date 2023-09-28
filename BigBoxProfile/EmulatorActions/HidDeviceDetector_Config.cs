using ComponentFactory.Krypton.Toolkit;
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
using static System.Windows.Forms.Design.AxImporter;

namespace BigBoxProfile.EmulatorActions
{
	public partial class HidDeviceDetector_Config : KryptonForm
	{
		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public HidDeviceDetector_Config(Dictionary<string, string> Options)
		{

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;

			InitializeComponent();

			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;
		}

		private void HidDeviceDetector_Config_Load(object sender, EventArgs e)
		{
			cmb_addDevType.Items.Clear();
			cmb_addDevType.Items.Add("controller");
			cmb_addDevType.Items.Add("lightgun");
			cmb_addDevType.Items.Add("wheel");
			cmb_addDevType.Items.Add("other");
			cmb_addDevType.SelectedIndex = 0;

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;

			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;

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

		private void btn_testdevice_Click(object sender, EventArgs e)
		{
			txt_testdevice.Text = "";
			if (chk_usehidsharp.Checked)
			{
				txt_testdevice.Text += "HIDSHARP:\r\n";
				txt_testdevice.Text += HIDInfo.GetHIDSharpInfo(true);
			}
			if (chk_useDS4.Checked)
			{
				txt_testdevice.Text += "DS4LIB:\r\n";
				txt_testdevice.Text += HIDInfo.GetDS4Info(true);
			}
			if (chk_useBT.Checked)
			{
				txt_testdevice.Text += "BLUETOOTHLIB:\r\n";
				txt_testdevice.Text += HIDInfo.GetBluetoothInfo(true);
			}
			if (chk_useXinput.Checked)
			{
				txt_testdevice.Text += "XINPUTLIB:\r\n";
				txt_testdevice.Text += HIDInfo.GetXINPUT(true,txt_DS4Win.Text);
			}
		}

		private void kryptonCheckBox2_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void txt_testdevice_TextChanged(object sender, EventArgs e)
		{

		}

		private void chk_useXinput_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void kryptonLabel13_Paint(object sender, PaintEventArgs e)
		{

		}

		private void chk_useBT_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_useDS4_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_usehidsharp_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void btn_addDevAdd_Click(object sender, EventArgs e)
		{
			if(!IsValidRegex(txt_addDevRegex.Text))
			{
				MessageBox.Show("Invalid Regex");
			}


			var hidMatcher = new HIDMatcher();
			hidMatcher.RegexToMatch = txt_addDevRegex.Text;
			hidMatcher.Suffix = txt_addDevSuffix.Text;
			hidMatcher.DeviceType = cmb_addDevType.SelectedItem.ToString();
			hidMatcher.UseHIDSharp = chk_addDevHIDSharp.Checked;
			hidMatcher.UseDS4Lib = chk_addDevDS4Lib.Checked;
			hidMatcher.UseBT = chk_addDevBT.Checked;
			hidMatcher.UseXInput = chk_addDevXinput.Checked;

			ListViewItem item = new ListViewItem(hidMatcher.ToStringArray());
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

		private void btn_addDevTest_Click(object sender, EventArgs e)
		{
			if (!IsValidRegex(txt_addDevRegex.Text))
			{
				MessageBox.Show("Invalid Regex");
			}
			var hidMatcher = new HIDMatcher();
			hidMatcher.RegexToMatch = txt_addDevRegex.Text;
			hidMatcher.Suffix = txt_addDevSuffix.Text;
			hidMatcher.DeviceType = cmb_addDevType.SelectedItem.ToString();
			hidMatcher.UseHIDSharp = chk_addDevHIDSharp.Checked;
			hidMatcher.UseDS4Lib = chk_addDevDS4Lib.Checked;
			hidMatcher.UseBT = chk_addDevBT.Checked;
			hidMatcher.UseXInput = chk_addDevXinput.Checked;

			var result = hidMatcher.isMatching(true,txt_DS4Win.Text);
			if(result == null)
			{
				MessageBox.Show("No Match !");
			}
			else
			{
				
				string prefix = "";
				if(hidMatcher.DeviceType == "controller") prefix = txt_prefixController.Text;
				if (hidMatcher.DeviceType == "lightgun") prefix = txt_prefixLightgun.Text;
				if (hidMatcher.DeviceType == "wheel") prefix = txt_prefixWheel.Text;
				if (hidMatcher.DeviceType == "other") prefix = txt_prefixOther.Text;
				string fullarg = prefix + result;
				fullarg = fullarg.Replace("%NUM%", "1");

				MessageBox.Show("Match ! Argument that will be added to cmd : " + fullarg + "\r\n" + "(For the test, %NUM% will be set to 1)");



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
			if (lv_priority.SelectedItems.Count == 1 && lv_priority.SelectedItems[0].Index > 1)
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

		private void btn_exploreDS4WinDir_Click(object sender, EventArgs e)
		{
			using (var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txt_DS4Win.Text = fbd.SelectedPath;
				}
			}
		}

		private void txt_DS4Win_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
