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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prefix_Config));
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_option = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.radio_arg = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_cmd = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_filter_matchall = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(511, 228);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 3;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_option
			// 
			this.txt_option.Location = new System.Drawing.Point(185, 12);
			this.txt_option.Name = "txt_option";
			this.txt_option.Size = new System.Drawing.Size(401, 23);
			this.txt_option.TabIndex = 2;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(430, 228);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 4;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 20);
			this.label1.TabIndex = 5;
			this.label1.Values.Text = "Add As Prefix :";
			// 
			// radio_arg
			// 
			this.radio_arg.Location = new System.Drawing.Point(349, 38);
			this.radio_arg.Name = "radio_arg";
			this.radio_arg.Size = new System.Drawing.Size(120, 20);
			this.radio_arg.TabIndex = 6;
			this.radio_arg.Values.Text = "Add As Argument";
			// 
			// radio_cmd
			// 
			this.radio_cmd.Location = new System.Drawing.Point(475, 38);
			this.radio_cmd.Name = "radio_cmd";
			this.radio_cmd.Size = new System.Drawing.Size(111, 20);
			this.radio_cmd.TabIndex = 7;
			this.radio_cmd.Values.Text = "Add As cmdLine";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 20);
			this.label2.TabIndex = 8;
			this.label2.Values.Text = "Add as :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(185, 64);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(401, 23);
			this.txt_filter.TabIndex = 9;
			this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 10;
			this.label3.Values.Text = "Only if cmdLine contains :";
			this.label3.Paint += new System.Windows.Forms.PaintEventHandler(this.label3_Paint);
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(495, 178);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 72;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(185, 178);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 71;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 156);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 70;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(185, 153);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(401, 23);
			this.txt_exclude.TabIndex = 69;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(495, 89);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 68;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(185, 89);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 67;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(185, 125);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 87;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			this.chk_filter_remove.CheckedChanged += new System.EventHandler(this.chk_filter_remove_CheckedChanged);
			// 
			// chk_filter_matchall
			// 
			this.chk_filter_matchall.Enabled = false;
			this.chk_filter_matchall.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
			this.chk_filter_matchall.Location = new System.Drawing.Point(185, 106);
			this.chk_filter_matchall.Name = "chk_filter_matchall";
			this.chk_filter_matchall.Size = new System.Drawing.Size(138, 20);
			this.chk_filter_matchall.TabIndex = 88;
			this.chk_filter_matchall.Values.Text = "Must match all args";
			// 
			// Prefix_Config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(603, 330);
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
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radio_cmd);
			this.Controls.Add(this.radio_arg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.txt_option);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Prefix_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : Prefix";
			this.Load += new System.EventHandler(this.Prefix_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_option;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_arg;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_cmd;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_matchall;
	}
}