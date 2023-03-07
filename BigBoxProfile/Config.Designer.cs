namespace BigBoxProfile
{
	partial class Config
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.label_status = new System.Windows.Forms.Label();
			this.btn_register = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.cmb_listProfiles = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_editEmulator = new System.Windows.Forms.Button();
			this.btn_addEmulator = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.button11 = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.comboBox9 = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmb_emulatorList = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn_editSoundcard = new System.Windows.Forms.Button();
			this.btn_editMonitorSwitch = new System.Windows.Forms.Button();
			this.txt_monitorswitch = new System.Windows.Forms.TextBox();
			this.txt_soundcard = new System.Windows.Forms.TextBox();
			this.txt_monitorpriority = new System.Windows.Forms.TextBox();
			this.chk_restore = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_editPriority = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_status
			// 
			this.label_status.AutoSize = true;
			this.label_status.Location = new System.Drawing.Point(138, 9);
			this.label_status.Name = "label_status";
			this.label_status.Size = new System.Drawing.Size(45, 13);
			this.label_status.TabIndex = 0;
			this.label_status.Text = "Inactive";
			// 
			// btn_register
			// 
			this.btn_register.Location = new System.Drawing.Point(24, 25);
			this.btn_register.Name = "btn_register";
			this.btn_register.Size = new System.Drawing.Size(159, 23);
			this.btn_register.TabIndex = 1;
			this.btn_register.Text = "Activate";
			this.btn_register.UseVisualStyleBackColor = true;
			this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(27, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "App Status :";
			// 
			// cmb_listProfiles
			// 
			this.cmb_listProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_listProfiles.FormattingEnabled = true;
			this.cmb_listProfiles.Location = new System.Drawing.Point(297, 17);
			this.cmb_listProfiles.Name = "cmb_listProfiles";
			this.cmb_listProfiles.Size = new System.Drawing.Size(121, 21);
			this.cmb_listProfiles.TabIndex = 3;
			this.cmb_listProfiles.SelectedIndexChanged += new System.EventHandler(this.cmb_listProfiles_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(267, 44);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 35);
			this.button1.TabIndex = 4;
			this.button1.Text = "Add New Profile";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_editEmulator);
			this.groupBox1.Controls.Add(this.btn_addEmulator);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.cmb_emulatorList);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Location = new System.Drawing.Point(24, 85);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(394, 395);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// btn_editEmulator
			// 
			this.btn_editEmulator.Enabled = false;
			this.btn_editEmulator.Location = new System.Drawing.Point(316, 181);
			this.btn_editEmulator.Name = "btn_editEmulator";
			this.btn_editEmulator.Size = new System.Drawing.Size(44, 24);
			this.btn_editEmulator.TabIndex = 21;
			this.btn_editEmulator.Text = "Edit";
			this.btn_editEmulator.UseVisualStyleBackColor = true;
			this.btn_editEmulator.Click += new System.EventHandler(this.button4_Click_2);
			// 
			// btn_addEmulator
			// 
			this.btn_addEmulator.Location = new System.Drawing.Point(267, 181);
			this.btn_addEmulator.Name = "btn_addEmulator";
			this.btn_addEmulator.Size = new System.Drawing.Size(44, 24);
			this.btn_addEmulator.TabIndex = 20;
			this.btn_addEmulator.Text = "Add";
			this.btn_addEmulator.UseVisualStyleBackColor = true;
			this.btn_addEmulator.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.checkBox2);
			this.groupBox4.Controls.Add(this.button11);
			this.groupBox4.Controls.Add(this.label10);
			this.groupBox4.Controls.Add(this.comboBox9);
			this.groupBox4.Enabled = false;
			this.groupBox4.Location = new System.Drawing.Point(6, 290);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(360, 91);
			this.groupBox4.TabIndex = 19;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "On Launchbox Launch :";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(150, 56);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(69, 17);
			this.checkBox2.TabIndex = 18;
			this.checkBox2.Text = "Maximize";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// button11
			// 
			this.button11.Location = new System.Drawing.Point(277, 27);
			this.button11.Name = "button11";
			this.button11.Size = new System.Drawing.Size(77, 23);
			this.button11.TabIndex = 11;
			this.button11.Text = "Select";
			this.button11.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 32);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(94, 13);
			this.label10.TabIndex = 10;
			this.label10.Text = "Move To Monitor :";
			// 
			// comboBox9
			// 
			this.comboBox9.FormattingEnabled = true;
			this.comboBox9.Location = new System.Drawing.Point(150, 27);
			this.comboBox9.Name = "comboBox9";
			this.comboBox9.Size = new System.Drawing.Size(121, 21);
			this.comboBox9.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 184);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(108, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Select Emulator Exe :";
			// 
			// cmb_emulatorList
			// 
			this.cmb_emulatorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_emulatorList.FormattingEnabled = true;
			this.cmb_emulatorList.Location = new System.Drawing.Point(117, 181);
			this.cmb_emulatorList.Name = "cmb_emulatorList";
			this.cmb_emulatorList.Size = new System.Drawing.Size(144, 21);
			this.cmb_emulatorList.TabIndex = 11;
			this.cmb_emulatorList.SelectedIndexChanged += new System.EventHandler(this.cmb_emulatorList_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btn_editSoundcard);
			this.groupBox2.Controls.Add(this.btn_editMonitorSwitch);
			this.groupBox2.Controls.Add(this.txt_monitorswitch);
			this.groupBox2.Controls.Add(this.txt_soundcard);
			this.groupBox2.Controls.Add(this.txt_monitorpriority);
			this.groupBox2.Controls.Add(this.chk_restore);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.btn_editPriority);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(6, 19);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(360, 156);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "\'";
			// 
			// btn_editSoundcard
			// 
			this.btn_editSoundcard.Location = new System.Drawing.Point(300, 87);
			this.btn_editSoundcard.Name = "btn_editSoundcard";
			this.btn_editSoundcard.Size = new System.Drawing.Size(44, 23);
			this.btn_editSoundcard.TabIndex = 29;
			this.btn_editSoundcard.Text = "Edit";
			this.btn_editSoundcard.UseVisualStyleBackColor = true;
			this.btn_editSoundcard.Click += new System.EventHandler(this.btn_editSoundcard_Click);
			// 
			// btn_editMonitorSwitch
			// 
			this.btn_editMonitorSwitch.Location = new System.Drawing.Point(300, 58);
			this.btn_editMonitorSwitch.Name = "btn_editMonitorSwitch";
			this.btn_editMonitorSwitch.Size = new System.Drawing.Size(44, 23);
			this.btn_editMonitorSwitch.TabIndex = 28;
			this.btn_editMonitorSwitch.Text = "Edit";
			this.btn_editMonitorSwitch.UseVisualStyleBackColor = true;
			this.btn_editMonitorSwitch.Click += new System.EventHandler(this.btn_editMonitorSwitch_Click);
			// 
			// txt_monitorswitch
			// 
			this.txt_monitorswitch.Location = new System.Drawing.Point(150, 60);
			this.txt_monitorswitch.Name = "txt_monitorswitch";
			this.txt_monitorswitch.ReadOnly = true;
			this.txt_monitorswitch.Size = new System.Drawing.Size(144, 20);
			this.txt_monitorswitch.TabIndex = 23;
			// 
			// txt_soundcard
			// 
			this.txt_soundcard.Location = new System.Drawing.Point(150, 87);
			this.txt_soundcard.Name = "txt_soundcard";
			this.txt_soundcard.ReadOnly = true;
			this.txt_soundcard.Size = new System.Drawing.Size(144, 20);
			this.txt_soundcard.TabIndex = 22;
			// 
			// txt_monitorpriority
			// 
			this.txt_monitorpriority.Location = new System.Drawing.Point(150, 29);
			this.txt_monitorpriority.Name = "txt_monitorpriority";
			this.txt_monitorpriority.ReadOnly = true;
			this.txt_monitorpriority.Size = new System.Drawing.Size(144, 20);
			this.txt_monitorpriority.TabIndex = 21;
			// 
			// chk_restore
			// 
			this.chk_restore.AutoSize = true;
			this.chk_restore.Location = new System.Drawing.Point(150, 113);
			this.chk_restore.Name = "chk_restore";
			this.chk_restore.Size = new System.Drawing.Size(142, 17);
			this.chk_restore.TabIndex = 18;
			this.chk_restore.Text = "Restaure On BigBox Exit";
			this.chk_restore.UseVisualStyleBackColor = true;
			this.chk_restore.CheckedChanged += new System.EventHandler(this.chk_restore_CheckedChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Set Primary Soundcard :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(121, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Use Monitor Disposition:";
			// 
			// btn_editPriority
			// 
			this.btn_editPriority.Location = new System.Drawing.Point(300, 29);
			this.btn_editPriority.Name = "btn_editPriority";
			this.btn_editPriority.Size = new System.Drawing.Size(44, 23);
			this.btn_editPriority.TabIndex = 11;
			this.btn_editPriority.Text = "Edit";
			this.btn_editPriority.UseVisualStyleBackColor = true;
			this.btn_editPriority.Click += new System.EventHandler(this.btn_editPriority_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Monitor Priority :";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(348, 44);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(70, 35);
			this.button2.TabIndex = 6;
			this.button2.Text = "Delete profile";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(216, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(75, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Select Profile :";
			// 
			// Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 492);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmb_listProfiles);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_register);
			this.Controls.Add(this.label_status);
			this.Name = "Config";
			this.Text = "à";
			this.Load += new System.EventHandler(this.Config_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_status;
		private System.Windows.Forms.Button btn_register;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmb_listProfiles;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cmb_emulatorList;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btn_editPriority;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox comboBox9;
		private System.Windows.Forms.TextBox txt_monitorpriority;
		private System.Windows.Forms.TextBox txt_monitorswitch;
		private System.Windows.Forms.TextBox txt_soundcard;
		private System.Windows.Forms.Button btn_editMonitorSwitch;
		private System.Windows.Forms.Button btn_editSoundcard;
		private System.Windows.Forms.CheckBox chk_restore;
		private System.Windows.Forms.Button btn_addEmulator;
		private System.Windows.Forms.Button btn_editEmulator;
	}
}

