using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class Replace : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public Replace()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "Replace";

		private string _search = "";
		private string _replacewith = "";
		private bool _useregex = false;
		private bool _casesensitive = false;
		private bool _asArg = false;
		private string _filter = "";


		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();


		public IEmulatorAction CreateNewInstance()
		{
			return new Replace();
		}

		public void Configure()
		{
			
			var frm = new Replace_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (frm.asArg) Options["as_arg"] = "yes";
				else Options["as_arg"] = "no";

				Options["search"] = frm.search;
				Options["replacewith"]= frm.replacewith;

				if (frm.useregex) Options["useregex"] = "yes";
				else Options["useregex"] = "no";

				if (frm.casesensitive) Options["casesensitive"] = "yes";
				else Options["casesensitive"] = "no";

				Options["filter"] = frm.filter.Trim();
				UpdateConfig();
			}
			

		}

		public void LoadConfiguration(Dictionary<string, string> Options)
		{
			this.Options = Options;
			if (Options.ContainsKey("search") == false) Options["search"] = "";
			if (Options.ContainsKey("replacewith") == false) Options["replacewith"] = "";
			if (Options.ContainsKey("useregex") == false) Options["useregex"] = "no";
			if (Options.ContainsKey("casesensitive") == false) Options["casesensitive"] = "no";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("as_arg") == false) Options["as_arg"] = "yes";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("search") ==false || Options["search"] == "")
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
				if (_asArg) description = "Replace foreach Arg : ";
				else description = "Replace : ";
				description += $"{_search} by {_replacewith}";
				if (_useregex) description += " [regex=on]";
				if (_casesensitive) description += " [casesensitive=on]";
				if (_filter != "") description += $" [Only if command line contains {_filter}]";

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
			if (_asArg)
			{
				var newarg = new string[args.Length];
				int index = 0;
				foreach(var cmd in args)
				{
					RegexOptions options = RegexOptions.Multiline;
					if (!_casesensitive) options |= RegexOptions.IgnoreCase;
					Regex regex = _useregex ? new Regex(_search, options) : null;
					string result = _useregex ? regex.Replace(cmd, MatchEvaluator) : cmd.Replace(_search, _replacewith);
					newarg[index] = result;
					index++;
				}
				args = newarg;
			}
			else
			{
				string cmd = BigBoxUtils.ArgsToCommandLine(args);
				RegexOptions options = RegexOptions.Multiline;
				if (!_casesensitive) options |= RegexOptions.IgnoreCase;
				Regex regex = _useregex ? new Regex(_search, options) : null;

				string result = _useregex ? regex.Replace(cmd, MatchEvaluator) : cmd.Replace(_search, _replacewith);

				args = BigBoxUtils.CommandLineToArgs(result);
			}
				


			return args;
		}
		*/


		public string[] ModifyExemple(string[] args)
		{

			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			var filteredCmd = BigBoxUtils.ArgsToCommandLine(filteredArgs);


			if (_asArg)
			{
				var newarg = new string[filteredArgs.Length];
				int index = 0;
				foreach (var elem in filteredArgs)
				{
					RegexOptions options = RegexOptions.Multiline;
					if (!_casesensitive) options |= RegexOptions.IgnoreCase;
					Regex regex = _useregex ? new Regex(_search, options) : null;
					string result = _useregex ? regex.Replace(elem, MatchEvaluator) : elem.Replace(_search, _replacewith);
					newarg[index] = result;
					index++;
				}
				filteredArgs = newarg;
			}
			else
			{
				RegexOptions options = RegexOptions.Multiline;
				if (!_casesensitive) options |= RegexOptions.IgnoreCase;
				Regex regex = _useregex ? new Regex(_search, options) : null;

				string result = _useregex ? regex.Replace(filteredCmd, MatchEvaluator) : filteredCmd.Replace(_search, _replacewith);

				filteredArgs = BigBoxUtils.CommandLineToArgs(result);
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
			_search = Options["search"];
			_replacewith= Options["replacewith"];
			_useregex= Options["useregex"] == "yes" ? true : false;
			_casesensitive = Options["casesensitive"] == "yes" ? true : false;
			_filter = Options["filter"];
			_asArg = Options["as_arg"] == "yes" ? true : false;
		}

		private string MatchEvaluator(Match match)
		{
			GroupCollection groups = match.Groups;

			string replaceWith = this._replacewith;
			for (int i = 1; i <= groups.Count; i++)
			{
				replaceWith = replaceWith.Replace($"\\{i}", groups[i].Value);
			}

			return replaceWith;
		}
	}
}
