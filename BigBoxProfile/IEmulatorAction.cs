using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBoxProfile
{
	public interface IEmulatorAction
	{
		string ModuleName { get; }
		
		Dictionary<string, string> Options { get; set; }
		IEmulatorAction CreateNewInstance();
		void Configure();

		bool IsConfigured();

		string[] ModifyExemple(string[] args);

		string[] ModifyReal(string[] args);

		void LoadConfiguration(Dictionary<string, string> Options);

		void ExecuteBefore(string[] args);

		void ExecuteAfter(string[] args);
	}
}
