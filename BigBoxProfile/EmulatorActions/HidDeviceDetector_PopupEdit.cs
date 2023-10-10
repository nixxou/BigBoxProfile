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

namespace BigBoxProfile.EmulatorActions
{
	public partial class HidDeviceDetector_PopupEdit : KryptonForm
	{

		public HIDMatcher HidData = null;
		public HidDeviceDetector_PopupEdit(HIDMatcher hidMatcher)
		{

			InitializeComponent();
			cmb_addDevType.Items.Clear();
			cmb_addDevType.Items.Add("controller");
			cmb_addDevType.Items.Add("lightgun");
			cmb_addDevType.Items.Add("wheel");
			cmb_addDevType.Items.Add("other");
			cmb_addDevType.SelectedIndex = 0;

			txt_addDevRegex.Text = hidMatcher.RegexToMatch;
			txt_addDevSuffix.Text = hidMatcher.Suffix;
			foreach (var item in cmb_addDevType.Items)
			{
				if (item is string stringValue)
				{
					if (stringValue == hidMatcher.DeviceType)
					{
						cmb_addDevType.SelectedItem = item;
						break;
					}
				}
			}

			chk_addDevHIDSharp.Checked = hidMatcher.UseHIDSharp;
			chk_addDevDS4Lib.Checked = hidMatcher.UseDS4Lib;
			chk_addDevBT.Checked = hidMatcher.UseBT;
			chk_addDevXinput.Checked = hidMatcher.UseXInput;
			num_addDevMaxMatch.Value = hidMatcher.MaxMatch;
			chk_addDevMatchUnique.Checked = hidMatcher.UniqueMatch;
			chk_addDevDinput.Checked = hidMatcher.UseDInput;
			chk_addDevSDL.Checked = hidMatcher.UseSDL;
		}

		private void HidDeviceDetector_PopupEdit_Load(object sender, EventArgs e)
		{

		}

		private void btn_addDevAdd_Click(object sender, EventArgs e)
		{

		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
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

		private void btn_ok_Click(object sender, EventArgs e)
		{

			if (!IsValidRegex(txt_addDevRegex.Text))
			{
				MessageBox.Show("Invalid Regex");
				return;
			}

			HidData = new HIDMatcher();
			HidData.RegexToMatch = txt_addDevRegex.Text;
			HidData.Suffix = txt_addDevSuffix.Text;
			HidData.DeviceType = cmb_addDevType.SelectedItem.ToString();
			HidData.UseHIDSharp = chk_addDevHIDSharp.Checked;
			HidData.UseDS4Lib = chk_addDevDS4Lib.Checked;
			HidData.UseBT = chk_addDevBT.Checked;
			HidData.UseXInput = chk_addDevXinput.Checked;
			HidData.MaxMatch = (int)num_addDevMaxMatch.Value;
			HidData.UniqueMatch = chk_addDevMatchUnique.Checked;
			HidData.UseDInput = chk_addDevDinput.Checked;
			HidData.UseSDL = chk_addDevSDL.Checked;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void chk_addDevHIDSharp_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_addDevDS4Lib_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_addDevBT_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void chk_addDevXinput_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
