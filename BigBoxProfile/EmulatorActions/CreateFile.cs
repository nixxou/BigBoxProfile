using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class CreateFile : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public CreateFile()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "CreateFile";

		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;

		private string _filepath = "";
		private string _filecontent = "";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();


		public IEmulatorAction CreateNewInstance()
		{
			return new CreateFile();
		}

		public void Configure()
		{
			var frm = new CreateFile_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["filter"] = frm.filter.Trim();

				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				Options["filepath"] = frm.filepath.Trim();

				Options["filecontent"] = frm.filecontent;

				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			if (Options.ContainsKey("filepath") == false) Options["filepath"] = "";
			if (Options.ContainsKey("filecontent") == false) Options["filecontent"] = "";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			
			if (Options.ContainsKey("filepath") == false || Options["filepath"] == "")
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

				description = "Create " + Path.GetFileName(_filepath); 
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_exclude != "") description += $" [Exclude {_exclude}]";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}
			

			return $"{ModuleName} => {description}";

		}

		public string[] ModifyExemple(string[] args)
		{
			return args;
		}
		public string[] Modify(string[] args)
		{
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			return args;
		}

		private void UpdateConfig()
		{
			_filter = Options["filter"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
			_filepath = Options["filepath"];
			_filecontent = Options["filecontent"];
		}

		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured() == false)
			{
				return;
			}
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
					if (!filter_found) return;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return;
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
					if (filter_found) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
			}
			try
			{
				File.WriteAllText(_filepath, _filecontent);
			}
			catch { }
			
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
