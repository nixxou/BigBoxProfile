using BigBoxProfile.EmulatorActions;
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


		public VariableData()
		{
			this.VariableName = "";
			this.VariableValue = "";
			this.RegexToMatch = "";
			this.SourceData = "arg";
			this.FallbackValue = "";
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
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		public string[] ToStringArray()
		{
			var arrayString = new string[6];
			arrayString[0] = Serialize();
			arrayString[1] = this.VariableName;
			arrayString[2] = this.SourceData;
			arrayString[3] = this.RegexToMatch;
			arrayString[4] = this.VariableValue;
			arrayString[5] = this.FallbackValue;
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
