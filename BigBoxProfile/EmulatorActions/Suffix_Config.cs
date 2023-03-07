using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BigBoxProfile.EmulatorActions
{
	
	public partial class Suffix_Config : Form
	{
		public string result = "";
		public string filter = "";
		public bool asArg = false;
		public Suffix_Config(Dictionary<string, string> Options)
		{
			result = Options.ContainsKey("suffix") ? Options["suffix"] : "";

			if (Options.ContainsKey("as_arg"))
			{
				if (Options["as_arg"] == "yes") asArg = true;
				else asArg = false;
			}
			else asArg = true;

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";

			InitializeComponent();
			txt_option.Text = result;
			txt_filter.Text = filter;
			if (asArg) radio_arg.Checked = true;
			else radio_cmd.Checked = true;

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			
			filter = txt_filter.Text;
			asArg = false;
			if(radio_arg.Checked) asArg= true;

			result = txt_option.Text;
			if (asArg) result = result.Trim();

			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void Prefix_Config_Load(object sender, EventArgs e)
		{

		}
	}
}