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
	

	public partial class ExecuteAHK_Config : Form
	{
		public string filter = "";
		public string ahkCodeExemple = "";
		public string ahkCodeReal = "";
		public string ahkCodeBefore = "";
		public string ahkCodeAfter = "";

		public ExecuteAHK_Config(Dictionary<string, string> Options)
		{
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			ahkCodeExemple = Options.ContainsKey("ahkCodeExemple") ? Options["ahkCodeExemple"] : "";
			ahkCodeReal = Options.ContainsKey("ahkCodeReal") ? Options["ahkCodeReal"] : "";
			ahkCodeBefore = Options.ContainsKey("ahkCodeBefore") ? Options["ahkCodeBefore"] : "";
			ahkCodeAfter = Options.ContainsKey("ahkCodeAfter") ? Options["ahkCodeAfter"] : "";

			InitializeComponent();

			txt_filter.Text = filter;
			txt_CodeExemple.Text = ahkCodeExemple;
			txt_CodeReal.Text = ahkCodeReal;
			txt_CodeBefore.Text = ahkCodeBefore;
			txt_CodeAfter.Text = ahkCodeAfter;

		}

		private void ExecuteAHK_Config_Load(object sender, EventArgs e)
		{

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			ahkCodeExemple = txt_CodeExemple.Text;
			ahkCodeReal = txt_CodeReal.Text;
			ahkCodeBefore = txt_CodeBefore.Text;
			ahkCodeAfter = txt_CodeAfter.Text;

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
