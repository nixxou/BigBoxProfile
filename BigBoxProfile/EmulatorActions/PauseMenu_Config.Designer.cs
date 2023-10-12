namespace BigBoxProfile.EmulatorActions
{
	partial class PauseMenu_Config
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.TextBoxKeyCombo = new System.Windows.Forms.TextBox();
			this.button6 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.TextBoxGKeyCombo = new System.Windows.Forms.TextBox();
			this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.num_gamepadKeyPressMinDuration = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.chk_forcefullActivation = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.txt_ahkPause = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_ahkResume = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.chk_pauseEmulation = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_copyArty = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_file = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_file = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btn_manageVariables = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.chk_executePauseAfter = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_executeResumeBefore = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_disableSound = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.num_delaystart = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.num_autoclose = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.radio_pause = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_startup = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_end = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.groupBox2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn_manage_exclude);
			this.groupBox2.Controls.Add(this.txt_filter);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chk_filter_comma);
			this.groupBox2.Controls.Add(this.btn_manage_filter);
			this.groupBox2.Controls.Add(this.txt_exclude);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.chk_exclude_comma);
			this.groupBox2.Controls.Add(this.chk_filter_remove);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(654, 158);
			this.groupBox2.TabIndex = 96;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Filters";
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(541, 112);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 78;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(190, 16);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(442, 23);
			this.txt_filter.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 19;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(190, 45);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 73;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
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
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(190, 83);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(442, 23);
			this.txt_exclude.TabIndex = 75;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(17, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 76;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(190, 112);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 77;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(190, 62);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 86;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1537, 502);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 98;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1627, 502);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 97;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// TextBoxKeyCombo
			// 
			this.TextBoxKeyCombo.Location = new System.Drawing.Point(31, 259);
			this.TextBoxKeyCombo.Name = "TextBoxKeyCombo";
			this.TextBoxKeyCombo.ReadOnly = true;
			this.TextBoxKeyCombo.Size = new System.Drawing.Size(274, 20);
			this.TextBoxKeyCombo.TabIndex = 100;
			this.TextBoxKeyCombo.TabStop = false;
			this.TextBoxKeyCombo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(31, 285);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(274, 24);
			this.button6.TabIndex = 99;
			this.button6.Values.Text = "Set Keyboard Bind Keys";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// TextBoxGKeyCombo
			// 
			this.TextBoxGKeyCombo.Location = new System.Drawing.Point(368, 259);
			this.TextBoxGKeyCombo.Name = "TextBoxGKeyCombo";
			this.TextBoxGKeyCombo.ReadOnly = true;
			this.TextBoxGKeyCombo.Size = new System.Drawing.Size(276, 20);
			this.TextBoxGKeyCombo.TabIndex = 102;
			this.TextBoxGKeyCombo.TabStop = false;
			this.TextBoxGKeyCombo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(368, 285);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(276, 24);
			this.button1.TabIndex = 101;
			this.button1.Values.Text = "Set Gamepad Bind Keys";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// num_gamepadKeyPressMinDuration
			// 
			this.num_gamepadKeyPressMinDuration.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.num_gamepadKeyPressMinDuration.Location = new System.Drawing.Point(524, 315);
			this.num_gamepadKeyPressMinDuration.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.num_gamepadKeyPressMinDuration.Name = "num_gamepadKeyPressMinDuration";
			this.num_gamepadKeyPressMinDuration.Size = new System.Drawing.Size(120, 22);
			this.num_gamepadKeyPressMinDuration.TabIndex = 103;
			// 
			// chk_forcefullActivation
			// 
			this.chk_forcefullActivation.Location = new System.Drawing.Point(29, 378);
			this.chk_forcefullActivation.Name = "chk_forcefullActivation";
			this.chk_forcefullActivation.Size = new System.Drawing.Size(126, 20);
			this.chk_forcefullActivation.TabIndex = 104;
			this.chk_forcefullActivation.Values.Text = "Forcefull activation";
			// 
			// txt_ahkPause
			// 
			this.txt_ahkPause.Location = new System.Drawing.Point(686, 14);
			this.txt_ahkPause.Name = "txt_ahkPause";
			this.txt_ahkPause.Size = new System.Drawing.Size(707, 235);
			this.txt_ahkPause.TabIndex = 105;
			this.txt_ahkPause.Text = "kryptonRichTextBox1";
			// 
			// txt_ahkResume
			// 
			this.txt_ahkResume.Location = new System.Drawing.Point(686, 259);
			this.txt_ahkResume.Name = "txt_ahkResume";
			this.txt_ahkResume.Size = new System.Drawing.Size(707, 237);
			this.txt_ahkResume.TabIndex = 106;
			this.txt_ahkResume.Text = "kryptonRichTextBox2";
			// 
			// chk_pauseEmulation
			// 
			this.chk_pauseEmulation.Location = new System.Drawing.Point(29, 404);
			this.chk_pauseEmulation.Name = "chk_pauseEmulation";
			this.chk_pauseEmulation.Size = new System.Drawing.Size(113, 20);
			this.chk_pauseEmulation.TabIndex = 107;
			this.chk_pauseEmulation.Values.Text = "Pause Emulation";
			// 
			// chk_copyArty
			// 
			this.chk_copyArty.Location = new System.Drawing.Point(29, 454);
			this.chk_copyArty.Name = "chk_copyArty";
			this.chk_copyArty.Size = new System.Drawing.Size(152, 20);
			this.chk_copyArty.TabIndex = 108;
			this.chk_copyArty.Values.Text = "Copy art img to tmp dir";
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(368, 315);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(150, 20);
			this.kryptonLabel1.TabIndex = 109;
			this.kryptonLabel1.Values.Text = "Minimum press duration :";
			// 
			// btn_file
			// 
			this.btn_file.Location = new System.Drawing.Point(609, 188);
			this.btn_file.Name = "btn_file";
			this.btn_file.Size = new System.Drawing.Size(35, 24);
			this.btn_file.TabIndex = 111;
			this.btn_file.Values.Text = "...";
			// 
			// txt_file
			// 
			this.txt_file.Location = new System.Drawing.Point(108, 189);
			this.txt_file.Name = "txt_file";
			this.txt_file.Size = new System.Drawing.Size(495, 23);
			this.txt_file.TabIndex = 110;
			this.txt_file.TextChanged += new System.EventHandler(this.txt_file_TextChanged);
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(31, 192);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(71, 20);
			this.kryptonLabel2.TabIndex = 112;
			this.kryptonLabel2.Values.Text = "HTML File :";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btn_manageVariables);
			this.groupBox4.Controls.Add(this.listBox1);
			this.groupBox4.Location = new System.Drawing.Point(1399, 14);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(309, 482);
			this.groupBox4.TabIndex = 113;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Variables (Advanced Users Only !)";
			// 
			// btn_manageVariables
			// 
			this.btn_manageVariables.Location = new System.Drawing.Point(12, 452);
			this.btn_manageVariables.Name = "btn_manageVariables";
			this.btn_manageVariables.Size = new System.Drawing.Size(291, 24);
			this.btn_manageVariables.TabIndex = 96;
			this.btn_manageVariables.Values.Text = "Manage Variables";
			this.btn_manageVariables.Click += new System.EventHandler(this.btn_manageVariables_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 19);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(291, 420);
			this.listBox1.TabIndex = 0;
			// 
			// chk_executePauseAfter
			// 
			this.chk_executePauseAfter.Location = new System.Drawing.Point(29, 480);
			this.chk_executePauseAfter.Name = "chk_executePauseAfter";
			this.chk_executePauseAfter.Size = new System.Drawing.Size(328, 20);
			this.chk_executePauseAfter.TabIndex = 114;
			this.chk_executePauseAfter.Values.Text = "Execute Pause Ahk code after showing the pause screen";
			// 
			// chk_executeResumeBefore
			// 
			this.chk_executeResumeBefore.Location = new System.Drawing.Point(29, 506);
			this.chk_executeResumeBefore.Name = "chk_executeResumeBefore";
			this.chk_executeResumeBefore.Size = new System.Drawing.Size(341, 20);
			this.chk_executeResumeBefore.TabIndex = 115;
			this.chk_executeResumeBefore.Values.Text = "Execute Resume ahk code before closing the pause screen";
			// 
			// chk_disableSound
			// 
			this.chk_disableSound.Location = new System.Drawing.Point(29, 428);
			this.chk_disableSound.Name = "chk_disableSound";
			this.chk_disableSound.Size = new System.Drawing.Size(102, 20);
			this.chk_disableSound.TabIndex = 116;
			this.chk_disableSound.Values.Text = "Disable Sound";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(29, 326);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(158, 20);
			this.kryptonLabel3.TabIndex = 118;
			this.kryptonLabel3.Values.Text = "Delay before starting (ms) :";
			// 
			// num_delaystart
			// 
			this.num_delaystart.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.num_delaystart.Location = new System.Drawing.Point(212, 324);
			this.num_delaystart.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.num_delaystart.Name = "num_delaystart";
			this.num_delaystart.Size = new System.Drawing.Size(120, 22);
			this.num_delaystart.TabIndex = 117;
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.Location = new System.Drawing.Point(29, 352);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.Size = new System.Drawing.Size(177, 20);
			this.kryptonLabel4.TabIndex = 120;
			this.kryptonLabel4.Values.Text = "Autoclose after : (0=disabled) :";
			// 
			// num_autoclose
			// 
			this.num_autoclose.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.num_autoclose.Location = new System.Drawing.Point(212, 350);
			this.num_autoclose.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.num_autoclose.Name = "num_autoclose";
			this.num_autoclose.Size = new System.Drawing.Size(120, 22);
			this.num_autoclose.TabIndex = 119;
			// 
			// radio_pause
			// 
			this.radio_pause.Location = new System.Drawing.Point(31, 229);
			this.radio_pause.Name = "radio_pause";
			this.radio_pause.Size = new System.Drawing.Size(133, 20);
			this.radio_pause.TabIndex = 121;
			this.radio_pause.Values.Text = "Use as Pause Screen";
			this.radio_pause.CheckedChanged += new System.EventHandler(this.radio_pause_CheckedChanged);
			// 
			// radio_startup
			// 
			this.radio_startup.Location = new System.Drawing.Point(174, 229);
			this.radio_startup.Name = "radio_startup";
			this.radio_startup.Size = new System.Drawing.Size(141, 20);
			this.radio_startup.TabIndex = 122;
			this.radio_startup.Values.Text = "Use as Startup Screen";
			this.radio_startup.CheckedChanged += new System.EventHandler(this.radio_startup_CheckedChanged);
			// 
			// radio_end
			// 
			this.radio_end.Location = new System.Drawing.Point(321, 229);
			this.radio_end.Name = "radio_end";
			this.radio_end.Size = new System.Drawing.Size(120, 20);
			this.radio_end.TabIndex = 123;
			this.radio_end.Values.Text = "Use as Exit Screen";
			this.radio_end.CheckedChanged += new System.EventHandler(this.radio_end_CheckedChanged);
			// 
			// PauseMenu_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1720, 546);
			this.Controls.Add(this.radio_end);
			this.Controls.Add(this.radio_startup);
			this.Controls.Add(this.radio_pause);
			this.Controls.Add(this.kryptonLabel4);
			this.Controls.Add(this.num_autoclose);
			this.Controls.Add(this.kryptonLabel3);
			this.Controls.Add(this.num_delaystart);
			this.Controls.Add(this.chk_disableSound);
			this.Controls.Add(this.chk_executeResumeBefore);
			this.Controls.Add(this.chk_executePauseAfter);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.kryptonLabel2);
			this.Controls.Add(this.btn_file);
			this.Controls.Add(this.txt_file);
			this.Controls.Add(this.kryptonLabel1);
			this.Controls.Add(this.chk_copyArty);
			this.Controls.Add(this.chk_pauseEmulation);
			this.Controls.Add(this.txt_ahkResume);
			this.Controls.Add(this.txt_ahkPause);
			this.Controls.Add(this.chk_forcefullActivation);
			this.Controls.Add(this.num_gamepadKeyPressMinDuration);
			this.Controls.Add(this.TextBoxGKeyCombo);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.TextBoxKeyCombo);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.groupBox2);
			this.Name = "PauseMenu_Config";
			this.Text = "PauseMenu_Config";
			this.Load += new System.EventHandler(this.PauseMenu_Config_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private System.Windows.Forms.TextBox TextBoxKeyCombo;
		private ComponentFactory.Krypton.Toolkit.KryptonButton button6;
		private System.Windows.Forms.TextBox TextBoxGKeyCombo;
		private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_gamepadKeyPressMinDuration;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_forcefullActivation;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_ahkPause;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_ahkResume;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_pauseEmulation;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_copyArty;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_file;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_file;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private System.Windows.Forms.GroupBox groupBox4;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manageVariables;
		private System.Windows.Forms.ListBox listBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_executePauseAfter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_executeResumeBefore;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_disableSound;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_delaystart;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_autoclose;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_pause;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_startup;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_end;
	}
}