namespace BigBoxProfile.EmulatorActions
{
	partial class ChangeRomPath_Config
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeRomPath_Config));
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.list_hightpriority = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.list_lowpriority = new System.Windows.Forms.ListView();
			this.val = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_hightpriority = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_lowpriority = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_add_hightpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add_lowpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_hightpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_hightpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_delete_hightpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_lowpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_lowpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_delete_lowpriority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.groupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.groupBox2 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).BeginInit();
			this.groupBox1.Panel.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox2.Panel)).BeginInit();
			this.groupBox2.Panel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(109, 20);
			this.label3.TabIndex = 18;
			this.label3.Values.Text = "Path to remplace :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(143, 11);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(712, 23);
			this.txt_filter.TabIndex = 17;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(709, 501);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 16;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(790, 501);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 15;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// list_hightpriority
			// 
			this.list_hightpriority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_hightpriority.HideSelection = false;
			this.list_hightpriority.Location = new System.Drawing.Point(9, 109);
			this.list_hightpriority.Name = "list_hightpriority";
			this.list_hightpriority.Size = new System.Drawing.Size(349, 295);
			this.list_hightpriority.TabIndex = 19;
			this.list_hightpriority.UseCompatibleStateImageBehavior = false;
			this.list_hightpriority.View = System.Windows.Forms.View.List;
			this.list_hightpriority.SelectedIndexChanged += new System.EventHandler(this.list_hightpriority_SelectedIndexChanged);
			// 
			// list_lowpriority
			// 
			this.list_lowpriority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.val});
			this.list_lowpriority.HideSelection = false;
			this.list_lowpriority.Location = new System.Drawing.Point(9, 109);
			this.list_lowpriority.Name = "list_lowpriority";
			this.list_lowpriority.Size = new System.Drawing.Size(347, 295);
			this.list_lowpriority.TabIndex = 20;
			this.list_lowpriority.UseCompatibleStateImageBehavior = false;
			this.list_lowpriority.View = System.Windows.Forms.View.List;
			this.list_lowpriority.SelectedIndexChanged += new System.EventHandler(this.list_lowpriority_SelectedIndexChanged);
			// 
			// txt_hightpriority
			// 
			this.txt_hightpriority.Location = new System.Drawing.Point(9, 83);
			this.txt_hightpriority.Name = "txt_hightpriority";
			this.txt_hightpriority.Size = new System.Drawing.Size(349, 23);
			this.txt_hightpriority.TabIndex = 21;
			// 
			// txt_lowpriority
			// 
			this.txt_lowpriority.Location = new System.Drawing.Point(9, 83);
			this.txt_lowpriority.Name = "txt_lowpriority";
			this.txt_lowpriority.Size = new System.Drawing.Size(347, 23);
			this.txt_lowpriority.TabIndex = 22;
			// 
			// btn_add_hightpriority
			// 
			this.btn_add_hightpriority.Location = new System.Drawing.Point(364, 83);
			this.btn_add_hightpriority.Name = "btn_add_hightpriority";
			this.btn_add_hightpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_add_hightpriority.TabIndex = 23;
			this.btn_add_hightpriority.Values.Text = "Add";
			this.btn_add_hightpriority.Click += new System.EventHandler(this.btn_add_hightpriority_Click);
			// 
			// btn_add_lowpriority
			// 
			this.btn_add_lowpriority.Location = new System.Drawing.Point(362, 82);
			this.btn_add_lowpriority.Name = "btn_add_lowpriority";
			this.btn_add_lowpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_add_lowpriority.TabIndex = 24;
			this.btn_add_lowpriority.Values.Text = "Add";
			this.btn_add_lowpriority.Click += new System.EventHandler(this.btn_add_lowpriority_Click);
			// 
			// btn_up_hightpriority
			// 
			this.btn_up_hightpriority.Enabled = false;
			this.btn_up_hightpriority.Location = new System.Drawing.Point(364, 151);
			this.btn_up_hightpriority.Name = "btn_up_hightpriority";
			this.btn_up_hightpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_up_hightpriority.TabIndex = 25;
			this.btn_up_hightpriority.Values.Text = "Up";
			this.btn_up_hightpriority.Click += new System.EventHandler(this.btn_up_hightpriority_Click);
			// 
			// btn_down_hightpriority
			// 
			this.btn_down_hightpriority.Enabled = false;
			this.btn_down_hightpriority.Location = new System.Drawing.Point(364, 181);
			this.btn_down_hightpriority.Name = "btn_down_hightpriority";
			this.btn_down_hightpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_down_hightpriority.TabIndex = 26;
			this.btn_down_hightpriority.Values.Text = "Down";
			this.btn_down_hightpriority.Click += new System.EventHandler(this.btn_down_hightpriority_Click);
			// 
			// btn_delete_hightpriority
			// 
			this.btn_delete_hightpriority.Enabled = false;
			this.btn_delete_hightpriority.Location = new System.Drawing.Point(364, 211);
			this.btn_delete_hightpriority.Name = "btn_delete_hightpriority";
			this.btn_delete_hightpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_delete_hightpriority.TabIndex = 27;
			this.btn_delete_hightpriority.Values.Text = "Delete";
			this.btn_delete_hightpriority.Click += new System.EventHandler(this.btn_delete_hightpriority_Click);
			// 
			// btn_up_lowpriority
			// 
			this.btn_up_lowpriority.Enabled = false;
			this.btn_up_lowpriority.Location = new System.Drawing.Point(362, 151);
			this.btn_up_lowpriority.Name = "btn_up_lowpriority";
			this.btn_up_lowpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_up_lowpriority.TabIndex = 28;
			this.btn_up_lowpriority.Values.Text = "Up";
			this.btn_up_lowpriority.Click += new System.EventHandler(this.btn_up_lowpriority_Click);
			// 
			// btn_down_lowpriority
			// 
			this.btn_down_lowpriority.Enabled = false;
			this.btn_down_lowpriority.Location = new System.Drawing.Point(362, 180);
			this.btn_down_lowpriority.Name = "btn_down_lowpriority";
			this.btn_down_lowpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_down_lowpriority.TabIndex = 29;
			this.btn_down_lowpriority.Values.Text = "Down";
			this.btn_down_lowpriority.Click += new System.EventHandler(this.btn_down_lowpriority_Click);
			// 
			// btn_delete_lowpriority
			// 
			this.btn_delete_lowpriority.Enabled = false;
			this.btn_delete_lowpriority.Location = new System.Drawing.Point(362, 209);
			this.btn_delete_lowpriority.Name = "btn_delete_lowpriority";
			this.btn_delete_lowpriority.Size = new System.Drawing.Size(46, 24);
			this.btn_delete_lowpriority.TabIndex = 30;
			this.btn_delete_lowpriority.Values.Text = "Delete";
			this.btn_delete_lowpriority.Click += new System.EventHandler(this.btn_delete_lowpriority_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(12, 46);
			this.groupBox1.Name = "groupBox1";
			// 
			// groupBox1.Panel
			// 
			this.groupBox1.Panel.Controls.Add(this.label4);
			this.groupBox1.Panel.Controls.Add(this.label2);
			this.groupBox1.Panel.Controls.Add(this.label1);
			this.groupBox1.Panel.Controls.Add(this.list_hightpriority);
			this.groupBox1.Panel.Controls.Add(this.txt_hightpriority);
			this.groupBox1.Panel.Controls.Add(this.btn_delete_hightpriority);
			this.groupBox1.Panel.Controls.Add(this.btn_add_hightpriority);
			this.groupBox1.Panel.Controls.Add(this.btn_down_hightpriority);
			this.groupBox1.Panel.Controls.Add(this.btn_up_hightpriority);
			this.groupBox1.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox1_Panel_Paint);
			this.groupBox1.Size = new System.Drawing.Size(417, 440);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.Values.Heading = "Hight Priority Path";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(294, 20);
			this.label4.TabIndex = 2;
			this.label4.Values.Text = " you copy few games on C:\\Roms on your fast nvme";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(299, 20);
			this.label2.TabIndex = 1;
			this.label2.Values.Text = "For exemple, you have your RomSet on D:\\Roms, but";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(9, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(386, 20);
			this.label1.TabIndex = 0;
			this.label1.Values.Text = "Hight Priority path will replace the path, even if the normal path exist";
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(445, 46);
			this.groupBox2.Name = "groupBox2";
			// 
			// groupBox2.Panel
			// 
			this.groupBox2.Panel.Controls.Add(this.kryptonLabel1);
			this.groupBox2.Panel.Controls.Add(this.label6);
			this.groupBox2.Panel.Controls.Add(this.label7);
			this.groupBox2.Panel.Controls.Add(this.btn_delete_lowpriority);
			this.groupBox2.Panel.Controls.Add(this.list_lowpriority);
			this.groupBox2.Panel.Controls.Add(this.btn_down_lowpriority);
			this.groupBox2.Panel.Controls.Add(this.txt_lowpriority);
			this.groupBox2.Panel.Controls.Add(this.btn_up_lowpriority);
			this.groupBox2.Panel.Controls.Add(this.btn_add_lowpriority);
			this.groupBox2.Size = new System.Drawing.Size(420, 440);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.Values.Heading = "Low Priority Path";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(346, 20);
			this.label6.TabIndex = 4;
			this.label6.Values.Text = "Like you play on an other computer and look for the rompath";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(407, 20);
			this.label7.TabIndex = 3;
			this.label7.Values.Text = "Low Priority path will replace the path, only if the normal path don\'t exist";
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(8, 60);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(100, 20);
			this.kryptonLabel1.TabIndex = 31;
			this.kryptonLabel1.Values.Text = "on your network";
			// 
			// ChangeRomPath_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(877, 539);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeRomPath_Config";
			this.Text = "Configuration Module : Change Rom Path";
			this.Load += new System.EventHandler(this.ChangeRomPath_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.groupBox1.Panel)).EndInit();
			this.groupBox1.Panel.ResumeLayout(false);
			this.groupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupBox2.Panel)).EndInit();
			this.groupBox2.Panel.ResumeLayout(false);
			this.groupBox2.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox2)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private System.Windows.Forms.ListView list_hightpriority;
		private System.Windows.Forms.ListView list_lowpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_hightpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_lowpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add_hightpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add_lowpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_hightpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_hightpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_hightpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_lowpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_lowpriority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_lowpriority;
		private System.Windows.Forms.ColumnHeader valh;
		private System.Windows.Forms.ColumnHeader val;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}