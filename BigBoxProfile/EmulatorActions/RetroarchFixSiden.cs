using BigBoxProfile.HID;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class RetroarchFixSiden : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public RetroarchFixSiden()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "RetroarchFixSiden";

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
		private bool _enablegun3 = false;
		private bool _enablegun4 = false;

		private string _restrictgun1 = "";
		private string _restrictgun2 = "";
		private string _restrictgun3 = "";
		private string _restrictgun4 = "";

		//private bool _forceDefaultNoFilter = false;
		//private bool _forceDefaultNoMatch = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//private string appendConfig = "";
		private string selectedInputDriver = "";
		private string selectedPlayer1 = "";
		private string selectedPlayer2 = "";
		private string selectedPlayer3 = "";
		private string selectedPlayer4 = "";

		private string argRowPlayer1 = "";
		private string argRowPlayer2 = "";
		private string argRowPlayer3 = "";
		private string argRowPlayer4 = "";
		//private bool filtersOk = false;

		


		/*
		 
		input_driver = "dinput"
		input_driver = "raw"
		input_player2_mouse_index = "0" //start
		*/



		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new RetroarchFixSiden();
		}

		public void Configure()
		{
			
			var frm = new RetroarchFixSiden_Config(this.Options);
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

				//if (frm.forceDefaultNoFilter) Options["forceDefaultNoFilter"] = "yes";
				//else Options["forceDefaultNoFilter"] = "no";

				//if (frm.forceDefaultNoMatch) Options["forceDefaultNoMatch"] = "yes";
				//else Options["forceDefaultNoMatch"] = "no";

				if (frm.matchModuleOnce) Options["matchModuleOnce"] = "yes";
				else Options["matchModuleOnce"] = "no";

				if (frm.enablegun1) Options["enablegun1"] = "yes";
				else Options["enablegun1"] = "no";

				if (frm.enablegun2) Options["enablegun2"] = "yes";
				else Options["enablegun2"] = "no";

				if (frm.enablegun1) Options["enablegun3"] = "yes";
				else Options["enablegun3"] = "no";

				if (frm.enablegun2) Options["enablegun4"] = "yes";
				else Options["enablegun4"] = "no";

				Options["restrictgun1"] = frm.restrictgun1.Trim();
				Options["restrictgun2"] = frm.restrictgun2.Trim();
				Options["restrictgun3"] = frm.restrictgun3.Trim();
				Options["restrictgun4"] = frm.restrictgun4.Trim();

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
			if (Options.ContainsKey("enablegun3") == false) Options["enablegun3"] = "no";
			if (Options.ContainsKey("enablegun4") == false) Options["enablegun4"] = "no";

			if (Options.ContainsKey("restrictgun1") == false) Options["restrictgun1"] = "";
			if (Options.ContainsKey("restrictgun2") == false) Options["restrictgun2"] = "";
			if (Options.ContainsKey("restrictgun3") == false) Options["restrictgun3"] = "";
			if (Options.ContainsKey("restrictgun4") == false) Options["restrictgun4"] = "";
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

			foreach (var arg in filteredArgs)
			{
				if (arg.Trim().StartsWith("--config="))
				{
					PathConfig = arg.Trim().Substring(9);
					if (File.Exists(PathConfig))
					{
						return PathConfig;
					}
				}
			}

			for (int i = 0; i < filteredArgs.Length; i++)
			{
				if (filteredArgs[i] == "-c" && i < filteredArgs.Length - 1 && !string.IsNullOrEmpty(filteredArgs[i + 1]))
				{
					PathConfig = filteredArgs[i + 1];
					if (File.Exists(PathConfig))
					{
						return PathConfig;
					}
				}
			}
			string currDir = String.IsNullOrEmpty(EmulatorLauncher.WorkingDirExe) ? Environment.CurrentDirectory : EmulatorLauncher.WorkingDirExe;
			PathConfig = Path.Combine(currDir, "retroarch.cfg");
			if (File.Exists(PathConfig))
			{
				return PathConfig;
			}

			PathConfig = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "retroarch.cfg");
			if (File.Exists(PathConfig))
			{
				return PathConfig;
			}

			return "";
		}



		public string[] ModifyReal(string[] args)
		{
			if(_matchModuleOnce && isTriggered) { return args; }


			if (IsConfigured() == false)
			{
				return args;
			}
			if(selectedInputDriver == "") return args;

			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
			string retroarchConfigPath = LocateRetroarchConfig(args);
			if(retroarchConfigPath == "")
			{
				return args;
			}

			isTriggered = true;

			string contentConfig = File.ReadAllText(retroarchConfigPath);

			if(selectedInputDriver != "")
			{
				string pattern = @"input_driver([ ]*)=([ ]*)""(.*?)""";

				RegexOptions options = RegexOptions.Multiline;
				options |= RegexOptions.IgnoreCase;
				Regex regex = new Regex(pattern, options);

				Match match = regex.Match(contentConfig);
				if (match.Success)
				{
					contentConfig = regex.Replace(contentConfig, $"input_driver = \"{selectedInputDriver}\"", 1);
				}
				else
				{
					contentConfig += "\n" + $"input_driver = \"{selectedInputDriver}\"";
				}
				

			}

			if (selectedPlayer1 != "")
			{
				string pattern = @"input_player1_mouse_index([ ]*)=([ ]*)""(.*?)""";

				RegexOptions options = RegexOptions.Multiline;
				options |= RegexOptions.IgnoreCase;
				Regex regex = new Regex(pattern, options);

				Match match = regex.Match(contentConfig);
				if (match.Success)
				{
					contentConfig = regex.Replace(contentConfig, $"input_player1_mouse_index = \"{selectedPlayer1}\"", 1);
				}
				else
				{
					contentConfig += "\n" + $"input_player1_mouse_index = \"{selectedPlayer1}\"";
				}
			}

			if (selectedPlayer2 != "")
			{
				string pattern = @"input_player2_mouse_index([ ]*)=([ ]*)""(.*?)""";

				RegexOptions options = RegexOptions.Multiline;
				options |= RegexOptions.IgnoreCase;
				Regex regex = new Regex(pattern, options);

				Match match = regex.Match(contentConfig);
				if (match.Success)
				{
					contentConfig = regex.Replace(contentConfig, $"input_player2_mouse_index = \"{selectedPlayer2}\"", 1);
				}
				else
				{
					contentConfig += "\n" + $"input_player2_mouse_index = \"{selectedPlayer2}\"";
				}
			}

			if (selectedPlayer3 != "")
			{
				string pattern = @"input_player3_mouse_index([ ]*)=([ ]*)""(.*?)""";

				RegexOptions options = RegexOptions.Multiline;
				options |= RegexOptions.IgnoreCase;
				Regex regex = new Regex(pattern, options);

				Match match = regex.Match(contentConfig);
				if (match.Success)
				{
					contentConfig = regex.Replace(contentConfig, $"input_player3_mouse_index = \"{selectedPlayer3}\"", 1);
				}
				else
				{
					contentConfig += "\n" + $"input_player3_mouse_index = \"{selectedPlayer3}\"";
				}
			}

			if (selectedPlayer4 != "")
			{
				string pattern = @"input_player4_mouse_index([ ]*)=([ ]*)""(.*?)""";

				RegexOptions options = RegexOptions.Multiline;
				options |= RegexOptions.IgnoreCase;
				Regex regex = new Regex(pattern, options);

				Match match = regex.Match(contentConfig);
				if (match.Success)
				{
					contentConfig = regex.Replace(contentConfig, $"input_player4_mouse_index = \"{selectedPlayer4}\"", 1);
				}
				else
				{
					contentConfig += "\n" + $"input_player4_mouse_index = \"{selectedPlayer4}\"";
				}
			}

			if(selectedInputDriver == "raw")
			{
				for (int i = 5; i <= 16; i++)
				{
					string pattern = @"input_player" + i.ToString() + @"_mouse_index([ ]*)=([ ]*)""(.*?)""";

					RegexOptions options = RegexOptions.Multiline;
					options |= RegexOptions.IgnoreCase;
					Regex regex = new Regex(pattern, options);

					Match match = regex.Match(contentConfig);
					if (match.Success)
					{
						contentConfig = regex.Replace(contentConfig, $"input_player{i}_mouse_index = \"100\"", 1);
					}
				}

			}


			File.WriteAllText(retroarchConfigPath, contentConfig);
			Thread.Sleep(100);


			if (!string.IsNullOrEmpty(argRowPlayer1))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer1="+argRowPlayer1);
			}
			if (!string.IsNullOrEmpty(argRowPlayer2))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer2=" + argRowPlayer2);
			}
			if (!string.IsNullOrEmpty(argRowPlayer3))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer3=" + argRowPlayer3);
			}
			if (!string.IsNullOrEmpty(argRowPlayer4))
			{
				filteredArgs = BigBoxUtils.AddFirstElementToArg(filteredArgs, "--rawplayer4=" + argRowPlayer4);
			}


			args = BigBoxUtils.AddFirstElementToArg(filteredArgs, exeArg);


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
			_priority = Options["priority"];
			//_forceDefaultNoFilter = Options["forceDefaultNoFilter"] == "yes" ? true : false;
			//_forceDefaultNoMatch = Options["forceDefaultNoMatch"] == "yes" ? true : false;

			_matchModuleOnce = Options["matchModuleOnce"] == "yes" ? true : false;
			_enablegun1 = Options["enablegun1"] == "yes" ? true : false;
			_enablegun2 = Options["enablegun2"] == "yes" ? true : false;
			_enablegun3 = Options["enablegun3"] == "yes" ? true : false;
			_enablegun4 = Options["enablegun4"] == "yes" ? true : false;

			_restrictgun1 = Options["restrictgun1"];
			_restrictgun2 = Options["restrictgun2"];
			_restrictgun3 = Options["restrictgun3"];
			_restrictgun4 = Options["restrictgun4"];
		}

		public void SetDefaultRetroarchConfig()
		{
			selectedInputDriver = "dinput";
			selectedPlayer1 = "0";
			selectedPlayer2 = "1";
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
			var mouseList = MouseIndexRetroarch.ListMouse();

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
					if (!isMatch && PriorityElem.ToLower()=="sidenblue" && mouse.Path.ToUpper().Contains("VID_16C0&PID_0F01"))
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
						/*
						playerFound++;
						selectedInputDriver = "raw";
						if (playerFound == 1)
						{
							selectedPlayer1 = (mouse.Index - 1).ToString();
							selectedPlayer2 = mouse.Index.ToString();
							argRowPlayer1 = MouseIndexRetroarch.SanitizeForCommand(PriorityElem.Trim());
						}
						if(playerFound == 2)
						{
							selectedPlayer2 = (mouse.Index - 1).ToString();
							argRowPlayer2 = MouseIndexRetroarch.SanitizeForCommand(PriorityElem.Trim());
						}
						*/
						priorityResult.Add(PriorityElem.Trim(), (mouse.Index - 1).ToString());


					}
				}

				//if (playerFound >= 2) break;
			}


			if (_enablegun1)
			{
				if (string.IsNullOrEmpty(_restrictgun1))
				{
					if(priorityResult.Count > 0)
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
					foreach(var restrictgun in restrictgun1_array)
					{
						string restrictgun_val = restrictgun.Trim();
						if (string.IsNullOrEmpty(restrictgun_val)) continue;
						restrictgun_list.Add(restrictgun_val);
					}

					string foundkey = "";
					foreach(var pgun in priorityResult)
					{
						if (restrictgun_list.Contains(pgun.Key))
						{
							selectedPlayer1 = pgun.Value;
							argRowPlayer1 = MouseIndexRetroarch.SanitizeForCommand(pgun.Key);
							foundkey = pgun.Key;
							break;
						}
					}
					if(foundkey != "") priorityResult.Remove(foundkey);
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
							selectedPlayer2= pgun.Value;
							argRowPlayer2 = MouseIndexRetroarch.SanitizeForCommand(pgun.Key);
							foundkey = pgun.Key;
							break;
						}
					}
					if (foundkey != "") priorityResult.Remove(foundkey);
				}
			}

			if (_enablegun3)
			{
				if (string.IsNullOrEmpty(_restrictgun3))
				{
					if (priorityResult.Count > 0)
					{
						var gun = priorityResult.First();
						selectedPlayer3 = gun.Value;
						argRowPlayer3 = MouseIndexRetroarch.SanitizeForCommand(gun.Key);
						string key = gun.Key;
						priorityResult.Remove(key);
					}
				}
				else
				{
					var restrictgun1_array = BigBoxUtils.explode(_restrictgun3, ",");
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
							selectedPlayer3 = pgun.Value;
							argRowPlayer3 = MouseIndexRetroarch.SanitizeForCommand(pgun.Key);
							foundkey = pgun.Key;
							break;
						}
					}
					if (foundkey != "") priorityResult.Remove(foundkey);
				}
			}

			if (_enablegun4)
			{
				if (string.IsNullOrEmpty(_restrictgun3))
				{
					if (priorityResult.Count > 0)
					{
						var gun = priorityResult.First();
						selectedPlayer4 = gun.Value;
						argRowPlayer4 = MouseIndexRetroarch.SanitizeForCommand(gun.Key);
						string key = gun.Key;
						priorityResult.Remove(key);
					}
				}
				else
				{
					var restrictgun1_array = BigBoxUtils.explode(_restrictgun4, ",");
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
							selectedPlayer4 = pgun.Value;
							argRowPlayer4 = MouseIndexRetroarch.SanitizeForCommand(pgun.Key);
							foundkey = pgun.Key;
							break;
						}
					}
					if (foundkey != "") priorityResult.Remove(foundkey);
				}
			}

			if (selectedPlayer1 != "" || selectedPlayer2 != "" || selectedPlayer3 != "" || selectedPlayer4 != "")
			{
				selectedInputDriver = "raw";
				if (selectedPlayer1 == "") selectedPlayer1 = "100";
				if (selectedPlayer2 == "") selectedPlayer2 = "100";
				if (selectedPlayer3 == "") selectedPlayer3 = "100";
				if (selectedPlayer4 == "") selectedPlayer4 = "100";

			}

			//if(selectedInputDriver == "" && _forceDefaultNoMatch) SetDefaultRetroarchConfig();




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
			if (argRowPlayer3 != "")
			{
				string argtofilter = "--rawplayer3=" + argRowPlayer3;
				argtofilter = argtofilter.ToLower();
				arglistarr = BigBoxUtils.AddFirstElementToArg(arglistarr, argtofilter);
			}
			if (argRowPlayer4 != "")
			{
				string argtofilter = "--rawplayer4=" + argRowPlayer4;
				argtofilter = argtofilter.ToLower();
				arglistarr = BigBoxUtils.AddFirstElementToArg(arglistarr, argtofilter);
			}

			return arglistarr;
		}


	}
}
