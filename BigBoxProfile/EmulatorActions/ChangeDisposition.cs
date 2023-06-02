using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonitorSwitcherGUI;

namespace BigBoxProfile.EmulatorActions
{
	internal class ChangeDisposition : IEmulatorAction
	{
		public string ModuleName => "ChangeDisposition";
		private string _disposition = "";
		private string _filter = "";
		private string _filterInsideFile = "";
		private bool _restoreSwitch = false;

	


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
		}


		public void ExecuteBefore(string[] args)
		{

			if (IsConfigured() == false)
			{
				return;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd.Contains(_filter))
			{
				return;
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
