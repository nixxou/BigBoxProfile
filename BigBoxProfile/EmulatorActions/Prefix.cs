using System.Collections.Generic;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class Prefix : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public Prefix()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "Prefix";

		private string _prefix = "";
		private bool _asArg = false;
		private string _filter = "";

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new Prefix();
		}

		public void Configure()
		{
			var frm = new Prefix_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (frm.asArg) Options["as_arg"] = "yes";
				else Options["as_arg"] = "no";
				Options["prefix"] = frm.result;
				Options["filter"] = frm.filter.Trim();

				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				if (frm.matchAllFilter) Options["matchAllFilter"] = "yes";
				else Options["matchAllFilter"] = "no";

				if (frm.matchAllExclude) Options["matchAllExclude"] = "yes";
				else Options["matchAllExclude"] = "no";

				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("prefix") == false) Options["prefix"] = "";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("as_arg") == false) Options["as_arg"] = "yes";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			if (Options.ContainsKey("matchAllFilter") == false) Options["matchAllFilter"] = "no";
			if (Options.ContainsKey("matchAllExclude") == false) Options["matchAllExclude"] = "no";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("prefix") == false || Options["prefix"] == "")
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
				if (_asArg) description = "Prefix this to the Arg List : ";
				else description = "Prefix this to the command line : ";
				description += Options["prefix"].ToString();

				string matchall = "";
				string matchallexclude = "";
				if (_matchAllFilter) matchall = "[matchall=on]";
				if (_matchAllExclude) matchallexclude = "[matchall=on]";

				if (_filter != "") description += $" [Only if command line contains {_filter}]{matchall}";
				if (_exclude != "") description += $" [Exclude {_exclude}]{matchallexclude}";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		/*
		public string[] ModifyExemple(string[] args)
		{
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter == "" || cmd.Contains(_filter))
			{
				if (_asArg)
				{
					Array.Resize(ref args, args.Length + 1); // augmenter la taille du tableau de 1
					Array.Copy(args, 0, args, 1, args.Length - 1); // décaler tous les éléments vers la droite
					args[0] = _prefix; // définir le premier élément comme étant votre nouvelle valeur
				}
				else
				{
					cmd = _prefix + cmd;
					args = BigBoxUtils.CommandLineToArgs(cmd);
				}
			}


			return args;
		}
		*/
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

			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return args;
					if (_matchAllFilter && nbFilter > nbFilterFound) return args;
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
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found) return args;
					if (_matchAllExclude && nbFilter > nbFilterFound) return args;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return args;
					}
				}
			}


			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			var filteredCmd = BigBoxUtils.ArgsToCommandLine(filteredArgs);


			if (_asArg)
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, _prefix);
			}
			else
			{

				filteredCmd = _prefix + filteredCmd;
				filteredArgs = BigBoxUtils.CommandLineToArgs(filteredCmd);
			}


			args = BigBoxUtils.AddFirstElementToArg(filteredArgs, exeArg);

			return args;
		}



		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		private void UpdateConfig()
		{
			_prefix = Options["prefix"];
			_filter = Options["filter"];
			_asArg = Options["as_arg"] == "yes" ? true : false;

			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
			_matchAllFilter = Options["matchAllFilter"] == "yes" ? true : false;
			_matchAllExclude = Options["matchAllExclude"] == "yes" ? true : false;
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

		public string[] FiltersToRemoveOnFinalPass()
		{
			List<string> emptylist = new List<string>();
			if (_removeFilter)
			{
				return BigBoxUtils.MakeFilterListToRemove(_filter, _commaFilter);
			}
			return emptylist.ToArray();
		}
	}
}
