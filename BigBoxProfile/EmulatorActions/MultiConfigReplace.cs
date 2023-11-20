using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal struct MultiReplaceContent
	{
		public string group;
		public string matchtype;
		public string key;
		public string value;
	}

	internal class MultiConfigReplace : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public MultiConfigReplace()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "MultiConfigReplace";

		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;
		private string _variablesData = "";
		private string _selectedFile = "";
		private string _content = "";

		private string _selectedFileFinal = "";
		private string _contentFinal = "";


		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new MultiConfigReplace();
		}

		public void Configure()
		{
			
			var frm = new MultiConfigReplace_Config(this.Options);
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

				if (frm.matchAllFilter) Options["matchAllFilter"] = "yes";
				else Options["matchAllFilter"] = "no";

				if (frm.matchAllExclude) Options["matchAllExclude"] = "yes";
				else Options["matchAllExclude"] = "no";

				Options["variablesData"] = frm.variablesData;

				Options["selectedFile"] = frm.selectedFile.Trim();

				Options["content"] = frm.content;

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
			if (Options.ContainsKey("matchAllFilter") == false) Options["matchAllFilter"] = "no";
			if (Options.ContainsKey("matchAllExclude") == false) Options["matchAllExclude"] = "no";
			if (Options.ContainsKey("variablesData") == false) Options["variablesData"] = "";
			if (Options.ContainsKey("selectedFile") == false) Options["selectedFile"] = "";
			if (Options.ContainsKey("content") == false) Options["content"] = "";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{

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
			_matchAllFilter = Options["matchAllFilter"] == "yes" ? true : false;
			_matchAllExclude = Options["matchAllExclude"] == "yes" ? true : false;
			_variablesData = Options["variablesData"];
			_selectedFile = Options["selectedFile"];
			_content = Options["content"];
		}

		public void ExecuteBefore(string[] args)
		{
			//filterstart
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
					if (!filter_found) return;
					if (_matchAllFilter && nbFilter > nbFilterFound) return;
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
					if (filter_found)
					{
						return;
					}
					if (_matchAllExclude && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
			}
			//filterend

			Dictionary<string, VariableData> variablesDictionary = new Dictionary<string, VariableData>();
			if (!String.IsNullOrEmpty(_variablesData))
			{
				var priority_arr = BigBoxUtils.explode(_variablesData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new VariableData(p);
					if (!variablesDictionary.ContainsKey(pObj.VariableName))
					{
						variablesDictionary.Add(pObj.VariableName, pObj);
					}
				}
			}
			this._selectedFileFinal = this._selectedFile;
			this._contentFinal = this._content;
			if (variablesDictionary.Count > 0)
			{
				int currentLoopVariable = 0;
				int maxLoopVariable = 10;
				bool foundVariable = true;
				while (foundVariable)
				{
					foundVariable = false;
					currentLoopVariable++;
					foreach (var v in variablesDictionary)
					{
						if (_selectedFileFinal.ToLower().Contains(v.Key.ToLower()))
						{
							foundVariable = true;
							_selectedFileFinal = v.Value.ReplaceVariable(_selectedFileFinal, args);
						}
					}
					if (currentLoopVariable > maxLoopVariable) break;
				}
			}
			if (variablesDictionary.Count > 0)
			{
				int currentLoopVariable = 0;
				int maxLoopVariable = 10;
				bool foundVariable = true;
				while (foundVariable)
				{
					foundVariable = false;
					currentLoopVariable++;
					foreach (var v in variablesDictionary)
					{
						if (_contentFinal.ToLower().Contains(v.Key.ToLower()))
						{
							foundVariable = true;
							_contentFinal = v.Value.ReplaceVariable(_contentFinal, args);
						}
					}
					if (currentLoopVariable > maxLoopVariable) break;
				}
			}

			if (!File.Exists(_selectedFileFinal)) return;

			List<MultiReplaceContent> multiReplaceContents = new List<MultiReplaceContent>();

			{
				string[] lignes = _contentFinal.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
				string group = "";
				foreach (var lign in lignes)
				{
					string matchtype = "";
					string key = "";
					string value = "";

					if (matchtype == "" && lign.Trim() == "")
					{
						group = "";
						continue;
					}
					if (matchtype == "")
					{
						Regex regex = new Regex(@"^\[(.+)\](\s*)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							group = match.Groups[1].Value;
							continue;
						}
					}

					if (matchtype == "")
					{
						Regex regex = new Regex(@"^([^""]+)=(.+)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							matchtype = "equal";
							key = match.Groups[1].Value.Trim();
							value = match.Groups[2].Value.Trim();
						}
					}
					if (matchtype == "")
					{
						Regex regex = new Regex(@"^([^""]+):(.+)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							matchtype = "colon";
							key = match.Groups[1].Value.Trim();
							value = match.Groups[2].Value.Trim();
						}
					}
					if (matchtype == "")
					{
						Regex regex = new Regex(@"^(\s*)([\w]+)(\s*)(.+)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							matchtype = "space";
							key = match.Groups[2].Value.Trim();
							value = match.Groups[4].Value.Trim();
						}

					}

					if (value.StartsWith("\""))
					{
						Regex regex = new Regex(@"^""(.*)""");
						Match match = regex.Match(value);
						if (match.Success)
						{
							value = "\"" + match.Groups[1].Value + "\"";
						}
					}
					else
					{
						if (value.Contains(" #") || value.Contains(" ;") || value.Contains("\t#") || value.Contains("\t;"))
						{
							if (value.Contains(" #"))
							{
								value = value.Split(new string[] { " #" }, StringSplitOptions.None)[0];
							}
							if (value.Contains(" ;"))
							{
								value = value.Split(new string[] { " ;" }, StringSplitOptions.None)[0];
							}
							if (value.Contains("\t#"))
							{
								value = value.Split(new string[] { "\t#" }, StringSplitOptions.None)[0];
							}
							if (value.Contains("\t;"))
							{
								value = value.Split(new string[] { "\t;" }, StringSplitOptions.None)[0];
							}
						}
					}
					if (string.IsNullOrEmpty(key)) continue;
					Debug.WriteLine($"{matchtype}|{group}> {key} => {value}");
					multiReplaceContents.Add(new MultiReplaceContent { matchtype = matchtype, group = group, key = key, value = value });
				}
			}
			bool change = false;
			if(multiReplaceContents.Count > 0)
			{
				string contentFile = File.ReadAllText(_selectedFileFinal);
				string outContent = "";
				string group = "";
				string[] lignes = Regex.Split(contentFile, "(\r\n|\r|\n)");
				int tailleArrayLignes = lignes.Length;
				for (int i = 0; i < lignes.Length; i += 2)
				{
					string lign = lignes[i];
					string separateur = "";
					if (i + 1 < tailleArrayLignes) separateur = lignes[i + 1];

					string matchtype = "";
					string key = "";
					string value = "";
					string leftpart = "";
					string rightpart = "";

					if (matchtype == "" && lign.Trim() == "")
					{
						group = "";
						outContent += lign;
						outContent += separateur;
						continue;
					}
					if (matchtype == "")
					{
						Regex regex = new Regex(@"^\[(.+)\](\s*)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							group = match.Groups[1].Value;
							outContent += lign;
							outContent += separateur;
							continue;
						}
					}
	

					if (matchtype == "")
					{
						Regex regex = new Regex(@"^([^""]+)=(\s*)(.+)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							matchtype = "equal";
							key = match.Groups[1].Value.Trim();
							value = match.Groups[3].Value.Trim();
							leftpart = match.Groups[1].Value + "=" + match.Groups[2].Value;
							rightpart = match.Groups[3].Value;
						}
					}
					if (matchtype == "")
					{
						Regex regex = new Regex(@"^([^""]+):(\s*)(.+)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							matchtype = "colon";
							key = match.Groups[1].Value.Trim();
							value = match.Groups[3].Value.Trim();
							leftpart = match.Groups[1].Value + ":" + match.Groups[2].Value;
							rightpart = match.Groups[3].Value;
						}
					}
					if (matchtype == "")
					{
						Regex regex = new Regex(@"^(\s*)([\w]+)(\s*)(.+)");
						Match match = regex.Match(lign);
						if (match.Success)
						{
							matchtype = "space";
							key = match.Groups[2].Value.Trim();
							value = match.Groups[4].Value.Trim();
							leftpart = match.Groups[1].Value + match.Groups[2].Value + match.Groups[3].Value;
							rightpart = match.Groups[4].Value;
						}

					}

					if (string.IsNullOrEmpty(key))
					{
						outContent += lign;
						outContent += separateur;
						continue;
					}

					bool found = false;
					MultiReplaceContent multiReplaceContentFound = new MultiReplaceContent();
					foreach(var multiReplaceContent in multiReplaceContents)
					{
						if(multiReplaceContent.matchtype == matchtype && multiReplaceContent.key == key && multiReplaceContent.group == group)
						{
							multiReplaceContentFound = multiReplaceContent;
							found = true;
							break;
						}
					}
					if (!found)
					{
						outContent += lign;
						outContent += separateur;
						continue;
					}
					else
					{
						string newline = leftpart + multiReplaceContentFound.value;
						outContent += newline;
						outContent += separateur;
						if (newline != lign) change = true;
					}
				}
				File.WriteAllText(_selectedFileFinal + ".bis.txt", outContent);

			}


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
