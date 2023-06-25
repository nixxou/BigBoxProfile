namespace BigBoxProfile.EmulatorActions
{
	partial class Prefix_Config
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prefix_Config));
			this.btn_ok = new System.Windows.Forms.Button();
			this.txt_option = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.radio_arg = new System.Windows.Forms.RadioButton();
			this.radio_cmd = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.btn_manage_exclude = new System.Windows.Forms.Button();
			this.chk_exclude_comma = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_exclude = new System.Windows.Forms.TextBox();
			this.btn_manage_filter = new System.Windows.Forms.Button();
			this.chk_filter_comma = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(434, 220);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_option
			// 
			this.txt_option.Location = new System.Drawing.Point(162, 12);
			this.txt_option.Name = "txt_option";
			this.txt_option.Size = new System.Drawing.Size(348, 20);
			this.txt_option.TabIndex = 2;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(353, 220);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 4;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Add As Prefix :";
			// 
			// radio_arg
			// 
			this.radio_arg.AutoSize = true;
			this.radio_arg.Location = new System.Drawing.Point(284, 38);
			this.radio_arg.Name = "radio_arg";
			this.radio_arg.Size = new System.Drawing.Size(107, 17);
			this.radio_arg.TabIndex = 6;
			this.radio_arg.TabStop = true;
			this.radio_arg.Text = "Add As Argument";
			this.radio_arg.UseVisualStyleBackColor = true;
			// 
			// radio_cmd
			// 
			this.radio_cmd.AutoSize = true;
			this.radio_cmd.Location = new System.Drawing.Point(407, 38);
			this.radio_cmd.Name = "radio_cmd";
			this.radio_cmd.Size = new System.Drawing.Size(102, 17);
			this.radio_cmd.TabIndex = 7;
			this.radio_cmd.TabStop = true;
			this.radio_cmd.Text = "Add As cmdLine";
			this.radio_cmd.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Add as :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(165, 61);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(344, 20);
			this.txt_filter.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(422, 139);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_exclude.TabIndex = 72;
			this.btn_manage_exclude.Text = "Manage Items";
			this.btn_manage_exclude.UseVisualStyleBackColor = true;
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.AutoSize = true;
			this.chk_exclude_comma.Location = new System.Drawing.Point(165, 145);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_exclude_comma.TabIndex = 71;
			this.chk_exclude_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.UseVisualStyleBackColor = true;
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 120);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 13);
			this.label6.TabIndex = 70;
			this.label6.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(165, 117);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(348, 20);
			this.txt_exclude.TabIndex = 69;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(422, 92);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_filter.TabIndex = 68;
			this.btn_manage_filter.Text = "Manage Items";
			this.btn_manage_filter.UseVisualStyleBackColor = true;
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.AutoSize = true;
			this.chk_filter_comma.Location = new System.Drawing.Point(165, 92);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_filter_comma.TabIndex = 67;
			this.chk_filter_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.UseVisualStyleBackColor = true;
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// Prefix_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(522, 255);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radio_cmd);
			this.Controls.Add(this.radio_arg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.txt_option);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Prefix_Config";
			this.Text = "à";
			this.Load += new System.EventHandler(this.Prefix_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.TextBox txt_option;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radio_arg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton radio_cmd;
		private System.Windows.Forms.Button btn_manage_exclude;
		private System.Windows.Forms.CheckBox chk_exclude_comma;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_exclude;
		private System.Windows.Forms.Button btn_manage_filter;
		private System.Windows.Forms.CheckBox chk_filter_comma;
	}
}