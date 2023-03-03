using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public partial class Config : Form
	{
		public Config()
		{
			InitializeComponent();
		}

		private void Config_Load(object sender, EventArgs e)
		{
			UpdateRegisterStatus();
		}

		public void UpdateRegisterStatus()
		{
			if (BigBoxProfile.IsAppRegistered())
			{
				label_status.Text = "Active !";
				btn_register.Text = "Disable";
			}
			else
			{
				label_status.Text = "Inactive !";
				btn_register.Text = "Enable";
			}
		}

		private void btn_register_Click(object sender, EventArgs e)
		{
			if (BigBoxProfile.IsAppRegistered())
			{
				BigBoxProfile.UnregisterExec();
			}
			else
			{
				BigBoxProfile.RegisterExec();
			}
			MessageBox.Show("Done !");
			UpdateRegisterStatus();
		}
	}
}
