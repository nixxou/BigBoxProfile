using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class Replace_Config : KryptonForm
	{
		public string search = "";
		public string replacewith = "";
		public bool useregex = false;
		public bool casesensitive = false;

		public string filter = "";
		public bool asArg = false;
		public bool asCmd = false;
		public bool asFile = false;
		public string selectedFile = "";

		public string exclude = "";
		public bool commaFilter = false;
		public bool commaExclude = false;
		public bool removeFilter = false;


		public Replace_Config(Dictionary<string, string> Options)
		{
			search = Options.ContainsKey("search") ? Options["search"] : "";
			replacewith = Options.ContainsKey("replacewith") ? Options["replacewith"] : "";

			useregex = false;
			if (Options.ContainsKey("useregex"))
			{
				if (Options["useregex"] == "yes") useregex = true;

			}

			casesensitive = false;
			if (Options.ContainsKey("casesensitive"))
			{
				if (Options["casesensitive"] == "yes") casesensitive = true;

			}

			if (Options.ContainsKey("as_cmd"))
			{
				if (Options["as_cmd"] == "yes") asCmd = true;
				else asCmd = false;
			}
			else asCmd = true;

			if (Options.ContainsKey("as_arg"))
			{
				if (Options["as_arg"] == "yes") asArg = true;
				else asArg = false;
			}
			else asArg = false;

			if (Options.ContainsKey("as_file"))
			{
				if (Options["as_file"] == "yes") asFile = true;
				else asFile = false;
			}
			else asFile = false;

			if (asCmd) asArg = asFile = false;
			if (asArg) asCmd = asFile = false;
			if (asFile) asArg = asCmd = false;




			filter = Options.ContainsKey("filter") ? Options["filter"] : "";
			exclude = Options.ContainsKey("exclude") ? Options["exclude"] : "";
			selectedFile = Options.ContainsKey("selectedFile") ? Options["selectedFile"] : "";

			if (Options.ContainsKey("commaFilter") && Options["commaFilter"] == "yes") commaFilter = true;
			if (Options.ContainsKey("commaExclude") && Options["commaExclude"] == "yes") commaExclude = true;
			if (Options.ContainsKey("removeFilter") && Options["removeFilter"] == "yes") removeFilter = true;

			InitializeComponent();
			txt_search.Text = search;
			txt_replacewith.Text = replacewith;
			chk_casesensitive.Checked = casesensitive;
			chk_useregex.Checked = useregex;

			txt_filter.Text = filter;

			radio_arg.Checked = asArg;
			radio_cmd.Checked = asCmd;
			radio_file.Checked = asFile;

			txt_file.Enabled = radio_file.Checked;
			btn_file.Enabled = radio_file.Checked;
			txt_file.Text = selectedFile;

			txt_exclude.Text = exclude;
			chk_exclude_comma.Checked = commaExclude;
			chk_filter_comma.Checked = commaFilter;
			btn_manage_filter.Enabled = commaFilter;
			btn_manage_exclude.Enabled = commaExclude;
			chk_filter_remove.Checked = removeFilter;
			UpdateGUI();

		}

		private void UpdateGUI()
		{
			txt_file.Enabled = radio_file.Checked;
			btn_file.Enabled = radio_file.Checked;
			txt_search.Multiline = radio_file.Checked;
			txt_replacewith.Multiline = radio_file.Checked;

		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			try
			{
				string fileContent = txt_textin.Text;
				RegexOptions options = RegexOptions.Multiline;
				if (!chk_casesensitive.Checked) options |= RegexOptions.IgnoreCase;
				Regex regex = chk_useregex.Checked ? new Regex(txt_search.Text, options) : null;
				fileContent = chk_useregex.Checked ? regex.Replace(fileContent, MatchEvaluator) : Regex.Replace(fileContent, Regex.Escape(txt_search.Text), txt_replacewith.Text, options);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}


			if (chk_useregex.Checked && !IsValidRegex(txt_search.Text))
			{
				MessageBox.Show("Invalid Regex !");
				return;
			}

			filter = txt_filter.Text;
			asArg = radio_arg.Checked;
			asCmd = radio_cmd.Checked;
			asFile = radio_file.Checked;

			selectedFile = txt_file.Text;

			search = txt_search.Text;
			replacewith = txt_replacewith.Text;
			useregex = chk_useregex.Checked;
			casesensitive = chk_casesensitive.Checked;

			exclude = txt_exclude.Text;
			commaFilter = chk_filter_comma.Checked;
			commaExclude = chk_exclude_comma.Checked;
			removeFilter = chk_filter_remove.Checked;


			this.DialogResult = DialogResult.OK;
			this.Close();

		}

		private bool IsValidRegex(string pattern)
		{
			try
			{
				new Regex(pattern);
				return true;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}


		private void Replace_Config_Load(object sender, EventArgs e)
		{

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
		}

		private void chk_exclude_comma_CheckedChanged(object sender, EventArgs e)
		{
			commaExclude = chk_exclude_comma.Checked;
			btn_manage_exclude.Enabled = commaExclude;
		}

		private void radio_file_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGUI();
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

		private void btn_testReplace_Click(object sender, EventArgs e)
		{
			try
			{
				string fileContent = txt_textin.Text;
				RegexOptions options = RegexOptions.Multiline;
				if (!chk_casesensitive.Checked) options |= RegexOptions.IgnoreCase;
				options |= RegexOptions.Singleline;

				Regex regex = chk_useregex.Checked ? new Regex(txt_search.Text, options) : null;
				fileContent = chk_useregex.Checked ? regex.Replace(fileContent, MatchEvaluator) : Regex.Replace(fileContent, Regex.Escape(txt_search.Text), txt_replacewith.Text, options);

				txt_textout.Text = fileContent;

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private string MatchEvaluator(Match match)
		{
			GroupCollection groups = match.Groups;

			string replaceWith = txt_replacewith.Text;
			for (int i = 1; i <= groups.Count; i++)
			{
				replaceWith = replaceWith.Replace($"\\{i}", groups[i].Value);
			}

			return replaceWith;
		}

		private void radio_arg_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGUI();
		}

		private void radio_cmd_CheckedChanged(object sender, EventArgs e)
		{
			UpdateGUI();
		}
	}
}
