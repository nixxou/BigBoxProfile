using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class ChangeDisposition : IEmulatorAction
	{
		public string ModuleName => "ChangeDisposition";
		private string _disposition = "";


		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new ChangeDisposition_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["disposition"] = frm.result;
				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new ChangeDisposition();
		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("disposition") == false || Options["disposition"] == "")
			{
				return false;
			}
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> Options)
		{
			this.Options = Options;
			if (Options.ContainsKey("disposition") == false) Options["disposition"] = "";
			UpdateConfig();
		}

		public string[] ModifyExemple(string[] args)
		{
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			return args;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				description = $"Change disposition to {_disposition}";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";
		}

		private void UpdateConfig()
		{
			_disposition = Options["disposition"];
		}
	}
}
