using System.Collections.Generic;

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

		bool UseM3UContent();
		string[] FiltersToRemoveOnFinalPass();
	}
}
