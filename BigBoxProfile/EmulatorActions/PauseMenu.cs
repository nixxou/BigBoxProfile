using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using XInput.Wrapper;

namespace BigBoxProfile.EmulatorActions
{
	internal class PauseMenu : IEmulatorAction
	{

		private static IKeyboardMouseEvents _globalHook = null;

		private static int _instanceCount = 0;
		private int _instanceId;

		public PauseMenu()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "PauseMenu";

		private string _filter = "";
		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private string _keyCombo = "";
		private string _gamepadCombo = "";

		private X.Gamepad gamepad = null;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		private int pressDurationMilliseconds = 1000; // Par exemple, 1000 millisecondes (1 seconde)
		private bool isComboActive = false; // Variable pour suivre si la combinaison est active
		private System.Timers.Timer timerGamepad = null;



		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new PauseMenu();
		}

		public void Configure()
		{
			var frm = new PauseMenu_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{

				Options["filter"] = frm.filter.Trim();

				Options["exclude"] = frm.exclude.Trim();

				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";

				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";

				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				Options["keyCombo"] = frm.keyCombo.Trim();
				Options["gamepadCombo"] = frm.gamepadCombo.Trim();

				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";

			if (Options.ContainsKey("keyCombo") == false) Options["keyCombo"] = "";
			if (Options.ContainsKey("gamepadCombo") == false) Options["gamepadCombo"] = "";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			if(string.IsNullOrEmpty(_keyCombo)) return false;
			return true;
		}

		public override string ToString()
		{
			string description = "";


			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		public string[] ModifyExemple(string[] args)
		{

			return args;

		}
		public string[] Modify(string[] args)
		{

			return args;
		}



		public string[] ModifyReal(string[] args)
		{
			return args;
		}

		private void UpdateConfig()
		{
			_filter = Options["filter"];
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;

			_keyCombo = Options["keyCombo"];
			_gamepadCombo = Options["gamepadCombo"];
		}

		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured())
			{
				var keycombi = Combination.FromString(_keyCombo);
				Action actionPauseMenu = () => { MessageBox.Show("TEST"); };
				var assignment = new Dictionary<Combination, Action>
				{
					{keycombi, actionPauseMenu}
				};

				_globalHook = Hook.GlobalEvents();
				_globalHook.OnCombination(assignment);

				if (!string.IsNullOrEmpty(_gamepadCombo))
				{
					gamepad = X.Gamepad_1;
					X.StartPolling(gamepad);
					timerGamepad = new System.Timers.Timer(pressDurationMilliseconds);

					timerGamepad.Elapsed += (sender, e) =>
					{
						// Le timer s'est écoulé, la touche a été pressée pendant la durée spécifiée
						if (isComboActive)
						{
							MessageBox.Show("Gamepad Combo Timer !");
						}

						// Réinitialisez la variable pour la prochaine pression de touche
						isComboActive = false;
					};

					gamepad.KeyDown += (object sender, EventArgs e) =>
					{
						if (gamepad.state.Gamepad.IsButtonDown(_gamepadCombo))
						{
							isComboActive = true;
							timerGamepad.Start();
							//MessageBox.Show("Gamepad Combo !");
						}
						else
						{
							if (isComboActive)
							{
								timerGamepad.Stop();
								isComboActive = false; // Réinitialisez la variable
							}
						}

					};
				}



				/*
				HookManager.CleanHook();

				HookManager.SetCombinationHook(assignment);
				*/
			}

		}



		private void GamepadKeyDown()
		{
			throw new NotImplementedException();
		}

		public void ExecuteAfter(string[] args)
		{

		}

		public bool UseM3UContent()
		{
			return false;
		}

		public string[] FiltersToRemoveOnFinalPass()
		{
			List<string> emptylist = new List<string>();
			if (_removeFilter)
			{
				return BigBoxUtils.MakeFilterListToRemove(_filter, _commaFilter);
			}
			return emptylist.ToArray();
		}
	}
}
