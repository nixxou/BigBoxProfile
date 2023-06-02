using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class ChangeRomPath : IEmulatorAction
	{
		public string ModuleName => "ChangeRomPath";

		private string _filter = "";
		private string _low_priority = "";
		private string _hight_priority = "";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new ChangeRomPath_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["filter"] = frm.filter.Trim();
				Options["low_priority"] = frm.low_priority.Trim();
				Options["hight_priority"] = frm.hight_priority.Trim();

				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new ChangeRomPath();
		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("filter") == false || Options["filter"] == "")
			{
				return false;
			}
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("low_priority") == false) Options["low_priority"] = "";
			if (Options.ContainsKey("hight_priority") == false) Options["hight_priority"] = "";
			UpdateConfig();
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
			string exeArg = args[0];
			var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);

			int index = 0;
			foreach (var elem in filteredArgs)
			{
				if (elem.Contains(_filter))
				{
					bool found = false;
					int indexsearch = elem.IndexOf(_filter);
					string before = elem.Substring(0, indexsearch);
					string after = elem.Substring(indexsearch + _filter.Length);
					if (after == "\\") after = "";
					after = after.TrimStart('\\');
					after = after.TrimEnd('"');

					var hight_priority_array = BigBoxUtils.explode(_hight_priority, "|||");
					foreach(var potentialPath in hight_priority_array)
					{
						
						string newPath = potentialPath;
						if (!String.IsNullOrEmpty(after.TrimStart('\\'))) newPath = Path.Combine(potentialPath, after.TrimStart('\\'));
						if (NetworkPathExists(newPath))
						{
							found = true;
							filteredArgs[index] = before + Path.Combine(potentialPath, after.TrimStart('\\'));
							break;
						}
					}

					if (!found)
					{
						bool elem_exist = NetworkPathExists(Path.Combine(_filter, after));
						if(elem_exist == false)
						{
							var low_priority_array = BigBoxUtils.explode(_low_priority, "|||");
							foreach (var potentialPath in low_priority_array)
							{
								string newPath = potentialPath;
								if (!String.IsNullOrEmpty(after.TrimStart('\\'))) newPath = Path.Combine(potentialPath, after.TrimStart('\\'));
								if (NetworkPathExists(newPath))
								{
									found = true;
									filteredArgs[index] = before + Path.Combine(potentialPath, after.TrimStart('\\'));
									break;
								}
							}
						}
					}
				}
				index++;
			}

			args = BigBoxUtils.AddFirstElementToArg(filteredArgs, exeArg);



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
			_low_priority = Options["low_priority"];
			_hight_priority = Options["hight_priority"];
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				if (_filter != "") description += $" [Will replace {_filter} with other path if needed]";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

		}

		public static bool NetworkPathExists(string path)
		{
			if (path.StartsWith(@"\\"))
			{
				string serverName = path.Split('\\')[2];
				Ping ping = new Ping();
				PingReply reply = ping.Send(serverName);

				if (reply.Status != IPStatus.Success)
				{
					Console.WriteLine("The server is not reachable.");
					return false;
				}
			}

			if (File.Exists(path) || Directory.Exists(path))
			{
				Console.WriteLine("The path exists.");
				return true;
			}
			else
			{
				Console.WriteLine("The path does not exist.");
				return false;
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
			return true;
		}
	}
}
