namespace BigBoxProfile.EmulatorActions
{
	partial class ExecuteAHK_Config
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
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_CodeExemple = new System.Windows.Forms.RichTextBox();
			this.txt_CodeBefore = new System.Windows.Forms.RichTextBox();
			this.txt_CodeReal = new System.Windows.Forms.RichTextBox();
			this.txt_CodeAfter = new System.Windows.Forms.RichTextBox();
			this.btn_manage_exclude = new System.Windows.Forms.Button();
			this.chk_exclude_comma = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_exclude = new System.Windows.Forms.TextBox();
			this.btn_manage_filter = new System.Windows.Forms.Button();
			this.chk_filter_comma = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(187, 12);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(398, 20);
			this.txt_filter.TabIndex = 13;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1013, 819);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 12;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1094, 819);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 11;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 130);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Modify Command Line (Exemple Only) :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 473);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Modify Command Line (Real) :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(612, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Execute Before :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(612, 473);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Execute After :";
			// 
			// txt_CodeExemple
			// 
			this.txt_CodeExemple.Location = new System.Drawing.Point(21, 146);
			this.txt_CodeExemple.Name = "txt_CodeExemple";
			this.txt_CodeExemple.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeExemple.TabIndex = 23;
			this.txt_CodeExemple.Text = "";
			// 
			// txt_CodeBefore
			// 
			this.txt_CodeBefore.Location = new System.Drawing.Point(612, 146);
			this.txt_CodeBefore.Name = "txt_CodeBefore";
			this.txt_CodeBefore.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeBefore.TabIndex = 24;
			this.txt_CodeBefore.Text = "";
			// 
			// txt_CodeReal
			// 
			this.txt_CodeReal.Location = new System.Drawing.Point(21, 489);
			this.txt_CodeReal.Name = "txt_CodeReal";
			this.txt_CodeReal.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeReal.TabIndex = 25;
			this.txt_CodeReal.Text = "";
			// 
			// txt_CodeAfter
			// 
			this.txt_CodeAfter.Location = new System.Drawing.Point(612, 489);
			this.txt_CodeAfter.Name = "txt_CodeAfter";
			this.txt_CodeAfter.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeAfter.TabIndex = 26;
			this.txt_CodeAfter.Text = "";
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(494, 87);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_exclude.TabIndex = 54;
			this.btn_manage_exclude.Text = "Manage Items";
			this.btn_manage_exclude.UseVisualStyleBackColor = true;
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.AutoSize = true;
			this.chk_exclude_comma.Location = new System.Drawing.Point(187, 89);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_exclude_comma.TabIndex = 53;
			this.chk_exclude_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.UseVisualStyleBackColor = true;
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(26, 64);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 13);
			this.label6.TabIndex = 52;
			this.label6.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(187, 61);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(398, 20);
			this.txt_exclude.TabIndex = 51;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(494, 34);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_filter.TabIndex = 50;
			this.btn_manage_filter.Text = "Manage Items";
			this.btn_manage_filter.UseVisualStyleBackColor = true;
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.AutoSize = true;
			this.chk_filter_comma.Location = new System.Drawing.Point(187, 38);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_filter_comma.TabIndex = 49;
			this.chk_filter_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.UseVisualStyleBackColor = true;
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 13);
			this.label7.TabIndex = 48;
			this.label7.Text = "Only if cmdLine contains :";
			// 
			// ExecuteAHK_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1188, 852);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txt_CodeAfter);
			this.Controls.Add(this.txt_CodeReal);
			this.Controls.Add(this.txt_CodeBefore);
			this.Controls.Add(this.txt_CodeExemple);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Name = "ExecuteAHK_Config";
			this.Text = "ExecuteAHK_Config";
			this.Load += new System.EventHandler(this.ExecuteAHK_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox txt_CodeExemple;
		private System.Windows.Forms.RichTextBox txt_CodeBefore;
		private System.Windows.Forms.RichTextBox txt_CodeReal;
		private System.Windows.Forms.RichTextBox txt_CodeAfter;
		private System.Windows.Forms.Button btn_manage_exclude;
		private System.Windows.Forms.CheckBox chk_exclude_comma;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_exclude;
		private System.Windows.Forms.Button btn_manage_filter;
		private System.Windows.Forms.CheckBox chk_filter_comma;
		private System.Windows.Forms.Label label7;
	}
}