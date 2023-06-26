namespace BigBoxProfile.EmulatorActions
{
	partial class CopyFile_Config
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
			this.txt_sourceDir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_source = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_targetDir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_target = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.num_maxSize = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.chk_useRamDisk = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_deleteOnExit = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.groupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.label_Imdisk_false = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label_Imdisk_true = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).BeginInit();
			this.groupBox3.Panel.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_sourceDir
			// 
			this.txt_sourceDir.Location = new System.Drawing.Point(217, 19);
			this.txt_sourceDir.Name = "txt_sourceDir";
			this.txt_sourceDir.Size = new System.Drawing.Size(362, 23);
			this.txt_sourceDir.TabIndex = 0;
			// 
			// btn_source
			// 
			this.btn_source.Location = new System.Drawing.Point(585, 18);
			this.btn_source.Name = "btn_source";
			this.btn_source.Size = new System.Drawing.Size(35, 24);
			this.btn_source.TabIndex = 1;
			this.btn_source.Values.Text = "...";
			this.btn_source.Click += new System.EventHandler(this.btn_source_Click);
			// 
			// txt_targetDir
			// 
			this.txt_targetDir.Location = new System.Drawing.Point(217, 49);
			this.txt_targetDir.Name = "txt_targetDir";
			this.txt_targetDir.Size = new System.Drawing.Size(362, 23);
			this.txt_targetDir.TabIndex = 2;
			// 
			// btn_target
			// 
			this.btn_target.Location = new System.Drawing.Point(585, 45);
			this.btn_target.Name = "btn_target";
			this.btn_target.Size = new System.Drawing.Size(35, 24);
			this.btn_target.TabIndex = 3;
			this.btn_target.Values.Text = "...";
			this.btn_target.Click += new System.EventHandler(this.btn_target_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(15, 220);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(196, 20);
			this.label2.TabIndex = 31;
			this.label2.Values.Text = "Max Size To use Ramdisk (In MB) :";
			// 
			// num_maxSize
			// 
			this.num_maxSize.Location = new System.Drawing.Point(217, 218);
			this.num_maxSize.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.num_maxSize.Name = "num_maxSize";
			this.num_maxSize.Size = new System.Drawing.Size(120, 22);
			this.num_maxSize.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(107, 20);
			this.label1.TabIndex = 32;
			this.label1.Values.Text = "Source Directory :";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(105, 20);
			this.label3.TabIndex = 33;
			this.label3.Values.Text = "Target Directory :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(217, 78);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(362, 23);
			this.txt_filter.TabIndex = 34;
			// 
			// chk_useRamDisk
			// 
			this.chk_useRamDisk.Location = new System.Drawing.Point(217, 194);
			this.chk_useRamDisk.Name = "chk_useRamDisk";
			this.chk_useRamDisk.Size = new System.Drawing.Size(190, 20);
			this.chk_useRamDisk.TabIndex = 36;
			this.chk_useRamDisk.Values.Text = "Use RamDisk Instead of Target";
			this.chk_useRamDisk.CheckedChanged += new System.EventHandler(this.chk_useRamDisk_CheckedChanged);
			// 
			// chk_deleteOnExit
			// 
			this.chk_deleteOnExit.Location = new System.Drawing.Point(409, 194);
			this.chk_deleteOnExit.Name = "chk_deleteOnExit";
			this.chk_deleteOnExit.Size = new System.Drawing.Size(170, 20);
			this.chk_deleteOnExit.TabIndex = 37;
			this.chk_deleteOnExit.Values.Text = "Delete File After App Close";
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(458, 337);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 39;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(539, 337);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 38;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(15, 256);
			this.groupBox3.Name = "groupBox3";
			// 
			// groupBox3.Panel
			// 
			this.groupBox3.Panel.Controls.Add(this.kryptonLinkLabel1);
			this.groupBox3.Panel.Controls.Add(this.label_Imdisk_false);
			this.groupBox3.Panel.Controls.Add(this.label_Imdisk_true);
			this.groupBox3.Panel.Controls.Add(this.label8);
			this.groupBox3.Size = new System.Drawing.Size(292, 105);
			this.groupBox3.TabIndex = 40;
			this.groupBox3.Values.Heading = "ImDisk";
			// 
			// kryptonLinkLabel1
			// 
			this.kryptonLinkLabel1.Location = new System.Drawing.Point(6, 41);
			this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
			this.kryptonLinkLabel1.Size = new System.Drawing.Size(266, 20);
			this.kryptonLinkLabel1.TabIndex = 48;
			this.kryptonLinkLabel1.Values.Text = "http://www.ltr-data.se/opencode.html/#ImDisk";
			this.kryptonLinkLabel1.LinkClicked += new System.EventHandler(this.kryptonLinkLabel1_LinkClicked);
			// 
			// label_Imdisk_false
			// 
			this.label_Imdisk_false.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Imdisk_false.ForeColor = System.Drawing.Color.Red;
			this.label_Imdisk_false.Location = new System.Drawing.Point(185, 19);
			this.label_Imdisk_false.Name = "label_Imdisk_false";
			this.label_Imdisk_false.Size = new System.Drawing.Size(80, 20);
			this.label_Imdisk_false.TabIndex = 22;
			this.label_Imdisk_false.Values.Text = "Not Installed";
			// 
			// label_Imdisk_true
			// 
			this.label_Imdisk_true.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Imdisk_true.ForeColor = System.Drawing.Color.Green;
			this.label_Imdisk_true.Location = new System.Drawing.Point(185, 19);
			this.label_Imdisk_true.Name = "label_Imdisk_true";
			this.label_Imdisk_true.Size = new System.Drawing.Size(56, 20);
			this.label_Imdisk_true.TabIndex = 20;
			this.label_Imdisk_true.Values.Text = "Installed";
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(6, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 20);
			this.label8.TabIndex = 18;
			this.label8.Values.Text = "ImDisk Status :";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 3000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(488, 156);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 47;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(217, 158);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 46;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(13, 135);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 45;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(217, 132);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(362, 23);
			this.txt_exclude.TabIndex = 44;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(488, 102);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 43;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(217, 102);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 42;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(15, 81);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(150, 20);
			this.label5.TabIndex = 41;
			this.label5.Values.Text = "Only if cmdLine contains :";
			// 
			// CopyFile_Config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(639, 370);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.chk_deleteOnExit);
			this.Controls.Add(this.chk_useRamDisk);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.num_maxSize);
			this.Controls.Add(this.btn_target);
			this.Controls.Add(this.txt_targetDir);
			this.Controls.Add(this.btn_source);
			this.Controls.Add(this.txt_sourceDir);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CopyFile_Config";
			this.Text = "Configuration Module : Copy File";
			this.Load += new System.EventHandler(this.CopyFile_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).EndInit();
			this.groupBox3.Panel.ResumeLayout(false);
			this.groupBox3.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_sourceDir;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_source;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_targetDir;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_target;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_maxSize;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_useRamDisk;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_deleteOnExit;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label_Imdisk_false;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label_Imdisk_true;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
		private System.Windows.Forms.Timer timer1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}