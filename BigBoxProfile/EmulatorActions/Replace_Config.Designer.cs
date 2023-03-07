namespace BigBoxProfile.EmulatorActions
{
	partial class Replace_Config
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
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.radio_cmd = new System.Windows.Forms.RadioButton();
			this.radio_arg = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.txt_search = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_replacewith = new System.Windows.Forms.TextBox();
			this.chk_useregex = new System.Windows.Forms.CheckBox();
			this.chk_casesensitive = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 119);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(146, 116);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(344, 20);
			this.txt_filter.TabIndex = 18;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 97);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "Execute for :";
			// 
			// radio_cmd
			// 
			this.radio_cmd.AutoSize = true;
			this.radio_cmd.Location = new System.Drawing.Point(396, 93);
			this.radio_cmd.Name = "radio_cmd";
			this.radio_cmd.Size = new System.Drawing.Size(83, 17);
			this.radio_cmd.TabIndex = 16;
			this.radio_cmd.TabStop = true;
			this.radio_cmd.Text = "the cmdLine";
			this.radio_cmd.UseVisualStyleBackColor = true;
			// 
			// radio_arg
			// 
			this.radio_arg.AutoSize = true;
			this.radio_arg.Location = new System.Drawing.Point(289, 93);
			this.radio_arg.Name = "radio_arg";
			this.radio_arg.Size = new System.Drawing.Size(98, 17);
			this.radio_arg.TabIndex = 15;
			this.radio_arg.TabStop = true;
			this.radio_arg.Text = "Each Argument";
			this.radio_arg.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(47, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Search :";
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(338, 143);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 13;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(419, 143);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 12;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// txt_search
			// 
			this.txt_search.Location = new System.Drawing.Point(146, 12);
			this.txt_search.Name = "txt_search";
			this.txt_search.Size = new System.Drawing.Size(348, 20);
			this.txt_search.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 38);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Replace With :";
			// 
			// txt_replacewith
			// 
			this.txt_replacewith.Location = new System.Drawing.Point(146, 38);
			this.txt_replacewith.Name = "txt_replacewith";
			this.txt_replacewith.Size = new System.Drawing.Size(348, 20);
			this.txt_replacewith.TabIndex = 20;
			// 
			// chk_useregex
			// 
			this.chk_useregex.AutoSize = true;
			this.chk_useregex.Location = new System.Drawing.Point(289, 64);
			this.chk_useregex.Name = "chk_useregex";
			this.chk_useregex.Size = new System.Drawing.Size(79, 17);
			this.chk_useregex.TabIndex = 22;
			this.chk_useregex.Text = "Use Regex";
			this.chk_useregex.UseVisualStyleBackColor = true;
			// 
			// chk_casesensitive
			// 
			this.chk_casesensitive.AutoSize = true;
			this.chk_casesensitive.Location = new System.Drawing.Point(396, 64);
			this.chk_casesensitive.Name = "chk_casesensitive";
			this.chk_casesensitive.Size = new System.Drawing.Size(94, 17);
			this.chk_casesensitive.TabIndex = 23;
			this.chk_casesensitive.Text = "Case sensitive";
			this.chk_casesensitive.UseVisualStyleBackColor = true;
			// 
			// Replace_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(517, 184);
			this.Controls.Add(this.chk_casesensitive);
			this.Controls.Add(this.chk_useregex);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txt_replacewith);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radio_cmd);
			this.Controls.Add(this.radio_arg);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.txt_search);
			this.Name = "Replace_Config";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Replace_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radio_cmd;
		private System.Windows.Forms.RadioButton radio_arg;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.TextBox txt_search;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_replacewith;
		private System.Windows.Forms.CheckBox chk_useregex;
		private System.Windows.Forms.CheckBox chk_casesensitive;
	}
}