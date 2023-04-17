using AutoHotkey.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
			if(_targetType == "Custom Exe") description += " : " + _target.Trim();
			if (_targetType == "Regex") description += " : " + _regex.Trim();

			description += $"[ Timeout={_timeout}, Wait={_wait} ]";

			if (_filter != "") description += $" [Only if command line contains {_filter}]";
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
			_target= Options["target"];
			_regex = Options["regex"];
			_timeout = Options["timeout"];
			_wait = Options["wait"];

		}

		public void ExecuteBefore(string[] args)
		{

			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd.Contains(_filter))
			{
				return;
			}

			string executable = "";
			if(_targetType == "Emulator Exe")
			{
				executable = Path.GetFileName(args[0]);
			}
			if(_targetType == "Custom Exe")
			{
				executable = _target;
			}
			if(_targetType == "Regex")
			{
				var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
				foreach (var elem in filteredArgs)
				{
					RegexOptions options = RegexOptions.Multiline;
					options |= RegexOptions.IgnoreCase;
					Regex regex = new Regex(_regex, options);
					string result = regex.Replace(elem, MatchEvaluator);
					if(result != elem)
					{
						executable= result;
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

	}
}
