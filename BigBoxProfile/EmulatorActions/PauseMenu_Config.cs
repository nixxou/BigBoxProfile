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
		public bool copyArt = true;
		public string ahkPause = "";
		public string ahkResume = "";
		public string htmlFile = "";
		public string variablesData = "";


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
			if (Options.ContainsKey("copyArt") && Options["copyArt"] == "no") copyArt = false;

			ahkPause = Options.ContainsKey("ahkPause") ? Options["ahkPause"] : "";
			ahkResume = Options.ContainsKey("ahkResume") ? Options["ahkResume"] : "";
			htmlFile = Options.ContainsKey("htmlFile") ? Options["htmlFile"] : "";

			variablesData = Options.ContainsKey("variablesData") ? Options["variablesData"] : "";

			int tmpInt = 0;
			gamepadKeyPressMinDuration = 0;
			if (Options.ContainsKey("gamepadKeyPressMinDuration"))
			{
				if(int.TryParse(Options["gamepadKeyPressMinDuration"], out tmpInt))
				{
					gamepadKeyPressMinDuration = tmpInt;
				}
			}
			//gamepadKeyPressMinDuration = Options.ContainsKey("gamepadKeyPressMinDuration") ? int.Parse(Options["gamepadKeyPressMinDuration"]) : 0;

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
			txt_file.Text = htmlFile;
			txt_ahkPause.Text = ahkPause;
			txt_ahkResume.Text = ahkResume;
			UpdateGUI();
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
			htmlFile = txt_file.Text;

			ahkPause = txt_ahkPause.Text;
			ahkResume = txt_ahkResume.Text;



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
