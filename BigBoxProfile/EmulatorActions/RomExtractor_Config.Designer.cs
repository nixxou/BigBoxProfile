namespace BigBoxProfile.EmulatorActions
{
	partial class RomExtractor_Config
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
			this.btn_delete_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SmartExtract = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DeleteOnExit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.json = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_add = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.UseRamDisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CacheSubDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_down_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.Priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lv_priority = new System.Windows.Forms.ListView();
			this.PathFilters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_metadataExtensions = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_standaloneExtensions = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_excludeFilter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.groupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.kryptonLinkLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLinkLabel();
			this.label_Imdisk_false = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label_Imdisk_true = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_cachedir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_cachedir = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.num_cacheMaxSize = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).BeginInit();
			this.groupBox3.Panel.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_delete_priority
			// 
			this.btn_delete_priority.Enabled = false;
			this.btn_delete_priority.Location = new System.Drawing.Point(988, 442);
			this.btn_delete_priority.Name = "btn_delete_priority";
			this.btn_delete_priority.Size = new System.Drawing.Size(75, 24);
			this.btn_delete_priority.TabIndex = 64;
			this.btn_delete_priority.Values.Text = "Delete";
			this.btn_delete_priority.Click += new System.EventHandler(this.btn_delete_priority_Click);
			// 
			// btn_up_priority
			// 
			this.btn_up_priority.Enabled = false;
			this.btn_up_priority.Location = new System.Drawing.Point(988, 382);
			this.btn_up_priority.Name = "btn_up_priority";
			this.btn_up_priority.Size = new System.Drawing.Size(75, 24);
			this.btn_up_priority.TabIndex = 62;
			this.btn_up_priority.Values.Text = "Up";
			this.btn_up_priority.Click += new System.EventHandler(this.btn_up_priority_Click);
			// 
			// SmartExtract
			// 
			this.SmartExtract.Text = "SmartExtract";
			this.SmartExtract.Width = 100;
			// 
			// DeleteOnExit
			// 
			this.DeleteOnExit.Text = "Delete On Exit";
			this.DeleteOnExit.Width = 95;
			// 
			// json
			// 
			this.json.Text = "json";
			// 
			// btn_add
			// 
			this.btn_add.Location = new System.Drawing.Point(988, 255);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(75, 24);
			this.btn_add.TabIndex = 61;
			this.btn_add.Values.Text = "Add";
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// UseRamDisk
			// 
			this.UseRamDisk.Text = "Use Ramdisk";
			this.UseRamDisk.Width = 99;
			// 
			// CacheSubDir
			// 
			this.CacheSubDir.Text = "Cache Sub Directory";
			this.CacheSubDir.Width = 136;
			// 
			// btn_down_priority
			// 
			this.btn_down_priority.Enabled = false;
			this.btn_down_priority.Location = new System.Drawing.Point(988, 412);
			this.btn_down_priority.Name = "btn_down_priority";
			this.btn_down_priority.Size = new System.Drawing.Size(75, 24);
			this.btn_down_priority.TabIndex = 63;
			this.btn_down_priority.Values.Text = "Down";
			this.btn_down_priority.Click += new System.EventHandler(this.btn_down_priority_Click);
			// 
			// Priority
			// 
			this.Priority.Text = "Priority";
			this.Priority.Width = 89;
			// 
			// lv_priority
			// 
			this.lv_priority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.json,
            this.PathFilters,
            this.Priority,
            this.CacheSubDir,
            this.UseRamDisk,
            this.DeleteOnExit,
            this.SmartExtract});
			this.lv_priority.FullRowSelect = true;
			this.lv_priority.HideSelection = false;
			this.lv_priority.Location = new System.Drawing.Point(14, 255);
			this.lv_priority.MultiSelect = false;
			this.lv_priority.Name = "lv_priority";
			this.lv_priority.Size = new System.Drawing.Size(966, 422);
			this.lv_priority.TabIndex = 60;
			this.lv_priority.UseCompatibleStateImageBehavior = false;
			this.lv_priority.View = System.Windows.Forms.View.Details;
			this.lv_priority.DoubleClick += new System.EventHandler(this.lv_priority_DoubleClick);
			this.lv_priority.DpiChangedAfterParent += new System.EventHandler(this.lv_priority_DpiChangedAfterParent);
			// 
			// PathFilters
			// 
			this.PathFilters.Text = "Path Filters";
			this.PathFilters.Width = 100;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(14, 222);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(124, 20);
			this.label4.TabIndex = 59;
			this.label4.Values.Text = "Metadata Extension :";
			// 
			// txt_metadataExtensions
			// 
			this.txt_metadataExtensions.Location = new System.Drawing.Point(187, 219);
			this.txt_metadataExtensions.Name = "txt_metadataExtensions";
			this.txt_metadataExtensions.Size = new System.Drawing.Size(793, 23);
			this.txt_metadataExtensions.TabIndex = 58;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(14, 193);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(164, 20);
			this.label2.TabIndex = 57;
			this.label2.Values.Text = "StandAlone Rom Extension :";
			// 
			// txt_standaloneExtensions
			// 
			this.txt_standaloneExtensions.Location = new System.Drawing.Point(187, 190);
			this.txt_standaloneExtensions.Name = "txt_standaloneExtensions";
			this.txt_standaloneExtensions.Size = new System.Drawing.Size(793, 23);
			this.txt_standaloneExtensions.TabIndex = 56;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 138);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(167, 20);
			this.label1.TabIndex = 55;
			this.label1.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_excludeFilter
			// 
			this.txt_excludeFilter.Location = new System.Drawing.Point(187, 135);
			this.txt_excludeFilter.Name = "txt_excludeFilter";
			this.txt_excludeFilter.Size = new System.Drawing.Size(793, 23);
			this.txt_excludeFilter.TabIndex = 54;
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(187, 69);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(793, 23);
			this.txt_filter.TabIndex = 52;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(14, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 53;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(14, 683);
			this.groupBox3.Name = "groupBox3";
			// 
			// groupBox3.Panel
			// 
			this.groupBox3.Panel.Controls.Add(this.kryptonLinkLabel1);
			this.groupBox3.Panel.Controls.Add(this.label_Imdisk_false);
			this.groupBox3.Panel.Controls.Add(this.label_Imdisk_true);
			this.groupBox3.Panel.Controls.Add(this.label8);
			this.groupBox3.Size = new System.Drawing.Size(377, 111);
			this.groupBox3.TabIndex = 67;
			this.groupBox3.Values.Heading = "ImDisk";
			// 
			// kryptonLinkLabel1
			// 
			this.kryptonLinkLabel1.Location = new System.Drawing.Point(6, 45);
			this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
			this.kryptonLinkLabel1.Size = new System.Drawing.Size(266, 20);
			this.kryptonLinkLabel1.TabIndex = 23;
			this.kryptonLinkLabel1.Values.Text = "http://www.ltr-data.se/opencode.html/#ImDisk";
			this.kryptonLinkLabel1.LinkClicked += new System.EventHandler(this.kryptonLinkLabel1_LinkClicked);
			// 
			// label_Imdisk_false
			// 
			this.label_Imdisk_false.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Imdisk_false.ForeColor = System.Drawing.Color.Red;
			this.label_Imdisk_false.Location = new System.Drawing.Point(166, 15);
			this.label_Imdisk_false.Name = "label_Imdisk_false";
			this.label_Imdisk_false.Size = new System.Drawing.Size(80, 20);
			this.label_Imdisk_false.TabIndex = 22;
			this.label_Imdisk_false.Values.Text = "Not Installed";
			// 
			// label_Imdisk_true
			// 
			this.label_Imdisk_true.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Imdisk_true.ForeColor = System.Drawing.Color.Green;
			this.label_Imdisk_true.Location = new System.Drawing.Point(166, 15);
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
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(905, 770);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 66;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(988, 769);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 65;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_cachedir
			// 
			this.txt_cachedir.Location = new System.Drawing.Point(187, 12);
			this.txt_cachedir.Name = "txt_cachedir";
			this.txt_cachedir.Size = new System.Drawing.Size(747, 23);
			this.txt_cachedir.TabIndex = 68;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(14, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(103, 20);
			this.label5.TabIndex = 69;
			this.label5.Values.Text = "Cache Directory :";
			// 
			// btn_cachedir
			// 
			this.btn_cachedir.Location = new System.Drawing.Point(940, 12);
			this.btn_cachedir.Name = "btn_cachedir";
			this.btn_cachedir.Size = new System.Drawing.Size(40, 24);
			this.btn_cachedir.TabIndex = 70;
			this.btn_cachedir.Values.Text = "...";
			this.btn_cachedir.Click += new System.EventHandler(this.btn_cachedir_Click);
			// 
			// num_cacheMaxSize
			// 
			this.num_cacheMaxSize.Location = new System.Drawing.Point(187, 41);
			this.num_cacheMaxSize.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
			this.num_cacheMaxSize.Name = "num_cacheMaxSize";
			this.num_cacheMaxSize.Size = new System.Drawing.Size(120, 22);
			this.num_cacheMaxSize.TabIndex = 71;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(14, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(149, 20);
			this.label6.TabIndex = 72;
			this.label6.Values.Text = "Cache Dir Max Size (MB) :";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(317, 43);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 20);
			this.label7.TabIndex = 73;
			this.label7.Values.Text = "( 0 = Unlimited )";
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(889, 94);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 88;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(187, 98);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 87;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(889, 160);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 92;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(187, 164);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 91;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(187, 114);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 93;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			// 
			// RomExtractor_Config
			// 
			this.AcceptButton = this.btn_manage_filter;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1080, 805);
			this.Controls.Add(this.chk_filter_remove);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.num_cacheMaxSize);
			this.Controls.Add(this.btn_cachedir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txt_cachedir);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.btn_delete_priority);
			this.Controls.Add(this.btn_up_priority);
			this.Controls.Add(this.btn_add);
			this.Controls.Add(this.btn_down_priority);
			this.Controls.Add(this.lv_priority);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txt_metadataExtensions);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txt_standaloneExtensions);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_excludeFilter);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.label3);
			this.Name = "RomExtractor_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : RomExtractor";
			this.Load += new System.EventHandler(this.RomExtractor_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).EndInit();
			this.groupBox3.Panel.ResumeLayout(false);
			this.groupBox3.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_priority;
		private System.Windows.Forms.ColumnHeader SmartExtract;
		private System.Windows.Forms.ColumnHeader DeleteOnExit;
		private System.Windows.Forms.ColumnHeader json;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add;
		private System.Windows.Forms.ColumnHeader UseRamDisk;
		private System.Windows.Forms.ColumnHeader CacheSubDir;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_priority;
		private System.Windows.Forms.ColumnHeader Priority;
		private System.Windows.Forms.ListView lv_priority;
		private System.Windows.Forms.ColumnHeader PathFilters;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_metadataExtensions;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_standaloneExtensions;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_excludeFilter;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label_Imdisk_false;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label_Imdisk_true;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_cachedir;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cachedir;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_cacheMaxSize;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonLinkLabel kryptonLinkLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
	}
}