namespace BigBoxProfile.EmulatorActions
{
	partial class Replace_Config
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Replace_Config));
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.radio_cmd = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_arg = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_useregex = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_casesensitive = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.radio_file = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.btn_file = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_file = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_textout = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_textin = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.btn_testReplace = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_search = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_replacewith = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btn_manageVariables = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.chk_filter_matchall = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_exclude_matchall = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 19;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(190, 16);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(442, 23);
			this.txt_filter.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 220);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 20);
			this.label2.TabIndex = 17;
			this.label2.Values.Text = "Execute for :";
			// 
			// radio_cmd
			// 
			this.radio_cmd.Location = new System.Drawing.Point(446, 220);
			this.radio_cmd.Name = "radio_cmd";
			this.radio_cmd.Size = new System.Drawing.Size(89, 20);
			this.radio_cmd.TabIndex = 16;
			this.radio_cmd.Values.Text = "the cmdLine";
			this.radio_cmd.CheckedChanged += new System.EventHandler(this.radio_cmd_CheckedChanged);
			// 
			// radio_arg
			// 
			this.radio_arg.Location = new System.Drawing.Point(334, 220);
			this.radio_arg.Name = "radio_arg";
			this.radio_arg.Size = new System.Drawing.Size(106, 20);
			this.radio_arg.TabIndex = 15;
			this.radio_arg.Values.Text = "Each Argument";
			this.radio_arg.CheckedChanged += new System.EventHandler(this.radio_arg_CheckedChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 20);
			this.label1.TabIndex = 14;
			this.label1.Values.Text = "Search :";
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1297, 496);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 13;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1378, 496);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 12;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 20);
			this.label4.TabIndex = 21;
			this.label4.Values.Text = "Replace With :";
			// 
			// chk_useregex
			// 
			this.chk_useregex.Location = new System.Drawing.Point(442, 194);
			this.chk_useregex.Name = "chk_useregex";
			this.chk_useregex.Size = new System.Drawing.Size(80, 20);
			this.chk_useregex.TabIndex = 22;
			this.chk_useregex.Values.Text = "Use Regex";
			// 
			// chk_casesensitive
			// 
			this.chk_casesensitive.Location = new System.Drawing.Point(528, 194);
			this.chk_casesensitive.Name = "chk_casesensitive";
			this.chk_casesensitive.Size = new System.Drawing.Size(99, 20);
			this.chk_casesensitive.TabIndex = 23;
			this.chk_casesensitive.Values.Text = "Case sensitive";
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(541, 134);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 78;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(190, 134);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 77;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(17, 108);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 76;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(190, 105);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(442, 23);
			this.txt_exclude.TabIndex = 75;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(541, 45);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 74;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(190, 45);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 73;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(190, 84);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 86;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			// 
			// radio_file
			// 
			this.radio_file.Location = new System.Drawing.Point(541, 220);
			this.radio_file.Name = "radio_file";
			this.radio_file.Size = new System.Drawing.Size(86, 20);
			this.radio_file.TabIndex = 87;
			this.radio_file.Values.Text = "Specific File";
			this.radio_file.CheckedChanged += new System.EventHandler(this.radio_file_CheckedChanged);
			// 
			// btn_file
			// 
			this.btn_file.Location = new System.Drawing.Point(592, 245);
			this.btn_file.Name = "btn_file";
			this.btn_file.Size = new System.Drawing.Size(35, 24);
			this.btn_file.TabIndex = 89;
			this.btn_file.Values.Text = "...";
			this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
			// 
			// txt_file
			// 
			this.txt_file.Location = new System.Drawing.Point(185, 246);
			this.txt_file.Name = "txt_file";
			this.txt_file.Size = new System.Drawing.Size(401, 23);
			this.txt_file.TabIndex = 88;
			this.txt_file.TextChanged += new System.EventHandler(this.txt_file_TextChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txt_textout);
			this.groupBox1.Controls.Add(this.txt_textin);
			this.groupBox1.Controls.Add(this.btn_testReplace);
			this.groupBox1.Location = new System.Drawing.Point(939, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(514, 478);
			this.groupBox1.TabIndex = 91;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Basic test replace";
			// 
			// txt_textout
			// 
			this.txt_textout.Location = new System.Drawing.Point(15, 238);
			this.txt_textout.Name = "txt_textout";
			this.txt_textout.Size = new System.Drawing.Size(493, 202);
			this.txt_textout.TabIndex = 95;
			this.txt_textout.Text = "Text Out";
			// 
			// txt_textin
			// 
			this.txt_textin.Location = new System.Drawing.Point(15, 19);
			this.txt_textin.Name = "txt_textin";
			this.txt_textin.Size = new System.Drawing.Size(493, 202);
			this.txt_textin.TabIndex = 94;
			this.txt_textin.Text = "Text In";
			this.txt_textin.TextChanged += new System.EventHandler(this.txt_textin_TextChanged);
			// 
			// btn_testReplace
			// 
			this.btn_testReplace.Location = new System.Drawing.Point(401, 446);
			this.btn_testReplace.Name = "btn_testReplace";
			this.btn_testReplace.Size = new System.Drawing.Size(107, 24);
			this.btn_testReplace.TabIndex = 92;
			this.btn_testReplace.Values.Text = "Test Replace";
			this.btn_testReplace.Click += new System.EventHandler(this.btn_testReplace_Click);
			// 
			// txt_search
			// 
			this.txt_search.Location = new System.Drawing.Point(119, 19);
			this.txt_search.Name = "txt_search";
			this.txt_search.Size = new System.Drawing.Size(508, 79);
			this.txt_search.TabIndex = 92;
			this.txt_search.Text = "";
			// 
			// txt_replacewith
			// 
			this.txt_replacewith.Location = new System.Drawing.Point(119, 104);
			this.txt_replacewith.Name = "txt_replacewith";
			this.txt_replacewith.Size = new System.Drawing.Size(508, 79);
			this.txt_replacewith.TabIndex = 93;
			this.txt_replacewith.Text = "";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chk_exclude_matchall);
			this.groupBox2.Controls.Add(this.chk_filter_matchall);
			this.groupBox2.Controls.Add(this.btn_manage_exclude);
			this.groupBox2.Controls.Add(this.txt_filter);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chk_filter_comma);
			this.groupBox2.Controls.Add(this.btn_manage_filter);
			this.groupBox2.Controls.Add(this.txt_exclude);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.chk_exclude_comma);
			this.groupBox2.Controls.Add(this.chk_filter_remove);
			this.groupBox2.Location = new System.Drawing.Point(12, 332);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(654, 184);
			this.groupBox2.TabIndex = 95;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Filters";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txt_search);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.radio_arg);
			this.groupBox3.Controls.Add(this.txt_replacewith);
			this.groupBox3.Controls.Add(this.radio_cmd);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.btn_file);
			this.groupBox3.Controls.Add(this.chk_useregex);
			this.groupBox3.Controls.Add(this.txt_file);
			this.groupBox3.Controls.Add(this.chk_casesensitive);
			this.groupBox3.Controls.Add(this.radio_file);
			this.groupBox3.Location = new System.Drawing.Point(17, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(654, 300);
			this.groupBox3.TabIndex = 96;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Search And Replace";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btn_manageVariables);
			this.groupBox4.Controls.Add(this.listBox1);
			this.groupBox4.Location = new System.Drawing.Point(677, 12);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(256, 478);
			this.groupBox4.TabIndex = 97;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Variables (Advanced Users Only !)";
			this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
			// 
			// btn_manageVariables
			// 
			this.btn_manageVariables.Location = new System.Drawing.Point(12, 433);
			this.btn_manageVariables.Name = "btn_manageVariables";
			this.btn_manageVariables.Size = new System.Drawing.Size(233, 24);
			this.btn_manageVariables.TabIndex = 96;
			this.btn_manageVariables.Values.Text = "Manage Variables";
			this.btn_manageVariables.Click += new System.EventHandler(this.btn_manageVariables_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 19);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(233, 407);
			this.listBox1.TabIndex = 0;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// chk_filter_matchall
			// 
			this.chk_filter_matchall.Enabled = false;
			this.chk_filter_matchall.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
			this.chk_filter_matchall.Location = new System.Drawing.Point(190, 65);
			this.chk_filter_matchall.Name = "chk_filter_matchall";
			this.chk_filter_matchall.Size = new System.Drawing.Size(138, 20);
			this.chk_filter_matchall.TabIndex = 101;
			this.chk_filter_matchall.Values.Text = "Must match all args";
			// 
			// chk_exclude_matchall
			// 
			this.chk_exclude_matchall.Enabled = false;
			this.chk_exclude_matchall.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
			this.chk_exclude_matchall.Location = new System.Drawing.Point(190, 156);
			this.chk_exclude_matchall.Name = "chk_exclude_matchall";
			this.chk_exclude_matchall.Size = new System.Drawing.Size(138, 20);
			this.chk_exclude_matchall.TabIndex = 102;
			this.chk_exclude_matchall.Values.Text = "Must match all args";
			// 
			// Replace_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1461, 528);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Replace_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : Replace";
			this.Load += new System.EventHandler(this.Replace_Config_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_cmd;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_arg;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_useregex;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_casesensitive;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_file;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_file;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_file;
		private System.Windows.Forms.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_testReplace;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_search;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_textout;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_textin;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_replacewith;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.ListBox listBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manageVariables;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_matchall;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_matchall;
	}
}