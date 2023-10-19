using ComponentFactory.Krypton.Toolkit;
using HidSharp.Utility;
using SharpDX;
using SharpDX.XInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInput.Wrapper;
using System.Threading;
using DualShock4Lib;
using System.Diagnostics;
using CefSharp.DevTools.BackgroundService;
using MonitorSwitcherGUI;
using static System.Windows.Forms.Design.AxImporter;
using CefSharp.DevTools.DOM;
using System.IO;
using System.Xml.Linq;

namespace BigBoxProfile.EmulatorActions
{
	public partial class PauseMenu_Config : KryptonForm
	{

		private PickKeyCombo KeyPicker { get; set; }
		private PickControllerCombo GKeyPicker { get; set; }
		public Keys[] Keys { get; set; }

		public string[] GKeys { get; set; }

		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public string keyCombo = "";
		public string gamepadCombo = "";
		public int gamepadKeyPressMinDuration = 0;
		public bool forcefullActivation = false;

		public bool pauseEmulation = false;
		public bool disableSound = false;
		public bool copyArt = false;
		public string ahkPause = "";
		public string ahkResume = "";
		public string htmlFile = "";
		public string variablesData = "";

		public bool executePauseAfter = false;
		public int delayStarting = 0;
		public int delayAutoClose = 0;
		public string typeScreen = "pause";
		public string selectedMonitor = "Main";
		public bool showDevTools = false;
		public bool ahkFromExe = false;
		public bool includeSpecialVariable = false;


		public int dpi = 0;


		public PauseMenu_Config(Dictionary<string, string> Options)
		{
			this.KeyPicker = new PickKeyCombo(this);
			this.GKeyPicker = new PickControllerCombo(this);

			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;

			keyCombo = Options.ContainsKey("keyCombo") ? Options["keyCombo"] : "";
			gamepadCombo = Options.ContainsKey("gamepadCombo") ? Options["gamepadCombo"] : "";

			if (Options.ContainsKey("forcefullActivation") && Options["forcefullActivation"] == "yes") forcefullActivation = true;
			if (Options.ContainsKey("pauseEmulation") && Options["pauseEmulation"] == "yes") pauseEmulation = true;
			if (Options.ContainsKey("disableSound") && Options["disableSound"] == "yes") disableSound = true;
			if (Options.ContainsKey("copyArt") && Options["copyArt"] == "yes") copyArt = true;

			ahkPause = Options.ContainsKey("ahkPause") ? Options["ahkPause"] : "";
			ahkResume = Options.ContainsKey("ahkResume") ? Options["ahkResume"] : "";
			htmlFile = Options.ContainsKey("htmlFile") ? Options["htmlFile"] : "";

			variablesData = Options.ContainsKey("variablesData") ? Options["variablesData"] : "";

			if (Options.ContainsKey("executePauseAfter") && Options["executePauseAfter"] == "yes") executePauseAfter = true;
			if (Options.ContainsKey("includeSpecialVariable") && Options["includeSpecialVariable"] == "yes") includeSpecialVariable = true;



			int tmpInt = 0;
			gamepadKeyPressMinDuration = 0;
			if (Options.ContainsKey("gamepadKeyPressMinDuration"))
			{
				if(int.TryParse(Options["gamepadKeyPressMinDuration"], out tmpInt))
				{
					gamepadKeyPressMinDuration = tmpInt;
				}
			}

			tmpInt = 0;
			delayStarting = 0;
			if (Options.ContainsKey("delayStarting"))
			{
				if (int.TryParse(Options["delayStarting"], out tmpInt))
				{
					delayStarting = tmpInt;
				}
			}

			tmpInt = 0;
			delayAutoClose = 0;
			if (Options.ContainsKey("delayAutoClose"))
			{
				if (int.TryParse(Options["delayAutoClose"], out tmpInt))
				{
					delayAutoClose = tmpInt;
				}
			}

			tmpInt = 0;
			dpi = 0;
			if (Options.ContainsKey("dpi"))
			{
				if (int.TryParse(Options["dpi"], out tmpInt))
				{
					dpi = tmpInt;
				}
			}

			typeScreen = Options.ContainsKey("typeScreen") ? Options["typeScreen"] : "pause";
			selectedMonitor = Options.ContainsKey("selectedMonitor") ? Options["selectedMonitor"] : "Main";
			if (Options.ContainsKey("showDevTools") && Options["showDevTools"] == "yes") showDevTools = true;
			if (Options.ContainsKey("ahkFromExe") && Options["ahkFromExe"] == "yes") ahkFromExe = true;

			InitializeComponent();

			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;
			TextBoxKeyCombo.Text = keyCombo;
			TextBoxGKeyCombo.Text = gamepadCombo;
			num_gamepadKeyPressMinDuration.Value = gamepadKeyPressMinDuration;
			chk_forcefullActivation.Checked = forcefullActivation;

			chk_copyArty.Checked = copyArt;
			chk_pauseEmulation.Checked = pauseEmulation;
			chk_disableSound.Checked = disableSound;
			txt_file.Text = htmlFile;
			txt_ahkPause.Text = ahkPause;
			txt_ahkResume.Text = ahkResume;

			num_delaystart.Value = delayStarting;
			num_autoclose.Value = delayAutoClose;
			chk_executePauseAfter.Checked = executePauseAfter;

			if(typeScreen=="pause") radio_pause.Checked = true;
			if(typeScreen=="start") radio_startup.Checked = true;
			if(typeScreen=="end") radio_end.Checked = true;

			chk_showDevTools.Checked = showDevTools;
			chk_ahkFromExe.Checked = ahkFromExe;
			chk_includeSpecialVariable.Checked = includeSpecialVariable;


			UpdateGUI();
			UpdateRadioGUI();

			cmb_add.Items.Clear();
			cmb_add.Items.Add("Main");
			Screen[] screens = Screen.AllScreens;
			Debug.WriteLine($"Nombre d'écrans : {screens.Length}");
			for (int i = 0; i < screens.Length; i++)
			{
				Screen screen = screens[i];
				Debug.WriteLine($"Écran {i + 1}");
				Debug.WriteLine($"Device Name : {screen.DeviceName}");
				Debug.WriteLine($"Working Area : {screen.WorkingArea}");
				Debug.WriteLine($"Bounds : {screen.Bounds}");
				Debug.WriteLine($"Primary : {screen.Primary}");

				int currentDpi = DPIUtils.GetMonitorDPI(i);
				Debug.WriteLine($"Primary : {currentDpi}");

				string DeviceName = screen.DeviceName.Trim('\\').Trim('.').Trim('\\');

				cmb_add.Items.Add(DeviceName);
			}
			var index = cmb_add.Items.IndexOf(selectedMonitor);
			if (index >= 0)
			{
				cmb_add.SelectedIndex = index;
			}
			else
			{
				cmb_add.Items.Add(selectedMonitor);
				index = cmb_add.Items.IndexOf(selectedMonitor);
				cmb_add.SelectedIndex = index;
			}

			cmb_dpi.Items.Clear();
			cmb_dpi.Items.Add("Automatic");
			cmb_dpi.Items.Add("100%");
			cmb_dpi.Items.Add("125%");
			cmb_dpi.Items.Add("150%");
			cmb_dpi.Items.Add("175%");
			cmb_dpi.Items.Add("200%");
			cmb_dpi.Items.Add("225%");
			cmb_dpi.SelectedIndex = 0;
			index = cmb_dpi.Items.IndexOf(dpi.ToString() + "%");
			if (index >= 0)
			{
				cmb_dpi.SelectedIndex = index;
			}
			
			




		}

		private void UpdateRadioGUI()
		{
			if (radio_pause.Checked) typeScreen = "pause";
			if (radio_startup.Checked) typeScreen = "start";
			if (radio_end.Checked) typeScreen = "end";

			if (typeScreen == "pause")
			{
				num_autoclose.Visible = false;
				TextBoxKeyCombo.Visible = true;
				TextBoxGKeyCombo.Visible=true;
				button6.Visible = true;
				button1.Visible = true;
			}
			else 
			{
				num_autoclose.Visible = true;
				TextBoxKeyCombo.Visible = false;
				TextBoxGKeyCombo.Visible = false;
				button6.Visible = false;
				button1.Visible = false;
			}

		}
		private void UpdateGUI()
		{
			listBox1.Items.Clear();
			if (!String.IsNullOrEmpty(variablesData))
			{
				var priority_arr = BigBoxUtils.explode(variablesData, "|||");
				foreach (var p in priority_arr)
				{
					var pObj = new VariableData(p);
					listBox1.Items.Add(pObj.VariableName);
				}
			}

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			string errorTxt = "";
			if (!BigBoxUtils.AHKSyntaxCheck(txt_ahkPause.Text, true, out errorTxt))
			{
				DialogResult dialogResult = MessageBox.Show($"Syntax error : {errorTxt} \n Are you sure you want to save ?", "<<AHK Pause code>> Syntax error", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}
			errorTxt = "";
			if (!BigBoxUtils.AHKSyntaxCheck(txt_ahkResume.Text, true, out errorTxt))
			{
				DialogResult dialogResult = MessageBox.Show($"Syntax error : {errorTxt} \n Are you sure you want to save ?", "<<AHK Resume code>> Syntax error", MessageBoxButtons.YesNo);
				if (dialogResult == DialogResult.No)
				{
					return;
				}
			}

			List<string> variablesList = new List<string>();
			for (int i = 0; i < listBox1.Items.Count; i++)
			{
				variablesList.Add(listBox1.Items[i].ToString());
			}

			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;
			keyCombo = TextBoxKeyCombo.Text;
			gamepadCombo = TextBoxGKeyCombo.Text;
			gamepadKeyPressMinDuration = (int)num_gamepadKeyPressMinDuration.Value;
			forcefullActivation = chk_forcefullActivation.Checked;

			copyArt = chk_copyArty.Checked;
			pauseEmulation = chk_pauseEmulation.Checked;
			disableSound = chk_disableSound.Checked;
			htmlFile = txt_file.Text;

			ahkPause = txt_ahkPause.Text;
			ahkResume = txt_ahkResume.Text;

			delayStarting = (int)num_delaystart.Value;
			delayAutoClose = (int)num_autoclose.Value;
			executePauseAfter = chk_executePauseAfter.Checked;


			if (radio_pause.Checked) typeScreen = "pause";
			if (radio_startup.Checked) typeScreen = "start";
			if (radio_end.Checked) typeScreen = "end";

			selectedMonitor = cmb_add.SelectedItem.ToString();

			dpi = 0;
			string dpistring = cmb_dpi.SelectedItem.ToString();
			if (dpistring != "Automatic")
			{
				dpistring = dpistring.Trim('%').Trim();
				int tmpDpi = 0;
				if (int.TryParse(dpistring, out tmpDpi))
				{
					dpi = tmpDpi;
				}
			}

			showDevTools = chk_showDevTools.Checked;
			ahkFromExe = chk_ahkFromExe.Checked;
			includeSpecialVariable = chk_includeSpecialVariable.Checked;

			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void btn_manage_filter_Click(object sender, EventArgs e)
		{
			var frm = new Manage_Items(txt_filter.Text);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				txt_filter.Text = frm.TxtValue;
			}
		}

		private void btn_manage_exclude_Click(object sender, EventArgs e)
		{
			var frm = new Manage_Items(txt_exclude.Text);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				txt_exclude.Text = frm.TxtValue;
			}
		}

		public void DrawKeyDisplay()
		{
			TextBoxKeyCombo.Text = PickKeyCombo.GetKeyCombo(this.Keys, true);
		}

		public void DrawGKeyDisplay()
		{
			TextBoxGKeyCombo.Text = PickControllerCombo.GetGKeyCombo(this.GKeys);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			button6.Enabled = false;
			foreach (Control c in this.Controls)
			{
				c.Enabled = false;
			}

			//KeyComboGroupBox.Enabled = true;
			TextBoxKeyCombo.Text = "Press up to three keys...";
			KeyPicker.StartPicking();
			Focus();
			TextBoxKeyCombo.Focus();
			TextBoxKeyCombo.Select(TextBoxKeyCombo.Text.Length, 0);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			button1.Enabled = false;
			foreach (Control c in this.Controls)
			{
				c.Enabled = false;
			}

			//KeyComboGroupBox.Enabled = true;
			TextBoxGKeyCombo.Text = "Press up to three keys...";
			GKeyPicker.StartPicking();
			Focus();
			TextBoxGKeyCombo.Focus();
			TextBoxGKeyCombo.Select(TextBoxGKeyCombo.Text.Length, 0);
		}

		private void txt_file_TextChanged(object sender, EventArgs e)
		{

		}

		private void btn_manageVariables_Click(object sender, EventArgs e)
		{
			var frm = new Manage_Variables(variablesData);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				variablesData = frm.result;
				UpdateGUI();
			}
		}

		private void PauseMenu_Config_Load(object sender, EventArgs e)
		{

		}

		private void radio_startup_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRadioGUI();
		}

		private void radio_end_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRadioGUI();
		}

		private void radio_pause_CheckedChanged(object sender, EventArgs e)
		{
			UpdateRadioGUI();
		}

		private void btn_file_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					// Obtenez le chemin complet du fichier sélectionné
					txt_file.Text = openFileDialog.FileName;

				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			MessageBox.Show(Emulator.LastEmulatorName);
		}

		private void btn_importFromLaunchbox_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Please select the Emulators.xml file in the Data directory of Launchbox.");
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Fichiers XML (*.xml)|*.xml|Tous les fichiers (*.*)|*.*";
				openFileDialog.FilterIndex = 1;
				openFileDialog.CheckFileExists = true;
				openFileDialog.CheckPathExists = true;
				openFileDialog.Title = "Select Emulators.xml";

				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					if (Path.GetFileName(openFileDialog.FileName) != "Emulators.xml")
					{
						MessageBox.Show("Please select the Emulators.xml file in the Data directory of Launchbox.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						string sourceXml = openFileDialog.FileName;
						string exename = Emulator.LastEmulatorName;
						try
						{
							XDocument xdoc = XDocument.Parse(File.ReadAllText(sourceXml));
							var node = xdoc.Root.Elements("Emulator").Where(p => ((string)p.Element("ApplicationPath")).ToLower().EndsWith(exename.Trim().ToLower())).FirstOrDefault();
							if(node != null)
							{
								string pauseScript = node.Elements("PauseAutoHotkeyScript").FirstOrDefault().Value;
								string resumeScript = node.Elements("ResumeAutoHotkeyScript").FirstOrDefault().Value;
								string loadStateScript = node.Elements("LoadStateAutoHotkeyScript").FirstOrDefault().Value;
								string saveStateScript = node.Elements("SaveStateAutoHotkeyScript").FirstOrDefault().Value;
								string resetScript = node.Elements("ResetAutoHotkeyScript").FirstOrDefault().Value;
								string swapDiscsScript = node.Elements("SwapDiscsAutoHotkeyScript").FirstOrDefault().Value;

								txt_ahkPause.Text = pauseScript;
								txt_ahkResume.Text = resumeScript;

								Dictionary<string, VariableData> variablesDictionary = new Dictionary<string, VariableData>();
								if (!String.IsNullOrEmpty(variablesData))
								{
									var priority_arr = BigBoxUtils.explode(variablesData, "|||");
									foreach (var p in priority_arr)
									{
										var pObj = new VariableData(p);
										if (!variablesDictionary.ContainsKey(pObj.VariableName))
										{
											variablesDictionary.Add(pObj.VariableName, pObj);
										}
									}
								}

								bool IsVariableAdded = false;
								//if(!string.IsNullOrEmpty(loadStateScript))
								{
									string keyname = "{{loadState}}";
									if (!variablesDictionary.ContainsKey(keyname))
									{
										VariableData newItem = new VariableData();
										newItem.VariableName = keyname;
										newItem.SourceData = "cmd";
										newItem.VariableValue = loadStateScript;
										variablesDictionary.Add(keyname, newItem);
										IsVariableAdded = true;
									}
								}
								//if (!string.IsNullOrEmpty(saveStateScript))
								{
									string keyname = "{{saveState}}";
									if (!variablesDictionary.ContainsKey(keyname))
									{
										VariableData newItem = new VariableData();
										newItem.VariableName = keyname;
										newItem.SourceData = "cmd";
										newItem.VariableValue = saveStateScript;
										variablesDictionary.Add(keyname, newItem);
										IsVariableAdded = true;
									}
								}
								//if (!string.IsNullOrEmpty(resetScript))
								{
									string keyname = "{{reset}}";
									if (!variablesDictionary.ContainsKey(keyname))
									{
										VariableData newItem = new VariableData();
										newItem.VariableName = keyname;
										newItem.SourceData = "cmd";
										newItem.VariableValue = resetScript;
										variablesDictionary.Add(keyname, newItem);
										IsVariableAdded = true;
									}
								}
								//if (!string.IsNullOrEmpty(swapDiscsScript))
								{
									string keyname = "{{swapDiscs}}";
									if (!variablesDictionary.ContainsKey(keyname))
									{
										VariableData newItem = new VariableData();
										newItem.VariableName = keyname;
										newItem.SourceData = "cmd";
										newItem.VariableValue = swapDiscsScript;
										variablesDictionary.Add(keyname, newItem);
										IsVariableAdded = true;
									}
								}
								{
									string keyname = "{{exit}}";
									if (!variablesDictionary.ContainsKey(keyname))
									{
										VariableData newItem = new VariableData();
										newItem.VariableName = keyname;
										newItem.SourceData = "cmd";
										newItem.VariableValue = "WinClose, ahk_exe {{{StartupEXE}}}";
										variablesDictionary.Add(keyname, newItem);
										IsVariableAdded = true;
									}
								}
								{
									string keyname = "{{{StartupEXE}}}";
									if (!variablesDictionary.ContainsKey(keyname))
									{
										VariableData newItem = new VariableData();
										newItem.VariableName = keyname;
										newItem.SourceData = "cmd";
										newItem.RegexToMatch = @"(.*?)(?:[\\/])?([^\\/]+)(\.exe)(.*)";
										newItem.VariableValue = @"\2\3";
										newItem.FallbackValue = Emulator.LastEmulatorName;
										variablesDictionary.Add(keyname, newItem);
										IsVariableAdded = true;
									}
								}



								if (IsVariableAdded)
								{
									listBox1.Items.Clear();
									string result = "";
									foreach(var variable in variablesDictionary)
									{
										listBox1.Items.Add(variable.Key);
										result += variable.Value.Serialize() + "|||";
									}
									result = result.Trim('|').Trim('|').Trim('|').Trim('|').Trim('|').Trim('|');
									variablesData = result;
								}

							}
						}
						catch(Exception ex)
						{
							MessageBox.Show("erreur :" + ex.Message);
						}
					}
				}
			}

			

		}

		private void chk_copyArty_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void btn_clearkeyboard_Click(object sender, EventArgs e)
		{
			TextBoxKeyCombo.Text = string.Empty;
		}

		private void btn_cleargamepad_Click(object sender, EventArgs e)
		{
			TextBoxGKeyCombo.Text = string.Empty;
		}
	}

	public class PickControllerCombo
	{
		private PauseMenu_Config AddForm { get; set; }

		public string[] GKeys { get; set; }
		public X.Gamepad gamepad1;

		public event EventHandler GamepadKeyDown;
		public event EventHandler GamepadKeyUp;
		public Dictionary<string, bool> StateKeys = new Dictionary<string, bool>();



		public PickControllerCombo(PauseMenu_Config addForm)
		{
			this.AddForm = addForm;
		}

		public void StartPicking()
		{
			StateKeys.Clear();
			StateKeys.Add("A", false);
			StateKeys.Add("B", false);
			StateKeys.Add("X", false);
			StateKeys.Add("Y", false);
			StateKeys.Add("Start", false);
			StateKeys.Add("Back", false);
			StateKeys.Add("Guide", false);

			StateKeys.Add("Dpad_Up", false);
			StateKeys.Add("Dpad_Down", false);
			StateKeys.Add("Dpad_Left", false);
			StateKeys.Add("Dpad_Right", false);
			StateKeys.Add("LBumper", false);
			StateKeys.Add("RBumper", false);

			this.GKeys = new string[0];
			gamepad1 = X.Gamepad_1;
			gamepad1.StateChanged += StateChanged;
			GamepadKeyDown += GlobalKeyDown;
			GamepadKeyUp += GlobalKeyUp;
			X.StartPolling(gamepad1);



		}

		private void StateChanged(object sender, EventArgs e)
		{
			var z = gamepad1;

			bool keyDown = false;
			bool keyUp = false;
			if (gamepad1.A_down && StateKeys["A"] != gamepad1.A_down) keyDown = true;
			if (gamepad1.B_down && StateKeys["B"] != gamepad1.B_down) keyDown = true;
			if (gamepad1.X_down && StateKeys["X"] != gamepad1.X_down) keyDown = true;
			if (gamepad1.Y_down && StateKeys["Y"] != gamepad1.Y_down) keyDown = true;
			if (gamepad1.Start_down && StateKeys["Start"] != gamepad1.Start_down) keyDown = true;
			if (gamepad1.Back_down && StateKeys["Back"] != gamepad1.Back_down) keyDown = true;
			if (gamepad1.Guide_down && StateKeys["Guide"] != gamepad1.Guide_down) keyDown = true;

			// Gestion des boutons Dpad_Up, Dpad_Down, Dpad_Left, Dpad_Right, LBumper, RBumper
			if (gamepad1.Dpad_Up_down && StateKeys["Dpad_Up"] != gamepad1.Dpad_Up_down) keyDown = true;
			if (gamepad1.Dpad_Down_down && StateKeys["Dpad_Down"] != gamepad1.Dpad_Down_down) keyDown = true;
			if (gamepad1.Dpad_Left_down && StateKeys["Dpad_Left"] != gamepad1.Dpad_Left_down) keyDown = true;
			if (gamepad1.Dpad_Right_down && StateKeys["Dpad_Right"] != gamepad1.Dpad_Right_down) keyDown = true;
			if (gamepad1.LBumper_down && StateKeys["LBumper"] != gamepad1.LBumper_down) keyDown = true;
			if (gamepad1.RBumper_down && StateKeys["RBumper"] != gamepad1.RBumper_down) keyDown = true;


			if (!keyDown)
			{
				if (gamepad1.A_up && StateKeys["A"] == gamepad1.A_up) keyUp = true;
				if (gamepad1.B_up && StateKeys["B"] == gamepad1.B_up) keyUp = true;
				if (gamepad1.X_up && StateKeys["X"] == gamepad1.X_up) keyUp = true;
				if (gamepad1.Y_up && StateKeys["Y"] == gamepad1.Y_up) keyUp = true;
				if (gamepad1.Start_up && StateKeys["Start"] == gamepad1.Start_up) keyUp = true;
				if (gamepad1.Back_up && StateKeys["Back"] == gamepad1.Back_up) keyUp = true;
				if (gamepad1.Guide_up && StateKeys["Guide"] == gamepad1.Guide_up) keyUp = true;

				// Gestion des boutons Dpad_Up, Dpad_Down, Dpad_Left, Dpad_Right, LBumper, RBumper
				if (gamepad1.Dpad_Up_up && StateKeys["Dpad_Up"] == gamepad1.Dpad_Up_up) keyUp = true;
				if (gamepad1.Dpad_Down_up && StateKeys["Dpad_Down"] == gamepad1.Dpad_Down_up) keyUp = true;
				if (gamepad1.Dpad_Left_up && StateKeys["Dpad_Left"] == gamepad1.Dpad_Left_up) keyUp = true;
				if (gamepad1.Dpad_Right_up && StateKeys["Dpad_Right"] == gamepad1.Dpad_Right_up) keyUp = true;
				if (gamepad1.LBumper_up && StateKeys["LBumper"] == gamepad1.LBumper_up) keyUp = true;
				if (gamepad1.RBumper_up && StateKeys["RBumper"] == gamepad1.RBumper_up) keyUp = true;


				if (keyUp) GamepadKeyUp(this, EventArgs.Empty);
			}

			StateKeys["A"] = gamepad1.A_down;
			StateKeys["B"] = gamepad1.B_down;
			StateKeys["X"] = gamepad1.X_down;
			StateKeys["Y"] = gamepad1.Y_down;
			StateKeys["Start"] = gamepad1.Start_down;
			StateKeys["Back"] = gamepad1.Back_down;
			StateKeys["Guide"] = gamepad1.Guide_down;
			StateKeys["Dpad_Up"] = gamepad1.Dpad_Up_down;
			StateKeys["Dpad_Down"] = gamepad1.Dpad_Down_down;
			StateKeys["Dpad_Left"] = gamepad1.Dpad_Left_down;
			StateKeys["Dpad_Right"] = gamepad1.Dpad_Right_down;
			StateKeys["LBumper"] = gamepad1.LBumper_down;
			StateKeys["RBumper"] = gamepad1.RBumper_down;

			if (keyDown)
			{
				GamepadKeyDown(this, EventArgs.Empty);
				return;
			}

		}

		private void GlobalKeyDown(object sender, EventArgs e)
		{
			//lock (this.GKeys)
			//{
			List<string> PressedKeys = new List<string>();
			foreach (var skey in StateKeys.Where(s => s.Value == true))
			{
				PressedKeys.Add(skey.Key);
			}
			this.GKeys = PressedKeys.ToArray();
			//}



			//AddForm.TextBoxKeyCombo.Text = GetKeyCombo(this.Keys, true);
			//AddForm.DrawKeyDisplay();

		}

		private void GlobalKeyUp(object sender, EventArgs e)
		{

			AddForm.GKeys = this.GKeys;
			// update form
			foreach (Control c in AddForm.Controls)
			{
				c.Enabled = true;
			}

			AddForm.DrawGKeyDisplay();
			//AddForm.TextBoxKeyCombo.Select(AddForm.TextBoxKeyCombo.Text.Length, 0);

			// remove hook

			X.StopPolling();

		}

		internal static string GetGKeyCombo(string[] gKeys)
		{
			string res = string.Empty;
			int count = 0;
			foreach (var gkey in gKeys)
			{
				if (count != 0) res += "+";
				res += gkey;
				count++;
			}
			return res;
		}
	}

	public class PickKeyCombo
	{
		private PauseMenu_Config AddForm { get; set; }

		public Keys[] Keys { get; set; }

		public PickKeyCombo(PauseMenu_Config addForm)
		{
			this.AddForm = addForm;
			this.Keys = new Keys[3];
		}

		public void StartPicking()
		{
			Keys = new Keys[3];
			HookManager.CleanHook();
			HookManager.SetKeyDown(GlobalKeyDown);
			HookManager.SetKeyUp(GlobalKeyUp);
		}

		private void GlobalKeyDown(object sender, KeyEventArgs e)
		{

			string[] parts = GetKeyCombo(Keys, true).Split('+');
			if (parts.Where(p => p == PrettyKeys.Convert(e.KeyCode)).Any()) return; // dont allow duplicate keys in the combo

			if (parts.Length < 3)
			{
				for (int i = 0; i < Keys.Length; i++)
				{
					if (Keys[i] == System.Windows.Forms.Keys.None)
					{
						Keys[i] = e.KeyCode;
						break;
					}
				}
			}
			//AddForm.TextBoxKeyCombo.Text = GetKeyCombo(this.Keys, true);
			//AddForm.DrawKeyDisplay();

		}

		private void GlobalKeyUp(object sender, KeyEventArgs e)
		{

			AddForm.Keys = Keys;
			// update form
			foreach (Control c in AddForm.Controls)
			{
				c.Enabled = true;
			}



			AddForm.DrawKeyDisplay();
			//AddForm.TextBoxKeyCombo.Select(AddForm.TextBoxKeyCombo.Text.Length, 0);

			// remove hook

			HookManager.CleanHook();
		}

		public static string GetKeyCombo(Keys[] keys, bool pretty)
		{
			string res = string.Empty;
			int count = 0;
			foreach (Keys key in keys.Where(k => k != System.Windows.Forms.Keys.None))
			{
				if (count != 0) res += "+";
				res += pretty ? PrettyKeys.Convert(key) : key.ToString();
				count++;
			}
			return res;
		}
	}
}
