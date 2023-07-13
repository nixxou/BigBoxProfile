namespace BigBoxProfile.EmulatorActions
{
	partial class ExecutePrePostCmdAsAdmin_Config
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
			this.list_cmd = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_cmd = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_delete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.radio_exit = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_start = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.btn_searchFile = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_arg = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.SuspendLayout();
			// 
			// list_cmd
			// 
			this.list_cmd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_cmd.HideSelection = false;
			this.list_cmd.Location = new System.Drawing.Point(12, 248);
			this.list_cmd.Name = "list_cmd";
			this.list_cmd.Size = new System.Drawing.Size(664, 338);
			this.list_cmd.TabIndex = 28;
			this.list_cmd.UseCompatibleStateImageBehavior = false;
			this.list_cmd.View = System.Windows.Forms.View.List;
			this.list_cmd.SelectedIndexChanged += new System.EventHandler(this.list_cmd_SelectedIndexChanged);
			// 
			// txt_cmd
			// 
			this.txt_cmd.Location = new System.Drawing.Point(94, 184);
			this.txt_cmd.Name = "txt_cmd";
			this.txt_cmd.Size = new System.Drawing.Size(532, 23);
			this.txt_cmd.TabIndex = 29;
			// 
			// btn_delete
			// 
			this.btn_delete.Enabled = false;
			this.btn_delete.Location = new System.Drawing.Point(682, 398);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(75, 24);
			this.btn_delete.TabIndex = 33;
			this.btn_delete.Values.Text = "Delete";
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// btn_add
			// 
			this.btn_add.Location = new System.Drawing.Point(632, 212);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(46, 24);
			this.btn_add.TabIndex = 30;
			this.btn_add.Values.Text = "Add";
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// btn_down
			// 
			this.btn_down.Enabled = false;
			this.btn_down.Location = new System.Drawing.Point(682, 369);
			this.btn_down.Name = "btn_down";
			this.btn_down.Size = new System.Drawing.Size(75, 24);
			this.btn_down.TabIndex = 32;
			this.btn_down.Values.Text = "Down";
			this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
			// 
			// btn_up
			// 
			this.btn_up.Enabled = false;
			this.btn_up.Location = new System.Drawing.Point(682, 340);
			this.btn_up.Name = "btn_up";
			this.btn_up.Size = new System.Drawing.Size(75, 24);
			this.btn_up.TabIndex = 31;
			this.btn_up.Values.Text = "Up";
			this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 39);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 38;
			this.label3.Values.Text = "Only if cmdLine contains :";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(181, 36);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(495, 23);
			this.txt_filter.TabIndex = 37;
			this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 20);
			this.label2.TabIndex = 36;
			this.label2.Values.Text = "Execute :";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// radio_exit
			// 
			this.radio_exit.Location = new System.Drawing.Point(255, 13);
			this.radio_exit.Name = "radio_exit";
			this.radio_exit.Size = new System.Drawing.Size(61, 20);
			this.radio_exit.TabIndex = 35;
			this.radio_exit.Values.Text = "On Exit";
			this.radio_exit.CheckedChanged += new System.EventHandler(this.radio_exit_CheckedChanged);
			// 
			// radio_start
			// 
			this.radio_start.Location = new System.Drawing.Point(181, 13);
			this.radio_start.Name = "radio_start";
			this.radio_start.Size = new System.Drawing.Size(68, 20);
			this.radio_start.TabIndex = 34;
			this.radio_start.Values.Text = "On Start";
			this.radio_start.CheckedChanged += new System.EventHandler(this.radio_start_CheckedChanged);
			// 
			// btn_searchFile
			// 
			this.btn_searchFile.Location = new System.Drawing.Point(632, 183);
			this.btn_searchFile.Name = "btn_searchFile";
			this.btn_searchFile.Size = new System.Drawing.Size(46, 24);
			this.btn_searchFile.TabIndex = 39;
			this.btn_searchFile.Values.Text = "...";
			this.btn_searchFile.Click += new System.EventHandler(this.btn_searchFile_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(682, 534);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 42;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(682, 563);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 41;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_arg
			// 
			this.txt_arg.Location = new System.Drawing.Point(94, 213);
			this.txt_arg.Name = "txt_arg";
			this.txt_arg.Size = new System.Drawing.Size(530, 23);
			this.txt_arg.TabIndex = 43;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 187);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 20);
			this.label1.TabIndex = 44;
			this.label1.Values.Text = "Executable :";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 216);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 20);
			this.label4.TabIndex = 45;
			this.label4.Values.Text = "Arguments :";
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(585, 118);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 60;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(181, 121);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 59;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(11, 96);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 58;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(181, 93);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(495, 23);
			this.txt_exclude.TabIndex = 57;
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(585, 61);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 56;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(181, 62);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 55;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// ExecutePrePostCmdAsAdmin_Config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(769, 593);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_arg);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.btn_searchFile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radio_exit);
			this.Controls.Add(this.radio_start);
			this.Controls.Add(this.list_cmd);
			this.Controls.Add(this.txt_cmd);
			this.Controls.Add(this.btn_delete);
			this.Controls.Add(this.btn_add);
			this.Controls.Add(this.btn_down);
			this.Controls.Add(this.btn_up);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExecutePrePostCmdAsAdmin_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : Execute Pre/Post Commands";
			this.Load += new System.EventHandler(this.ExecutePrePostCmdAsAdmin_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView list_cmd;
		private System.Windows.Forms.ColumnHeader valh;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_cmd;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_exit;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_start;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_searchFile;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_arg;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}