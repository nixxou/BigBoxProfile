using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class UseFileContent_Config : Form
	{
		public string filter = "";
		public bool usefile = false;

		public UseFileContent_Config(Dictionary<string, string> Options)
		{
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			if (Options.ContainsKey("usefile"))
			{
				if (Options["usefile"] == "yes") usefile = true;
				else usefile = false;
			}
			else usefile = true;

			InitializeComponent();


			if (usefile) radio_usefile.Checked = true;
			else radio_usedir.Checked = true;

			txt_filter.Text = filter;




		}

		private void UseFileContent_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			usefile = false;
			if (radio_usefile.Checked) usefile = true;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
