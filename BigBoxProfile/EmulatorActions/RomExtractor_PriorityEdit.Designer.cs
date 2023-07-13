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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RomExtractor_PriorityEdit));
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_priority = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_delete_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label8 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.list_path = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_path = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_delete_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.num_maxSize = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.chk_deleteOnExit = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.txt_priority_res = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.chk_SmartExtract = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_up_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.infoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.groupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.list_priority = new System.Windows.Forms.ListView();
			this.groupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.txt_path_res = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.chk_Ramdisk = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_cacheSubDir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox2.Panel)).BeginInit();
			this.groupBox2.Panel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).BeginInit();
			this.groupBox1.Panel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 370;
			// 
			// txt_priority
			// 
			this.txt_priority.Location = new System.Drawing.Point(9, 260);
			this.txt_priority.Name = "txt_priority";
			this.txt_priority.Size = new System.Drawing.Size(418, 23);
			this.txt_priority.TabIndex = 21;
			// 
			// btn_delete_priority
			// 
			this.btn_delete_priority.Enabled = false;
			this.btn_delete_priority.Location = new System.Drawing.Point(433, 424);
			this.btn_delete_priority.Name = "btn_delete_priority";
			this.btn_delete_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_delete_priority.TabIndex = 27;
			this.btn_delete_priority.Values.Text = "Delete";
			this.btn_delete_priority.Click += new System.EventHandler(this.btn_delete_priority_Click);
			// 
			// btn_add_priority
			// 
			this.btn_add_priority.Location = new System.Drawing.Point(433, 258);
			this.btn_add_priority.Name = "btn_add_priority";
			this.btn_add_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_add_priority.TabIndex = 23;
			this.btn_add_priority.Values.Text = "Add";
			this.btn_add_priority.Click += new System.EventHandler(this.btn_add_priority_Click);
			// 
			// btn_down_priority
			// 
			this.btn_down_priority.Enabled = false;
			this.btn_down_priority.Location = new System.Drawing.Point(433, 394);
			this.btn_down_priority.Name = "btn_down_priority";
			this.btn_down_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_down_priority.TabIndex = 26;
			this.btn_down_priority.Values.Text = "Down";
			this.btn_down_priority.Click += new System.EventHandler(this.btn_down_priority_Click);
			// 
			// btn_up_priority
			// 
			this.btn_up_priority.Enabled = false;
			this.btn_up_priority.Location = new System.Drawing.Point(433, 364);
			this.btn_up_priority.Name = "btn_up_priority";
			this.btn_up_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_up_priority.TabIndex = 25;
			this.btn_up_priority.Values.Text = "Up";
			this.btn_up_priority.Click += new System.EventHandler(this.btn_up_priority_Click);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 42);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(437, 20);
			this.label8.TabIndex = 32;
			this.label8.Values.Text = "It\'s used to see if the rom should use this priority config or use the default on" +
    "e";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 27);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(341, 20);
			this.label7.TabIndex = 31;
			this.label7.Values.Text = "This does not remplace the global include and exclude filters";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 125);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(208, 20);
			this.label6.TabIndex = 30;
			this.label6.Values.Text = "Or you can add and edit them here :";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(11, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(152, 20);
			this.label5.TabIndex = 29;
			this.label5.Values.Text = "Filter list (separate with ,) :";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 11);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(372, 20);
			this.label4.TabIndex = 28;
			this.label4.Values.Text = "To use this priority, the rom path have to contain one of this filters";
			// 
			// list_path
			// 
			this.list_path.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_path.HideSelection = false;
			this.list_path.Location = new System.Drawing.Point(11, 176);
			this.list_path.MultiSelect = false;
			this.list_path.Name = "list_path";
			this.list_path.Size = new System.Drawing.Size(418, 316);
			this.list_path.TabIndex = 19;
			this.list_path.UseCompatibleStateImageBehavior = false;
			this.list_path.View = System.Windows.Forms.View.Details;
			this.list_path.SelectedIndexChanged += new System.EventHandler(this.list_path_SelectedIndexChanged);
			this.list_path.DoubleClick += new System.EventHandler(this.list_path_DoubleClick);
			// 
			// valh
			// 
			this.valh.Width = 370;
			// 
			// txt_path
			// 
			this.txt_path.Location = new System.Drawing.Point(11, 144);
			this.txt_path.Name = "txt_path";
			this.txt_path.Size = new System.Drawing.Size(418, 23);
			this.txt_path.TabIndex = 21;
			// 
			// btn_delete_path
			// 
			this.btn_delete_path.Enabled = false;
			this.btn_delete_path.Location = new System.Drawing.Point(435, 309);
			this.btn_delete_path.Name = "btn_delete_path";
			this.btn_delete_path.Size = new System.Drawing.Size(46, 24);
			this.btn_delete_path.TabIndex = 27;
			this.btn_delete_path.Values.Text = "Delete";
			this.btn_delete_path.Click += new System.EventHandler(this.btn_delete_path_Click);
			// 
			// btn_add_path
			// 
			this.btn_add_path.Location = new System.Drawing.Point(435, 143);
			this.btn_add_path.Name = "btn_add_path";
			this.btn_add_path.Size = new System.Drawing.Size(46, 24);
			this.btn_add_path.TabIndex = 23;
			this.btn_add_path.Values.Text = "Add";
			this.btn_add_path.Click += new System.EventHandler(this.btn_add_path_Click);
			// 
			// btn_down_path
			// 
			this.btn_down_path.Enabled = false;
			this.btn_down_path.Location = new System.Drawing.Point(435, 279);
			this.btn_down_path.Name = "btn_down_path";
			this.btn_down_path.Size = new System.Drawing.Size(46, 24);
			this.btn_down_path.TabIndex = 26;
			this.btn_down_path.Values.Text = "Down";
			this.btn_down_path.Click += new System.EventHandler(this.btn_down_path_Click);
			// 
			// num_maxSize
			// 
			this.num_maxSize.Location = new System.Drawing.Point(436, 41);
			this.num_maxSize.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
			this.num_maxSize.Name = "num_maxSize";
			this.num_maxSize.Size = new System.Drawing.Size(74, 22);
			this.num_maxSize.TabIndex = 53;
			// 
			// chk_deleteOnExit
			// 
			this.chk_deleteOnExit.Location = new System.Drawing.Point(143, 69);
			this.chk_deleteOnExit.Name = "chk_deleteOnExit";
			this.chk_deleteOnExit.Size = new System.Drawing.Size(177, 20);
			this.chk_deleteOnExit.TabIndex = 52;
			this.chk_deleteOnExit.Values.Text = "Delete Extracted File On Exit";
			// 
			// txt_priority_res
			// 
			this.txt_priority_res.Location = new System.Drawing.Point(9, 211);
			this.txt_priority_res.Name = "txt_priority_res";
			this.txt_priority_res.Size = new System.Drawing.Size(470, 23);
			this.txt_priority_res.TabIndex = 7;
			this.txt_priority_res.TextChanged += new System.EventHandler(this.txt_priority_res_TextChanged);
			this.txt_priority_res.Leave += new System.EventHandler(this.txt_priority_res_Leave);
			// 
			// chk_SmartExtract
			// 
			this.chk_SmartExtract.Location = new System.Drawing.Point(143, 95);
			this.chk_SmartExtract.Name = "chk_SmartExtract";
			this.chk_SmartExtract.Size = new System.Drawing.Size(116, 20);
			this.chk_SmartExtract.TabIndex = 55;
			this.chk_SmartExtract.Values.Text = "Use SmartExtract";
			// 
			// btn_up_path
			// 
			this.btn_up_path.Enabled = false;
			this.btn_up_path.Location = new System.Drawing.Point(435, 249);
			this.btn_up_path.Name = "btn_up_path";
			this.btn_up_path.Size = new System.Drawing.Size(46, 24);
			this.btn_up_path.TabIndex = 25;
			this.btn_up_path.Values.Text = "Up";
			this.btn_up_path.Click += new System.EventHandler(this.btn_up_path_Click);
			// 
			// infoLabel
			// 
			this.infoLabel.Location = new System.Drawing.Point(12, 16);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(467, 164);
			this.infoLabel.TabIndex = 34;
			this.infoLabel.Values.Text = resources.GetString("infoLabel.Values.Text");
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(9, 240);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(208, 20);
			this.label11.TabIndex = 30;
			this.label11.Values.Text = "Or you can add and edit them here :";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(9, 190);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(152, 20);
			this.label12.TabIndex = 29;
			this.label12.Values.Text = "Filter list (separate with ,) :";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(247, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(183, 20);
			this.label1.TabIndex = 54;
			this.label1.Values.Text = "Maximum FileSize for Ramdisk :";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(529, 6);
			this.groupBox2.Name = "groupBox2";
			// 
			// groupBox2.Panel
			// 
			this.groupBox2.Panel.Controls.Add(this.infoLabel);
			this.groupBox2.Panel.Controls.Add(this.label11);
			this.groupBox2.Panel.Controls.Add(this.label12);
			this.groupBox2.Panel.Controls.Add(this.list_priority);
			this.groupBox2.Panel.Controls.Add(this.txt_priority);
			this.groupBox2.Panel.Controls.Add(this.btn_delete_priority);
			this.groupBox2.Panel.Controls.Add(this.btn_add_priority);
			this.groupBox2.Panel.Controls.Add(this.btn_down_priority);
			this.groupBox2.Panel.Controls.Add(this.btn_up_priority);
			this.groupBox2.Panel.Controls.Add(this.txt_priority_res);
			this.groupBox2.Size = new System.Drawing.Size(498, 651);
			this.groupBox2.TabIndex = 48;
			this.groupBox2.Values.Heading = "Priority List";
			// 
			// list_priority
			// 
			this.list_priority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.list_priority.HideSelection = false;
			this.list_priority.Location = new System.Drawing.Point(9, 291);
			this.list_priority.MultiSelect = false;
			this.list_priority.Name = "list_priority";
			this.list_priority.Size = new System.Drawing.Size(418, 316);
			this.list_priority.TabIndex = 19;
			this.list_priority.UseCompatibleStateImageBehavior = false;
			this.list_priority.View = System.Windows.Forms.View.Details;
			this.list_priority.SelectedIndexChanged += new System.EventHandler(this.list_priority_SelectedIndexChanged);
			this.list_priority.DoubleClick += new System.EventHandler(this.list_priority_DoubleClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(10, 121);
			this.groupBox1.Name = "groupBox1";
			// 
			// groupBox1.Panel
			// 
			this.groupBox1.Panel.Controls.Add(this.label8);
			this.groupBox1.Panel.Controls.Add(this.label7);
			this.groupBox1.Panel.Controls.Add(this.label6);
			this.groupBox1.Panel.Controls.Add(this.label5);
			this.groupBox1.Panel.Controls.Add(this.label4);
			this.groupBox1.Panel.Controls.Add(this.list_path);
			this.groupBox1.Panel.Controls.Add(this.txt_path);
			this.groupBox1.Panel.Controls.Add(this.btn_delete_path);
			this.groupBox1.Panel.Controls.Add(this.btn_add_path);
			this.groupBox1.Panel.Controls.Add(this.btn_down_path);
			this.groupBox1.Panel.Controls.Add(this.btn_up_path);
			this.groupBox1.Panel.Controls.Add(this.txt_path_res);
			this.groupBox1.Size = new System.Drawing.Size(500, 536);
			this.groupBox1.TabIndex = 47;
			this.groupBox1.Values.Heading = "Filter List";
			// 
			// txt_path_res
			// 
			this.txt_path_res.Location = new System.Drawing.Point(11, 96);
			this.txt_path_res.Name = "txt_path_res";
			this.txt_path_res.Size = new System.Drawing.Size(470, 23);
			this.txt_path_res.TabIndex = 7;
			this.txt_path_res.TextChanged += new System.EventHandler(this.txt_path_res_TextChanged);
			this.txt_path_res.Leave += new System.EventHandler(this.txt_path_res_Leave);
			// 
			// chk_Ramdisk
			// 
			this.chk_Ramdisk.Location = new System.Drawing.Point(143, 43);
			this.chk_Ramdisk.Name = "chk_Ramdisk";
			this.chk_Ramdisk.Size = new System.Drawing.Size(94, 20);
			this.chk_Ramdisk.TabIndex = 46;
			this.chk_Ramdisk.Values.Text = "Use RamDisk";
			this.chk_Ramdisk.CheckedChanged += new System.EventHandler(this.chk_Ramdisk_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(10, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(127, 20);
			this.label3.TabIndex = 45;
			this.label3.Values.Text = "Cache Sub Directory :";
			// 
			// txt_cacheSubDir
			// 
			this.txt_cacheSubDir.Location = new System.Drawing.Point(143, 12);
			this.txt_cacheSubDir.Name = "txt_cacheSubDir";
			this.txt_cacheSubDir.Size = new System.Drawing.Size(367, 23);
			this.txt_cacheSubDir.TabIndex = 44;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(952, 663);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 42;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(871, 663);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 43;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// RomExtractor_PriorityEdit
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1038, 697);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "RomExtractor_PriorityEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : RomExtractor Priority Edition";
			this.Load += new System.EventHandler(this.RomExtractor_PriorityEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupBox2.Panel)).EndInit();
			this.groupBox2.Panel.ResumeLayout(false);
			this.groupBox2.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).EndInit();
			this.groupBox1.Panel.ResumeLayout(false);
			this.groupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ColumnHeader columnHeader1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label8;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private System.Windows.Forms.ListView list_path;
		private System.Windows.Forms.ColumnHeader valh;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_path;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_maxSize;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_deleteOnExit;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_priority_res;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_SmartExtract;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_path;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel infoLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label11;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label12;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox2;
		private System.Windows.Forms.ListView list_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_path_res;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_Ramdisk;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_cacheSubDir;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}