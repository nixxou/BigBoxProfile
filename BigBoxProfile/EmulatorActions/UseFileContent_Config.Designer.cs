namespace BigBoxProfile.EmulatorActions
{
	partial class UseFileContent_Config
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UseFileContent_Config));
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.radio_usefile = new System.Windows.Forms.RadioButton();
			this.radio_usedir = new System.Windows.Forms.RadioButton();
			this.btn_manage_exclude = new System.Windows.Forms.Button();
			this.chk_exclude_comma = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txt_exclude = new System.Windows.Forms.TextBox();
			this.btn_manage_filter = new System.Windows.Forms.Button();
			this.chk_filter_comma = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(167, 12);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(431, 20);
			this.txt_filter.TabIndex = 13;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(442, 156);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 12;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(523, 156);
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
			this.label1.Location = new System.Drawing.Point(12, 133);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(212, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "If the Path within the file content is relative :";
			// 
			// radio_usefile
			// 
			this.radio_usefile.AutoSize = true;
			this.radio_usefile.Location = new System.Drawing.Point(256, 131);
			this.radio_usefile.Name = "radio_usefile";
			this.radio_usefile.Size = new System.Drawing.Size(159, 17);
			this.radio_usefile.TabIndex = 16;
			this.radio_usefile.TabStop = true;
			this.radio_usefile.Text = "Use the File path as base dir";
			this.radio_usefile.UseVisualStyleBackColor = true;
			// 
			// radio_usedir
			// 
			this.radio_usedir.AutoSize = true;
			this.radio_usedir.Location = new System.Drawing.Point(432, 131);
			this.radio_usedir.Name = "radio_usedir";
			this.radio_usedir.Size = new System.Drawing.Size(166, 17);
			this.radio_usedir.TabIndex = 17;
			this.radio_usedir.TabStop = true;
			this.radio_usedir.Text = "Use Emulator path as base dir";
			this.radio_usedir.UseVisualStyleBackColor = true;
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(507, 85);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_exclude.TabIndex = 90;
			this.btn_manage_exclude.Text = "Manage Items";
			this.btn_manage_exclude.UseVisualStyleBackColor = true;
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.AutoSize = true;
			this.chk_exclude_comma.Location = new System.Drawing.Point(167, 91);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_exclude_comma.TabIndex = 89;
			this.chk_exclude_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.UseVisualStyleBackColor = true;
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(12, 66);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(145, 13);
			this.label6.TabIndex = 88;
			this.label6.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(167, 63);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(431, 20);
			this.txt_exclude.TabIndex = 87;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(507, 34);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 23);
			this.btn_manage_filter.TabIndex = 86;
			this.btn_manage_filter.Text = "Manage Items";
			this.btn_manage_filter.UseVisualStyleBackColor = true;
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.AutoSize = true;
			this.chk_filter_comma.Location = new System.Drawing.Point(167, 38);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(226, 17);
			this.chk_filter_comma.TabIndex = 85;
			this.chk_filter_comma.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.UseVisualStyleBackColor = true;
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// UseFileContent_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(610, 188);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.radio_usedir);
			this.Controls.Add(this.radio_usefile);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "UseFileContent_Config";
			this.Text = "UseFileContent_Config";
			this.Load += new System.EventHandler(this.UseFileContent_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RadioButton radio_usefile;
		private System.Windows.Forms.RadioButton radio_usedir;
		private System.Windows.Forms.Button btn_manage_exclude;
		private System.Windows.Forms.CheckBox chk_exclude_comma;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txt_exclude;
		private System.Windows.Forms.Button btn_manage_filter;
		private System.Windows.Forms.CheckBox chk_filter_comma;
	}
}