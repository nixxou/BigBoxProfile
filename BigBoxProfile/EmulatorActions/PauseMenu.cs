using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using XInput.Wrapper;

namespace BigBoxProfile.EmulatorActions
{
	internal class PauseMenu : IEmulatorAction
	{
		[DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
		public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

		[DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
		public static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
		private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
		private const int WS_SHOWNORMAL = 1;

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
		private int _gamepadKeyPressMinDuration = 0;
		private bool _forcefullActivation = false;
		private bool _pauseEmulation = false;
		private bool _copyArt = true;
		private string _ahkPause = "";
		private string _ahkResume = "";
		private string _htmlFile = "";

		private string _variablesData = "";

		private X.Gamepad gamepad = null;

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//private int pressDurationMilliseconds = 1000; // Par exemple, 1000 millisecondes (1 seconde)
		private bool isComboActive = false; // Variable pour suivre si la combinaison est active
		private System.Timers.Timer timerGamepad = null;

		private PauseMenu_Show activePauseMenu = null;

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

				Options["gamepadKeyPressMinDuration"] = frm.gamepadKeyPressMinDuration.ToString();

				if (frm.forcefullActivation) Options["forcefullActivation"] = "yes";
				else Options["forcefullActivation"] = "no";

				if (frm.pauseEmulation) Options["pauseEmulation"] = "yes";
				else Options["pauseEmulation"] = "no";

				if (frm.copyArt) Options["copyArt"] = "yes";
				else Options["copyArt"] = "no";

				Options["htmlFile"] = frm.htmlFile.Trim();
				Options["ahkPause"] = frm.ahkPause.Trim();
				Options["ahkResume"] = frm.ahkResume.Trim();

				Options["variablesData"] = frm.variablesData;

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

			if (Options.ContainsKey("gamepadKeyPressMinDuration") == false) Options["gamepadKeyPressMinDuration"] = "0";

			if (Options.ContainsKey("forcefullActivation") == false) Options["forcefullActivation"] = "no";

			if (Options.ContainsKey("pauseEmulation") == false) Options["pauseEmulation"] = "no";
			if (Options.ContainsKey("copyArt") == false) Options["copyArt"] = "yes";

			if (Options.ContainsKey("htmlFile") == false) Options["htmlFile"] = "";
			if (Options.ContainsKey("ahkPause") == false) Options["ahkPause"] = "";
			if (Options.ContainsKey("ahkResume") == false) Options["ahkResume"] = "";

			if (Options.ContainsKey("variablesData") == false) Options["variablesData"] = "";

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

			int tmpInt = 0;
			_gamepadKeyPressMinDuration = 0;
			if (Options.ContainsKey("gamepadKeyPressMinDuration"))
			{
				if (int.TryParse(Options["gamepadKeyPressMinDuration"], out tmpInt))
				{
					_gamepadKeyPressMinDuration = tmpInt;
				}
			}

			_forcefullActivation = Options["forcefullActivation"] == "yes" ? true : false;
			_pauseEmulation = Options["pauseEmulation"] == "yes" ? true : false;
			_copyArt = Options["copyArt"] == "yes" ? true : false;
			_htmlFile = Options["htmlFile"];
			_ahkPause = Options["ahkPause"];
			_ahkResume = Options["ahkResume"];
			_variablesData = Options["variablesData"];
		}

		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured())
			{
				var keycombi = Combination.FromString(_keyCombo);
				Action actionPauseMenu = () => { ShowPause(); };
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
					timerGamepad = new System.Timers.Timer(_gamepadKeyPressMinDuration);

					timerGamepad.Elapsed += (sender, e) =>
					{
						
						// Le timer s'est écoulé, la touche a été pressée pendant la durée spécifiée
						if (isComboActive)
						{
							ShowPause();
						}
						isComboActive = false;
						timerGamepad.Stop();

						// Réinitialisez la variable pour la prochaine pression de touche

					};

					gamepad.StateChanged += (object a, EventArgs b) =>
					{
						if (gamepad.state.Gamepad.IsButtonDown("Guide"))
						{
							if (_gamepadKeyPressMinDuration == 0)
							{
								ShowPause();
							}
							else
							{
								if (!isComboActive)
								{
									isComboActive = true;
									timerGamepad.Start();
								}
							}
						}
						else
						{
							timerGamepad.Stop();
							isComboActive = false; // Réinitialisez la variable
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

		public void ShowPause()
		{
			if (activePauseMenu == null)
			{
				/*
				// Créez un nouveau thread avec une fonction anonyme
				Thread backgroundThread = new Thread(() =>
				{
					activePauseMenu = new PauseMenu_Show(true);
					activePauseMenu.FormClosed += (sender, e) =>
					{
						activePauseMenu = null; // Réinitialise la référence lorsque la fenêtre est fermée.
					};
					activePauseMenu.ShowDialog();
				});


				// Démarrez le thread
				backgroundThread.Start();
				*/

				activePauseMenu = new PauseMenu_Show(true);
				activePauseMenu.FormClosed += (sender, e) =>
				{
					activePauseMenu.chromiumWebBrowser1.Dispose();
					activePauseMenu.Dispose();
					activePauseMenu = null; // Réinitialise la référence lorsque la fenêtre est fermée.
				};
				activePauseMenu.ShowDialog();



				/*
				activePauseMenu.Location = new Point(0, 0);
				activePauseMenu.FormBorderStyle = FormBorderStyle.None;
				activePauseMenu.Width = Screen.PrimaryScreen.Bounds.Width;
				activePauseMenu.Height = Screen.PrimaryScreen.Bounds.Height;

				activePauseMenu.ShowDialog();
				activePauseMenu.BringToFront();
				activePauseMenu.TopMost = true;
				activePauseMenu.Activate();
				
				SystemParametersInfo((uint)0x2001, 0, 0, 0x0002 | 0x0001);
				ShowWindowAsync(activePauseMenu.Handle, WS_SHOWNORMAL);
				SetForegroundWindow(activePauseMenu.Handle);
				SystemParametersInfo((uint)0x2001, 200000, 200000, 0x0002 | 0x0001);
				*/
			}
			else
			{
				activePauseMenu.Close();
			}


		}
	}
}
