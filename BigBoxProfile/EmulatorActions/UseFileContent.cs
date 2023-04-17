using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class UseFileContent : IEmulatorAction
	{
		public string ModuleName => "UseFileContent";
		private string _filter = "";
		private bool _usefile = true;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new UseFileContent_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				if (frm.usefile) Options["usefile"] = "yes";
				else Options["usefile"] = "no";
				Options["filter"] = frm.filter.Trim();
				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new UseFileContent();
		}

		public bool IsConfigured()
		{
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (options.ContainsKey("filter") == false) Options["filter"] = "";
			if (options.ContainsKey("usefile") == false) Options["usefile"] = "yes";

			UpdateConfig();
		}

		public string[] Modify(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}
		public string[] ModifyExemple(string[] args)
		{
			if(args.Length > 1)
			{
				for (int i = 0; i < args.Length; i++)
				{
					if (File.Exists(args[i]))
					{
						var content = File.ReadAllText(args[i]);
						if (!Path.IsPathRooted(content))
						{
							string path = "";
							if(_usefile) path = Path.GetDirectoryName(args[i]);
							else path = Directory.GetCurrentDirectory();
							content = Path.Combine(path, content);
						}
						args[i] = content;
					}
				}
			}
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		public override string ToString()
		{
			string description = "Remplace file in parameter with there content";


			if (_filter != "")
			{
				description += $" if filename contains {_filter}";

			}

			return $"{ModuleName} => {description}";
		}

		private void UpdateConfig()
		{
			//if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			//if (Options.ContainsKey("usefile") == false) Options["usefile"] = "yes";
			_filter = Options["filter"];
			_usefile = Options["usefile"] == "yes" ? true : false;
		}

		public void ExecuteBefore(string[] args)
		{

		}
		public void ExecuteAfter(string[] args)
		{

		}


	}
}
