namespace BigBoxProfile.EmulatorActions
{
	partial class RetroarchOverlay_Config
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
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_bezeldir = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_bezeldir = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.chk_useautoname = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_windowName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(448, 543);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 74;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(191, 547);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 73;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(18, 521);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 72;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(191, 518);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(348, 23);
			this.txt_exclude.TabIndex = 71;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(448, 488);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 70;
			this.btn_manage_filter.Values.Text = "Manage Items";
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(191, 492);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 69;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(18, 466);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 68;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(191, 463);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(348, 23);
			this.txt_filter.TabIndex = 67;
			// 
			// btn_bezeldir
			// 
			this.btn_bezeldir.Location = new System.Drawing.Point(889, 11);
			this.btn_bezeldir.Name = "btn_bezeldir";
			this.btn_bezeldir.Size = new System.Drawing.Size(40, 24);
			this.btn_bezeldir.TabIndex = 77;
			this.btn_bezeldir.Values.Text = "...";
			this.btn_bezeldir.Click += new System.EventHandler(this.btn_bezeldir_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(18, 14);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(98, 20);
			this.label5.TabIndex = 76;
			this.label5.Values.Text = "Bezel Directory :";
			// 
			// txt_bezeldir
			// 
			this.txt_bezeldir.Location = new System.Drawing.Point(136, 11);
			this.txt_bezeldir.Name = "txt_bezeldir";
			this.txt_bezeldir.Size = new System.Drawing.Size(747, 23);
			this.txt_bezeldir.TabIndex = 75;
			// 
			// chk_useautoname
			// 
			this.chk_useautoname.Location = new System.Drawing.Point(615, 43);
			this.chk_useautoname.Name = "chk_useautoname";
			this.chk_useautoname.Size = new System.Drawing.Size(106, 20);
			this.chk_useautoname.TabIndex = 80;
			this.chk_useautoname.Values.Text = "Use AutoName";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 43);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 20);
			this.label1.TabIndex = 79;
			this.label1.Values.Text = "Search :";
			// 
			// txt_windowName
			// 
			this.txt_windowName.Location = new System.Drawing.Point(136, 40);
			this.txt_windowName.Name = "txt_windowName";
			this.txt_windowName.Size = new System.Drawing.Size(442, 23);
			this.txt_windowName.TabIndex = 78;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(770, 598);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 82;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(851, 598);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 81;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// RetroarchOverlay_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(938, 634);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.chk_useautoname);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_windowName);
			this.Controls.Add(this.btn_bezeldir);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txt_bezeldir);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Name = "RetroarchOverlay_Config";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_bezeldir;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_bezeldir;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_useautoname;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_windowName;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
	}
}