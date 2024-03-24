using BigBoxProfile.HID;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class SupermodelFixSiden : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public SupermodelFixSiden()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "SupermodelFixSiden";

		public static bool isTriggered = false;

		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;
		private string _priority = "";

		private bool _matchModuleOnce = true;
		private bool _enablegun1 = true;
		private bool _enablegun2 = true;

		private string _restrictgun1 = "";
		private string _restrictgun2 = "";

		private bool _addInputArg = true;

		private string _supermodelConfig = @"
InputGunX = ""GUN1_XAXIS,JOY1_XAXIS""
InputGunY = ""GUN1_YAXIS,JOY1_YAXIS""
InputTrigger = ""KEY_A,JOY1_BUTTON1,GUN1_LEFT_BUTTON""
InputOffscreen = ""KEY_S,JOY1_BUTTON2,GUN1_RIGHT_BUTTON""   

InputGunX2 = ""GUN2_XAXIS,JOY2_XAXIS""    
InputGunY2 = ""GUN2_YAXIS,JOY2_YAXIS""    
InputTrigger2 = ""KEY_A,JOY1_BUTTON1,GUN2_LEFT_BUTTON""
InputOffscreen2 = ""KEY_S,JOY1_BUTTON2,GUN2_RIGHT_BUTTON"" 

InputAnalogGunX = ""GUN1_XAXIS,JOY1_XAXIS""    
InputAnalogGunY = ""GUN1_YAXIS,JOY1_YAXIS""   
InputAnalogTriggerLeft = ""KEY_A,JOY1_BUTTON1,GUN1_LEFT_BUTTON""
InputAnalogTriggerRight = ""KEY_S,JOY1_BUTTON2,GUN1_RIGHT_BUTTON""

InputAnalogGunX2 = ""GUN2_XAXIS,JOY2_XAXIS""
InputAnalogGunY2 = ""GUN2_YAXIS,JOY2_YAXIS""
InputAnalogTriggerLeft2 = ""KEY_C,JOY1_BUTTON1,GUN2_LEFT_BUTTON""
InputAnalogTriggerRight2 = ""KEY_D,JOY1_BUTTON2,GUN2_RIGHT_BUTTON""
";
		//private bool _forceDefaultNoFilter = false;
		//private bool _forceDefaultNoMatch = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//private string appendConfig = "";
		private string selectedInputDriver = "";
		private string selectedPlayer1 = "";
		private string selectedPlayer2 = "";

		private string argRowPlayer1 = "";
		private string argRowPlayer2 = "";



		//private bool filtersOk = false;




		/*
		 
		input_driver = "dinput"
		input_driver = "raw"
		input_player2_mouse_index = "0" //start
		*/



		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new SupermodelFixSiden();
		}

		public void Configure()
		{

			var frm = new RetroarchFixSiden_Config(this.Options,true);
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

				Options["priority"] = frm.priority.Trim();

				if (frm.matchModuleOnce) Options["matchModuleOnce"] = "yes";
				else Options["matchModuleOnce"] = "no";

				if (frm.enablegun1) Options["enablegun1"] = "yes";
				else Options["enablegun1"] = "no";

				if (frm.enablegun2) Options["enablegun2"] = "yes";
				else Options["enablegun2"] = "no";


				Options["restrictgun1"] = frm.restrictgun1.Trim();
				Options["restrictgun2"] = frm.restrictgun2.Trim();

				if (frm.enablegun1) Options["addInputArg"] = "yes";
				else Options["addInputArg"] = "no";

				Options["supermodelConfig"] = frm.supermodelConfig;

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

			if (Options.ContainsKey("priority") == false) Options["priority"] = "SidenBlue,SidenRed,SidenBlack,SidenPlayer2";

			if (Options.ContainsKey("matchModuleOnce") == false) Options["matchModuleOnce"] = "yes";
			if (Options.ContainsKey("enablegun1") == false) Options["enablegun1"] = "yes";
			if (Options.ContainsKey("enablegun2") == false) Options["enablegun2"] = "yes";

			if (Options.ContainsKey("restrictgun1") == false) Options["restrictgun1"] = "";
			if (Options.ContainsKey("restrictgun2") == false) Options["restrictgun2"] = "";

			if (Options.ContainsKey("addInputArg") == false) Options["addInputArg"] = "yes";

			if (Options.ContainsKey("supermodelConfig") == false) Options["supermodelConfig"] = _supermodelConfig;
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
				//if (_asArg) description = "suffix this to the Arg List : ";
				//else description = "suffix this to the command line : ";
				description += $"{_priority}";

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

		public static string LocateRetroarchConfig(string[] args)
		{
			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);

			string PathConfig = "";

			string currDir = String.IsNullOrEmpty(EmulatorLauncher.WorkingDirExe) ? Environment.CurrentDirectory : EmulatorLauncher.WorkingDirExe;
			PathConfig = Path.Combine(currDir, "Config", "Supermodel.ini");
			if (File.Exists(PathConfig))
			{
				return PathConfig;
			}
			return "";
		}



		public string[] ModifyReal(string[] args)
		{
			if (_matchModuleOnce && isTriggered) { return args; }


			if (IsConfigured() == false)
			{
				return args;
			}
			if (selectedInputDriver == "") return args;

			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			string retroarchConfigPath = LocateRetroarchConfig(args);
			if (retroarchConfigPath == "")
			{
				return args;
			}

			isTriggered = true;

			//string contentConfig = File.ReadAllText(retroarchConfigPath);

			string newConfig = _supermodelConfig;


			newConfig = newConfig.Replace("GUN1", "MOUSE" + selectedPlayer1);
			newConfig = newConfig.Replace("GUN2", "MOUSE" + selectedPlayer2);

			RemplaceConfig(newConfig, retroarchConfigPath);

			

			//File.WriteAllText(retroarchConfigPath, contentConfig);
			Thread.Sleep(100);


			if (!string.IsNullOrEmpty(argRowPlayer1))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer1=" + argRowPlayer1);
			}
			if (!string.IsNullOrEmpty(argRowPlayer2))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer2=" + argRowPlayer2);
			}

			if (_addInputArg)
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "-input-system=rawinput");
			}

			args = BigBoxUtils.AddFirstElementToArg(filteredArgs, exeArg);

			return args;
		}

		private void RemplaceConfig(string customConfigContent, string selectedFile)
		{
			List<MultiReplaceContent> multiReplaceContents = new List<MultiReplaceContent>();

			{
				string[] lignes = customConfigContent.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
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
			if (multiReplaceContents.Count > 0)
			{
				string contentFile = File.ReadAllText(selectedFile);
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
					foreach (var multiReplaceContent in multiReplaceContents)
					{
						if (multiReplaceContent.matchtype == matchtype && multiReplaceContent.key == key && multiReplaceContent.group == group)
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
				File.WriteAllText(selectedFile, outContent);

			}
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
			_priority = Options["priority"];
			//_forceDefaultNoFilter = Options["forceDefaultNoFilter"] == "yes" ? true : false;
			//_forceDefaultNoMatch = Options["forceDefaultNoMatch"] == "yes" ? true : false;

			_matchModuleOnce = Options["matchModuleOnce"] == "yes" ? true : false;
			_enablegun1 = Options["enablegun1"] == "yes" ? true : false;
			_enablegun2 = Options["enablegun2"] == "yes" ? true : false;


			_restrictgun1 = Options["restrictgun1"];
			_restrictgun2 = Options["restrictgun2"];
			_addInputArg = Options["addInputArg"] == "yes" ? true : false;
			_supermodelConfig = Options["supermodelConfig"];

		}

		public void SetDefaultRetroarchConfig()
		{
			selectedInputDriver = "dinput";
			selectedPlayer1 = "1";
			selectedPlayer2 = "2";
		}

		public void ExecuteBefore(string[] args)
		{
			if (_matchModuleOnce && isTriggered) { return; }
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
					if (!filter_found)
					{
						//if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
					if (_matchAllFilter && nbFilter > nbFilterFound)
					{
						//if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						//if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
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
						//if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
					if (_matchAllExclude && nbFilter > nbFilterFound)
					{
						//if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						//if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
				}
			}
			//filterend
			//filtersOk = true;
			int playerFound = 0;
			var priority_array = BigBoxUtils.explode(_priority, ",");
			var mouseList = MouseIndexRetroarch.ListMouse(true);

			//var gunAssignement = new Dictionary<int, string>();
			//if (_enablegun1) gunAssignement.Add(1, "");
			//if (_enablegun2) gunAssignement.Add(2, "");

			var priorityResult = new Dictionary<string, string>();


			foreach (var pElem in priority_array)
			{
				string PriorityElem = pElem.Trim();

				foreach (var mouse in mouseList)
				{
					bool isMatch = false;
					//1 : SindenLightgun : HID#VID_16C0&PID_0F01&MI_02&COL02#9&31C2F27D&0&0001
					//SidenBlue,SidenRed,SidenBlack,SidenPlayer2
					if (!isMatch && PriorityElem.ToLower() == "sidenblue" && mouse.Path.ToUpper().Contains("VID_16C0&PID_0F01"))
					{
						isMatch = true;
					}
					if (!isMatch && PriorityElem.ToLower() == "sidenred" && mouse.Path.ToUpper().Contains("VID_16C0&PID_0F02"))
					{
						isMatch = true;
					}
					if (!isMatch && PriorityElem.ToLower() == "sidenblack" && mouse.Path.ToUpper().Contains("VID_16C0&PID_0F38"))
					{
						isMatch = true;
					}
					if (!isMatch && PriorityElem.ToLower() == "sidenplayer2" && mouse.Path.ToUpper().Contains("VID_16C0&PID_0F39"))
					{
						isMatch = true;
					}
					if (!isMatch && mouse.Name.ToLower().Contains(PriorityElem.ToLower()))
					{
						isMatch = true;
					}
					if (!isMatch && mouse.Path.ToLower().Contains(PriorityElem.ToLower()))
					{
						isMatch = true;
					}
					if (isMatch)
					{
						priorityResult.Add(PriorityElem.Trim(), (mouse.Index).ToString());
					}
				}
			}


			if (_enablegun1)
			{
				if (string.IsNullOrEmpty(_restrictgun1))
				{
					if (priorityResult.Count > 0)
					{
						var gun = priorityResult.First();
						selectedPlayer1 = gun.Value;
						argRowPlayer1 = MouseIndexRetroarch.SanitizeForCommand(gun.Key);
						string key = gun.Key;
						priorityResult.Remove(key);
					}
				}
				else
				{
					var restrictgun1_array = BigBoxUtils.explode(_restrictgun1, ",");
					List<string> restrictgun_list = new List<string>();
					foreach (var restrictgun in restrictgun1_array)
					{
						string restrictgun_val = restrictgun.Trim();
						if (string.IsNullOrEmpty(restrictgun_val)) continue;
						restrictgun_list.Add(restrictgun_val);
					}

					string foundkey = "";
					foreach (var pgun in priorityResult)
					{
						if (restrictgun_list.Contains(pgun.Key))
						{
							selectedPlayer1 = pgun.Value;
							argRowPlayer1 = MouseIndexRetroarch.SanitizeForCommand(pgun.Key);
							foundkey = pgun.Key;
							break;
						}
					}
					if (foundkey != "") priorityResult.Remove(foundkey);
				}
			}

			if (_enablegun2)
			{
				if (string.IsNullOrEmpty(_restrictgun2))
				{
					if (priorityResult.Count > 0)
					{
						var gun = priorityResult.First();
						selectedPlayer2 = gun.Value;
						argRowPlayer2 = MouseIndexRetroarch.SanitizeForCommand(gun.Key);
						string key = gun.Key;
						priorityResult.Remove(key);
					}
				}
				else
				{
					var restrictgun1_array = BigBoxUtils.explode(_restrictgun2, ",");
					List<string> restrictgun_list = new List<string>();
					foreach (var restrictgun in restrictgun1_array)
					{
						string restrictgun_val = restrictgun.Trim();
						if (string.IsNullOrEmpty(restrictgun_val)) continue;
						restrictgun_list.Add(restrictgun_val);
					}

					string foundkey = "";
					foreach (var pgun in priorityResult)
					{
						if (restrictgun_list.Contains(pgun.Key))
						{
							selectedPlayer2 = pgun.Value;
							argRowPlayer2 = MouseIndexRetroarch.SanitizeForCommand(pgun.Key);
							foundkey = pgun.Key;
							break;
						}
					}
					if (foundkey != "") priorityResult.Remove(foundkey);
				}
			}


			if (selectedPlayer1 != "" || selectedPlayer2 != "")
			{
				selectedInputDriver = "raw";
				if (selectedPlayer1 == "") selectedPlayer1 = "100";
				if (selectedPlayer2 == "") selectedPlayer2 = "100";

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
			List<string> arglist = new List<string>();
			var arglistarr = arglist.ToArray();


			/*
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer1="+argRowPlayer1);
			}
			if (!string.IsNullOrEmpty(argRowPlayer2))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer2=" + argRowPlayer2);
			 * */
			if (_removeFilter)
			{
				arglistarr = BigBoxUtils.MakeFilterListToRemove(_filter, _commaFilter);

			}
			if (argRowPlayer1 != "")
			{
				string argtofilter = "--rawplayer1=" + argRowPlayer1;
				argtofilter = argtofilter.ToLower();
				arglistarr = BigBoxUtils.AddFirstElementToArg(arglistarr, argtofilter);
			}
			if (argRowPlayer2 != "")
			{
				string argtofilter = "--rawplayer2=" + argRowPlayer2;
				argtofilter = argtofilter.ToLower();
				arglistarr = BigBoxUtils.AddFirstElementToArg(arglistarr, argtofilter);
			}

			return arglistarr;
		}


	}
}
