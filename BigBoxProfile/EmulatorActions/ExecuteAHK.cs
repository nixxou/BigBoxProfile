using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace BigBoxProfile.EmulatorActions
{
	internal class ExecuteAHK : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public ExecuteAHK()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "ExecuteAHK";

		private string _filter = "";
		private string _ahkCodeExemple = "";
		private string _ahkCodeReal = "";
		private string _ahkCodeBefore = "";
		private string _ahkCodeAfter = "";

		private bool _runbeforebackground = false;

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new ExecuteAHK();
		}

		public void Configure()
		{

			var frm = new ExecuteAHK_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["filter"] = frm.filter.Trim();
				Options["ahkCodeExemple"] = frm.ahkCodeExemple.Trim();
				Options["ahkCodeReal"] = frm.ahkCodeReal.Trim();
				Options["ahkCodeBefore"] = frm.ahkCodeBefore.Trim();
				Options["ahkCodeAfter"] = frm.ahkCodeAfter.Trim();

				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				if (frm.runbeforebackground) Options["runbeforebackground"] = "yes";
				else Options["runbeforebackground"] = "no";

				UpdateConfig();
			}


		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("ahkCodeExemple") == false) Options["ahkCodeExemple"] = "";
			if (Options.ContainsKey("ahkCodeReal") == false) Options["ahkCodeReal"] = "";
			if (Options.ContainsKey("ahkCodeBefore") == false) Options["ahkCodeBefore"] = "";
			if (Options.ContainsKey("ahkCodeAfter") == false) Options["ahkCodeAfter"] = "";
			if (Options.ContainsKey("runbeforebackground") == false) Options["runbeforebackground"] = "no";

			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
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
				description = "Execute user definited ahk code";
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

		private string[] AhkExecute(string[] args, string code)
		{
			var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
			string ahk_prefixMemory = @"
class JSON
{
	class parse extends JSON.functor
	{
		call(self, ByRef param_string, param_reviver:="""")
		{
			this.rev := isObject(param_reviver) ? param_reviver : false
			; Object keys(and array indices) are temporarily stored in arrays so that
			; we can enumerate them in the order they appear in the string instead
			; of alphabetically. Skip if no reviver function is specified.
			this.keys := this.rev ? {} : false

			static quot := chr(34), bashq := ""\"" quot
				, json_value := quot ""{[01234567890-tfn""
				, json_value_or_array_closing := quot ""{[]01234567890-tfn""
				, object_key_or_object_closing := quot ""}""

			key := """"
			is_key := false
			root := {}
			stack := [root]
			next := json_value
			pos := 0

			while ((ch := subStr(param_string, ++pos, 1)) != """") {
				if inStr("" `t`r`n"", ch) {
					continue
				}
				if !inStr(next, ch, 1) {
					this.parseError(next, param_string, pos)
				}

				holder := stack[1]
				is_array := holder.IsArray

				if inStr("",:"", ch) {
					next := (is_key := !is_array && ch == "","") ? quot : json_value

				} else if (inStr(""}]"", ch)) {
					objRemoveAt(stack, 1)
					next := stack[1]==root ? """" : stack[1].IsArray ? "",]"" : "",}""

				} else {
					if (inStr(""{["", ch)) {
					; Check if Array() is overridden and if its return value has
					; the 'IsArray' property. If so, Array() will be called normally,
					; otherwise, use a custom base object for arrays
					static json_array := func(""Array"").isBuiltIn || ![].IsArray ? {IsArray: true} : 0

					; sacrifice readability for minor(actually negligible) performance gain
						(ch == ""{"")
							? ( is_key := true
							  , value := {}
							  , next := object_key_or_object_closing )
						; ch == ""[""
							: ( value := json_array ? new json_array : []
							  , next := json_value_or_array_closing )

						ObjInsertAt(stack, 1, value)

						if (this.keys) {
							this.keys[value] := []
						}
					} else {
						if (ch == quot) {
							i := pos
							while (i := inStr(param_string, quot,, i+1)) {
								value := strReplace(subStr(param_string, pos+1, i-pos-1), ""\\"", ""\u005c"")

								static tail := A_AhkVersion<""2"" ? 0 : -1
								if (subStr(value, tail) != ""\"") {
									break
								}
							}

							if (!i) {
								this.parseError(""'"", param_string, pos)
							}

							value := strReplace(value, ""\/"",  ""/"")
							, value := strReplace(value, bashq, quot)
							, value := strReplace(value, ""\b"", ""`b"")
							, value := strReplace(value, ""\f"", ""`f"")
							, value := strReplace(value, ""\n"", ""`n"")
							, value := strReplace(value, ""\r"", ""`r"")
							, value := strReplace(value, ""\t"", ""`t"")

							pos := i ; update pos

							i := 0
							while (i := inStr(value, ""\"",, i+1)) {
								if (!(subStr(value, i+1, 1) == ""u"")) {
									this.parseError(""\"", param_string, pos - strLen(subStr(value, i+1)))
								}

								uffff := Abs(""0x"" subStr(value, i+2, 4))
								if (A_IsUnicode || uffff < 0x100) {
									value := subStr(value, 1, i-1) chr(uffff) subStr(value, i+6)
								}
							}

							if (is_key) {
								key := value, next := "":""
								continue
							}

						} else {
							value := subStr(param_string, pos, i := regExMatch(param_string, ""[\]\},\s]|$"",, pos)-pos)

							if value is number
							{
								if value is integer
								{
									value += 0
								}
							}
							else if (value == ""true"" || value == ""false"") {
								value := %value% + 0
							} else if (value == ""null"") {
								value := """"
							} else {
								; we can do more here to pinpoint the actual culprit
								; but that's just too much extra work.
								this.parseError(next, text, pos, i)
							}
							pos += i - 1
						}
						next := holder == root ? """" : is_array ? "",]"" : "",}""
					} ; If inStr(""{["", ch) { ... } else

					is_array? key := objPush(holder, value) : holder[key] := value

					if (this.keys && this.keys.hasKey(holder)) {
						this.keys[holder].Push(key)
					}
				}
			} ; while ( ... )
			return this.rev ? this.walk(root, """") : root[""""]
		}

		parseError(param_expect, ByRef param_string, pos, param_length:=1)
		{
			static quot := chr(34), qurly := quot ""}""

			line := strSplit(subStr(param_string, 1, pos), ""`n"", ""`r"").length()
			col := pos - inStr(param_string, ""`n"",, -(strLen(param_string)-pos+1))
			msg := format(""{1}`n`nLine:`t{2}`nCol:`t{3}`nChar:`t{4}""
				, (param_expect == """")     ?	""Extra data""
				: (param_expect == ""'"")    ?	""Unterminated string starting at""
				: (param_expect == ""\"")    ?	""Invalid \escape""
				: (param_expect == "":"")    ?	""Expecting ':' delimiter""
				: (param_expect == quot)   ?	""Expecting object key enclosed in double quotes""
				: (param_expect == qurly)  ?	""Expecting object key enclosed in double quotes or object closing '}'""
				: (param_expect == "",}"")   ?	""Expecting ',' delimiter or object closing '}'""
				: (param_expect == "",]"")   ?	""Expecting ',' delimiter or array closing ']'""
				: inStr(param_expect, ""]"") ?	""Expecting JSON value or array closing ']'""
				:								""Expecting JSON value(string, number, true, false, null, object or array)""
			, line, col, pos)

			static offset := A_AhkVersion < ""2"" ? -3 : -4
			throw Exception(msg, offset, subStr(param_string, pos, param_length))
		}

		walk(param_holder, param_key)
		{
			value := param_holder[param_key]
			if (isObject(value)) {
				for i, k in this.keys[value] {
					; check if objhasKey(value, k) ??
					v := this.walk(value, k)
					if (v != JSON.Undefined) {
						value[k] := v
					} else {
						objDelete(value, k)
					}
				}
			}
			return this.rev.call(param_holder, param_key, value)
		}
	}


	class stringify extends JSON.functor
	{
		call(self, param_value, param_replacer:="""", space:="""")
		{
			this.rep := isObject(param_replacer) ? param_replacer : """"

			this.gap := """"
			if (space) {
				if space is integer
				{
					loop, % ((n := Abs(space))>10 ? 10 : n) {
						this.gap .= "" ""
					}
				} else {
					this.gap := subStr(space, 1, 10)
				}
				this.indent := ""`n""
			}
			return this.str({"""": param_value}, """")
		}

		str(param_holder, param_key)
		{
			param_value := param_holder[param_key]

			if (this.rep) {
				param_value := this.rep.call(param_holder, param_key, objhasKey(param_holder, param_key) ? param_value : JSON.Undefined)
			}

			if isObject(param_value) {
			; Check object type, skip serialization for other object types such as
			; ComObject, Func, BoundFunc, FileObject, RegExMatchObject, Property, etc.
				static type := A_AhkVersion<""2"" ? """" : func(""Type"")
				if (type ? type.call(param_value) == ""Object"" : objGetCapacity(param_value) != """") {
					if (this.gap) {
						stepback := this.indent
						this.indent .= this.gap
					}

					is_array := param_value.IsArray
					; Array() is not overridden, rollback to old method of
					; identifying array-like objects. Due to the use of a for-loop
					; sparse arrays such as '[1,,3]' are detected as objects({}).
					if (!is_array) {
						for i in param_value {
							is_array := i == A_Index
						}
						until (!is_array)
					}

					str := """"
					if (is_array) {
						loop, % param_value.length() {
							if (this.gap) {
								str .= this.indent
							}
							v := this.str(param_value, A_Index)
							str .= (v != """") ? v "","" : ""null,""
						}
					} else {
						colon := this.gap ? "": "" : "":""
						for k in param_value {
							v := this.str(param_value, k)
							if (v != """") {
								if (this.gap) {
									str .= this.indent
								}
								str .= this.quote(k) colon v "",""
							}
						}
					}

					if (str != """") {
						str := rTrim(str, "","")
						if (this.gap) {
							str .= stepback
						}
					}

					if (this.gap) {
						this.indent := stepback
					}
					return is_array ? ""["" str ""]"" : ""{"" str ""}""
				}
			} else {
				; is_number ? param_value : ""param_value""
				return objGetCapacity([param_value], 1) == """" ? param_value : this.quote(param_value)
			}
		}

		quote(param_string)
		{
			static quot := chr(34), bashq := ""\"" quot

			if (param_string != """") {
				param_string := strReplace(param_string,  ""\"", ""\\"")
				; , param_string := strReplace(param_string,  ""/"",  ""\/"") ; optional in ECMAScript
				, param_string := strReplace(param_string, quot, bashq)
				, param_string := strReplace(param_string, ""`b"", ""\b"")
				, param_string := strReplace(param_string, ""`f"", ""\f"")
				, param_string := strReplace(param_string, ""`n"", ""\n"")
				, param_string := strReplace(param_string, ""`r"", ""\r"")
				, param_string := strReplace(param_string, ""`t"", ""\t"")

				static rx_escapable := A_AhkVersion<""2"" ? ""O)[^\x20-\x7e]"" : ""[^\x20-\x7e]""
				while regExMatch(param_string, rx_escapable, m) {
					param_string := strReplace(param_string, m.Value, format(""\u{1:04x}"", ord(m.Value)))
				}
			}
			return quot param_string quot
		}
	}

	class test extends JSON.functor
	{
		call(self, param_string:="""")
		{
			if (isObject(param_string) || param_string == """") {
				return false
			}

			try {
				JSON.parse(param_string)
			} catch error {
				return false
			}
			return true
		}
	}


	; For use with reviver and replacer functions since AutoHotkey does not
	; have an 'undefined' type. Returning blank("""") or 0 won't work since these
	; can't be distnguished from actual JSON values. This leaves us with objects.
	; Replacer() - the caller may return a non-serializable AHK objects such as
	; ComObject, Func, BoundFunc, FileObject, RegExMatchObject, and Property to
	; mimic the behavior of returning 'undefined' in JavaScript but for the sake
	; of code readability and convenience, it's better to do 'return JSON.Undefined'.
	; Internally, the property returns a ComObject with the variant type of VT_EMPTY.
	Undefined[]
	{
		get {
			static empty := {}, vt_empty := ComObject(0, &empty, 1)
			return vt_empty
		}
	}

	class functor
	{
		__call(param_method, ByRef param_args, param_extargs*)
		{
			; When casting to call(), use a new instance of the ""function object""
			; so as to avoid directly storing the properties(used across sub-methods)
			; into the ""function object"" itself.
			if isObject(param_method) {
				return (new this).call(param_method, param_args, param_extargs*)
			} else if (param_method == """") {
				return (new this).call(param_args, param_extargs*)
			}
		}
	}
}

ChangeObjToString(obj)
{
	if (!IsObject(obj))
		return obj
	str := ""`n{""
	for key, value in obj
		str .= ""`n"" key "": "" ChangeObjToString(value) "",""
	return str ""`n}""
}

gameDataJson =
(
" + BigBoxUtils.GameInfoJSON + @"
)

if(Json.test(resumeJson)){
	gameData := JSON.parse(resumeJson,true)
}
else{
	gameData := {}
}
gameDataString := ChangeObjToString(gameDataString)
";

			string ahk_code = ahk_prefixMemory + @"
Array(items*) {
	items.base := ArrayEx
	return items
}

class ArrayEx
{
	join(sep := "","") {
		for k, v in this {
			out .= sep v
		}
		return SubStr(out, StrLen(sep)+1)
	}
}
Args := []
";

			int i = 0;
			foreach (var arg in args)
			{
				ahk.SetVar($"arg{i}", arg);
				ahk_code += $@"Args.Insert({i}, arg{i})";
				ahk_code += "\n";
				i++;
			}

			ahk_code += "\n";
			ahk_code += "OriginalArgs := []";
			ahk_code += "\n";
			if(EmulatorLauncher.OriginalArgs != null)
			{
				int y = 0;
				foreach (var arg in EmulatorLauncher.OriginalArgs)
				{
					ahk.SetVar($"originalarg{y}", arg);
					ahk_code += $@"OriginalArgs.Insert({y}, originalarg{y})";
					ahk_code += "\n";
					y++;
				}
			}


			ahk_code += code;
			ahk_code += "\n";
			ahk_code += @"resultatfinal := Args.join(""|||"")";



			//ahk_code += "\n";
			//ahk_code += "MsgBox, %resultatfinal%";
			try
			{
				ahk.ExecRaw(ahk_code);
				string resultatfinal = ahk.GetVar("resultatfinal");
				args = BigBoxUtils.explode(resultatfinal, "|||");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


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


			if (_ahkCodeExemple != "") return AhkExecute(args, _ahkCodeExemple);
			return args;
		}
		public string[] Modify(string[] args)
		{

			return args;
		}



		public string[] ModifyReal(string[] args)
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

			if (_ahkCodeReal != "") return AhkExecute(args, _ahkCodeReal);
			return args;
		}

		private void UpdateConfig()
		{
			_filter = Options["filter"];
			_ahkCodeExemple = Options["ahkCodeExemple"];
			_ahkCodeReal = Options["ahkCodeReal"];
			_ahkCodeBefore = Options["ahkCodeBefore"];
			_ahkCodeAfter = Options["ahkCodeAfter"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
			_runbeforebackground = Options["runbeforebackground"] == "yes" ? true : false;
		}

		public void ExecuteBefore(string[] args)
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

			//if (_ahkCodeBefore != "") AhkExecute(args, _ahkCodeBefore);
			if (_ahkCodeBefore != "")
			{
				if(_runbeforebackground) Task.Run(() => AhkExecute(args, _ahkCodeBefore));
				else AhkExecute(args, _ahkCodeBefore);
			}

		}
		public void ExecuteAfter(string[] args)
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

			if (_ahkCodeAfter != "") AhkExecute(args, _ahkCodeAfter);
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
