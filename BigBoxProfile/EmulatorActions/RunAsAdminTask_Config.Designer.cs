namespace BigBoxProfile.EmulatorActions
{
	partial class RunAsAdminTask_Config
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
			this.label5 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_filter_inside_file = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_manage_exclude = new System.Windows.Forms.Button();
			this.chk_exclude_comma = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_exclude = new System.Windows.Forms.TextBox();
			this.btn_manage_filter = new System.Windows.Forms.Button();
			this.chk_filter_comma = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(3, 99);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(416, 13);
			this.label5.TabIndex = 34;
			this.label5.Text = "Only use it when are sure that this argument is a text file (like config or xml)," +
    " not a binary";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 83);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(419, 13);
			this.label2.TabIndex = 33;
			this.label2.Text = "Beware, this option will do a full text read on the first argument that match an " +
    "existing file";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(207, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Only if the first file passed as arg contains :";
			// 
			// txt_filter_inside_file
			// 
			this.txt_filter_inside_file.Location = new System.Drawing.Point(219, 60);
			this.txt_filter_inside_file.Name = "txt_filter_inside_file";
			this.txt_filter_inside_file.Size = new System.Drawing.Size(344, 20);
			this.txt_filter_inside_file.TabIndex = 31;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 30;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(219, 5);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(344, 20);
			this.txt_filter.TabIndex = 29;
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(407, 214);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 28;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(488, 214);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 27;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(471, 150);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_exclude.TabIndex = 84;
			this.btn_manage_exclude.Text = "Manage Items";
			this.btn_manage_exclude.UseVisualStyleBackColor = true;
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.AutoSize = true;
			this.chk_exclude_comma.Location = new System.Drawing.Point(214, 156);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_exclude_comma.TabIndex = 83;
			this.chk_exclude_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.UseVisualStyleBackColor = true;
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(3, 131);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 13);
			this.label6.TabIndex = 82;
			this.label6.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(214, 128);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(348, 20);
			this.txt_exclude.TabIndex = 81;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(471, 31);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_filter.TabIndex = 80;
			this.btn_manage_filter.Text = "Manage Items";
			this.btn_manage_filter.UseVisualStyleBackColor = true;
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.AutoSize = true;
			this.chk_filter_comma.Location = new System.Drawing.Point(214, 31);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_filter_comma.TabIndex = 79;
			this.chk_filter_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.UseVisualStyleBackColor = true;
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// RunAsAdminTask_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(576, 251);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_filter_inside_file);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Name = "RunAsAdminTask_Config";
			this.Text = "RunAsAdminTask_Config";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_filter_inside_file;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_manage_exclude;
		private System.Windows.Forms.CheckBox chk_exclude_comma;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_exclude;
		private System.Windows.Forms.Button btn_manage_filter;
		private System.Windows.Forms.CheckBox chk_filter_comma;
	}
}