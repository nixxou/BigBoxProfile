namespace BigBoxProfile.EmulatorActions
{
	partial class RomExtractor_PriorityEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RomExtractor_PriorityEdit));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_priority = new System.Windows.Forms.TextBox();
			this.btn_delete_priority = new System.Windows.Forms.Button();
			this.btn_add_priority = new System.Windows.Forms.Button();
			this.btn_down_priority = new System.Windows.Forms.Button();
			this.btn_up_priority = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.list_path = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.button1 = new System.Windows.Forms.Button();
			this.txt_path = new System.Windows.Forms.TextBox();
			this.btn_delete_path = new System.Windows.Forms.Button();
			this.btn_add_path = new System.Windows.Forms.Button();
			this.btn_down_path = new System.Windows.Forms.Button();
			this.num_maxSize = new System.Windows.Forms.NumericUpDown();
			this.chk_deleteOnExit = new System.Windows.Forms.CheckBox();
			this.txt_priority_res = new System.Windows.Forms.TextBox();
			this.chk_SmartExtract = new System.Windows.Forms.CheckBox();
			this.btn_up_path = new System.Windows.Forms.Button();
			this.infoLabel = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.list_priority = new System.Windows.Forms.ListView();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txt_path_res = new System.Windows.Forms.TextBox();
			this.chk_Ramdisk = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_cacheSubDir = new System.Windows.Forms.TextBox();
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.num_maxSize)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txt_priority
			// 
			this.txt_priority.Location = new System.Drawing.Point(9, 260);
			this.txt_priority.Name = "txt_priority";
			this.txt_priority.Size = new System.Drawing.Size(397, 20);
			this.txt_priority.TabIndex = 21;
			// 
			// btn_delete_priority
			// 
			this.btn_delete_priority.Enabled = false;
			this.btn_delete_priority.Location = new System.Drawing.Point(412, 433);
			this.btn_delete_priority.Name = "btn_delete_priority";
			this.btn_delete_priority.Size = new System.Drawing.Size(46, 23);
			this.btn_delete_priority.TabIndex = 27;
			this.btn_delete_priority.Text = "Delete";
			this.btn_delete_priority.UseVisualStyleBackColor = true;
			this.btn_delete_priority.Click += new System.EventHandler(this.btn_delete_priority_Click);
			// 
			// btn_add_priority
			// 
			this.btn_add_priority.Location = new System.Drawing.Point(412, 258);
			this.btn_add_priority.Name = "btn_add_priority";
			this.btn_add_priority.Size = new System.Drawing.Size(46, 23);
			this.btn_add_priority.TabIndex = 23;
			this.btn_add_priority.Text = "Add";
			this.btn_add_priority.UseVisualStyleBackColor = true;
			this.btn_add_priority.Click += new System.EventHandler(this.btn_add_priority_Click);
			// 
			// btn_down_priority
			// 
			this.btn_down_priority.Enabled = false;
			this.btn_down_priority.Location = new System.Drawing.Point(412, 404);
			this.btn_down_priority.Name = "btn_down_priority";
			this.btn_down_priority.Size = new System.Drawing.Size(46, 23);
			this.btn_down_priority.TabIndex = 26;
			this.btn_down_priority.Text = "Down";
			this.btn_down_priority.UseVisualStyleBackColor = true;
			this.btn_down_priority.Click += new System.EventHandler(this.btn_down_priority_Click);
			// 
			// btn_up_priority
			// 
			this.btn_up_priority.Enabled = false;
			this.btn_up_priority.Location = new System.Drawing.Point(412, 375);
			this.btn_up_priority.Name = "btn_up_priority";
			this.btn_up_priority.Size = new System.Drawing.Size(46, 23);
			this.btn_up_priority.TabIndex = 25;
			this.btn_up_priority.Text = "Up";
			this.btn_up_priority.UseVisualStyleBackColor = true;
			this.btn_up_priority.Click += new System.EventHandler(this.btn_up_priority_Click);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(6, 47);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(368, 13);
			this.label8.TabIndex = 32;
			this.label8.Text = "It\'s used to see if the rom should use this priority config or use the default on" +
    "e";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(291, 13);
			this.label7.TabIndex = 31;
			this.label7.Text = "This does not remplace the global include and exclude filters";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(11, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(177, 13);
			this.label6.TabIndex = 30;
			this.label6.Text = "Or you can add and edit them here :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(128, 13);
			this.label5.TabIndex = 29;
			this.label5.Text = "Filter list (separate with ,) :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(313, 13);
			this.label4.TabIndex = 28;
			this.label4.Text = "To use this priority, the rom path have to contain one of this filters";
			// 
			// list_path
			// 
			this.list_path.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_path.HideSelection = false;
			this.list_path.Location = new System.Drawing.Point(9, 166);
			this.list_path.MultiSelect = false;
			this.list_path.Name = "list_path";
			this.list_path.Size = new System.Drawing.Size(397, 295);
			this.list_path.TabIndex = 19;
			this.list_path.UseCompatibleStateImageBehavior = false;
			this.list_path.View = System.Windows.Forms.View.List;
			this.list_path.SelectedIndexChanged += new System.EventHandler(this.list_path_SelectedIndexChanged);
			this.list_path.DoubleClick += new System.EventHandler(this.list_path_DoubleClick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(674, 663);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 50;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// txt_path
			// 
			this.txt_path.Location = new System.Drawing.Point(9, 138);
			this.txt_path.Name = "txt_path";
			this.txt_path.Size = new System.Drawing.Size(397, 20);
			this.txt_path.TabIndex = 21;
			// 
			// btn_delete_path
			// 
			this.btn_delete_path.Enabled = false;
			this.btn_delete_path.Location = new System.Drawing.Point(412, 308);
			this.btn_delete_path.Name = "btn_delete_path";
			this.btn_delete_path.Size = new System.Drawing.Size(46, 23);
			this.btn_delete_path.TabIndex = 27;
			this.btn_delete_path.Text = "Delete";
			this.btn_delete_path.UseVisualStyleBackColor = true;
			this.btn_delete_path.Click += new System.EventHandler(this.btn_delete_path_Click);
			// 
			// btn_add_path
			// 
			this.btn_add_path.Location = new System.Drawing.Point(412, 138);
			this.btn_add_path.Name = "btn_add_path";
			this.btn_add_path.Size = new System.Drawing.Size(46, 23);
			this.btn_add_path.TabIndex = 23;
			this.btn_add_path.Text = "Add";
			this.btn_add_path.UseVisualStyleBackColor = true;
			this.btn_add_path.Click += new System.EventHandler(this.btn_add_path_Click);
			// 
			// btn_down_path
			// 
			this.btn_down_path.Enabled = false;
			this.btn_down_path.Location = new System.Drawing.Point(412, 279);
			this.btn_down_path.Name = "btn_down_path";
			this.btn_down_path.Size = new System.Drawing.Size(46, 23);
			this.btn_down_path.TabIndex = 26;
			this.btn_down_path.Text = "Down";
			this.btn_down_path.UseVisualStyleBackColor = true;
			this.btn_down_path.Click += new System.EventHandler(this.btn_down_path_Click);
			// 
			// num_maxSize
			// 
			this.num_maxSize.Location = new System.Drawing.Point(363, 37);
			this.num_maxSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.num_maxSize.Name = "num_maxSize";
			this.num_maxSize.Size = new System.Drawing.Size(74, 20);
			this.num_maxSize.TabIndex = 53;
			// 
			// chk_deleteOnExit
			// 
			this.chk_deleteOnExit.AutoSize = true;
			this.chk_deleteOnExit.Location = new System.Drawing.Point(105, 61);
			this.chk_deleteOnExit.Name = "chk_deleteOnExit";
			this.chk_deleteOnExit.Size = new System.Drawing.Size(161, 17);
			this.chk_deleteOnExit.TabIndex = 52;
			this.chk_deleteOnExit.Text = "Delete Extracted File On Exit";
			this.chk_deleteOnExit.UseVisualStyleBackColor = true;
			// 
			// txt_priority_res
			// 
			this.txt_priority_res.Location = new System.Drawing.Point(9, 211);
			this.txt_priority_res.Name = "txt_priority_res";
			this.txt_priority_res.Size = new System.Drawing.Size(449, 20);
			this.txt_priority_res.TabIndex = 7;
			this.txt_priority_res.TextChanged += new System.EventHandler(this.txt_priority_res_TextChanged);
			this.txt_priority_res.Leave += new System.EventHandler(this.txt_priority_res_Leave);
			// 
			// chk_SmartExtract
			// 
			this.chk_SmartExtract.AutoSize = true;
			this.chk_SmartExtract.Location = new System.Drawing.Point(105, 84);
			this.chk_SmartExtract.Name = "chk_SmartExtract";
			this.chk_SmartExtract.Size = new System.Drawing.Size(108, 17);
			this.chk_SmartExtract.TabIndex = 55;
			this.chk_SmartExtract.Text = "Use SmartExtract";
			this.chk_SmartExtract.UseVisualStyleBackColor = true;
			// 
			// btn_up_path
			// 
			this.btn_up_path.Enabled = false;
			this.btn_up_path.Location = new System.Drawing.Point(412, 250);
			this.btn_up_path.Name = "btn_up_path";
			this.btn_up_path.Size = new System.Drawing.Size(46, 23);
			this.btn_up_path.TabIndex = 25;
			this.btn_up_path.Text = "Up";
			this.btn_up_path.UseVisualStyleBackColor = true;
			this.btn_up_path.Click += new System.EventHandler(this.btn_up_path_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(12, 16);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(446, 150);
			this.infoLabel.TabIndex = 34;
			this.infoLabel.Text = resources.GetString("infoLabel.Text");
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(6, 237);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(177, 13);
			this.label11.TabIndex = 30;
			this.label11.Text = "Or you can add and edit them here :";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(6, 195);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(128, 13);
			this.label12.TabIndex = 29;
			this.label12.Text = "Filter list (separate with ,) :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(202, 39);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(155, 13);
			this.label1.TabIndex = 54;
			this.label1.Text = "Maximum FileSize for Ramdisk :";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.infoLabel);
			this.groupBox2.Controls.Add(this.label11);
			this.groupBox2.Controls.Add(this.label12);
			this.groupBox2.Controls.Add(this.list_priority);
			this.groupBox2.Controls.Add(this.txt_priority);
			this.groupBox2.Controls.Add(this.btn_delete_priority);
			this.groupBox2.Controls.Add(this.btn_add_priority);
			this.groupBox2.Controls.Add(this.btn_down_priority);
			this.groupBox2.Controls.Add(this.btn_up_priority);
			this.groupBox2.Controls.Add(this.txt_priority_res);
			this.groupBox2.Location = new System.Drawing.Point(500, 61);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(464, 596);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Priority List";
			// 
			// list_priority
			// 
			this.list_priority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.list_priority.HideSelection = false;
			this.list_priority.Location = new System.Drawing.Point(6, 291);
			this.list_priority.MultiSelect = false;
			this.list_priority.Name = "list_priority";
			this.list_priority.Size = new System.Drawing.Size(400, 295);
			this.list_priority.TabIndex = 19;
			this.list_priority.UseCompatibleStateImageBehavior = false;
			this.list_priority.View = System.Windows.Forms.View.List;
			this.list_priority.SelectedIndexChanged += new System.EventHandler(this.list_priority_SelectedIndexChanged);
			this.list_priority.DoubleClick += new System.EventHandler(this.list_priority_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.list_path);
			this.groupBox1.Controls.Add(this.txt_path);
			this.groupBox1.Controls.Add(this.btn_delete_path);
			this.groupBox1.Controls.Add(this.btn_add_path);
			this.groupBox1.Controls.Add(this.btn_down_path);
			this.groupBox1.Controls.Add(this.btn_up_path);
			this.groupBox1.Controls.Add(this.txt_path_res);
			this.groupBox1.Location = new System.Drawing.Point(9, 186);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(464, 471);
			this.groupBox1.TabIndex = 47;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Filter List";
			// 
			// txt_path_res
			// 
			this.txt_path_res.Location = new System.Drawing.Point(14, 86);
			this.txt_path_res.Name = "txt_path_res";
			this.txt_path_res.Size = new System.Drawing.Size(444, 20);
			this.txt_path_res.TabIndex = 7;
			this.txt_path_res.TextChanged += new System.EventHandler(this.txt_path_res_TextChanged);
			this.txt_path_res.Leave += new System.EventHandler(this.txt_path_res_Leave);
			// 
			// chk_Ramdisk
			// 
			this.chk_Ramdisk.AutoSize = true;
			this.chk_Ramdisk.Location = new System.Drawing.Point(105, 38);
			this.chk_Ramdisk.Name = "chk_Ramdisk";
			this.chk_Ramdisk.Size = new System.Drawing.Size(91, 17);
			this.chk_Ramdisk.TabIndex = 46;
			this.chk_Ramdisk.Text = "Use RamDisk";
			this.chk_Ramdisk.UseVisualStyleBackColor = true;
			this.chk_Ramdisk.CheckedChanged += new System.EventHandler(this.chk_Ramdisk_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 13);
			this.label3.TabIndex = 45;
			this.label3.Text = "Cache Sub Directory :";
			// 
			// txt_cacheSubDir
			// 
			this.txt_cacheSubDir.Location = new System.Drawing.Point(127, 12);
			this.txt_cacheSubDir.Name = "txt_cacheSubDir";
			this.txt_cacheSubDir.Size = new System.Drawing.Size(310, 20);
			this.txt_cacheSubDir.TabIndex = 44;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(889, 663);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 42;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(808, 663);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 43;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// RomExtractor_PriorityEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(983, 694);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.num_maxSize);
			this.Controls.Add(this.chk_deleteOnExit);
			this.Controls.Add(this.chk_SmartExtract);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chk_Ramdisk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_cacheSubDir);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.btn_cancel);
			this.Name = "RomExtractor_PriorityEdit";
			this.Text = "RomExtractor_PriorityEdit";
			this.Load += new System.EventHandler(this.RomExtractor_PriorityEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.num_maxSize)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox txt_priority;
		private System.Windows.Forms.Button btn_delete_priority;
		private System.Windows.Forms.Button btn_add_priority;
		private System.Windows.Forms.Button btn_down_priority;
		private System.Windows.Forms.Button btn_up_priority;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ListView list_path;
		private System.Windows.Forms.ColumnHeader valh;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txt_path;
		private System.Windows.Forms.Button btn_delete_path;
		private System.Windows.Forms.Button btn_add_path;
		private System.Windows.Forms.Button btn_down_path;
		private System.Windows.Forms.NumericUpDown num_maxSize;
		private System.Windows.Forms.CheckBox chk_deleteOnExit;
		private System.Windows.Forms.TextBox txt_priority_res;
		private System.Windows.Forms.CheckBox chk_SmartExtract;
		private System.Windows.Forms.Button btn_up_path;
		private System.Windows.Forms.Label infoLabel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView list_priority;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txt_path_res;
		private System.Windows.Forms.CheckBox chk_Ramdisk;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_cacheSubDir;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
	}
}