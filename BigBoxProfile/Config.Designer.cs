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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
			this.label_status = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.cmb_listProfiles = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.button2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_restore = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.txt_monitorpriority = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_soundcard = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_monitorswitch = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.chk_launchbox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_maximize = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.cmb_emulatorList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_addEmulator = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_editEmulator = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.groupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.btn_copyFromDefault = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_editSoundcard = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_editMonitorSwitch = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_editPriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.num_delayEmulator = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.cmb_DispositionList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.label9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.chk_Disable = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.cmb_listProfiles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cmb_emulatorList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).BeginInit();
			this.groupBox1.Panel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmb_DispositionList)).BeginInit();
			this.SuspendLayout();
			// 
			// label_status
			// 
			this.label_status.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_status.Location = new System.Drawing.Point(453, 36);
			this.label_status.Name = "label_status";
			this.label_status.Size = new System.Drawing.Size(52, 20);
			this.label_status.TabIndex = 0;
			this.label_status.Values.Text = "Inactive";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(445, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 20);
			this.label1.TabIndex = 2;
			this.label1.Values.Text = "App Status :";
			// 
			// cmb_listProfiles
			// 
			this.cmb_listProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_listProfiles.DropDownWidth = 249;
			this.cmb_listProfiles.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_listProfiles.FormattingEnabled = true;
			this.cmb_listProfiles.Location = new System.Drawing.Point(122, 7);
			this.cmb_listProfiles.Name = "cmb_listProfiles";
			this.cmb_listProfiles.Size = new System.Drawing.Size(249, 21);
			this.cmb_listProfiles.TabIndex = 1;
			this.cmb_listProfiles.SelectedIndexChanged += new System.EventHandler(this.cmb_listProfiles_SelectedIndexChanged);
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(253, 34);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(118, 35);
			this.button1.TabIndex = 11;
			this.button1.Values.Text = "Add New Profile";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(122, 34);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(125, 35);
			this.button2.TabIndex = 12;
			this.button2.Values.Text = "Delete profile";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(25, 10);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(87, 20);
			this.label5.TabIndex = 7;
			this.label5.Values.Text = "Select Profile :";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(8, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(103, 20);
			this.label2.TabIndex = 10;
			this.label2.Values.Text = "Monitor Priority :";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(145, 20);
			this.label3.TabIndex = 13;
			this.label3.Values.Text = "Use Monitor Disposition:";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(8, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(141, 20);
			this.label4.TabIndex = 16;
			this.label4.Values.Text = "Set Primary Soundcard :";
			// 
			// chk_restore
			// 
			this.chk_restore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_restore.Location = new System.Drawing.Point(165, 87);
			this.chk_restore.Name = "chk_restore";
			this.chk_restore.Size = new System.Drawing.Size(154, 20);
			this.chk_restore.TabIndex = 5;
			this.chk_restore.Values.Text = "Restaure On BigBox Exit";
			this.chk_restore.CheckedChanged += new System.EventHandler(this.chk_restore_CheckedChanged);
			// 
			// txt_monitorpriority
			// 
			this.txt_monitorpriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_monitorpriority.Location = new System.Drawing.Point(165, 3);
			this.txt_monitorpriority.Name = "txt_monitorpriority";
			this.txt_monitorpriority.ReadOnly = true;
			this.txt_monitorpriority.Size = new System.Drawing.Size(269, 23);
			this.txt_monitorpriority.TabIndex = 21;
			// 
			// txt_soundcard
			// 
			this.txt_soundcard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_soundcard.Location = new System.Drawing.Point(165, 61);
			this.txt_soundcard.Name = "txt_soundcard";
			this.txt_soundcard.ReadOnly = true;
			this.txt_soundcard.Size = new System.Drawing.Size(269, 23);
			this.txt_soundcard.TabIndex = 22;
			// 
			// txt_monitorswitch
			// 
			this.txt_monitorswitch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_monitorswitch.Location = new System.Drawing.Point(165, 32);
			this.txt_monitorswitch.Name = "txt_monitorswitch";
			this.txt_monitorswitch.ReadOnly = true;
			this.txt_monitorswitch.Size = new System.Drawing.Size(269, 23);
			this.txt_monitorswitch.TabIndex = 23;
			// 
			// chk_launchbox
			// 
			this.chk_launchbox.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_launchbox.Location = new System.Drawing.Point(165, 110);
			this.chk_launchbox.Name = "chk_launchbox";
			this.chk_launchbox.Size = new System.Drawing.Size(157, 20);
			this.chk_launchbox.TabIndex = 6;
			this.chk_launchbox.Values.Text = "Apply to Launchbox Too";
			this.chk_launchbox.CheckedChanged += new System.EventHandler(this.chk_launchbox_CheckedChanged);
			// 
			// chk_maximize
			// 
			this.chk_maximize.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_maximize.Location = new System.Drawing.Point(165, 133);
			this.chk_maximize.Name = "chk_maximize";
			this.chk_maximize.Size = new System.Drawing.Size(138, 20);
			this.chk_maximize.TabIndex = 7;
			this.chk_maximize.Values.Text = "Maximize Launchbox";
			this.chk_maximize.Visible = false;
			this.chk_maximize.CheckedChanged += new System.EventHandler(this.chk_maximize_CheckedChanged);
			// 
			// cmb_emulatorList
			// 
			this.cmb_emulatorList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_emulatorList.DropDownWidth = 144;
			this.cmb_emulatorList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmb_emulatorList.FormattingEnabled = true;
			this.cmb_emulatorList.Location = new System.Drawing.Point(167, 221);
			this.cmb_emulatorList.Name = "cmb_emulatorList";
			this.cmb_emulatorList.Size = new System.Drawing.Size(217, 21);
			this.cmb_emulatorList.TabIndex = 8;
			this.cmb_emulatorList.SelectedIndexChanged += new System.EventHandler(this.cmb_emulatorList_SelectedIndexChanged);
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 221);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 20);
			this.label6.TabIndex = 12;
			this.label6.Values.Text = "Select Emulator Exe :";
			// 
			// btn_addEmulator
			// 
			this.btn_addEmulator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_addEmulator.Location = new System.Drawing.Point(390, 221);
			this.btn_addEmulator.Name = "btn_addEmulator";
			this.btn_addEmulator.Size = new System.Drawing.Size(44, 24);
			this.btn_addEmulator.TabIndex = 10;
			this.btn_addEmulator.Values.Text = "Add";
			this.btn_addEmulator.Click += new System.EventHandler(this.button3_Click);
			// 
			// btn_editEmulator
			// 
			this.btn_editEmulator.Enabled = false;
			this.btn_editEmulator.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editEmulator.Location = new System.Drawing.Point(440, 221);
			this.btn_editEmulator.Name = "btn_editEmulator";
			this.btn_editEmulator.Size = new System.Drawing.Size(44, 24);
			this.btn_editEmulator.TabIndex = 9;
			this.btn_editEmulator.Values.Text = "Edit";
			this.btn_editEmulator.Click += new System.EventHandler(this.button4_Click_2);
			// 
			// groupBox1
			// 
			this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(25, 99);
			this.groupBox1.Name = "groupBox1";
			// 
			// groupBox1.Panel
			// 
			this.groupBox1.Panel.Controls.Add(this.btn_copyFromDefault);
			this.groupBox1.Panel.Controls.Add(this.btn_editSoundcard);
			this.groupBox1.Panel.Controls.Add(this.btn_editMonitorSwitch);
			this.groupBox1.Panel.Controls.Add(this.btn_editPriority);
			this.groupBox1.Panel.Controls.Add(this.label8);
			this.groupBox1.Panel.Controls.Add(this.num_delayEmulator);
			this.groupBox1.Panel.Controls.Add(this.label7);
			this.groupBox1.Panel.Controls.Add(this.chk_maximize);
			this.groupBox1.Panel.Controls.Add(this.btn_editEmulator);
			this.groupBox1.Panel.Controls.Add(this.chk_launchbox);
			this.groupBox1.Panel.Controls.Add(this.btn_addEmulator);
			this.groupBox1.Panel.Controls.Add(this.label6);
			this.groupBox1.Panel.Controls.Add(this.cmb_emulatorList);
			this.groupBox1.Panel.Controls.Add(this.txt_monitorswitch);
			this.groupBox1.Panel.Controls.Add(this.txt_soundcard);
			this.groupBox1.Panel.Controls.Add(this.label2);
			this.groupBox1.Panel.Controls.Add(this.txt_monitorpriority);
			this.groupBox1.Panel.Controls.Add(this.chk_restore);
			this.groupBox1.Panel.Controls.Add(this.label3);
			this.groupBox1.Panel.Controls.Add(this.label4);
			this.groupBox1.Size = new System.Drawing.Size(506, 303);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.Values.Heading = "&";
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// btn_copyFromDefault
			// 
			this.btn_copyFromDefault.Enabled = false;
			this.btn_copyFromDefault.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_copyFromDefault.Location = new System.Drawing.Point(329, 249);
			this.btn_copyFromDefault.Name = "btn_copyFromDefault";
			this.btn_copyFromDefault.Size = new System.Drawing.Size(155, 27);
			this.btn_copyFromDefault.TabIndex = 30;
			this.btn_copyFromDefault.Values.Text = "Copy From Default profile";
			this.btn_copyFromDefault.Visible = false;
			this.btn_copyFromDefault.Click += new System.EventHandler(this.btn_copyFromDefault_Click);
			// 
			// btn_editSoundcard
			// 
			this.btn_editSoundcard.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editSoundcard.Location = new System.Drawing.Point(440, 60);
			this.btn_editSoundcard.Name = "btn_editSoundcard";
			this.btn_editSoundcard.Size = new System.Drawing.Size(44, 24);
			this.btn_editSoundcard.TabIndex = 29;
			this.btn_editSoundcard.Values.Text = "Edit";
			this.btn_editSoundcard.Click += new System.EventHandler(this.btn_editSoundcard_Click);
			// 
			// btn_editMonitorSwitch
			// 
			this.btn_editMonitorSwitch.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editMonitorSwitch.Location = new System.Drawing.Point(440, 32);
			this.btn_editMonitorSwitch.Name = "btn_editMonitorSwitch";
			this.btn_editMonitorSwitch.Size = new System.Drawing.Size(44, 24);
			this.btn_editMonitorSwitch.TabIndex = 28;
			this.btn_editMonitorSwitch.Values.Text = "Edit";
			this.btn_editMonitorSwitch.Click += new System.EventHandler(this.btn_editMonitorSwitch_Click);
			// 
			// btn_editPriority
			// 
			this.btn_editPriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_editPriority.Location = new System.Drawing.Point(440, 2);
			this.btn_editPriority.Name = "btn_editPriority";
			this.btn_editPriority.Size = new System.Drawing.Size(44, 24);
			this.btn_editPriority.TabIndex = 27;
			this.btn_editPriority.Values.Text = "Edit";
			this.btn_editPriority.Click += new System.EventHandler(this.btn_editPriority_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 158);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(150, 20);
			this.label8.TabIndex = 26;
			this.label8.Values.Text = "Delay Emulator Start (sec)";
			// 
			// num_delayEmulator
			// 
			this.num_delayEmulator.Location = new System.Drawing.Point(165, 156);
			this.num_delayEmulator.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.num_delayEmulator.Name = "num_delayEmulator";
			this.num_delayEmulator.Size = new System.Drawing.Size(144, 22);
			this.num_delayEmulator.TabIndex = 25;
			this.num_delayEmulator.ValueChanged += new System.EventHandler(this.num_delayEmulator_ValueChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 195);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(183, 20);
			this.label7.TabIndex = 24;
			this.label7.Values.Text = "Hijack Emulator command line :";
			// 
			// cmb_DispositionList
			// 
			this.cmb_DispositionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_DispositionList.DropDownWidth = 224;
			this.cmb_DispositionList.FormattingEnabled = true;
			this.cmb_DispositionList.Location = new System.Drawing.Point(229, 408);
			this.cmb_DispositionList.Name = "cmb_DispositionList";
			this.cmb_DispositionList.Size = new System.Drawing.Size(302, 21);
			this.cmb_DispositionList.TabIndex = 13;
			this.cmb_DispositionList.SelectedIndexChanged += new System.EventHandler(this.cmb_DispositionList_SelectedIndexChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(25, 410);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(198, 20);
			this.label9.TabIndex = 14;
			this.label9.Values.Text = "Quick Monitor Disposition Switch :";
			// 
			// chk_Disable
			// 
			this.chk_Disable.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_Disable.Location = new System.Drawing.Point(25, 73);
			this.chk_Disable.Name = "chk_Disable";
			this.chk_Disable.Size = new System.Drawing.Size(463, 20);
			this.chk_Disable.TabIndex = 15;
			this.chk_Disable.Values.Text = "Disable LB/BB \"hooking\" and just use Hijack Emulator feature with default profile" +
    "";
			this.chk_Disable.CheckedChanged += new System.EventHandler(this.chk_Disable_CheckedChanged);
			// 
			// Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(543, 441);
			this.Controls.Add(this.chk_Disable);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.cmb_DispositionList);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.cmb_listProfiles);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label_status);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Config";
			this.Text = "BigBoxProfile Configuration";
			this.Load += new System.EventHandler(this.Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmb_listProfiles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cmb_emulatorList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).EndInit();
			this.groupBox1.Panel.ResumeLayout(false);
			this.groupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmb_DispositionList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel label_status;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_listProfiles;
		private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton button2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_restore;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_monitorpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_soundcard;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_monitorswitch;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_launchbox;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_maximize;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_emulatorList;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_addEmulator;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_editEmulator;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_delayEmulator;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_DispositionList;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label9;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_editSoundcard;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_editMonitorSwitch;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_editPriority;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_Disable;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_copyFromDefault;
	}
}

