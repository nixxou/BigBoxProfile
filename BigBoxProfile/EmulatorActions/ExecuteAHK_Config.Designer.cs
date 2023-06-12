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
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_CodeExemple = new System.Windows.Forms.RichTextBox();
			this.txt_CodeBefore = new System.Windows.Forms.RichTextBox();
			this.txt_CodeReal = new System.Windows.Forms.RichTextBox();
			this.txt_CodeAfter = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 14;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(152, 12);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(433, 20);
			this.txt_filter.TabIndex = 13;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(1013, 737);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 12;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(1094, 737);
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
			this.label1.Location = new System.Drawing.Point(18, 48);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(190, 13);
			this.label1.TabIndex = 19;
			this.label1.Text = "Modify Command Line (Exemple Only) :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 391);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(148, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Modify Command Line (Real) :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(612, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(86, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Execute Before :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(612, 391);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 13);
			this.label5.TabIndex = 22;
			this.label5.Text = "Execute After :";
			// 
			// txt_CodeExemple
			// 
			this.txt_CodeExemple.Location = new System.Drawing.Point(21, 64);
			this.txt_CodeExemple.Name = "txt_CodeExemple";
			this.txt_CodeExemple.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeExemple.TabIndex = 23;
			this.txt_CodeExemple.Text = "";
			// 
			// txt_CodeBefore
			// 
			this.txt_CodeBefore.Location = new System.Drawing.Point(612, 64);
			this.txt_CodeBefore.Name = "txt_CodeBefore";
			this.txt_CodeBefore.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeBefore.TabIndex = 24;
			this.txt_CodeBefore.Text = "";
			// 
			// txt_CodeReal
			// 
			this.txt_CodeReal.Location = new System.Drawing.Point(21, 407);
			this.txt_CodeReal.Name = "txt_CodeReal";
			this.txt_CodeReal.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeReal.TabIndex = 25;
			this.txt_CodeReal.Text = "";
			// 
			// txt_CodeAfter
			// 
			this.txt_CodeAfter.Location = new System.Drawing.Point(612, 407);
			this.txt_CodeAfter.Name = "txt_CodeAfter";
			this.txt_CodeAfter.Size = new System.Drawing.Size(564, 324);
			this.txt_CodeAfter.TabIndex = 26;
			this.txt_CodeAfter.Text = "";
			// 
			// ExecuteAHK_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1188, 767);
			this.Controls.Add(this.txt_CodeAfter);
			this.Controls.Add(this.txt_CodeReal);
			this.Controls.Add(this.txt_CodeBefore);
			this.Controls.Add(this.txt_CodeExemple);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Name = "ExecuteAHK_Config";
			this.Text = "ExecuteAHK_Config";
			this.Load += new System.EventHandler(this.ExecuteAHK_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.RichTextBox txt_CodeExemple;
		private System.Windows.Forms.RichTextBox txt_CodeBefore;
		private System.Windows.Forms.RichTextBox txt_CodeReal;
		private System.Windows.Forms.RichTextBox txt_CodeAfter;
	}
}