using BigBoxProfile.EmulatorActions;
using CefSharp.DevTools.DOM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
				if (!EmulatorLauncher.UseAhkExe)
				{
					var ahk_session = new AutoHotkey.Interop.AutoHotkeyEngine();

					string code_prefix_gamedata = "";
					string code_prefix_args = "";
					string code = ahkCode;
					if (code.Contains("#includegamedata"))
					{
						code = code.Replace("#includegamedata", "");
						code_prefix_gamedata = BigBoxUtils.AHKGetPrefix();
					}

					if (code.Contains("#includeargs"))
					{
						code = code.Replace("#includeargs", "");
						int i = 0;
						foreach (var arg in argsData)
						{
							ahk_session.SetVar($"arg{i}", arg);
							code_prefix_args += $@"Args.Insert({i}, arg{i})";
							code_prefix_args += "\n";
							i++;
						}

						code_prefix_args += "\n";
						if (EmulatorLauncher.OriginalArgs != null)
						{
							int y = 0;
							foreach (var arg in EmulatorLauncher.OriginalArgs)
							{
								ahk_session.SetVar($"originalarg{y}", arg);
								code_prefix_args += $@"OriginalArgs.Insert({y}, originalarg{y})";
								code_prefix_args += "\n";
								y++;
							}
						}
						code_prefix_args += "\n";
						code_prefix_args += @"resultatfinal := Args.join(""|||"")";
						code_prefix_args += "\n";
					}

					
					string newcode = code_prefix_gamedata + "\n" + code_prefix_args + "\n";

					newcode += "\n";
					newcode += @"returnvalue := """"";
					newcode += "\n";

					code = newcode + code;

					try
					{
						ahk_session.ExecRaw(code);
						resultatfinal = ahk_session.GetVar("returnvalue");
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
				}
				else
				{
					try
					{
						string code = BigBoxUtils.GetAHKCode(ahkCode, argsData, true);
						string currentDir = Path.GetFullPath(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
						string ahkExe = Path.Combine(currentDir, "AutoHotkeyU32.exe");
						string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".ahk");
						string tempFileRes = tempFilePath + ".res.txt";
						code += "\n";
						code += @"resultatfinal := Args.join(""|||"")";
						code += "\n";
						code += @"FileAppend, %returnvalue%, " + tempFileRes;
						code += "\n";
						File.WriteAllText(tempFilePath, code);
						Thread.Sleep(50);
						if (File.Exists(tempFilePath))
						{
							Process process = new Process();
							process.StartInfo.FileName = ahkExe;
							process.StartInfo.Arguments = tempFilePath;
							process.StartInfo.UseShellExecute = false;
							process.StartInfo.CreateNoWindow = true;

							// Démarrer le processus
							process.Start();
							process.WaitForExit();

							File.Delete(tempFilePath);
						}
						Thread.Sleep(50);
						
						if (File.Exists(tempFileRes))
						{
							resultatfinal = File.ReadAllText(tempFileRes);
							File.Delete(tempFileRes);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}
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
