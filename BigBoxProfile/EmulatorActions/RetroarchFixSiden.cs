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

		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private string _priority = "";

		private bool _forceDefaultNoFilter = false;
		private bool _forceDefaultNoMatch = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		private string appendConfig = "";
		private string selectedInputDriver = "";
		private string selectedPlayer1 = "";
		private string selectedPlayer2 = "";
		private string argRowPlayer1 = "";
		private string argRowPlayer2 = "";
		private bool filtersOk = false;


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

				Options["priority"] = frm.priority.Trim();

				if (frm.forceDefaultNoFilter) Options["forceDefaultNoFilter"] = "yes";
				else Options["forceDefaultNoFilter"] = "no";

				if (frm.forceDefaultNoMatch) Options["forceDefaultNoMatch"] = "yes";
				else Options["forceDefaultNoMatch"] = "no";

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

			if (Options.ContainsKey("priority") == false) Options["priority"] = "SidenBlue,SidenRed,SidenBlack,SidenPlayer2";

			if (Options.ContainsKey("forceDefaultNoFilter") == false) Options["forceDefaultNoFilter"] = "no";
			if (Options.ContainsKey("forceDefaultNoMatch") == false) Options["forceDefaultNoMatch"] = "no";
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
				
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_exclude != "") description += $" [Exclude {_exclude}]";

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

			PathConfig = Path.Combine(Environment.CurrentDirectory, "retroarch.cfg");
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
			_priority = Options["priority"];
			_forceDefaultNoFilter = Options["forceDefaultNoFilter"] == "yes" ? true : false;
			_forceDefaultNoMatch = Options["forceDefaultNoMatch"] == "yes" ? true : false;
		}

		public void SetDefaultRetroarchConfig()
		{
			selectedInputDriver = "dinput";
			selectedPlayer1 = "0";
			selectedPlayer2 = "1";
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
					if (!filter_found)
					{
						if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
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
					if (filter_found)
					{
						if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						if (_forceDefaultNoFilter) SetDefaultRetroarchConfig();
						return;
					}
				}
			}
			//filterend
			filtersOk = true;
			int playerFound = 0;
			var priority_array = BigBoxUtils.explode(_priority, ",");
			var mouseList = MouseIndexRetroarch.ListMouse();

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
					}
				}

				if (playerFound >= 2) break;

			}

			if(selectedInputDriver == "" && _forceDefaultNoMatch) SetDefaultRetroarchConfig();




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
