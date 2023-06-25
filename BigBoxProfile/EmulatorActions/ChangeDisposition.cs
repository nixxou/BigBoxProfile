using MonitorSwitcherGUI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class ChangeDisposition : IEmulatorAction
	{
		public string ModuleName => "ChangeDisposition";
		private string _disposition = "";
		private string _filter = "";
		private string _filterInsideFile = "";
		private bool _restoreSwitch = false;

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;




		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new ChangeDisposition_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["disposition"] = frm.result;
				Options["filter"] = frm.filter.Trim();
				Options["filterInsideFile"] = frm.filterInsideFile.Trim();
				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";


				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new ChangeDisposition();
		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("disposition") == false || Options["disposition"] == "")
			{
				return false;
			}
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("disposition") == false) Options["disposition"] = "";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("filterInsideFile") == false) Options["filterInsideFile"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			UpdateConfig();
		}

		public string[] ModifyExemple(string[] args)
		{
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			return args;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				description = $"Change disposition to {_disposition}";
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_filterInsideFile != "") description += $" [Only if file in arg contains {_filterInsideFile}]";
				if (_exclude != "") description += $" [Exclude {_exclude}]";
			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";
		}

		private void UpdateConfig()
		{
			_disposition = Options["disposition"];
			_filter = Options["filter"];
			_filterInsideFile = Options["filterInsideFile"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;

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



			bool change_dispostion = true;
			if (_filterInsideFile != "")
			{
				change_dispostion = false;
				var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
				foreach (string arg in filteredArgs)
				{
					// Vérifier si l'argument est un chemin de fichier valide
					bool isFilePath = BigBoxUtils.IsValidPath(arg);

					if (isFilePath)
					{
						// Vérifier si le fichier existe
						if (File.Exists(arg))
						{
							string fileContent = File.ReadAllText(arg);
							// Vérifier si la chaîne cible est présente dans le contenu du fichier
							if (fileContent.Contains(_filterInsideFile))
							{
								change_dispostion = true;
							}
							break;
						}
					}
					else
					{
						if (arg.Contains("="))
						{
							var exploded = BigBoxUtils.explode(arg, "=");
							if (exploded.Count() > 1)
							{
								string argFromEqual = exploded[1];
								isFilePath = BigBoxUtils.IsValidPath(argFromEqual);

								if (isFilePath)
								{
									// Vérifier si le fichier existe
									if (File.Exists(argFromEqual))
									{
										string fileContent = File.ReadAllText(argFromEqual);
										// Vérifier si la chaîne cible est présente dans le contenu du fichier
										if (fileContent.Contains(_filterInsideFile))
										{
											change_dispostion = true;
										}
										break;
									}
								}
							}
						}
					}
				}
			}

			if (change_dispostion)
			{
				if (MonitorSwitcher.SaveDisplaySettings(Path.Combine(Profile.PathMainProfileDir, "dispositionrestore_app.xml")))
				{
					if (BigBoxUtils.UseMonitorDisposition(_disposition))
					{
						_restoreSwitch = true;
					}
				}
			}






		}
		public void ExecuteAfter(string[] args)
		{
			if (_restoreSwitch)
			{
				MonitorSwitcher.LoadDisplaySettings(Path.Combine(Profile.PathMainProfileDir, "dispositionrestore_app.xml"));
			}
		}

		public bool UseM3UContent()
		{
			return false;
		}

	}
}
