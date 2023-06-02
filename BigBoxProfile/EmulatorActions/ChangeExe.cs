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
	internal class ChangeExe : IEmulatorAction
	{
		public string ModuleName => "ChangeExe";
		private string _newexe = "";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			string name = Interaction.InputBox("New Exe :", "New Exe", _newexe);

			if (!string.IsNullOrEmpty(name.Trim()))
			{
				Options["newexe"] = name;
				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new ChangeExe();
		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("newexe") == false || Options["newexe"] == "")
			{
				return false;
			}
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("newexe") == false) Options["newexe"] = "";
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
			if (Path.IsPathRooted(_newexe))
			{
				args[0] = _newexe;
			}
			else
			{
				args[0] = Path.Combine(Path.GetDirectoryName(args[0]),_newexe);
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
			string description = "";


			if (IsConfigured())
			{
				 description = $"Change Exe to {_newexe}";

			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";
		}


		private void UpdateConfig()
		{
			_newexe = Options["newexe"];
		}

		public void ExecuteBefore(string[] args)
		{

		}
		public void ExecuteAfter(string[] args)
		{

		}

		public bool UseM3UContent()
		{
			return false;
		}
	}
}
