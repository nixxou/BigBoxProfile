using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BigBoxProfile
{
	public partial class EmulatorConfig : Form
	{
		private Emulator _emulator;
		public EmulatorConfig(string emulatorExe, string profileName)
		{
			_emulator = new Emulator(profileName, emulatorExe);
			InitializeComponent();
			
		}

		private void EmulatorConfig_Load(object sender, EventArgs e)
		{
			txt_emulatorExe.Text = _emulator.FileNameEmulator;
			txt_profileName.Text = _emulator.ProfileName;

			if(_emulator.ProfileName.ToLower() != "default") chk_ApplyWithoutLaunchbox.Visible= false;
			else
			{
				if (_emulator.ApplyWithoutLaunchbox) chk_ApplyWithoutLaunchbox.Checked = true;
				else chk_ApplyWithoutLaunchbox.Checked= false;
			}


			foreach (var module in _emulator._modules)
			{
				cmb_selectAction.Items.Add(module.ModuleName);
			}
			foreach (var module in _emulator._selectedModules)
			{

				ListViewItem item = new ListViewItem();
				item.Text = module.ToString(); // Or whatever display text you need
				item.Tag = module;
				lv_selectedActions.Items.Add(item);
			}
			lv_selectedActions.DoubleClick += new EventHandler(lv_selectedActions_DoubleClick);

			txt_exempleIn.Text = _emulator.FileNameEmulator + " " + "\"C:\\MyRomDir\\MyRom.bin\"";
			CalculateExemple();
		}

		private void CalculateExemple()
		{
			string initial_cmd = txt_exempleIn.Text;
			string ExeName = "";
			string[] args = BigBoxUtils.CommandLineToArgs(initial_cmd, out ExeName, false);
			args = BigBoxUtils.AddFirstElementToArg(args, ExeName);

			foreach (ListViewItem lvitem in lv_selectedActions.Items)
			{
				var module = (IEmulatorAction)lvitem.Tag;
				if(module.IsConfigured()) args = module.ModifyExemple(args);
			}
			string outCmd = BigBoxUtils.ArgsToCommandLine(args);
			txt_exempleOut.Text = outCmd;
		}

		private void button6_Click(object sender, EventArgs e)
		{
			var selectedModule = _emulator._modules[cmb_selectAction.SelectedIndex];

			// Ajouter une nouvelle instance du module à la liste des modules sélectionnés
			var newModuleInstance = selectedModule.CreateNewInstance();

			_emulator._selectedModules.Add(newModuleInstance);

			// Ajouter le nom du module à la liste des modules sélectionnés dans la listBox


			ListViewItem item = new ListViewItem();
			item.Text = newModuleInstance.ToString(); // Or whatever display text you need
			item.Tag = newModuleInstance;
			lv_selectedActions.Items.Add(item);
		}

		private void groupBox3_Enter(object sender, EventArgs e)
		{

		}

		private void lv_selectedActions_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lv_selectedActions.SelectedItems.Count > 0)
			{
				btn_delete.Enabled = true;
				btn_down.Enabled = true;
				btn_up.Enabled = true;

			}
			else
			{
				btn_delete.Enabled = false;
				btn_down.Enabled = false;
				btn_up.Enabled = false;
			}
		}

		private void lv_selectedActions_DoubleClick(object sender, EventArgs e)
		{

			var myAction = (IEmulatorAction)lv_selectedActions.SelectedItems[0].Tag;
			myAction.Configure();
			lv_selectedActions.SelectedItems[0].Text = myAction.ToString();
			lv_selectedActions.Refresh();
			CalculateExemple();

		}

		private void button8_Click(object sender, EventArgs e)
		{
			var options = new List<ConfigurationData>();
			foreach(ListViewItem lvitem in lv_selectedActions.Items)
			{
				var module = (IEmulatorAction)lvitem.Tag;
				var emulationActionOption = new ConfigurationData();
				emulationActionOption.name = module.ModuleName;
				emulationActionOption.Options = module.Options;
				options.Add(emulationActionOption);

			}

			var emulationActionOptionEmulator = new ConfigurationData();
			emulationActionOptionEmulator.name = "OptionsEmulator";
			emulationActionOptionEmulator.Options = new Dictionary<string, string>();
			if (chk_ApplyWithoutLaunchbox.Checked)
			{
				emulationActionOptionEmulator.Options["ApplyWithoutLaunchbox"] = "yes";
			}
			else
			{
				emulationActionOptionEmulator.Options["ApplyWithoutLaunchbox"] = "no";
			}
			options.Add(emulationActionOptionEmulator);


			ConfigurationData.SaveConfigurationDataList(_emulator.FileNameConfig, options);
		}

		private void txt_exempleIn_TextChanged(object sender, EventArgs e)
		{
			CalculateExemple();
		}

		private void btn_up_Click(object sender, EventArgs e)
		{
			if (lv_selectedActions.SelectedItems.Count > 0)
			{
				int selectedIndex = lv_selectedActions.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = lv_selectedActions.SelectedItems[0];
					lv_selectedActions.Items.RemoveAt(selectedIndex);
					lv_selectedActions.Items.Insert(selectedIndex - 1, item);
					lv_selectedActions.Focus();
					lv_selectedActions.Items[selectedIndex - 1].Selected = true;
					CalculateExemple();
				}
			}
		}

		private void btn_down_Click(object sender, EventArgs e)
		{
			if (lv_selectedActions.SelectedItems.Count > 0)
			{
				int selectedIndex = lv_selectedActions.SelectedIndices[0];
				if (selectedIndex < lv_selectedActions.Items.Count - 1)
				{
					ListViewItem item = lv_selectedActions.SelectedItems[0];
					lv_selectedActions.Items.RemoveAt(selectedIndex);
					lv_selectedActions.Items.Insert(selectedIndex + 1, item);
					lv_selectedActions.Focus();
					lv_selectedActions.Items[selectedIndex + 1].Selected = true;
					CalculateExemple();
				}
			}
		}

		private void btn_delete_Click(object sender, EventArgs e)
		{
			if (lv_selectedActions.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = lv_selectedActions.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				lv_selectedActions.Items.RemoveAt(selectedIndex);
				CalculateExemple();
			}
		}

		private void cmb_selectAction_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmb_selectAction.SelectedIndex == -1)
			{
				btn_add.Enabled = false;

			}
			else
			{
				btn_add.Enabled = true;
			}
		}
	}
}
