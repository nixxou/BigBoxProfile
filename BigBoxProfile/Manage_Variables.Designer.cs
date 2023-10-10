﻿namespace BigBoxProfile
{
	partial class Manage_Variables
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
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_variableName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_file = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_file = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.radio_file = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_cmd = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_arg = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.txt_regex = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_value = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.btn_delete_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.lv_priority = new System.Windows.Forms.ListView();
			this.cjson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cRegex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_add = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_textout = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_textin = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.btn_testReplace = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_fallback = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.kryptonLabel5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.cFallback = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.rtest_variable = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.rtest_simple = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.txt_fakecmdline = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.test_label = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			this.rtest_full = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.lbl_fakecmd = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonWrapLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonWrapLabel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(49, 20);
			this.kryptonLabel1.TabIndex = 0;
			this.kryptonLabel1.Values.Text = "Name :";
			this.kryptonLabel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonLabel1_Paint);
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(14, 224);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(88, 20);
			this.kryptonLabel2.TabIndex = 1;
			this.kryptonLabel2.Values.Text = "Replace With :";
			// 
			// txt_variableName
			// 
			this.txt_variableName.Location = new System.Drawing.Point(146, 9);
			this.txt_variableName.Name = "txt_variableName";
			this.txt_variableName.Size = new System.Drawing.Size(296, 23);
			this.txt_variableName.TabIndex = 2;
			this.txt_variableName.TextChanged += new System.EventHandler(this.txt_variableName_TextChanged);
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(10, 45);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(83, 20);
			this.kryptonLabel3.TabIndex = 5;
			this.kryptonLabel3.Values.Text = "Data Source :";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.Location = new System.Drawing.Point(10, 106);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.Size = new System.Drawing.Size(50, 20);
			this.kryptonLabel4.TabIndex = 7;
			this.kryptonLabel4.Values.Text = "Regex :";
			// 
			// btn_file
			// 
			this.btn_file.Location = new System.Drawing.Point(671, 70);
			this.btn_file.Name = "btn_file";
			this.btn_file.Size = new System.Drawing.Size(35, 24);
			this.btn_file.TabIndex = 94;
			this.btn_file.Values.Text = "...";
			this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
			// 
			// txt_file
			// 
			this.txt_file.Location = new System.Drawing.Point(146, 71);
			this.txt_file.Name = "txt_file";
			this.txt_file.Size = new System.Drawing.Size(519, 23);
			this.txt_file.TabIndex = 93;
			this.txt_file.TextChanged += new System.EventHandler(this.txt_file_TextChanged);
			// 
			// radio_file
			// 
			this.radio_file.Location = new System.Drawing.Point(356, 45);
			this.radio_file.Name = "radio_file";
			this.radio_file.Size = new System.Drawing.Size(86, 20);
			this.radio_file.TabIndex = 92;
			this.radio_file.Values.Text = "Specific File";
			this.radio_file.CheckedChanged += new System.EventHandler(this.radio_file_CheckedChanged);
			// 
			// radio_cmd
			// 
			this.radio_cmd.Location = new System.Drawing.Point(261, 45);
			this.radio_cmd.Name = "radio_cmd";
			this.radio_cmd.Size = new System.Drawing.Size(89, 20);
			this.radio_cmd.TabIndex = 91;
			this.radio_cmd.Values.Text = "the cmdLine";
			this.radio_cmd.CheckedChanged += new System.EventHandler(this.radio_cmd_CheckedChanged);
			// 
			// radio_arg
			// 
			this.radio_arg.Checked = true;
			this.radio_arg.Location = new System.Drawing.Point(149, 45);
			this.radio_arg.Name = "radio_arg";
			this.radio_arg.Size = new System.Drawing.Size(106, 20);
			this.radio_arg.TabIndex = 90;
			this.radio_arg.Values.Text = "Each Argument";
			this.radio_arg.CheckedChanged += new System.EventHandler(this.radio_arg_CheckedChanged);
			// 
			// txt_regex
			// 
			this.txt_regex.Location = new System.Drawing.Point(146, 106);
			this.txt_regex.Name = "txt_regex";
			this.txt_regex.Size = new System.Drawing.Size(560, 102);
			this.txt_regex.TabIndex = 95;
			this.txt_regex.Text = "";
			this.txt_regex.TextChanged += new System.EventHandler(this.txt_regex_TextChanged);
			// 
			// txt_value
			// 
			this.txt_value.Location = new System.Drawing.Point(146, 224);
			this.txt_value.Name = "txt_value";
			this.txt_value.Size = new System.Drawing.Size(560, 102);
			this.txt_value.TabIndex = 96;
			this.txt_value.Text = "";
			this.txt_value.TextChanged += new System.EventHandler(this.txt_value_TextChanged);
			// 
			// btn_delete_priority
			// 
			this.btn_delete_priority.Enabled = false;
			this.btn_delete_priority.Location = new System.Drawing.Point(1388, 557);
			this.btn_delete_priority.Name = "btn_delete_priority";
			this.btn_delete_priority.Size = new System.Drawing.Size(75, 24);
			this.btn_delete_priority.TabIndex = 123;
			this.btn_delete_priority.Values.Text = "Delete";
			this.btn_delete_priority.Click += new System.EventHandler(this.btn_delete_priority_Click);
			// 
			// btn_up_priority
			// 
			this.btn_up_priority.Enabled = false;
			this.btn_up_priority.Location = new System.Drawing.Point(1388, 488);
			this.btn_up_priority.Name = "btn_up_priority";
			this.btn_up_priority.Size = new System.Drawing.Size(75, 24);
			this.btn_up_priority.TabIndex = 121;
			this.btn_up_priority.Values.Text = "Up";
			this.btn_up_priority.Click += new System.EventHandler(this.btn_up_priority_Click);
			// 
			// btn_down_priority
			// 
			this.btn_down_priority.Enabled = false;
			this.btn_down_priority.Location = new System.Drawing.Point(1388, 518);
			this.btn_down_priority.Name = "btn_down_priority";
			this.btn_down_priority.Size = new System.Drawing.Size(75, 24);
			this.btn_down_priority.TabIndex = 122;
			this.btn_down_priority.Values.Text = "Down";
			this.btn_down_priority.Click += new System.EventHandler(this.btn_down_priority_Click);
			// 
			// lv_priority
			// 
			this.lv_priority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cjson,
            this.cName,
            this.cSource,
            this.cRegex,
            this.cValue,
            this.cFallback});
			this.lv_priority.FullRowSelect = true;
			this.lv_priority.HideSelection = false;
			this.lv_priority.Location = new System.Drawing.Point(14, 488);
			this.lv_priority.MultiSelect = false;
			this.lv_priority.Name = "lv_priority";
			this.lv_priority.Size = new System.Drawing.Size(1368, 242);
			this.lv_priority.TabIndex = 120;
			this.lv_priority.UseCompatibleStateImageBehavior = false;
			this.lv_priority.View = System.Windows.Forms.View.Details;
			this.lv_priority.SelectedIndexChanged += new System.EventHandler(this.lv_priority_SelectedIndexChanged);
			this.lv_priority.DoubleClick += new System.EventHandler(this.lv_priority_DoubleClick);
			// 
			// cjson
			// 
			this.cjson.Text = "json";
			this.cjson.Width = 50;
			// 
			// cName
			// 
			this.cName.Text = "Name";
			this.cName.Width = 450;
			// 
			// cSource
			// 
			this.cSource.Text = "Source";
			this.cSource.Width = 121;
			// 
			// cRegex
			// 
			this.cRegex.Text = "Regex";
			this.cRegex.Width = 110;
			// 
			// cValue
			// 
			this.cValue.Text = "Value";
			this.cValue.Width = 100;
			// 
			// btn_add
			// 
			this.btn_add.Location = new System.Drawing.Point(596, 449);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(110, 25);
			this.btn_add.TabIndex = 124;
			this.btn_add.Values.Text = "Add new Variable";
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1388, 736);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 125;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1307, 736);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 126;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lbl_fakecmd);
			this.groupBox1.Controls.Add(this.rtest_full);
			this.groupBox1.Controls.Add(this.test_label);
			this.groupBox1.Controls.Add(this.kryptonLabel6);
			this.groupBox1.Controls.Add(this.txt_textout);
			this.groupBox1.Controls.Add(this.txt_textin);
			this.groupBox1.Controls.Add(this.rtest_variable);
			this.groupBox1.Controls.Add(this.btn_testReplace);
			this.groupBox1.Controls.Add(this.rtest_simple);
			this.groupBox1.Controls.Add(this.txt_fakecmdline);
			this.groupBox1.Location = new System.Drawing.Point(726, 9);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(656, 465);
			this.groupBox1.TabIndex = 127;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Test replace";
			// 
			// txt_textout
			// 
			this.txt_textout.Location = new System.Drawing.Point(15, 305);
			this.txt_textout.Name = "txt_textout";
			this.txt_textout.Size = new System.Drawing.Size(632, 124);
			this.txt_textout.TabIndex = 95;
			this.txt_textout.Text = "Text Out";
			// 
			// txt_textin
			// 
			this.txt_textin.Location = new System.Drawing.Point(15, 215);
			this.txt_textin.Name = "txt_textin";
			this.txt_textin.Size = new System.Drawing.Size(629, 84);
			this.txt_textin.TabIndex = 94;
			this.txt_textin.Text = "Text In";
			// 
			// btn_testReplace
			// 
			this.btn_testReplace.Location = new System.Drawing.Point(543, 435);
			this.btn_testReplace.Name = "btn_testReplace";
			this.btn_testReplace.Size = new System.Drawing.Size(107, 24);
			this.btn_testReplace.TabIndex = 92;
			this.btn_testReplace.Values.Text = "Test Replace";
			this.btn_testReplace.Click += new System.EventHandler(this.btn_testReplace_Click);
			// 
			// txt_fallback
			// 
			this.txt_fallback.Location = new System.Drawing.Point(146, 341);
			this.txt_fallback.Name = "txt_fallback";
			this.txt_fallback.Size = new System.Drawing.Size(560, 102);
			this.txt_fallback.TabIndex = 128;
			this.txt_fallback.Text = "";
			this.txt_fallback.TextChanged += new System.EventHandler(this.txt_fallback_TextChanged);
			// 
			// kryptonLabel5
			// 
			this.kryptonLabel5.Location = new System.Drawing.Point(12, 341);
			this.kryptonLabel5.Name = "kryptonLabel5";
			this.kryptonLabel5.Size = new System.Drawing.Size(94, 20);
			this.kryptonLabel5.TabIndex = 129;
			this.kryptonLabel5.Values.Text = "FallBack Value :";
			// 
			// cFallback
			// 
			this.cFallback.Text = "Fallback Value";
			this.cFallback.Width = 510;
			// 
			// rtest_variable
			// 
			this.rtest_variable.Location = new System.Drawing.Point(215, 19);
			this.rtest_variable.Name = "rtest_variable";
			this.rtest_variable.Size = new System.Drawing.Size(135, 20);
			this.rtest_variable.TabIndex = 132;
			this.rtest_variable.Values.Text = "Test current Variable";
			// 
			// rtest_simple
			// 
			this.rtest_simple.Checked = true;
			this.rtest_simple.Location = new System.Drawing.Point(93, 19);
			this.rtest_simple.Name = "rtest_simple";
			this.rtest_simple.Size = new System.Drawing.Size(116, 20);
			this.rtest_simple.TabIndex = 131;
			this.rtest_simple.Values.Text = "Simple regex test";
			this.rtest_simple.CheckedChanged += new System.EventHandler(this.rtest_simple_CheckedChanged);
			// 
			// txt_fakecmdline
			// 
			this.txt_fakecmdline.Location = new System.Drawing.Point(128, 186);
			this.txt_fakecmdline.Name = "txt_fakecmdline";
			this.txt_fakecmdline.Size = new System.Drawing.Size(504, 23);
			this.txt_fakecmdline.TabIndex = 130;
			// 
			// kryptonLabel6
			// 
			this.kryptonLabel6.Location = new System.Drawing.Point(15, 19);
			this.kryptonLabel6.Name = "kryptonLabel6";
			this.kryptonLabel6.Size = new System.Drawing.Size(74, 20);
			this.kryptonLabel6.TabIndex = 130;
			this.kryptonLabel6.Values.Text = "Test mode :";
			// 
			// test_label
			// 
			this.test_label.AutoSize = false;
			this.test_label.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.test_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this.test_label.Location = new System.Drawing.Point(15, 61);
			this.test_label.Name = "test_label";
			this.test_label.Size = new System.Drawing.Size(617, 115);
			this.test_label.Click += new System.EventHandler(this.test_label_Click);
			// 
			// rtest_full
			// 
			this.rtest_full.Location = new System.Drawing.Point(356, 19);
			this.rtest_full.Name = "rtest_full";
			this.rtest_full.Size = new System.Drawing.Size(159, 20);
			this.rtest_full.TabIndex = 134;
			this.rtest_full.Values.Text = "Test Registered Variables";
			// 
			// lbl_fakecmd
			// 
			this.lbl_fakecmd.Location = new System.Drawing.Point(15, 189);
			this.lbl_fakecmd.Name = "lbl_fakecmd";
			this.lbl_fakecmd.Size = new System.Drawing.Size(94, 20);
			this.lbl_fakecmd.TabIndex = 135;
			this.lbl_fakecmd.Values.Text = "command line :";
			// 
			// kryptonWrapLabel1
			// 
			this.kryptonWrapLabel1.AutoSize = false;
			this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
			this.kryptonWrapLabel1.Location = new System.Drawing.Point(14, 260);
			this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
			this.kryptonWrapLabel1.Size = new System.Drawing.Size(117, 48);
			this.kryptonWrapLabel1.Text = "You can use \\1 \\2 ... to match your regex groups";
			// 
			// Manage_Variables
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1468, 766);
			this.Controls.Add(this.kryptonWrapLabel1);
			this.Controls.Add(this.kryptonLabel5);
			this.Controls.Add(this.txt_fallback);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_add);
			this.Controls.Add(this.btn_delete_priority);
			this.Controls.Add(this.btn_up_priority);
			this.Controls.Add(this.btn_down_priority);
			this.Controls.Add(this.lv_priority);
			this.Controls.Add(this.txt_value);
			this.Controls.Add(this.txt_regex);
			this.Controls.Add(this.btn_file);
			this.Controls.Add(this.txt_file);
			this.Controls.Add(this.radio_file);
			this.Controls.Add(this.radio_cmd);
			this.Controls.Add(this.radio_arg);
			this.Controls.Add(this.kryptonLabel4);
			this.Controls.Add(this.kryptonLabel3);
			this.Controls.Add(this.txt_variableName);
			this.Controls.Add(this.kryptonLabel2);
			this.Controls.Add(this.kryptonLabel1);
			this.Name = "Manage_Variables";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Manage_Variables_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_variableName;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_file;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_file;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_file;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_cmd;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_arg;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_regex;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_value;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_priority;
		private System.Windows.Forms.ListView lv_priority;
		private System.Windows.Forms.ColumnHeader cjson;
		private System.Windows.Forms.ColumnHeader cName;
		private System.Windows.Forms.ColumnHeader cSource;
		private System.Windows.Forms.ColumnHeader cRegex;
		private System.Windows.Forms.ColumnHeader cValue;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private System.Windows.Forms.GroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_textout;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_textin;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_testReplace;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_fallback;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel5;
		private System.Windows.Forms.ColumnHeader cFallback;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rtest_variable;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rtest_simple;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_fakecmdline;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel6;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel test_label;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton rtest_full;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel lbl_fakecmd;
		private ComponentFactory.Krypton.Toolkit.KryptonWrapLabel kryptonWrapLabel1;
	}
}