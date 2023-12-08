using BigBoxProfile.HID;
using ComponentFactory.Krypton.Toolkit;
using HidSharp.Utility;
using SharpDX;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace BigBoxProfile.EmulatorActions
{
	public partial class RetroarchFixSiden_Config : KryptonForm
	{

		private CancellationTokenSource tokenSource_Priority;

		public string filter = "";
		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;
		public bool matchAllFilter = false;
		public bool matchAllExclude = false;

		public string priority = "SidenBlue,SidenRed,SidenBlack,SidenPlayer2";
		//public bool forceDefaultNoFilter = false;
		//public bool forceDefaultNoMatch = false;

		public bool matchModuleOnce = true;
		public string restrictgun1 = "";
		public string restrictgun2 = "";
		public string restrictgun3 = "";
		public string restrictgun4 = "";
		public bool enablegun1 = true;
		public bool enablegun2 = true;
		public bool enablegun3 = false;
		public bool enablegun4 = false;

		public bool addInputArg = true;
		public string supermodelConfig = @"
InputGunX = ""GUN1_XAXIS,JOY1_XAXIS""
InputGunY = ""GUN1_YAXIS,JOY1_YAXIS""
InputTrigger = ""KEY_A,JOY1_BUTTON1,GUN1_LEFT_BUTTON""
InputOffscreen = ""KEY_S,JOY1_BUTTON2,GUN1_RIGHT_BUTTON""   

InputGunX2 = ""GUN2_XAXIS,JOY2_XAXIS""    
InputGunY2 = ""GUN2_YAXIS,JOY2_YAXIS""    
InputTrigger2 = ""KEY_A,JOY1_BUTTON1,GUN2_LEFT_BUTTON""
InputOffscreen2 = ""KEY_S,JOY1_BUTTON2,GUN2_RIGHT_BUTTON"" 

InputAnalogGunX = ""GUN1_XAXIS,JOY1_XAXIS""    
InputAnalogGunY = ""GUN1_YAXIS,JOY1_YAXIS""   
InputAnalogTriggerLeft = ""KEY_A,JOY1_BUTTON1,GUN1_LEFT_BUTTON""
InputAnalogTriggerRight = ""KEY_S,JOY1_BUTTON2,GUN1_RIGHT_BUTTON""

InputAnalogGunX2 = ""GUN2_XAXIS,JOY2_XAXIS""
InputAnalogGunY2 = ""GUN2_YAXIS,JOY2_YAXIS""
InputAnalogTriggerLeft2 = ""KEY_C,JOY1_BUTTON1,GUN2_LEFT_BUTTON""
InputAnalogTriggerRight2 = ""KEY_D,JOY1_BUTTON2,GUN2_RIGHT_BUTTON""
";

		public bool Supermodel = false;

		public RetroarchFixSiden_Config(Dictionary<string, string> Options, bool supermodel = false)
		{
			Supermodel = supermodel;
			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;
			if (Options.ContainsKey("matchAllFilter") && Options["matchAllFilter"] == "yes") matchAllFilter = true;
			if (Options.ContainsKey("matchAllExclude") && Options["matchAllExclude"] == "yes") matchAllExclude = true;

			priority = Options.ContainsKey("priority") ? Options["priority"] : "SidenBlue,SidenRed,SidenBlack,SidenPlayer2";

			//if (Options.ContainsKey("forceDefaultNoFilter") && Options["forceDefaultNoFilter"] == "yes") forceDefaultNoFilter = true;
			//if (Options.ContainsKey("forceDefaultNoMatch") && Options["forceDefaultNoMatch"] == "yes") forceDefaultNoMatch = true;


			if (Options.ContainsKey("matchModuleOnce") && Options["matchModuleOnce"] == "no") matchModuleOnce = false;
			if (Options.ContainsKey("enablegun1") && Options["enablegun1"] == "no") enablegun1 = false;
			if (Options.ContainsKey("enablegun2") && Options["enablegun2"] == "no") enablegun2 = false;
			if (Options.ContainsKey("enablegun3") && Options["enablegun3"] == "yes") enablegun1 = true;
			if (Options.ContainsKey("enablegun4") && Options["enablegun4"] == "yes") enablegun2 = true;

			restrictgun1 = Options.ContainsKey("restrictgun1") ? Options["restrictgun1"] : "";
			restrictgun2 = Options.ContainsKey("restrictgun2") ? Options["restrictgun2"] : "";
			restrictgun3 = Options.ContainsKey("restrictgun3") ? Options["restrictgun3"] : "";
			restrictgun4 = Options.ContainsKey("restrictgun4") ? Options["restrictgun4"] : "";

			if (Options.ContainsKey("addInputArg") && Options["addInputArg"] == "no") addInputArg = false;

			supermodelConfig = Options.ContainsKey("supermodelConfig") ? Options["supermodelConfig"] : supermodelConfig;

			InitializeComponent();

			txt_filter.Text = filter;
			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;

			chk_filter_matchall.Checked = matchAllFilter;
			if (!commaFilter) chk_filter_matchall.Enabled = false;

			chk_exclude_matchall.Checked = matchAllExclude;
			if (!commaExclude) chk_exclude_matchall.Enabled = false;

			txt_priority_res.Text = priority;
			//chk_dontmatch.Checked = forceDefaultNoFilter;
			//chk_forceDefaultNoMatch.Checked = forceDefaultNoMatch;

			chk_matchModuleOnce.Checked = matchModuleOnce;
			chk_fillgun1.Checked = enablegun1;
			chk_fillgun2.Checked = enablegun2;
			chk_fillgun3.Checked = enablegun3;
			chk_fillgun4.Checked = enablegun4;

			txt_restrictgun1.Text = restrictgun1;
			txt_restrictgun2.Text = restrictgun2;
			txt_restrictgun3.Text = restrictgun3;
			txt_restrictgun4.Text = restrictgun4;

			chk_addInputArg.Checked = addInputArg;
			txt_supermodelConfig.Text = supermodelConfig;

			if (Supermodel)
			{
				chk_fillgun3.Visible = false;
				chk_fillgun4.Visible = false;
				txt_restrictgun3.Visible = false;
				txt_restrictgun4.Visible = false;
				kryptonLabel4.Visible = false;
				kryptonLabel5.Visible = false;
				kryptonLabel1.Text = "Supermodel Sinden Fix";
				kryptonLabel7.Text = "In your Supermodel.ini instead of MOUSE1, use GUN1";
				
			}
			else
			{
				txt_supermodelConfig.Visible = false;
				chk_addInputArg.Visible = false;
			}

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			filter = txt_filter.Text;
			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;

			matchAllFilter = chk_filter_matchall.Checked;
			matchAllExclude = chk_exclude_matchall.Checked;

			priority = txt_priority_res.Text;

			//forceDefaultNoFilter = chk_dontmatch.Checked;
			//forceDefaultNoMatch = chk_forceDefaultNoMatch.Checked;

			matchModuleOnce = chk_matchModuleOnce.Checked;
			enablegun1 = chk_fillgun1.Checked;
			enablegun2 = chk_fillgun2.Checked;
			enablegun3 = chk_fillgun3.Checked;
			enablegun4 = chk_fillgun4.Checked;

			restrictgun1 = txt_restrictgun1.Text;
			restrictgun2 = txt_restrictgun2.Text;
			restrictgun3 = txt_restrictgun3.Text;
			restrictgun4 = txt_restrictgun4.Text;

			addInputArg = chk_addInputArg.Checked;
			supermodelConfig = txt_supermodelConfig.Text;

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

		private void chk_filter_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaFilter = chk_filter_comma.Checked;
			btn_manage_filter.Enabled = commaFilter;
			chk_filter_matchall.Enabled = chk_filter_comma.Checked;
			if (!chk_filter_comma.Checked) chk_filter_matchall.Checked = false;
		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaExclude = chk_exclude_comma.Checked;
			btn_manage_exclude.Enabled = commaExclude;
			chk_exclude_matchall.Enabled = chk_exclude_comma.Checked;
			if (!chk_exclude_comma.Checked) chk_exclude_matchall.Checked = false;
		}

		private void btn_add_priority_Click(object sender, EventArgs e)
		{
			list_priority.Items.Add(txt_priority.Text);
			UpdateFromList(txt_priority_res, list_priority);
		}

		private void btn_up_priority_Click(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_priority.SelectedIndices[0];
				if (selectedIndex > 0)
				{
					ListViewItem item = list_priority.SelectedItems[0];
					list_priority.Items.RemoveAt(selectedIndex);
					list_priority.Items.Insert(selectedIndex - 1, item);
					list_priority.Focus();
					list_priority.Items[selectedIndex - 1].Selected = true;
				}
				UpdateFromList(txt_priority_res, list_priority);
			}
		}

		private void btn_down_priority_Click(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				int selectedIndex = list_priority.SelectedIndices[0];
				if (selectedIndex < list_priority.Items.Count - 1)
				{
					ListViewItem item = list_priority.SelectedItems[0];
					list_priority.Items.RemoveAt(selectedIndex);
					list_priority.Items.Insert(selectedIndex + 1, item);
					list_priority.Focus();
					list_priority.Items[selectedIndex + 1].Selected = true;
				}
				UpdateFromList(txt_priority_res, list_priority);
			}
		}

		private void btn_delete_priority_Click(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				// Récupérer l'index de l'élément sélectionné
				int selectedIndex = list_priority.SelectedIndices[0];

				// Supprimer l'élément sélectionné de la liste
				list_priority.Items.RemoveAt(selectedIndex);
				UpdateFromList(txt_priority_res, list_priority);
			}
		}
		private void UpdateFromList(KryptonTextBox textbox, ListView listview)
		{
			string liste_txt = "";
			foreach (ListViewItem item in listview.Items)
			{
				liste_txt += item.Text + ",";
			}

			liste_txt = liste_txt.TrimEnd(',');
			Invoke(new Action(() =>
			{
				textbox.Text = liste_txt;
			}));

		}

		private void list_priority_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (list_priority.SelectedItems.Count > 0)
			{
				btn_up_priority.Enabled = true;
				btn_down_priority.Enabled = true;
				btn_delete_priority.Enabled = true;

			}
			else
			{
				btn_up_priority.Enabled = false;
				btn_down_priority.Enabled = false;
				btn_delete_priority.Enabled = false;
			}
		}

		private void groupBox2_Enter(object sender, EventArgs e)
		{

		}

		private void btn_showMouse_Click(object sender, EventArgs e)
		{
			txt_showMouse.Text = "";
			var mouseList = MouseIndexRetroarch.ListMouse(Supermodel);
			foreach(var item in mouseList)
			{
				string Line = $"{item.Index} : {item.Name} : {item.Path}\r\n";
				txt_showMouse.Text += Line;
			}
		}

		private void kryptonGroupBox1_Panel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void txt_showMouse_TextChanged(object sender, EventArgs e)
		{

		}

		private void infoLabel_Paint(object sender, PaintEventArgs e)
		{

		}

		private void label12_Paint(object sender, PaintEventArgs e)
		{

		}

		private void RetroarchFixSiden_Config_Load(object sender, EventArgs e)
		{
			UpdateFromTxt(txt_priority_res, list_priority, false);
		}

		private void txt_priority_res_TextChanged(object sender, EventArgs e)
		{
			if (tokenSource_Priority != null)
			{
				// Annuler la tâche précédente si elle existe
				tokenSource_Priority.Cancel();
			}

			tokenSource_Priority = new CancellationTokenSource();
			var cancellationToken = tokenSource_Priority.Token;

			Task.Delay(500, cancellationToken).ContinueWith(task =>
			{

				if (!task.IsCanceled)
				{
					bool isFocus = false;
					Invoke(new Action(() =>
					{
						isFocus = txt_priority_res.Focused;
					}));
					if (isFocus) UpdateFromTxt(txt_priority_res, list_priority, false);
				}
			}, cancellationToken);
		}

		private void txt_priority_res_Leave(object sender, EventArgs e)
		{
			if (tokenSource_Priority != null) tokenSource_Priority.Cancel();
			UpdateFromTxt(txt_priority_res, list_priority, false);

		}
		private void UpdateFromTxt(KryptonTextBox textbox, ListView listview, bool updatetxt = true)
		{
			var liste_txt = textbox.Text;
			var liste_array = BigBoxUtils.explode(liste_txt, ",");
			string liste_txt_res = "";
			Invoke(new Action(() =>
			{
				listview.Items.Clear();
			}));

			foreach (var item in liste_array)
			{
				var path_elem = item.Trim();
				liste_txt_res += path_elem + ",";
				Invoke(new Action(() =>
				{
					listview.Items.Add(path_elem);
				}));

			}
			liste_txt_res = liste_txt_res.TrimEnd(',');
			Invoke(new Action(() =>
			{
				if (updatetxt) textbox.Text = liste_txt_res;
			}));



		}

		private void chk_forceDefaultNoMatch_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void txt_restrictgun4_TextChanged(object sender, EventArgs e)
		{

		}

		private void txt_restrictgun2_TextChanged(object sender, EventArgs e)
		{

		}

		private void kryptonButton1_Click(object sender, EventArgs e)
		{

		}

		private void kryptonLabel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void txt_restrictgun3_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
