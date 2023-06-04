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
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_target = new System.Windows.Forms.TextBox();
			this.num_timeout = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.num_waitbefore = new System.Windows.Forms.NumericUpDown();
			this.cmb_targetType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_regex = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.num_timeout)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.num_waitbefore)).BeginInit();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 157);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 25;
			this.label3.Text = "Only if cmdLine contains :";
			this.label3.Click += new System.EventHandler(this.label3_Click);
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(136, 154);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(348, 20);
			this.txt_filter.TabIndex = 24;
			this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(325, 180);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 23;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(406, 180);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 22;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 27;
			this.label1.Text = "Target Exe :";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// txt_target
			// 
			this.txt_target.Location = new System.Drawing.Point(136, 37);
			this.txt_target.Name = "txt_target";
			this.txt_target.Size = new System.Drawing.Size(348, 20);
			this.txt_target.TabIndex = 26;
			this.txt_target.TextChanged += new System.EventHandler(this.txt_target_TextChanged);
			// 
			// num_timeout
			// 
			this.num_timeout.Location = new System.Drawing.Point(136, 101);
			this.num_timeout.Name = "num_timeout";
			this.num_timeout.Size = new System.Drawing.Size(120, 20);
			this.num_timeout.TabIndex = 28;
			this.num_timeout.ValueChanged += new System.EventHandler(this.num_timeout_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 108);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 13);
			this.label2.TabIndex = 29;
			this.label2.Text = "TimeOut :";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 135);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(114, 13);
			this.label4.TabIndex = 31;
			this.label4.Text = "Wait before Maximise :";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// num_waitbefore
			// 
			this.num_waitbefore.Location = new System.Drawing.Point(136, 128);
			this.num_waitbefore.Name = "num_waitbefore";
			this.num_waitbefore.Size = new System.Drawing.Size(120, 20);
			this.num_waitbefore.TabIndex = 30;
			this.num_waitbefore.ValueChanged += new System.EventHandler(this.num_waitbefore_ValueChanged);
			// 
			// cmb_targetType
			// 
			this.cmb_targetType.FormattingEnabled = true;
			this.cmb_targetType.Items.AddRange(new object[] {
            "Emulator Exe",
            "Custom Exe",
            "Regex"});
			this.cmb_targetType.Location = new System.Drawing.Point(136, 12);
			this.cmb_targetType.Name = "cmb_targetType";
			this.cmb_targetType.Size = new System.Drawing.Size(345, 21);
			this.cmb_targetType.TabIndex = 32;
			this.cmb_targetType.SelectedIndexChanged += new System.EventHandler(this.cmb_targetType_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 66);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(44, 13);
			this.label5.TabIndex = 34;
			this.label5.Text = "Regex :";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// txt_regex
			// 
			this.txt_regex.Location = new System.Drawing.Point(136, 63);
			this.txt_regex.Name = "txt_regex";
			this.txt_regex.Size = new System.Drawing.Size(348, 20);
			this.txt_regex.TabIndex = 33;
			this.txt_regex.TextChanged += new System.EventHandler(this.txt_regex_TextChanged);
			// 
			// FakeFullScreen_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(568, 235);
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
			this.Name = "FakeFullScreen_Config";
			this.Text = "FakeFullScreen_Config";
			this.Load += new System.EventHandler(this.FakeFullScreen_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.num_timeout)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.num_waitbefore)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_target;
		private System.Windows.Forms.NumericUpDown num_timeout;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown num_waitbefore;
		private System.Windows.Forms.ComboBox cmb_targetType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txt_regex;
	}
}