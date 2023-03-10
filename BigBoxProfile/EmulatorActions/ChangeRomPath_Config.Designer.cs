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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeRomPath_Config));
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.list_hightpriority = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.list_lowpriority = new System.Windows.Forms.ListView();
			this.val = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_hightpriority = new System.Windows.Forms.TextBox();
			this.txt_lowpriority = new System.Windows.Forms.TextBox();
			this.btn_add_hightpriority = new System.Windows.Forms.Button();
			this.btn_add_lowpriority = new System.Windows.Forms.Button();
			this.btn_up_hightpriority = new System.Windows.Forms.Button();
			this.btn_down_hightpriority = new System.Windows.Forms.Button();
			this.btn_delete_hightpriority = new System.Windows.Forms.Button();
			this.btn_up_lowpriority = new System.Windows.Forms.Button();
			this.btn_down_lowpriority = new System.Windows.Forms.Button();
			this.btn_delete_lowpriority = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Path to remplace :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(143, 11);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(619, 20);
			this.txt_filter.TabIndex = 17;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(601, 462);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 16;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(698, 462);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 15;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// list_hightpriority
			// 
			this.list_hightpriority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_hightpriority.HideSelection = false;
			this.list_hightpriority.Location = new System.Drawing.Point(9, 109);
			this.list_hightpriority.Name = "list_hightpriority";
			this.list_hightpriority.Size = new System.Drawing.Size(296, 295);
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
			this.list_lowpriority.Size = new System.Drawing.Size(296, 295);
			this.list_lowpriority.TabIndex = 20;
			this.list_lowpriority.UseCompatibleStateImageBehavior = false;
			this.list_lowpriority.View = System.Windows.Forms.View.List;
			this.list_lowpriority.SelectedIndexChanged += new System.EventHandler(this.list_lowpriority_SelectedIndexChanged);
			// 
			// txt_hightpriority
			// 
			this.txt_hightpriority.Location = new System.Drawing.Point(9, 83);
			this.txt_hightpriority.Name = "txt_hightpriority";
			this.txt_hightpriority.Size = new System.Drawing.Size(296, 20);
			this.txt_hightpriority.TabIndex = 21;
			// 
			// txt_lowpriority
			// 
			this.txt_lowpriority.Location = new System.Drawing.Point(9, 83);
			this.txt_lowpriority.Name = "txt_lowpriority";
			this.txt_lowpriority.Size = new System.Drawing.Size(296, 20);
			this.txt_lowpriority.TabIndex = 22;
			// 
			// btn_add_hightpriority
			// 
			this.btn_add_hightpriority.Location = new System.Drawing.Point(311, 83);
			this.btn_add_hightpriority.Name = "btn_add_hightpriority";
			this.btn_add_hightpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_add_hightpriority.TabIndex = 23;
			this.btn_add_hightpriority.Text = "Add";
			this.btn_add_hightpriority.UseVisualStyleBackColor = true;
			this.btn_add_hightpriority.Click += new System.EventHandler(this.btn_add_hightpriority_Click);
			// 
			// btn_add_lowpriority
			// 
			this.btn_add_lowpriority.Location = new System.Drawing.Point(311, 83);
			this.btn_add_lowpriority.Name = "btn_add_lowpriority";
			this.btn_add_lowpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_add_lowpriority.TabIndex = 24;
			this.btn_add_lowpriority.Text = "Add";
			this.btn_add_lowpriority.UseVisualStyleBackColor = true;
			this.btn_add_lowpriority.Click += new System.EventHandler(this.btn_add_lowpriority_Click);
			// 
			// btn_up_hightpriority
			// 
			this.btn_up_hightpriority.Enabled = false;
			this.btn_up_hightpriority.Location = new System.Drawing.Point(311, 153);
			this.btn_up_hightpriority.Name = "btn_up_hightpriority";
			this.btn_up_hightpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_up_hightpriority.TabIndex = 25;
			this.btn_up_hightpriority.Text = "Up";
			this.btn_up_hightpriority.UseVisualStyleBackColor = true;
			this.btn_up_hightpriority.Click += new System.EventHandler(this.btn_up_hightpriority_Click);
			// 
			// btn_down_hightpriority
			// 
			this.btn_down_hightpriority.Enabled = false;
			this.btn_down_hightpriority.Location = new System.Drawing.Point(311, 182);
			this.btn_down_hightpriority.Name = "btn_down_hightpriority";
			this.btn_down_hightpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_down_hightpriority.TabIndex = 26;
			this.btn_down_hightpriority.Text = "Down";
			this.btn_down_hightpriority.UseVisualStyleBackColor = true;
			this.btn_down_hightpriority.Click += new System.EventHandler(this.btn_down_hightpriority_Click);
			// 
			// btn_delete_hightpriority
			// 
			this.btn_delete_hightpriority.Enabled = false;
			this.btn_delete_hightpriority.Location = new System.Drawing.Point(311, 211);
			this.btn_delete_hightpriority.Name = "btn_delete_hightpriority";
			this.btn_delete_hightpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_delete_hightpriority.TabIndex = 27;
			this.btn_delete_hightpriority.Text = "Delete";
			this.btn_delete_hightpriority.UseVisualStyleBackColor = true;
			this.btn_delete_hightpriority.Click += new System.EventHandler(this.btn_delete_hightpriority_Click);
			// 
			// btn_up_lowpriority
			// 
			this.btn_up_lowpriority.Enabled = false;
			this.btn_up_lowpriority.Location = new System.Drawing.Point(311, 157);
			this.btn_up_lowpriority.Name = "btn_up_lowpriority";
			this.btn_up_lowpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_up_lowpriority.TabIndex = 28;
			this.btn_up_lowpriority.Text = "Up";
			this.btn_up_lowpriority.UseVisualStyleBackColor = true;
			this.btn_up_lowpriority.Click += new System.EventHandler(this.btn_up_lowpriority_Click);
			// 
			// btn_down_lowpriority
			// 
			this.btn_down_lowpriority.Enabled = false;
			this.btn_down_lowpriority.Location = new System.Drawing.Point(311, 186);
			this.btn_down_lowpriority.Name = "btn_down_lowpriority";
			this.btn_down_lowpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_down_lowpriority.TabIndex = 29;
			this.btn_down_lowpriority.Text = "Down";
			this.btn_down_lowpriority.UseVisualStyleBackColor = true;
			this.btn_down_lowpriority.Click += new System.EventHandler(this.btn_down_lowpriority_Click);
			// 
			// btn_delete_lowpriority
			// 
			this.btn_delete_lowpriority.Enabled = false;
			this.btn_delete_lowpriority.Location = new System.Drawing.Point(311, 215);
			this.btn_delete_lowpriority.Name = "btn_delete_lowpriority";
			this.btn_delete_lowpriority.Size = new System.Drawing.Size(46, 23);
			this.btn_delete_lowpriority.TabIndex = 30;
			this.btn_delete_lowpriority.Text = "Delete";
			this.btn_delete_lowpriority.UseVisualStyleBackColor = true;
			this.btn_delete_lowpriority.Click += new System.EventHandler(this.btn_delete_lowpriority_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.list_hightpriority);
			this.groupBox1.Controls.Add(this.txt_hightpriority);
			this.groupBox1.Controls.Add(this.btn_delete_hightpriority);
			this.groupBox1.Controls.Add(this.btn_add_hightpriority);
			this.groupBox1.Controls.Add(this.btn_down_hightpriority);
			this.groupBox1.Controls.Add(this.btn_up_hightpriority);
			this.groupBox1.Location = new System.Drawing.Point(12, 46);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(372, 410);
			this.groupBox1.TabIndex = 31;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Hight Priority Path";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 60);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(254, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = " you copy few games on C:\\Roms on your fast nvme";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(260, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "For exemple, you have your RomSet on D:\\Roms, but";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(325, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Hight Priority path will replace the path, even if the normal path exist";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.btn_delete_lowpriority);
			this.groupBox2.Controls.Add(this.list_lowpriority);
			this.groupBox2.Controls.Add(this.btn_down_lowpriority);
			this.groupBox2.Controls.Add(this.txt_lowpriority);
			this.groupBox2.Controls.Add(this.btn_up_lowpriority);
			this.groupBox2.Controls.Add(this.btn_add_lowpriority);
			this.groupBox2.Location = new System.Drawing.Point(401, 46);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(372, 410);
			this.groupBox2.TabIndex = 32;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Low Priority Path";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 41);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(370, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Like you play on an other computer and look for the rompath on your network";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 25);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(341, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Low Priority path will replace the path, only if the normal path don\'t exist";
			// 
			// ChangeRomPath_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(780, 491);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ChangeRomPath_Config";
			this.Text = "ChangeRomPath_Config";
			this.Load += new System.EventHandler(this.ChangeRomPath_Config_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.ListView list_hightpriority;
		private System.Windows.Forms.ListView list_lowpriority;
		private System.Windows.Forms.TextBox txt_hightpriority;
		private System.Windows.Forms.TextBox txt_lowpriority;
		private System.Windows.Forms.Button btn_add_hightpriority;
		private System.Windows.Forms.Button btn_add_lowpriority;
		private System.Windows.Forms.Button btn_up_hightpriority;
		private System.Windows.Forms.Button btn_down_hightpriority;
		private System.Windows.Forms.Button btn_delete_hightpriority;
		private System.Windows.Forms.Button btn_up_lowpriority;
		private System.Windows.Forms.Button btn_down_lowpriority;
		private System.Windows.Forms.Button btn_delete_lowpriority;
		private System.Windows.Forms.ColumnHeader valh;
		private System.Windows.Forms.ColumnHeader val;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
	}
}