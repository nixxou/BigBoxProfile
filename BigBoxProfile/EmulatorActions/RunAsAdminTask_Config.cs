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
	public partial class RunAsAdminTask_Config : Form
	{
		public string filter = "";
		public string filterInsideFile = "";
		public RunAsAdminTask_Config(Dictionary<string, string> Options)
		{

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			filterInsideFile = Options.ContainsKey("filterInsideFile") ? Options["filterInsideFile"] : "";

			InitializeComponent();
			txt_filter.Text = filter;
			txt_filter_inside_file.Text = filterInsideFile;
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			filterInsideFile = txt_filter_inside_file.Text;

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
