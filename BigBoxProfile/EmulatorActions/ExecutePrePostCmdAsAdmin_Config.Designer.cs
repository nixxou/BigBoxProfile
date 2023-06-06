﻿namespace BigBoxProfile.EmulatorActions
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
			this.list_cmd = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_cmd = new System.Windows.Forms.TextBox();
			this.btn_delete = new System.Windows.Forms.Button();
			this.btn_add = new System.Windows.Forms.Button();
			this.btn_down = new System.Windows.Forms.Button();
			this.btn_up = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.radio_exit = new System.Windows.Forms.RadioButton();
			this.radio_start = new System.Windows.Forms.RadioButton();
			this.btn_searchFile = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.txt_arg = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// list_cmd
			// 
			this.list_cmd.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_cmd.HideSelection = false;
			this.list_cmd.Location = new System.Drawing.Point(12, 158);
			this.list_cmd.Name = "list_cmd";
			this.list_cmd.Size = new System.Drawing.Size(664, 338);
			this.list_cmd.TabIndex = 28;
			this.list_cmd.UseCompatibleStateImageBehavior = false;
			this.list_cmd.View = System.Windows.Forms.View.List;
			this.list_cmd.SelectedIndexChanged += new System.EventHandler(this.list_cmd_SelectedIndexChanged);
			// 
			// txt_cmd
			// 
			this.txt_cmd.Location = new System.Drawing.Point(145, 97);
			this.txt_cmd.Name = "txt_cmd";
			this.txt_cmd.Size = new System.Drawing.Size(450, 20);
			this.txt_cmd.TabIndex = 29;
			// 
			// btn_delete
			// 
			this.btn_delete.Enabled = false;
			this.btn_delete.Location = new System.Drawing.Point(682, 308);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(46, 23);
			this.btn_delete.TabIndex = 33;
			this.btn_delete.Text = "Delete";
			this.btn_delete.UseVisualStyleBackColor = true;
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// btn_add
			// 
			this.btn_add.Location = new System.Drawing.Point(601, 120);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(46, 23);
			this.btn_add.TabIndex = 30;
			this.btn_add.Text = "Add";
			this.btn_add.UseVisualStyleBackColor = true;
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// btn_down
			// 
			this.btn_down.Enabled = false;
			this.btn_down.Location = new System.Drawing.Point(682, 279);
			this.btn_down.Name = "btn_down";
			this.btn_down.Size = new System.Drawing.Size(46, 23);
			this.btn_down.TabIndex = 32;
			this.btn_down.Text = "Down";
			this.btn_down.UseVisualStyleBackColor = true;
			this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
			// 
			// btn_up
			// 
			this.btn_up.Enabled = false;
			this.btn_up.Location = new System.Drawing.Point(682, 250);
			this.btn_up.Name = "btn_up";
			this.btn_up.Size = new System.Drawing.Size(46, 23);
			this.btn_up.TabIndex = 31;
			this.btn_up.Text = "Up";
			this.btn_up.UseVisualStyleBackColor = true;
			this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 38;
			this.label3.Text = "Only if cmdLine contains :";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(145, 32);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(554, 20);
			this.txt_filter.TabIndex = 37;
			this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 13);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 36;
			this.label2.Text = "Execute :";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// radio_exit
			// 
			this.radio_exit.AutoSize = true;
			this.radio_exit.Location = new System.Drawing.Point(215, 9);
			this.radio_exit.Name = "radio_exit";
			this.radio_exit.Size = new System.Drawing.Size(59, 17);
			this.radio_exit.TabIndex = 35;
			this.radio_exit.TabStop = true;
			this.radio_exit.Text = "On Exit";
			this.radio_exit.UseVisualStyleBackColor = true;
			this.radio_exit.CheckedChanged += new System.EventHandler(this.radio_exit_CheckedChanged);
			// 
			// radio_start
			// 
			this.radio_start.AutoSize = true;
			this.radio_start.Location = new System.Drawing.Point(145, 9);
			this.radio_start.Name = "radio_start";
			this.radio_start.Size = new System.Drawing.Size(64, 17);
			this.radio_start.TabIndex = 34;
			this.radio_start.TabStop = true;
			this.radio_start.Text = "On Start";
			this.radio_start.UseVisualStyleBackColor = true;
			this.radio_start.CheckedChanged += new System.EventHandler(this.radio_start_CheckedChanged);
			// 
			// btn_searchFile
			// 
			this.btn_searchFile.Location = new System.Drawing.Point(601, 94);
			this.btn_searchFile.Name = "btn_searchFile";
			this.btn_searchFile.Size = new System.Drawing.Size(46, 23);
			this.btn_searchFile.TabIndex = 39;
			this.btn_searchFile.Text = "...";
			this.btn_searchFile.UseVisualStyleBackColor = true;
			this.btn_searchFile.Click += new System.EventHandler(this.btn_searchFile_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(682, 444);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 42;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(682, 473);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 41;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_arg
			// 
			this.txt_arg.Location = new System.Drawing.Point(145, 123);
			this.txt_arg.Name = "txt_arg";
			this.txt_arg.Size = new System.Drawing.Size(450, 20);
			this.txt_arg.TabIndex = 43;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(66, 13);
			this.label1.TabIndex = 44;
			this.label1.Text = "Executable :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 13);
			this.label4.TabIndex = 45;
			this.label4.Text = "Arguments :";
			// 
			// ExecutePrePostCmdAsAdmin_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(769, 521);
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
			this.Name = "ExecutePrePostCmdAsAdmin_Config";
			this.Text = "ExecutePrePostCmdAsAdmin_Config";
			this.Load += new System.EventHandler(this.ExecutePrePostCmdAsAdmin_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView list_cmd;
		private System.Windows.Forms.ColumnHeader valh;
		private System.Windows.Forms.TextBox txt_cmd;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Button btn_down;
		private System.Windows.Forms.Button btn_up;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radio_exit;
		private System.Windows.Forms.RadioButton radio_start;
		private System.Windows.Forms.Button btn_searchFile;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.TextBox txt_arg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
	}
}