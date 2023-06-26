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
			this.components = new System.ComponentModel.Container();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_CodeExemple = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_CodeBefore = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_CodeReal = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_CodeAfter = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.SuspendLayout();
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(187, 12);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(398, 23);
			this.txt_filter.TabIndex = 13;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1020, 819);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 12;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1101, 819);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 11;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(18, 130);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(226, 20);
			this.label1.TabIndex = 19;
			this.label1.Values.Text = "Modify Command Line (Exemple Only) :";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(18, 473);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(175, 20);
			this.label2.TabIndex = 20;
			this.label2.Values.Text = "Modify Command Line (Real) :";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(612, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(97, 20);
			this.label4.TabIndex = 21;
			this.label4.Values.Text = "Execute Before :";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(612, 473);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 20);
			this.label5.TabIndex = 22;
			this.label5.Values.Text = "Execute After :";
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
			this.btn_manage_exclude.Location = new System.Drawing.Point(494, 94);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 54;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(187, 94);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 53;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(18, 71);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 52;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(187, 68);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(398, 23);
			this.txt_exclude.TabIndex = 51;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(494, 38);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 50;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(187, 38);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 49;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(18, 15);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(150, 20);
			this.label7.TabIndex = 48;
			this.label7.Values.Text = "Only if cmdLine contains :";
			// 
			// ExecuteAHK_Config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(1198, 852);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExecuteAHK_Config";
			this.Text = "Configuration Module : Execute AHK";
			this.Load += new System.EventHandler(this.ExecuteAHK_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_CodeExemple;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_CodeBefore;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_CodeReal;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_CodeAfter;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}