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
			this.label1 = new System.Windows.Forms.Label();
			this.cmb_listProfiles = new System.Windows.Forms.ComboBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_editPriority = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.chk_restore = new System.Windows.Forms.CheckBox();
			this.txt_monitorpriority = new System.Windows.Forms.TextBox();
			this.txt_soundcard = new System.Windows.Forms.TextBox();
			this.txt_monitorswitch = new System.Windows.Forms.TextBox();
			this.btn_editMonitorSwitch = new System.Windows.Forms.Button();
			this.btn_editSoundcard = new System.Windows.Forms.Button();
			this.chk_launchbox = new System.Windows.Forms.CheckBox();
			this.chk_maximize = new System.Windows.Forms.CheckBox();
			this.cmb_emulatorList = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btn_addEmulator = new System.Windows.Forms.Button();
			this.btn_editEmulator = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label_status
			// 
			this.label_status.AutoSize = true;
			this.label_status.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_status.Location = new System.Drawing.Point(345, 25);
			this.label_status.Name = "label_status";
			this.label_status.Size = new System.Drawing.Size(46, 13);
			this.label_status.TabIndex = 0;
			this.label_status.Text = "Inactive";
			this.label_status.Click += new System.EventHandler(this.label_status_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(337, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "App Status :";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// cmb_listProfiles
			// 
			this.cmb_listProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_listProfiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_listProfiles.FormattingEnabled = true;
			this.cmb_listProfiles.Location = new System.Drawing.Point(106, 7);
			this.cmb_listProfiles.Name = "cmb_listProfiles";
			this.cmb_listProfiles.Size = new System.Drawing.Size(196, 21);
			this.cmb_listProfiles.TabIndex = 1;
			this.cmb_listProfiles.SelectedIndexChanged += new System.EventHandler(this.cmb_listProfiles_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(207, 34);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(95, 35);
			this.button1.TabIndex = 11;
			this.button1.Text = "Add New Profile";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(106, 34);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(95, 35);
			this.button2.TabIndex = 12;
			this.button2.Text = "Delete profile";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(25, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(76, 13);
			this.label5.TabIndex = 7;
			this.label5.Text = "Select Profile :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(7, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(87, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Monitor Priority :";
			// 
			// btn_editPriority
			// 
			this.btn_editPriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editPriority.Location = new System.Drawing.Point(297, 20);
			this.btn_editPriority.Name = "btn_editPriority";
			this.btn_editPriority.Size = new System.Drawing.Size(44, 23);
			this.btn_editPriority.TabIndex = 2;
			this.btn_editPriority.Text = "Edit";
			this.btn_editPriority.UseVisualStyleBackColor = true;
			this.btn_editPriority.Click += new System.EventHandler(this.btn_editPriority_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(7, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(122, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "Use Monitor Disposition:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(7, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(123, 13);
			this.label4.TabIndex = 16;
			this.label4.Text = "Set Primary Soundcard :";
			// 
			// chk_restore
			// 
			this.chk_restore.AutoSize = true;
			this.chk_restore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_restore.Location = new System.Drawing.Point(147, 104);
			this.chk_restore.Name = "chk_restore";
			this.chk_restore.Size = new System.Drawing.Size(143, 17);
			this.chk_restore.TabIndex = 5;
			this.chk_restore.Text = "Restaure On BigBox Exit";
			this.chk_restore.UseVisualStyleBackColor = true;
			this.chk_restore.CheckedChanged += new System.EventHandler(this.chk_restore_CheckedChanged);
			// 
			// txt_monitorpriority
			// 
			this.txt_monitorpriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_monitorpriority.Location = new System.Drawing.Point(147, 20);
			this.txt_monitorpriority.Name = "txt_monitorpriority";
			this.txt_monitorpriority.ReadOnly = true;
			this.txt_monitorpriority.Size = new System.Drawing.Size(144, 21);
			this.txt_monitorpriority.TabIndex = 21;
			// 
			// txt_soundcard
			// 
			this.txt_soundcard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_soundcard.Location = new System.Drawing.Point(147, 78);
			this.txt_soundcard.Name = "txt_soundcard";
			this.txt_soundcard.ReadOnly = true;
			this.txt_soundcard.Size = new System.Drawing.Size(144, 21);
			this.txt_soundcard.TabIndex = 22;
			// 
			// txt_monitorswitch
			// 
			this.txt_monitorswitch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_monitorswitch.Location = new System.Drawing.Point(147, 51);
			this.txt_monitorswitch.Name = "txt_monitorswitch";
			this.txt_monitorswitch.ReadOnly = true;
			this.txt_monitorswitch.Size = new System.Drawing.Size(144, 21);
			this.txt_monitorswitch.TabIndex = 23;
			// 
			// btn_editMonitorSwitch
			// 
			this.btn_editMonitorSwitch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editMonitorSwitch.Location = new System.Drawing.Point(297, 49);
			this.btn_editMonitorSwitch.Name = "btn_editMonitorSwitch";
			this.btn_editMonitorSwitch.Size = new System.Drawing.Size(44, 23);
			this.btn_editMonitorSwitch.TabIndex = 3;
			this.btn_editMonitorSwitch.Text = "Edit";
			this.btn_editMonitorSwitch.UseVisualStyleBackColor = true;
			this.btn_editMonitorSwitch.Click += new System.EventHandler(this.btn_editMonitorSwitch_Click);
			// 
			// btn_editSoundcard
			// 
			this.btn_editSoundcard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editSoundcard.Location = new System.Drawing.Point(297, 78);
			this.btn_editSoundcard.Name = "btn_editSoundcard";
			this.btn_editSoundcard.Size = new System.Drawing.Size(44, 23);
			this.btn_editSoundcard.TabIndex = 4;
			this.btn_editSoundcard.Text = "Edit";
			this.btn_editSoundcard.UseVisualStyleBackColor = true;
			this.btn_editSoundcard.Click += new System.EventHandler(this.btn_editSoundcard_Click);
			// 
			// chk_launchbox
			// 
			this.chk_launchbox.AutoSize = true;
			this.chk_launchbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_launchbox.Location = new System.Drawing.Point(147, 127);
			this.chk_launchbox.Name = "chk_launchbox";
			this.chk_launchbox.Size = new System.Drawing.Size(142, 17);
			this.chk_launchbox.TabIndex = 6;
			this.chk_launchbox.Text = "Apply to Launchbox Too";
			this.chk_launchbox.UseVisualStyleBackColor = true;
			this.chk_launchbox.CheckedChanged += new System.EventHandler(this.chk_launchbox_CheckedChanged);
			// 
			// chk_maximize
			// 
			this.chk_maximize.AutoSize = true;
			this.chk_maximize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_maximize.Location = new System.Drawing.Point(147, 150);
			this.chk_maximize.Name = "chk_maximize";
			this.chk_maximize.Size = new System.Drawing.Size(124, 17);
			this.chk_maximize.TabIndex = 7;
			this.chk_maximize.Text = "Maximize Launchbox";
			this.chk_maximize.UseVisualStyleBackColor = true;
			this.chk_maximize.CheckedChanged += new System.EventHandler(this.chk_maximize_CheckedChanged);
			// 
			// cmb_emulatorList
			// 
			this.cmb_emulatorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_emulatorList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_emulatorList.FormattingEnabled = true;
			this.cmb_emulatorList.Location = new System.Drawing.Point(149, 200);
			this.cmb_emulatorList.Name = "cmb_emulatorList";
			this.cmb_emulatorList.Size = new System.Drawing.Size(144, 21);
			this.cmb_emulatorList.TabIndex = 8;
			this.cmb_emulatorList.SelectedIndexChanged += new System.EventHandler(this.cmb_emulatorList_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(13, 200);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Select Emulator Exe :";
			// 
			// btn_addEmulator
			// 
			this.btn_addEmulator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_addEmulator.Location = new System.Drawing.Point(299, 200);
			this.btn_addEmulator.Name = "btn_addEmulator";
			this.btn_addEmulator.Size = new System.Drawing.Size(44, 24);
			this.btn_addEmulator.TabIndex = 10;
			this.btn_addEmulator.Text = "Add";
			this.btn_addEmulator.UseVisualStyleBackColor = true;
			this.btn_addEmulator.Click += new System.EventHandler(this.button3_Click);
			// 
			// btn_editEmulator
			// 
			this.btn_editEmulator.Enabled = false;
			this.btn_editEmulator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editEmulator.Location = new System.Drawing.Point(348, 200);
			this.btn_editEmulator.Name = "btn_editEmulator";
			this.btn_editEmulator.Size = new System.Drawing.Size(44, 24);
			this.btn_editEmulator.TabIndex = 9;
			this.btn_editEmulator.Text = "Edit";
			this.btn_editEmulator.UseVisualStyleBackColor = true;
			this.btn_editEmulator.Click += new System.EventHandler(this.button4_Click_2);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chk_maximize);
			this.groupBox1.Controls.Add(this.btn_editEmulator);
			this.groupBox1.Controls.Add(this.chk_launchbox);
			this.groupBox1.Controls.Add(this.btn_addEmulator);
			this.groupBox1.Controls.Add(this.btn_editSoundcard);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btn_editMonitorSwitch);
			this.groupBox1.Controls.Add(this.cmb_emulatorList);
			this.groupBox1.Controls.Add(this.txt_monitorswitch);
			this.groupBox1.Controls.Add(this.txt_soundcard);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txt_monitorpriority);
			this.groupBox1.Controls.Add(this.btn_editPriority);
			this.groupBox1.Controls.Add(this.chk_restore);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(24, 85);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(394, 244);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "&";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(435, 337);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmb_listProfiles);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_status);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Config";
			this.Text = "BigBoxProfile Configuration";
			this.Load += new System.EventHandler(this.Config_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_status;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmb_listProfiles;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_editPriority;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.CheckBox chk_restore;
		private System.Windows.Forms.TextBox txt_monitorpriority;
		private System.Windows.Forms.TextBox txt_soundcard;
		private System.Windows.Forms.TextBox txt_monitorswitch;
		private System.Windows.Forms.Button btn_editMonitorSwitch;
		private System.Windows.Forms.Button btn_editSoundcard;
		private System.Windows.Forms.CheckBox chk_launchbox;
		private System.Windows.Forms.CheckBox chk_maximize;
		private System.Windows.Forms.ComboBox cmb_emulatorList;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btn_addEmulator;
		private System.Windows.Forms.Button btn_editEmulator;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}

