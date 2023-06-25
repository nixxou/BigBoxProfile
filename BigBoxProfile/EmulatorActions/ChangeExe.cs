using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class ChangeExe : IEmulatorAction
	{
		public string ModuleName => "ChangeExe";
		private string _newexe = "";

		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new ChangeExe_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["newexe"] = frm.newexe.Trim();
				Options["filter"] = frm.filter.Trim();
				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";


				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new ChangeExe();
		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("newexe") == false || Options["newexe"] == "")
			{
				return false;
			}
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("newexe") == false) Options["newexe"] = "";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";

			UpdateConfig();
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
			if (IsConfigured() == false)
			{
				return args;
			}
			string cmdlower = BigBoxUtils.ArgsToCommandLine(args).ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (!filter_found) return args;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return args;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						if (cmdlower.Contains(filter.Trim()))
						{
							filter_found = true;
						}
					}
					if (filter_found) return args;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return args;
					}
				}
			}


			if (Path.IsPathRooted(_newexe))
			{
				args[0] = _newexe;
			}
			else
			{
				args[0] = Path.Combine(Path.GetDirectoryName(args[0]),_newexe);
			}
			
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				 description = $"Change Exe to {_newexe}";
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_exclude != "") description += $" [Exclude {_exclude}]";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";
		}


		private void UpdateConfig()
		{
			_newexe = Options["newexe"];
			_filter = Options["filter"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
		}

		public void ExecuteBefore(string[] args)
		{

		}
		public void ExecuteAfter(string[] args)
		{

		}

		public bool UseM3UContent()
		{
			return false;
		}
	}
}
