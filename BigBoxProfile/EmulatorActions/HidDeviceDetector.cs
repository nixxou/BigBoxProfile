using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class HidDeviceDetector : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public HidDeviceDetector()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "HidDeviceDetector";

		private string _filter = "";

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;

		private int _numController = 4;
		private int _numLightgun = 2;
		private int _numWheel = 1;
		private int _numOther = 100;
		private string _prefixController = "--controller%NUM%=";
		private string _prefixLightgun = "--lightgun%NUM%=";
		private string _prefixWheel = "--wheel%NUM%=";
		private string _prefixOther = "";
		private bool _forceRemoveArgController = false;
		private bool _forceRemoveArgWheel = false;
		private bool _forceRemoveArgLightgun = false;
		private bool _forceRemoveArgOther = false;
		private string _ds4winLogPath = "";
		private string _priorityData = "";
		private List<HIDMatcher> _matchers = new List<HIDMatcher>();

		private List<string> argsToFilterOut = new List<string>();

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new HidDeviceDetector();
		}

		public void Configure()
		{
			var frm = new HidDeviceDetector_Config(this.Options);
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

				Options["numController"] = frm.numController.ToString();
				Options["numLightgun"] = frm.numLightgun.ToString();
				Options["numWheel"] = frm.numWheel.ToString();
				Options["numOther"] = frm.numOther.ToString();

				Options["prefixController"] = frm.prefixController.Trim();
				Options["prefixLightgun"] = frm.prefixLightgun.Trim();
				Options["prefixWheel"] = frm.prefixWheel.Trim();
				Options["prefixOther"] = frm.prefixOther.Trim();

				if (frm.forceRemoveArgController) Options["forceRemoveArgController"] = "yes";
				else Options["forceRemoveArgController"] = "no";
				if (frm.forceRemoveArgWheel) Options["forceRemoveArgWheel"] = "yes";
				else Options["forceRemoveArgWheel"] = "no";
				if (frm.forceRemoveArgLightgun) Options["forceRemoveArgLightgun"] = "yes";
				else Options["forceRemoveArgLightgun"] = "no";
				if (frm.forceRemoveArgOther) Options["forceRemoveArgOther"] = "yes";
				else Options["forceRemoveArgOther"] = "no";

				Options["ds4winLogPath"] = frm.ds4winLogPath.Trim();
				Options["priorityData"] = frm.priorityData.Trim();

				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("as_arg") == false) Options["as_arg"] = "yes";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			if (Options.ContainsKey("matchAllFilter") == false) Options["matchAllFilter"] = "no";
			if (Options.ContainsKey("matchAllExclude") == false) Options["matchAllExclude"] = "no";

			if (Options.ContainsKey("numController") == false) Options["numController"] = "4";
			if (Options.ContainsKey("numLightgun") == false) Options["numLightgun"] = "2";
			if (Options.ContainsKey("numWheel") == false) Options["numWheel"] = "1";
			if (Options.ContainsKey("numOther") == false) Options["numOther"] = "100";

			if (Options.ContainsKey("prefixController") == false) Options["prefixController"] = "--controller%NUM%=";
			if (Options.ContainsKey("prefixLightgun") == false) Options["prefixLightgun"] = "--lightgun%NUM%=";
			if (Options.ContainsKey("prefixWheel") == false) Options["prefixWheel"] = "--wheel%NUM%=";
			if (Options.ContainsKey("prefixOther") == false) Options["prefixOther"] = "";

			if (Options.ContainsKey("forceRemoveArgController") == false) Options["forceRemoveArgController"] = "no";
			if (Options.ContainsKey("forceRemoveArgWheel") == false) Options["forceRemoveArgWheel"] = "no";
			if (Options.ContainsKey("forceRemoveArgLightgun") == false) Options["forceRemoveArgLightgun"] = "no";
			if (Options.ContainsKey("forceRemoveArgOther") == false) Options["forceRemoveArgOther"] = "no";

			if (Options.ContainsKey("ds4winLogPath") == false) Options["ds4winLogPath"] = "";
			if (Options.ContainsKey("priorityData") == false) Options["priorityData"] = "";


			UpdateConfig();

		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "";

			string matchall = "";
			string matchallexclude = "";
			if (_matchAllFilter) matchall = "[matchall=on]";
			if (_matchAllExclude) matchallexclude = "[matchall=on]";

			if (_filter != "") description += $" [Only if command line contains {_filter}]{matchall}";
			if (_exclude != "") description += $" [Exclude {_exclude}]{matchallexclude}";

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


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
			HIDInfo.ClearCache();

			List<string> argsController = new List<string>();
			List<string> argsLightgun = new List<string>();
			List<string> argsWheel = new List<string>();
			List<string> argsOther = new List<string>();

			int current_controller = 0;
			int current_lightgun = 0;
			int current_wheel = 0;
			int current_other = 0;

			foreach(var matcher in _matchers)
			{
				string type = matcher.DeviceType;
				if(type == "controller" && current_controller < _numController)
				{
					var result = matcher.isMatching(false, _ds4winLogPath);
					if (result != null)
					{
						foreach (var suffix in result)
						{
							current_controller++;
							string prefix = _prefixController;
							string fullarg = prefix + suffix;
							fullarg = fullarg.Replace("%NUM%", current_controller.ToString()).Trim();
							if (!argsController.Contains(fullarg))
							{
								argsController.Add(fullarg);
							}
							if (current_controller >= _numController) break;
						}
					}
				}
				if (type == "lightgun" && current_lightgun < _numLightgun)
				{
					var result = matcher.isMatching(false, _ds4winLogPath);
					if (result != null)
					{
						foreach (var suffix in result)
						{
							current_lightgun++;
							string prefix = _prefixLightgun;
							string fullarg = prefix + suffix;
							fullarg = fullarg.Replace("%NUM%", current_lightgun.ToString()).Trim();
							if (!argsLightgun.Contains(fullarg))
							{
								argsLightgun.Add(fullarg);
							}
							if (current_lightgun >= _numLightgun) break;
						}
						
					}
				}
				if (type == "wheel" && current_wheel < _numWheel)
				{
					var result = matcher.isMatching(false, _ds4winLogPath);
					if (result != null)
					{
						foreach (var suffix in result)
						{
							current_wheel++;
							string prefix = _prefixWheel;
							string fullarg = prefix + suffix;
							fullarg = fullarg.Replace("%NUM%", current_wheel.ToString()).Trim();
							if (!argsWheel.Contains(fullarg))
							{
								argsWheel.Add(fullarg);
							}
							if (current_wheel >= _numWheel) break;
						}
						
					}
				}
				if (type == "other" && current_other < _numOther)
				{
					var result = matcher.isMatching(false, _ds4winLogPath);
					if (result != null)
					{
						foreach (var suffix in result)
						{
							current_other++;
							string prefix = _prefixOther;
							string fullarg = prefix + suffix;
							fullarg = fullarg.Replace("%NUM%", current_other.ToString()).Trim();
							if (!argsOther.Contains(fullarg))
							{
								argsOther.Add(fullarg);
							}
							if (current_other >= _numOther) break;
						}
					}
				}
			}

			
			List<string> argsFinalList = new List<string>();

			foreach(var a in argsController)
			{
				if (_forceRemoveArgController && !argsToFilterOut.Contains(a.ToLower().Trim())) argsToFilterOut.Add(a.ToLower().Trim());
				if(!argsFinalList.Contains(a)) argsFinalList.Add(a);
			}
			foreach (var a in argsLightgun)
			{
				if (_forceRemoveArgLightgun && !argsToFilterOut.Contains(a.ToLower().Trim())) argsToFilterOut.Add(a.ToLower().Trim());
				if (!argsFinalList.Contains(a)) argsFinalList.Add(a);
			}
			foreach (var a in argsWheel)
			{
				if (_forceRemoveArgWheel && !argsToFilterOut.Contains(a.ToLower().Trim())) argsToFilterOut.Add(a.ToLower().Trim());
				if (!argsFinalList.Contains(a)) argsFinalList.Add(a);
			}
			foreach (var a in argsOther)
			{
				if (_forceRemoveArgOther && !argsToFilterOut.Contains(a.ToLower().Trim())) argsToFilterOut.Add(a.ToLower().Trim());
				if (!argsFinalList.Contains(a)) argsFinalList.Add(a);
			}

			List<string> newArgs = new List<string>();
			foreach (var a in args)
			{
				newArgs.Add(a);
			}
            foreach (var a in argsFinalList)
			{
				newArgs.Add(a);
			}
            args = newArgs.ToArray();


            return args;
		}




		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
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

			int tempVal = 0;
			if (Int32.TryParse(Options["numController"],out tempVal)) _numController = tempVal;
			if (Int32.TryParse(Options["numLightgun"], out tempVal)) _numLightgun = tempVal;
			if (Int32.TryParse(Options["numWheel"], out tempVal)) _numWheel = tempVal;
			if (Int32.TryParse(Options["numOther"], out tempVal)) _numOther = tempVal;

			_prefixController = Options["prefixController"];
			_prefixLightgun = Options["prefixLightgun"];
			_prefixWheel = Options["prefixWheel"];
			_prefixOther = Options["prefixOther"];

			_forceRemoveArgController = Options["forceRemoveArgController"] == "yes" ? true : false;
			_forceRemoveArgWheel = Options["forceRemoveArgWheel"] == "yes" ? true : false;
			_forceRemoveArgLightgun = Options["forceRemoveArgLightgun"] == "yes" ? true : false;
			_forceRemoveArgOther = Options["forceRemoveArgOther"] == "yes" ? true : false;

			_ds4winLogPath = Options["ds4winLogPath"];
			_priorityData = Options["priorityData"];

			if (!String.IsNullOrEmpty(_priorityData))
			{
				var priority_arr = BigBoxUtils.explode(_priorityData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new HIDMatcher(p);
					_matchers.Add(pObj);
				}
			}

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
			List<string> argsToRemove = new List<string>(argsToFilterOut.ToArray());
			if (_removeFilter)
			{
				foreach(var a in BigBoxUtils.MakeFilterListToRemove(_filter, _commaFilter))
				{
					argsToRemove.Add(a);
				}
			}
			return argsToRemove.ToArray();
		}
	}
}
