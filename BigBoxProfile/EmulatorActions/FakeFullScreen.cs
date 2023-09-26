using AutoHotkey.Interop;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class FakeFullScreen : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;


		public FakeFullScreen()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "FakeFullScreen";

		private string _targetType = "";
		private string _filter = "";
		private string _target = "";
		private string _regex = "";
		private string _timeout = "";
		private string _wait = "";

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new FakeFullScreen();
		}

		public void Configure()
		{
			var frm = new FakeFullScreen_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{

				Options["targetType"] = frm.targetType.Trim();
				Options["filter"] = frm.filter.Trim();
				Options["regex"] = frm.regex;
				Options["timeout"] = frm.timeout.Trim();
				Options["wait"] = frm.wait.Trim();
				Options["target"] = frm.target.Trim();

				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				UpdateConfig();
			}
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("targetType") == false) Options["targetType"] = "Emulator Exe";
			if (Options.ContainsKey("target") == false) Options["target"] = "";
			if (Options.ContainsKey("regex") == false) Options["regex"] = "";
			if (Options.ContainsKey("timeout") == false) Options["timeout"] = "5";
			if (Options.ContainsKey("wait") == false) Options["wait"] = "1";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";

			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";
			UpdateConfig();
		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "Maximize ";
			description += _targetType.Trim();
			if (_targetType == "Custom Exe") description += " : " + _target.Trim();
			if (_targetType == "Regex") description += " : " + _regex.Trim();

			description += $"[ Timeout={_timeout}, Wait={_wait} ]";

			if (_filter != "") description += $" [Only if command line contains {_filter}]";
			if (_exclude != "") description += $" [Exclude {_exclude}]";

			return $"{ModuleName} => {description}";



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
			_targetType = Options["targetType"];
			_target = Options["target"];
			_regex = Options["regex"];
			_timeout = Options["timeout"];
			_wait = Options["wait"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
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

			string executable = "";
			if (_targetType == "Emulator Exe")
			{
				executable = Path.GetFileName(args[0]);
			}
			if (_targetType == "Custom Exe")
			{
				executable = _target;
			}
			if (_targetType == "Regex")
			{
				var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
				foreach (var elem in filteredArgs)
				{
					RegexOptions options = RegexOptions.Multiline;
					options |= RegexOptions.IgnoreCase;
					Regex regex = new Regex(_regex, options);
					string result = regex.Replace(elem, MatchEvaluator);
					if (result != elem)
					{
						executable = result;
						break;
					}
				}
			}


			if (string.IsNullOrEmpty(executable)) return;



			string ahk_code = $@"
ToggleFakeFullscreen()
{{
	CoordMode Screen, Window
	static WINDOW_STYLE_UNDECORATED := -0xC40000
	static savedInfo := Object() ;; Associative array!
	;WinGet, id, ID, A
	id := WinExist(""ahk_exe {executable}"")
	if (savedInfo[id])
	{{
		inf := savedInfo[id]
		WinSet, Style, % inf[""style""], ahk_id %id%
		WinMove, ahk_id %id%,, % inf[""x""], % inf[""y""], % inf[""width""], % inf[""height""]
		savedInfo[id] := """"
	}}
	else
	{{
		savedInfo[id] := inf := Object()
		WinGet, ltmp, Style, A
		inf[""style""] := ltmp
		WinGetPos, ltmpX, ltmpY, ltmpWidth, ltmpHeight, ahk_id %id%
		inf[""x""] := ltmpX
		inf[""y""] := ltmpY
		inf[""width""] := ltmpWidth
		inf[""height""] := ltmpHeight
		WinSet, Style, %WINDOW_STYLE_UNDECORATED%, ahk_id %id%
		SysGet, mon, MonitorPrimary
		SysGet, mon, Monitor, %mon%
		WinMove, ahk_id %id%,, %monLeft%, %monTop%, % monRight-monLeft, % monBottom-monTop
	}}
}}
timeout := {_timeout}  ; définir le timeout en secondes
WinWait, ahk_exe {executable},, %timeout%  ; attendre la fenêtre de l'application pendant le timeout donné
if !ErrorLevel  ; vérifier si la fenêtre n'a pas été trouvée
{{
	Sleep {_wait}000
	ToggleFakeFullscreen()
}}

";

			AutoHotkeyEngine ahk = new AutoHotkeyEngine();
			Task.Run(() => ahk.ExecRaw(ahk_code));


		}
		public void ExecuteAfter(string[] args)
		{

		}

		private string MatchEvaluator(Match match)
		{
			GroupCollection groups = match.Groups;

			string replaceWith = @"\1";
			for (int i = 1; i <= groups.Count; i++)
			{
				replaceWith = replaceWith.Replace($"\\{i}", groups[i].Value);
			}

			return replaceWith;
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
