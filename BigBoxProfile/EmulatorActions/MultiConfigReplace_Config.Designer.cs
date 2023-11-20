namespace BigBoxProfile.EmulatorActions
{
	partial class MultiConfigReplace_Config
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
			this.chk_filter_matchall = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_matchall = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.btn_manageVariables = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btn_file = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_file = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_content = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// chk_filter_matchall
			// 
			this.chk_filter_matchall.Enabled = false;
			this.chk_filter_matchall.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
			this.chk_filter_matchall.Location = new System.Drawing.Point(180, 54);
			this.chk_filter_matchall.Name = "chk_filter_matchall";
			this.chk_filter_matchall.Size = new System.Drawing.Size(138, 20);
			this.chk_filter_matchall.TabIndex = 100;
			this.chk_filter_matchall.Values.Text = "Must match all args";
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(180, 73);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 99;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(490, 126);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 98;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(180, 126);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 97;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(7, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 96;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(180, 101);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(401, 23);
			this.txt_exclude.TabIndex = 95;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(490, 37);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 94;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(180, 37);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 93;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(7, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 92;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(180, 12);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(401, 23);
			this.txt_filter.TabIndex = 91;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1109, 672);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 90;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1190, 672);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 89;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// chk_exclude_matchall
			// 
			this.chk_exclude_matchall.Enabled = false;
			this.chk_exclude_matchall.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
			this.chk_exclude_matchall.Location = new System.Drawing.Point(180, 143);
			this.chk_exclude_matchall.Name = "chk_exclude_matchall";
			this.chk_exclude_matchall.Size = new System.Drawing.Size(138, 20);
			this.chk_exclude_matchall.TabIndex = 101;
			this.chk_exclude_matchall.Values.Text = "Must match all args";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.btn_manageVariables);
			this.groupBox4.Controls.Add(this.listBox1);
			this.groupBox4.Location = new System.Drawing.Point(1009, 188);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(256, 478);
			this.groupBox4.TabIndex = 102;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Variables (Advanced Users Only !)";
			// 
			// btn_manageVariables
			// 
			this.btn_manageVariables.Location = new System.Drawing.Point(12, 433);
			this.btn_manageVariables.Name = "btn_manageVariables";
			this.btn_manageVariables.Size = new System.Drawing.Size(233, 24);
			this.btn_manageVariables.TabIndex = 96;
			this.btn_manageVariables.Values.Text = "Manage Variables";
			this.btn_manageVariables.Click += new System.EventHandler(this.btn_manageVariables_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 19);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(233, 407);
			this.listBox1.TabIndex = 0;
			// 
			// btn_file
			// 
			this.btn_file.Location = new System.Drawing.Point(953, 208);
			this.btn_file.Name = "btn_file";
			this.btn_file.Size = new System.Drawing.Size(35, 24);
			this.btn_file.TabIndex = 104;
			this.btn_file.Values.Text = "...";
			this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
			// 
			// txt_file
			// 
			this.txt_file.Location = new System.Drawing.Point(227, 209);
			this.txt_file.Name = "txt_file";
			this.txt_file.Size = new System.Drawing.Size(720, 23);
			this.txt_file.TabIndex = 103;
			// 
			// txt_content
			// 
			this.txt_content.Location = new System.Drawing.Point(8, 237);
			this.txt_content.Name = "txt_content";
			this.txt_content.Size = new System.Drawing.Size(980, 408);
			this.txt_content.TabIndex = 105;
			this.txt_content.Text = "";
			// 
			// MultiConfigReplace_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1277, 707);
			this.Controls.Add(this.txt_content);
			this.Controls.Add(this.btn_file);
			this.Controls.Add(this.txt_file);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.chk_exclude_matchall);
			this.Controls.Add(this.chk_filter_matchall);
			this.Controls.Add(this.chk_filter_remove);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Name = "MultiConfigReplace_Config";
			this.Text = "MultiConfigReplace_Config";
			this.Load += new System.EventHandler(this.MultiConfigReplace_Config_Load);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_matchall;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_matchall;
		private System.Windows.Forms.GroupBox groupBox4;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manageVariables;
		private System.Windows.Forms.ListBox listBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_file;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_file;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_content;
	}
}