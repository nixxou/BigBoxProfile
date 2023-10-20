using CliWrap;
using CliWrap.Buffered;
using Gma.System.MouseKeyHook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInput.Wrapper;

namespace BigBoxProfile.EmulatorActions
{
	public class PauseMenu : IEmulatorAction
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

		public string _keyCombo { get; private set; } = "";
		public string _gamepadCombo { get; private set; } = "";
		public int _gamepadKeyPressMinDuration { get; private set; } = 0;
		public bool _forcefullActivation { get; private set; } = false;
		public bool _pauseEmulation { get; private set; } = false;
		public bool _disableSound { get; private set; } = false;
		public bool _copyArt { get; private set; } = false;
		public string _ahkPause { get; private set; } = "";
		public string _ahkResume { get; private set; } = "";
		public string _htmlFile { get; private set; } = "";
		public bool _executePauseAfter { get; private set; } = false;
		public int _delayStarting { get; private set; } = 0;
		public int _delayAutoClose { get; private set; } = 0;
		public string _typeScreen { get; private set; } = "pause";
		public string _variablesData { get; private set; } = "";
		public string _selectedMonitor { get; private set; } = "Main";
		public int _dpi { get; private set; } = 0;
		public bool _showDevTools { get; private set; } = false;
		public bool _ahkFromExe { get; private set; } = false;

		public bool _includeSpecialVariable { get; private set; } = false;



		public string specialVariableGameData { get; private set; } = "";
		public string specialVaribaleArgsData { get; private set; } = "";
		public string guessedRomFile { get; private set; } = "";
		public string ahkCodeToExecute = "";
		public bool tempDisableHotkey = false;
		private float? _restoreVolumeTo = null;
		private Process _processEmulator = null;
		private X.Gamepad gamepad = null;
		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();
		//private int pressDurationMilliseconds = 1000; // Par exemple, 1000 millisecondes (1 seconde)
		private bool isComboActive = false; // Variable pour suivre si la combinaison est active
		private System.Timers.Timer timerGamepad = null;
		private System.Timers.Timer timerStart = null;
		AutoHotkey.Interop.AutoHotkeyEngine ahk_session = null;
		public string htmlContent = "";
		private MemoryMappedFile mmf_dataIn = null;
		public Process activePauseProcess = null;
		public bool abordPauseProcessThread = false;
		private Dictionary<string, string> ArtOverride = new Dictionary<string, string>();

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

				if (frm.disableSound) Options["disableSound"] = "yes";
				else Options["disableSound"] = "no";

				if (frm.copyArt) Options["copyArt"] = "yes";
				else Options["copyArt"] = "no";

				Options["htmlFile"] = frm.htmlFile.Trim();
				Options["ahkPause"] = frm.ahkPause.Trim();
				Options["ahkResume"] = frm.ahkResume.Trim();

				if (frm.executePauseAfter) Options["executePauseAfter"] = "yes";
				else Options["executePauseAfter"] = "no";

				Options["delayStarting"] = frm.delayStarting.ToString();
				Options["delayAutoClose"] = frm.delayAutoClose.ToString();

				Options["variablesData"] = frm.variablesData;

				Options["typeScreen"] = frm.typeScreen;

				Options["selectedMonitor"] = frm.selectedMonitor.Trim();

				Options["dpi"] = frm.dpi.ToString();

				if (frm.showDevTools) Options["showDevTools"] = "yes";
				else Options["showDevTools"] = "no";

				if (frm.ahkFromExe) Options["ahkFromExe"] = "yes";
				else Options["ahkFromExe"] = "no";

				if (frm.includeSpecialVariable) Options["includeSpecialVariable"] = "yes";
				else Options["includeSpecialVariable"] = "no";

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
			if (Options.ContainsKey("disableSound") == false) Options["disableSound"] = "no";
			if (Options.ContainsKey("copyArt") == false) Options["copyArt"] = "no";

			if (Options.ContainsKey("htmlFile") == false) Options["htmlFile"] = "";
			if (Options.ContainsKey("ahkPause") == false) Options["ahkPause"] = "";
			if (Options.ContainsKey("ahkResume") == false) Options["ahkResume"] = "";

			if (Options.ContainsKey("variablesData") == false) Options["variablesData"] = "";

			if (Options.ContainsKey("executePauseAfter") == false) Options["executePauseAfter"] = "no";
			if (Options.ContainsKey("delayStarting") == false) Options["delayStarting"] = "0";
			if (Options.ContainsKey("delayAutoClose") == false) Options["delayAutoClose"] = "0";

			if (Options.ContainsKey("typeScreen") == false) Options["typeScreen"] = "pause";

			if (Options.ContainsKey("selectedMonitor") == false) Options["selectedMonitor"] = "Main";

			if (Options.ContainsKey("dpi") == false) Options["dpi"] = "0";

			if (Options.ContainsKey("showDevTools") == false) Options["showDevTools"] = "no";

			if (Options.ContainsKey("ahkFromExe") == false) Options["ahkFromExe"] = "no";

			if (Options.ContainsKey("includeSpecialVariable") == false) Options["includeSpecialVariable"] = "no";
			
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			if(string.IsNullOrEmpty(_htmlFile)) return false;
			if(!File.Exists(_htmlFile)) return false;
			return true;
		}

		public override string ToString()
		{
			string description = $"Menu {_typeScreen} : {Path.GetFileName(_htmlFile)}";
			if (_filter != "") description += $" [Only if command line contains {_filter}]";
			if (_exclude != "") description += $" [Exclude {_exclude}]";
			return $"{ModuleName} => {description}";
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
			_disableSound = Options["disableSound"] == "yes" ? true : false;

			_copyArt = Options["copyArt"] == "yes" ? true : false;
			_htmlFile = Options["htmlFile"];
			_ahkPause = Options["ahkPause"];
			_ahkResume = Options["ahkResume"];
			_variablesData = Options["variablesData"];


			_executePauseAfter = Options["executePauseAfter"] == "yes" ? true : false;

			tmpInt = 0;
			_delayStarting = 0;
			if (Options.ContainsKey("delayStarting"))
			{
				if (int.TryParse(Options["delayStarting"], out tmpInt))
				{
					_delayStarting = tmpInt;
				}
			}
			tmpInt = 0;
			_delayAutoClose = 0;
			if (Options.ContainsKey("delayAutoClose"))
			{
				if (int.TryParse(Options["delayAutoClose"], out tmpInt))
				{
					_delayAutoClose = tmpInt;
				}
			}

			_typeScreen = Options["typeScreen"];
			_selectedMonitor = Options["selectedMonitor"];

			tmpInt = 0;
			_dpi = 0;
			if (Options.ContainsKey("dpi"))
			{
				if (int.TryParse(Options["dpi"], out tmpInt))
				{
					_dpi = tmpInt;
				}
			}

			_showDevTools = Options["showDevTools"] == "yes" ? true : false;
			_ahkFromExe = Options["ahkFromExe"] == "yes" ? true : false;
			_includeSpecialVariable = Options["includeSpecialVariable"] == "yes" ? true : false;
		}

		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured()){
				specialVariableGameData = BigBoxUtils.GameInfoJSON;
				guessedRomFile = BigBoxUtils.GuessRomPath(args, EmulatorLauncher.OriginalArgs);

				Dictionary<string,object> argsData = new Dictionary<string,object>();
				argsData.Add("Args",new List<string>(args).ToArray());

				if (EmulatorLauncher.OriginalArgs != null)
				{
					argsData.Add("OriginalArgs", new List<string>(EmulatorLauncher.OriginalArgs).ToArray());
					if(guessedRomFile != "")
					{
						try
						{
							argsData.Add("RomFilePath", guessedRomFile);
							argsData.Add("RomFileName", Path.GetFileName(guessedRomFile));
							argsData.Add("RomFileNameWithoutExt", Path.GetFileNameWithoutExtension(guessedRomFile));
							argsData.Add("RomFileDir", Path.GetDirectoryName(guessedRomFile));
						}
						catch { }
					}
					else
					{
						argsData.Add("RomFilePath", "");
						argsData.Add("RomFileName", "");
						argsData.Add("RomFileNameWithoutExt", "");
						argsData.Add("RomFileDir", "");
					}
					
				}
				if (args.Length > 0)
				{
					argsData.Add("EmulatorFilePath", args[0]);
					argsData.Add("EmulatorFileName", Path.GetFileName(args[0]));
					argsData.Add("EmulatorNameWithoutExt", Path.GetFileNameWithoutExtension(args[0]));
					argsData.Add("EmulatorFileDir", Path.GetDirectoryName(args[0]));
				}
				else
				{
					argsData.Add("EmulatorFilePath", "");
					argsData.Add("EmulatorFileName", "");
					argsData.Add("EmulatorNameWithoutExt", "");
					argsData.Add("EmulatorFileDir", "");
				}



				ArtOverride.Clear();
				if (_copyArt)
				{

					Dictionary<string, object> gameData = JsonConvert.DeserializeObject<Dictionary<string, object>>(BigBoxUtils.GameInfoJSON);
					if (gameData != null)
					{

						string backgroundImage = "";
						if (gameData.ContainsKey("BackgroundImagePath") && !string.IsNullOrEmpty((string)gameData["BackgroundImagePath"]) && File.Exists((string)gameData["BackgroundImagePath"]))
						{
							backgroundImage = (string)gameData["BackgroundImagePath"];
						}
						if (backgroundImage == "" && gameData.ContainsKey("PlatformBackgroundImagePath") && !string.IsNullOrEmpty((string)gameData["PlatformBackgroundImagePath"]) && File.Exists((string)gameData["PlatformBackgroundImagePath"]))
						{
							backgroundImage = (string)gameData["PlatformBackgroundImagePath"];
						}
						if(backgroundImage != "" && File.Exists(backgroundImage))
						{
							ArtOverride.Add("background.jpg", backgroundImage);
						}


						if (gameData.ContainsKey("ClearLogoImagePath") && !string.IsNullOrEmpty((string)gameData["ClearLogoImagePath"]) && File.Exists((string)gameData["ClearLogoImagePath"]))
						{
							ArtOverride.Add("clearlogo.png", (string)gameData["ClearLogoImagePath"]);
						}
						if (gameData.ContainsKey("BezelImagePath") && !string.IsNullOrEmpty((string)gameData["BezelImagePath"]) && File.Exists((string)gameData["BezelImagePath"]))
						{
							ArtOverride.Add("bezel.png", (string)gameData["BezelImagePath"]);
							if(backgroundImage == "") ArtOverride.Add("background.jpg", (string)gameData["BezelImagePath"]);
						}
						if (gameData.ContainsKey("FrontImagePath") && !string.IsNullOrEmpty((string)gameData["FrontImagePath"]) && File.Exists((string)gameData["FrontImagePath"]))
						{
							ArtOverride.Add("front.jpg", (string)gameData["FrontImagePath"]);
						}
						if (gameData.ContainsKey("CartFrontImagePath") && !string.IsNullOrEmpty((string)gameData["CartFrontImagePath"]))
						{
							ArtOverride.Add("cart.jpg", (string)gameData["CartFrontImagePath"]);
						}
						if (gameData.ContainsKey("ManualPath") && !string.IsNullOrEmpty((string)gameData["ManualPath"]))
						{
							ArtOverride.Add("manual.pdf", (string)gameData["ManualPath"]);
						}
						if (gameData.ContainsKey("VideoPath") && !string.IsNullOrEmpty((string)gameData["VideoPath"]))
						{
							ArtOverride.Add("video.mp4", (string)gameData["VideoPath"]);
						}

					}

				}
				specialVaribaleArgsData = JsonConvert.SerializeObject(argsData, Newtonsoft.Json.Formatting.Indented);
			}

			if (IsConfigured() && _typeScreen == "pause")
			{
				
				if (!string.IsNullOrEmpty(_keyCombo))
				{
					try
					{
						var keycombi = Combination.FromString(_keyCombo);
						Action actionPauseMenu = () => {
							ShowPauseWithDelay(args);

						};
						var assignment = new Dictionary<Combination, Action>
						{
							{keycombi, actionPauseMenu}
						};
						_globalHook = Hook.GlobalEvents();
						_globalHook.OnCombination(assignment);
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message);
					}


				}
				

				
				if (!string.IsNullOrEmpty(_gamepadCombo))
				{
					gamepad = X.Gamepad_1;
					X.StartPolling(gamepad);

					if(_gamepadKeyPressMinDuration > 0)
					{
						timerGamepad = new System.Timers.Timer(_gamepadKeyPressMinDuration);

						timerGamepad.Elapsed += (sender, e) =>
						{
							if (isComboActive)
							{
								ShowPauseWithDelay(args);
							}
							isComboActive = false;
							timerGamepad.Stop();
						};

					}

					gamepad.StateChanged += (object a, EventArgs b) =>
					{
						if (gamepad.state.Gamepad.IsButtonDown(_gamepadCombo))
						{
							if (_gamepadKeyPressMinDuration == 0)
							{
								ShowPauseWithDelay(args);
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
							if(timerGamepad != null) timerGamepad.Stop();
							isComboActive = false; // Réinitialisez la variable
						}
					};
				}
				
			}
			if(IsConfigured() && _typeScreen == "start")
			{
				Task.Run(() => ShowPauseWithDelay(args));
				
			}
		}

		private void ShowPauseWithDelay(string[] args)
		{
			if(tempDisableHotkey == true || ahk_session != null)
			{
				return;
			}
			if(activePauseProcess != null && tempDisableHotkey == false && ahk_session == null)
			{
				tempDisableHotkey = true;
				//activePauseMenu.Close();

				if(activePauseProcess != null)
				{
					int pidToKill = activePauseProcess.Id;
					ProcessStartInfo psi = new ProcessStartInfo("taskkill")
					{
						Arguments = $"/F /PID {pidToKill}",
						CreateNoWindow = true,
						UseShellExecute = false
					};
					Process process = new Process
					{
						StartInfo = psi
					};
					process.Start();
					process.WaitForExit();
				}


				activePauseProcess = null;

				tempDisableHotkey = false;
				return;
			}
			if(activePauseProcess == null && tempDisableHotkey == false && ahk_session == null)
			{
				tempDisableHotkey = true;
				if (_delayStarting == 0) ShowPause(args);
				else
				{
					timerStart = new System.Timers.Timer(_delayStarting);
					timerStart.Enabled = true;
					timerStart.Elapsed += (sender, e) =>
					{
						timerStart.Stop();
						ShowPause(args);
					};
				}
				return;
			}
		}

		public void ExecuteAfter(string[] args)
		{
			if (IsConfigured() && _typeScreen == "end")
			{
				if(_delayStarting == 0) ShowPause(args);
				else
				{
					timerStart = new System.Timers.Timer(_delayStarting);

					timerStart.Elapsed += (sender, e) =>
					{
						timerStart.Stop();
						ShowPause(args);
					};
				}

			}
			if(IsConfigured() && (_typeScreen == "pause" || _typeScreen == "start"))
			{
				if (activePauseProcess != null)
				{
					int pidToKill = activePauseProcess.Id;
					ProcessStartInfo psi = new ProcessStartInfo("taskkill")
					{
						Arguments = $"/F /PID {pidToKill}",
						CreateNoWindow = true,
						UseShellExecute = false
					};
					Process process = new Process
					{
						StartInfo = psi
					};
					process.Start();
					process.WaitForExit();
				}
			}

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

		public async void ShowPause(string[] args)
		{
			if (!_executePauseAfter) AhkExecute(args, _ahkPause,_ahkFromExe);
			
			_processEmulator = BigBoxUtils.FindProcessEmulator(args);
			if(_processEmulator != null)
			{
				if (_disableSound)
				{
					float? currentVolume = VolumeMix.VolumeMixer.GetApplicationVolume(_processEmulator.Id);
					if(currentVolume != null)
					{
						VolumeMix.VolumeMixer.SetApplicationVolume(_processEmulator.Id, 0f);
						_restoreVolumeTo = currentVolume;
					}
						
				}
				if (_pauseEmulation)
				{
					BigBoxUtils.PauseProcess(_processEmulator.Id);
				}
			}

			Process process = new Process();
			activePauseProcess = process;
			/*
			activePauseMenu = new PauseMenu_Show(this, args);

			if (_executePauseAfter)
			{
				activePauseMenu.Load += (sender, e) =>
				{
					Task.Run(() => AhkExecute(args, _ahkPause, _ahkFromExe));
				};
			}
			*/


			htmlContent = GetHTMLContent(args);
			Dictionary<string,object> configOptions = new Dictionary<string, object>();
			
			configOptions.Add("Monitor", _selectedMonitor);
			configOptions.Add("Dpi", _dpi.ToString());
			configOptions.Add("HtmlContent", htmlContent);
			configOptions.Add("HtmlDir", BigBoxUtils.DataHtmlDir);
			configOptions.Add("ShowDevTools", _showDevTools);
			configOptions.Add("ForcefullActivation", _forcefullActivation);
			configOptions.Add("specialVariableGameData", specialVariableGameData);
			configOptions.Add("specialVaribaleArgsData", specialVaribaleArgsData);
			configOptions.Add("guessedRomFile", guessedRomFile);
			configOptions.Add("ArtOverride", JsonConvert.SerializeObject(ArtOverride, Newtonsoft.Json.Formatting.Indented));
			configOptions.Add("AHK_gamedataPrefix", BigBoxUtils.AHKGetPrefix());
			configOptions.Add("AHK_argsPrefix", BigBoxUtils.AHKGetPrefixArgs(args));

			if (_typeScreen == "pause") configOptions.Add("delayAutoClose", "0");
			else configOptions.Add("delayAutoClose", _delayAutoClose.ToString());

			string AHK_pauseCodeToSendOnceLoaded = "";
			if (_executePauseAfter) AHK_pauseCodeToSendOnceLoaded = _ahkPause;
			configOptions.Add("AHK_pauseCodeToSendOnceLoaded", AHK_pauseCodeToSendOnceLoaded);

			string json_resume = JsonConvert.SerializeObject(configOptions, Newtonsoft.Json.Formatting.Indented);
			byte[] jsonDataBytes_resume = Encoding.UTF8.GetBytes(json_resume);
			// Créez le MemoryMappedFile une seule fois
			if (mmf_dataIn != null) { mmf_dataIn.Dispose(); mmf_dataIn = null; }
			mmf_dataIn = MemoryMappedFile.CreateOrOpen($"PauseMenu_Instance{_instanceId}", jsonDataBytes_resume.Length);
			using (MemoryMappedViewAccessor accessor = mmf_dataIn.CreateViewAccessor())
			{
				accessor.WriteArray(0, jsonDataBytes_resume, 0, jsonDataBytes_resume.Length);
			}

			abordPauseProcessThread = false;
			string[] argsToPass = new List<string>(args).ToArray();
			Thread pipeThread = new Thread(StartPipeListener);
			pipeThread.Start(argsToPass);

			process.StartInfo.FileName = "PauseMenu.exe";
			process.StartInfo.Arguments = _instanceId.ToString();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			// Démarrer le processus
			process.Start();
			tempDisableHotkey = false;
			process.WaitForExit();
			abordPauseProcessThread = true;

			pipeThread.Abort();

			activePauseProcess = null;
			tempDisableHotkey = false;
			DoActionOnClose();

		}

		private void StartPipeListener(object argdata)
		{
			string[] args = (string[])argdata;

			using (NamedPipeClientStream client = new NamedPipeClientStream(".", $"PauseMenu_Tube-{_instanceId}", PipeDirection.In))
			{
				client.Connect();
				using (StreamReader reader = new StreamReader(client))
				{
					while (!abordPauseProcessThread)
					{


						string data = reader.ReadToEnd(); // Lire l'ensemble des données
						if (!string.IsNullOrEmpty(data) && data.Contains(":"))
						{

							string[] parts = data.Split(new char[] { ':' }, 2);
							if (parts.Length == 2)
							{
								string commande = parts[0];
								string action = parts[1];

								if(commande == "ahkclose")
								{
									ahkCodeToExecute = action;

									tempDisableHotkey = true;

									if (activePauseProcess != null)
									{
										int pidToKill = activePauseProcess.Id;
										ProcessStartInfo psi = new ProcessStartInfo("taskkill")
										{
											Arguments = $"/F /PID {pidToKill}",
											CreateNoWindow = true,
											UseShellExecute = false
										};
										Process process = new Process
										{
											StartInfo = psi
										};
										process.Start();
										process.WaitForExit();
									}
									//activePauseMenu = null;

									return;
								}
								if(commande == "ahkcontinue")
								{
									Task.Run(() => AhkExecute(args, action, _ahkFromExe));
								}

							}



						}
						Thread.Sleep(100); // Vérification périodique
					}
					return;
				}
			}
			
		}

		private void DoActionOnClose()
		{
			if (_processEmulator != null)
			{
				if (_pauseEmulation)
				{
					BigBoxUtils.ResumeProcess(_processEmulator.Id);
				}
				if (_restoreVolumeTo != null)
				{
					VolumeMix.VolumeMixer.SetApplicationVolume(_processEmulator.Id, (float)_restoreVolumeTo);
				}
				Thread.Sleep(300);
				IntPtr mainWindowHandle = _processEmulator.MainWindowHandle;
				SystemParametersInfo((uint)0x2001, 0, 0, 0x0002 | 0x0001);
				ShowWindowAsync(mainWindowHandle, WS_SHOWNORMAL);
				SetForegroundWindow(mainWindowHandle);
				SystemParametersInfo((uint)0x2001, 200000, 200000, 0x0002 | 0x0001);
				Thread.Sleep(300);
			}
			string[] nargs = new List<string>().ToArray();
			AhkExecute(nargs, _ahkResume, _ahkFromExe);

			if(ahkCodeToExecute != "")
			{
				AhkExecute(nargs, ahkCodeToExecute, _ahkFromExe);
				ahkCodeToExecute = "";
			}
			tempDisableHotkey = false;
		}

		private void AhkExecute(string[] args, string code, bool fromExe)
		{
			if (fromExe)
			{
				string currentDir = Path.GetFullPath(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
				string ahkExe = Path.Combine(currentDir, "AutoHotkeyU32.exe");
				if (!File.Exists(ahkExe)) fromExe = false;
			}

			if (fromExe)
			{
				code = BigBoxUtils.GetAHKCode(code, args);

				string tempFilePath = Path.Combine(Path.GetTempPath(), "temp_script.ahk");

				try
				{

					// Écrivez le code AHK dans le fichier temporaire
					File.WriteAllText(tempFilePath, code);

					string currentDir = Path.GetFullPath(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
					string ahkExe = Path.Combine(currentDir, "AutoHotkeyU32.exe");


					// Créez un processus pour exécuter le script AHK
					Process process = new Process();
					process.StartInfo.FileName = ahkExe;
					process.StartInfo.Arguments = tempFilePath;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.CreateNoWindow = true;

					// Démarrer le processus
					process.Start();
					process.WaitForExit();

					// Supprimez le fichier temporaire après l'exécution
					File.Delete(tempFilePath);
				}
				catch { }
			}
			else
			{
				while (ahk_session != null)
				{
					Thread.Sleep(100);
				}
				ahk_session = new AutoHotkey.Interop.AutoHotkeyEngine();

				string code_prefix_gamedata = "";
				string code_prefix_args = "";
				if (code.Contains("#includegamedata"))
				{
					code = code.Replace("#includegamedata", "");
					code_prefix_gamedata = BigBoxUtils.AHKGetPrefix();
				}

				if (code.Contains("#includeargs"))
				{
					code = code.Replace("#includeargs", "");
					int i = 0;
					foreach (var arg in args)
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
				}

				code = code_prefix_gamedata + "\n" + code_prefix_args + "\n" + code;

				try
				{
					ahk_session.ExecRaw(code);
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}

				ahk_session = null;
			}



			//string ahk_code = BigBoxUtils.AHKGetPrefix();
		}

		public string GetHTMLContent(string[] args)
		{
			Dictionary<string, VariableData> variablesDictionary = new Dictionary<string, VariableData>();
			if (!String.IsNullOrEmpty(_variablesData))
			{
				var priority_arr = BigBoxUtils.explode(_variablesData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new VariableData(p);
					if (!variablesDictionary.ContainsKey(pObj.VariableName))
					{
						variablesDictionary.Add(pObj.VariableName, pObj);
					}
				}
			}

			string htmlContent = File.ReadAllText(_htmlFile);

			if (_includeSpecialVariable)
			{
				htmlContent = htmlContent.Replace("{{GAMEDATA}}", specialVariableGameData);
				htmlContent = htmlContent.Replace("{{ARGSDATA}}", specialVaribaleArgsData);
			}

			if (variablesDictionary.Count > 0)
			{
				int currentLoopVariable = 0;
				int maxLoopVariable = 10;
				bool foundVariable = true;
				while (foundVariable)
				{
					foundVariable = false;
					currentLoopVariable++;
					foreach (var v in variablesDictionary)
					{
						if (htmlContent.ToLower().Contains(v.Key.ToLower()))
						{
							foundVariable = true;
							htmlContent = v.Value.ReplaceVariable(htmlContent, args);
						}
					}
					if (currentLoopVariable > maxLoopVariable) break;
				}
			}
			return htmlContent;

		}
	}


}
