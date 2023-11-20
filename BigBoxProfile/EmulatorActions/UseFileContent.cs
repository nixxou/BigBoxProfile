using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class UseFileContent : IEmulatorAction
	{
		public string ModuleName => "UseFileContent";
		private string _filter = "";
		private bool _usefile = true;

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;


		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new UseFileContent_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (frm.usefile) Options["usefile"] = "yes";
				else Options["usefile"] = "no";
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

		public IEmulatorAction CreateNewInstance()
		{
			return new UseFileContent();
		}

		public bool IsConfigured()
		{
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (options.ContainsKey("filter") == false) Options["filter"] = "";
			if (options.ContainsKey("usefile") == false) Options["usefile"] = "yes";

			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			if (Options.ContainsKey("matchAllFilter") == false) Options["matchAllFilter"] = "no";
			if (Options.ContainsKey("matchAllExclude") == false) Options["matchAllExclude"] = "no";

			UpdateConfig();
		}

		public string[] Modify(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}
		public string[] ModifyExemple(string[] args)
		{

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

			if (args.Length > 1)
			{
				for (int i = 0; i < args.Length; i++)
				{
					if (File.Exists(args[i]))
					{
						var content = File.ReadAllText(args[i]);
						if (!Path.IsPathRooted(content))
						{
							string path = "";
							if (_usefile) path = Path.GetDirectoryName(args[i]);
							else path = Directory.GetCurrentDirectory();
							content = Path.Combine(path, content);
						}
						args[i] = content;
					}
				}
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
			string description = "Remplace file in parameter with there content";

			/*
			if (_filter != "")
			{
				description += $" if filename contains {_filter}";

			}
			*/
			string matchall = "";
			string matchallexclude = "";
			if (_matchAllFilter) matchall = "[matchall=on]";
			if (_matchAllExclude) matchallexclude = "[matchall=on]";

			if (_filter != "") description += $" [Only if command line contains {_filter}]{matchall}";
			if (_exclude != "") description += $" [Exclude {_exclude}]{matchallexclude}";

			return $"{ModuleName} => {description}";
		}

		private void UpdateConfig()
		{
			//if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			//if (Options.ContainsKey("usefile") == false) Options["usefile"] = "yes";
			_filter = Options["filter"];
			_usefile = Options["usefile"] == "yes" ? true : false;
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
			return true;
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
