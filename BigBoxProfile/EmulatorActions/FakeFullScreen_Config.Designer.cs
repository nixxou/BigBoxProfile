namespace BigBoxProfile.EmulatorActions
{
	partial class FakeFullScreen_Config
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
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_target = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.num_timeout = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.num_waitbefore = new ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown();
			this.cmb_targetType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_regex = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.cmb_targetType)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 156);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 25;
			this.label3.Values.Text = "Only if cmdLine contains :";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(185, 153);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(348, 23);
			this.txt_filter.TabIndex = 24;
			this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(380, 294);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 23;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(461, 294);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 22;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 42);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 20);
			this.label1.TabIndex = 27;
			this.label1.Values.Text = "Target Exe :";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txt_target
			// 
			this.txt_target.Location = new System.Drawing.Point(185, 39);
			this.txt_target.Name = "txt_target";
			this.txt_target.Size = new System.Drawing.Size(348, 23);
			this.txt_target.TabIndex = 26;
			this.txt_target.TextChanged += new System.EventHandler(this.txt_target_TextChanged);
			// 
			// num_timeout
			// 
			this.num_timeout.Location = new System.Drawing.Point(185, 97);
			this.num_timeout.Name = "num_timeout";
			this.num_timeout.Size = new System.Drawing.Size(120, 22);
			this.num_timeout.TabIndex = 28;
			this.num_timeout.ValueChanged += new System.EventHandler(this.num_timeout_ValueChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 99);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(64, 20);
			this.label2.TabIndex = 29;
			this.label2.Values.Text = "TimeOut :";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 127);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(135, 20);
			this.label4.TabIndex = 31;
			this.label4.Values.Text = "Wait before Maximise :";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// num_waitbefore
			// 
			this.num_waitbefore.Location = new System.Drawing.Point(185, 125);
			this.num_waitbefore.Name = "num_waitbefore";
			this.num_waitbefore.Size = new System.Drawing.Size(120, 22);
			this.num_waitbefore.TabIndex = 30;
			this.num_waitbefore.ValueChanged += new System.EventHandler(this.num_waitbefore_ValueChanged);
			// 
			// cmb_targetType
			// 
			this.cmb_targetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_targetType.DropDownWidth = 348;
			this.cmb_targetType.FormattingEnabled = true;
			this.cmb_targetType.Items.AddRange(new object[] {
            "Emulator Exe",
            "Custom Exe",
            "Regex"});
			this.cmb_targetType.Location = new System.Drawing.Point(185, 12);
			this.cmb_targetType.Name = "cmb_targetType";
			this.cmb_targetType.Size = new System.Drawing.Size(348, 21);
			this.cmb_targetType.TabIndex = 32;
			this.cmb_targetType.SelectedIndexChanged += new System.EventHandler(this.cmb_targetType_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 20);
			this.label5.TabIndex = 34;
			this.label5.Values.Text = "Regex :";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// txt_regex
			// 
			this.txt_regex.Location = new System.Drawing.Point(185, 68);
			this.txt_regex.Name = "txt_regex";
			this.txt_regex.Size = new System.Drawing.Size(348, 23);
			this.txt_regex.TabIndex = 33;
			this.txt_regex.TextChanged += new System.EventHandler(this.txt_regex_TextChanged);
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(442, 233);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 66;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(185, 237);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 65;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 211);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 64;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(185, 208);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(348, 23);
			this.txt_exclude.TabIndex = 63;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(442, 178);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 62;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(185, 182);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 61;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// FakeFullScreen_Config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(548, 330);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txt_regex);
			this.Controls.Add(this.cmb_targetType);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.num_waitbefore);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.num_timeout);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_target);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FakeFullScreen_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : Fake FullScreen";
			this.Load += new System.EventHandler(this.FakeFullScreen_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmb_targetType)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_target;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_timeout;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonNumericUpDown num_waitbefore;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_targetType;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_regex;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}