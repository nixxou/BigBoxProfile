using BigBoxProfile.EmulatorActions;
using CefSharp.DevTools.DOM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static XInput.Wrapper.X.Gamepad;

namespace BigBoxProfile
{
	public class VariableData
	{
		public string VariableName { get; set; }
		public string SourceData { get; set; }
		public string RegexToMatch { get; set; }
		public string VariableValue { get; set; }
		public string FallbackValue { get; set; }
		public string ahkCode { get; set; }


		public VariableData()
		{
			this.VariableName = "";
			this.VariableValue = "";
			this.RegexToMatch = "";
			this.SourceData = "arg";
			this.FallbackValue = "";
			this.ahkCode = "";
		}

		public VariableData(string json)
		{
			try
			{
				VariableData DeserializeData = JsonConvert.DeserializeObject<VariableData>(json);
				this.VariableName = DeserializeData.VariableName;
				this.VariableValue = DeserializeData.VariableValue;
				this.RegexToMatch = DeserializeData.RegexToMatch;
				this.SourceData = DeserializeData.SourceData;
				this.FallbackValue = DeserializeData.FallbackValue;
				this.ahkCode = DeserializeData.ahkCode;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public string[] ToStringArray()
		{
			var arrayString = new string[7];
			arrayString[0] = Serialize();
			arrayString[1] = this.VariableName;
			arrayString[2] = this.SourceData;
			arrayString[3] = this.RegexToMatch;
			arrayString[4] = this.VariableValue;
			arrayString[5] = this.FallbackValue;
			arrayString[6] = this.ahkCode;
			return arrayString;

		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}

		public string ReplaceVariable(string textIn, string[] argsData)
		{
			string textOut = textIn;
			if(SourceData == "ahk")
			{
				string resultatfinal = "";
				var ahk = new AutoHotkey.Interop.AutoHotkeyEngine();
				string ahk_code = BigBoxUtils.AHKGetPrefix();

				int i = 0;
				foreach (var arg in argsData)
				{
					ahk.SetVar($"arg{i}", arg);
					ahk_code += $@"Args.Insert({i}, arg{i})";
					ahk_code += "\n";
					i++;
				}

				ahk_code += "\n";
				if (EmulatorLauncher.OriginalArgs != null)
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


				ahk_code += ahkCode;
				try
				{
					ahk.ExecRaw(ahk_code);
					resultatfinal = ahk.GetVar("returnvalue");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

				RegexOptions optionsRemplace = RegexOptions.Multiline;
				optionsRemplace |= RegexOptions.IgnoreCase;
				optionsRemplace |= RegexOptions.Singleline;

				textOut = Regex.Replace(textOut, Regex.Escape(VariableName), resultatfinal, optionsRemplace);
				return textOut;
			}


			List<string> listeSource = new List<string>();
			if(SourceData == "cmd") listeSource.Add(BigBoxUtils.ArgsToCommandLine(argsData));
			if(SourceData == "arg") foreach(string arg in argsData) { listeSource.Add(arg); }
			if(SourceData != "cmd" && SourceData != "arg" && !String.IsNullOrEmpty(SourceData) && File.Exists(SourceData))
			{
				listeSource.Add(BigBoxUtils.ReadAllTextLockedFile(SourceData));
			}

			RegexOptions options = RegexOptions.Multiline;
			options |= RegexOptions.IgnoreCase;
			options |= RegexOptions.Singleline;

			bool foundMatch = false;
			string ReplaceTo = FallbackValue;
			foreach (var sourcetxt in listeSource)
			{
				if (!String.IsNullOrEmpty(sourcetxt))
				{
					Regex regex = new Regex(RegexToMatch, options);
					Match match = regex.Match(sourcetxt);
					foundMatch = match.Success; // Cette variable indiquera si la regex a trouvé une correspondance
					if (foundMatch)
					{
						string ReplaceToNew = VariableValue;
						GroupCollection groups = match.Groups;
						for (int i = 1; i <= groups.Count; i++)
						{
							ReplaceToNew = ReplaceToNew.Replace($"\\{i}", groups[i].Value);
						}
						ReplaceTo = ReplaceToNew;
					}
				}
			}

			textOut = Regex.Replace(textOut, Regex.Escape(VariableName), ReplaceTo, options);
			return textOut;
		}

		private string MatchEvaluator(Match match)
		{
			GroupCollection groups = match.Groups;
			string replaceWith = VariableValue;
			for (int i = 1; i <= groups.Count; i++)
			{
				replaceWith = replaceWith.Replace($"\\{i}", groups[i].Value);
			}
			return replaceWith;
		}




	}
}
