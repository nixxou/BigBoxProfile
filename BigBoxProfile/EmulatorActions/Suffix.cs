using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class Suffix : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public Suffix()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "Suffix";

		private string _suffix = "";
		private bool _asArg = false;
		private string _filter = "";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new Suffix();
		}

		public void Configure()
		{
			var frm = new Suffix_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (frm.asArg) Options["as_arg"] = "yes";
				else Options["as_arg"] = "no";
				Options["suffix"] = frm.result;
				Options["filter"] = frm.filter.Trim();
				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("suffix") == false) Options["suffix"] = "";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("as_arg") == false) Options["as_arg"] = "yes";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("suffix")==false || Options["suffix"] == "")
			{
				return false;
			}
			return true;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				if (_asArg) description = "suffix this to the Arg List : ";
				else description = "suffix this to the command line : ";
				description += Options["suffix"].ToString();
				if (_filter != "") description += $" [Only if command line contains {_filter}]";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		public string[] ModifyExemple(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}
		public string[] Modify(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter == "" || cmd.Contains(_filter))
			{
				if (_asArg)
				{
					Array.Resize(ref args, args.Length + 1); // augmenter la taille du tableau de 1
					args[args.Length - 1] = _suffix;
				}
				else
				{
					cmd =  cmd + _suffix;
					args = BigBoxUtils.CommandLineToArgs(cmd);
				}
			}


			return args;
		}




		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		private void UpdateConfig()
		{
			_suffix = Options["suffix"];
			_filter = Options["filter"];
			_asArg = Options["as_arg"] == "yes" ? true : false;
		}
	}
}
