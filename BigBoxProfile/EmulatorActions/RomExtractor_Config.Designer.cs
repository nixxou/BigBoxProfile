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
			this.btn_delete_priority = new System.Windows.Forms.Button();
			this.btn_up_priority = new System.Windows.Forms.Button();
			this.SmartExtract = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DeleteOnExit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.json = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_add = new System.Windows.Forms.Button();
			this.UseRamDisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.CacheSubDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_down_priority = new System.Windows.Forms.Button();
			this.Priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lv_priority = new System.Windows.Forms.ListView();
			this.PathFilters = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label4 = new System.Windows.Forms.Label();
			this.txt_metadataExtensions = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_standaloneExtensions = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_excludeFilter = new System.Windows.Forms.TextBox();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label_Imdisk_false = new System.Windows.Forms.Label();
			this.label_Imdisk_true = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label8 = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.txt_cachedir = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btn_cachedir = new System.Windows.Forms.Button();
			this.num_cacheMaxSize = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_cacheMaxSize)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_delete_priority
			// 
			this.btn_delete_priority.Enabled = false;
			this.btn_delete_priority.Location = new System.Drawing.Point(981, 354);
			this.btn_delete_priority.Name = "btn_delete_priority";
			this.btn_delete_priority.Size = new System.Drawing.Size(75, 23);
			this.btn_delete_priority.TabIndex = 64;
			this.btn_delete_priority.Text = "Delete";
			this.btn_delete_priority.UseVisualStyleBackColor = true;
			this.btn_delete_priority.Click += new System.EventHandler(this.btn_delete_priority_Click);
			// 
			// btn_up_priority
			// 
			this.btn_up_priority.Enabled = false;
			this.btn_up_priority.Location = new System.Drawing.Point(981, 296);
			this.btn_up_priority.Name = "btn_up_priority";
			this.btn_up_priority.Size = new System.Drawing.Size(75, 23);
			this.btn_up_priority.TabIndex = 62;
			this.btn_up_priority.Text = "Up";
			this.btn_up_priority.UseVisualStyleBackColor = true;
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
			this.btn_add.Location = new System.Drawing.Point(981, 168);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(75, 23);
			this.btn_add.TabIndex = 61;
			this.btn_add.Text = "Add";
			this.btn_add.UseVisualStyleBackColor = true;
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
			this.btn_down_priority.Location = new System.Drawing.Point(981, 325);
			this.btn_down_priority.Name = "btn_down_priority";
			this.btn_down_priority.Size = new System.Drawing.Size(75, 23);
			this.btn_down_priority.TabIndex = 63;
			this.btn_down_priority.Text = "Down";
			this.btn_down_priority.UseVisualStyleBackColor = true;
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
			this.lv_priority.Location = new System.Drawing.Point(9, 168);
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
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 145);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(107, 13);
			this.label4.TabIndex = 59;
			this.label4.Text = "Metadata Extension :";
			// 
			// txt_metadataExtensions
			// 
			this.txt_metadataExtensions.Location = new System.Drawing.Point(154, 142);
			this.txt_metadataExtensions.Name = "txt_metadataExtensions";
			this.txt_metadataExtensions.Size = new System.Drawing.Size(554, 20);
			this.txt_metadataExtensions.TabIndex = 58;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(142, 13);
			this.label2.TabIndex = 57;
			this.label2.Text = "StandAlone Rom Extension :";
			// 
			// txt_standaloneExtensions
			// 
			this.txt_standaloneExtensions.Location = new System.Drawing.Point(154, 116);
			this.txt_standaloneExtensions.Name = "txt_standaloneExtensions";
			this.txt_standaloneExtensions.Size = new System.Drawing.Size(554, 20);
			this.txt_standaloneExtensions.TabIndex = 56;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 93);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(145, 13);
			this.label1.TabIndex = 55;
			this.label1.Text = "Exclude if cmdLine contains :";
			// 
			// txt_excludeFilter
			// 
			this.txt_excludeFilter.Location = new System.Drawing.Point(154, 90);
			this.txt_excludeFilter.Name = "txt_excludeFilter";
			this.txt_excludeFilter.Size = new System.Drawing.Size(554, 20);
			this.txt_excludeFilter.TabIndex = 54;
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(154, 64);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(554, 20);
			this.txt_filter.TabIndex = 52;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 53;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label_Imdisk_false);
			this.groupBox3.Controls.Add(this.label_Imdisk_true);
			this.groupBox3.Controls.Add(this.linkLabel1);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Location = new System.Drawing.Point(27, 596);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(377, 88);
			this.groupBox3.TabIndex = 67;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "ImDisk";
			// 
			// label_Imdisk_false
			// 
			this.label_Imdisk_false.AutoSize = true;
			this.label_Imdisk_false.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Imdisk_false.ForeColor = System.Drawing.Color.Red;
			this.label_Imdisk_false.Location = new System.Drawing.Point(166, 15);
			this.label_Imdisk_false.Name = "label_Imdisk_false";
			this.label_Imdisk_false.Size = new System.Drawing.Size(125, 24);
			this.label_Imdisk_false.TabIndex = 22;
			this.label_Imdisk_false.Text = "Not Installed";
			// 
			// label_Imdisk_true
			// 
			this.label_Imdisk_true.AutoSize = true;
			this.label_Imdisk_true.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Imdisk_true.ForeColor = System.Drawing.Color.Green;
			this.label_Imdisk_true.Location = new System.Drawing.Point(166, 15);
			this.label_Imdisk_true.Name = "label_Imdisk_true";
			this.label_Imdisk_true.Size = new System.Drawing.Size(87, 24);
			this.label_Imdisk_true.TabIndex = 20;
			this.label_Imdisk_true.Text = "Installed";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(7, 55);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(230, 13);
			this.linkLabel1.TabIndex = 19;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://www.ltr-data.se/opencode.html/#ImDisk";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(6, 19);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(132, 20);
			this.label8.TabIndex = 18;
			this.label8.Text = "ImDisk Status :";
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(803, 661);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 66;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(900, 661);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 65;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_cachedir
			// 
			this.txt_cachedir.Location = new System.Drawing.Point(154, 12);
			this.txt_cachedir.Name = "txt_cachedir";
			this.txt_cachedir.Size = new System.Drawing.Size(554, 20);
			this.txt_cachedir.TabIndex = 68;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 15);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(89, 13);
			this.label5.TabIndex = 69;
			this.label5.Text = "Cache Directory :";
			// 
			// btn_cachedir
			// 
			this.btn_cachedir.Location = new System.Drawing.Point(714, 10);
			this.btn_cachedir.Name = "btn_cachedir";
			this.btn_cachedir.Size = new System.Drawing.Size(39, 23);
			this.btn_cachedir.TabIndex = 70;
			this.btn_cachedir.Text = "...";
			this.btn_cachedir.UseVisualStyleBackColor = true;
			this.btn_cachedir.Click += new System.EventHandler(this.btn_cachedir_Click);
			// 
			// num_cacheMaxSize
			// 
			this.num_cacheMaxSize.Location = new System.Drawing.Point(154, 38);
			this.num_cacheMaxSize.Name = "num_cacheMaxSize";
			this.num_cacheMaxSize.Size = new System.Drawing.Size(120, 20);
			this.num_cacheMaxSize.TabIndex = 71;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 40);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 13);
			this.label6.TabIndex = 72;
			this.label6.Text = "Cache Dir Max Size (MB) :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(282, 42);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 13);
			this.label7.TabIndex = 73;
			this.label7.Text = "( 0 = Unlimited )";
			// 
			// RomExtractor_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1068, 711);
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
			this.Text = "RomExtractor_Config";
			this.Load += new System.EventHandler(this.RomExtractor_Config_Load);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.num_cacheMaxSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_delete_priority;
		private System.Windows.Forms.Button btn_up_priority;
		private System.Windows.Forms.ColumnHeader SmartExtract;
		private System.Windows.Forms.ColumnHeader DeleteOnExit;
		private System.Windows.Forms.ColumnHeader json;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.ColumnHeader UseRamDisk;
		private System.Windows.Forms.ColumnHeader CacheSubDir;
		private System.Windows.Forms.Button btn_down_priority;
		private System.Windows.Forms.ColumnHeader Priority;
		private System.Windows.Forms.ListView lv_priority;
		private System.Windows.Forms.ColumnHeader PathFilters;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_metadataExtensions;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_standaloneExtensions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_excludeFilter;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label_Imdisk_false;
		private System.Windows.Forms.Label label_Imdisk_true;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.TextBox txt_cachedir;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btn_cachedir;
		private System.Windows.Forms.NumericUpDown num_cacheMaxSize;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}