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
			if (_filter != "") description += $" [Only if command line contains {_filter}]";
			if (_exclude != "") description += $" [Exclude {_exclude}]";

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


	}
}
