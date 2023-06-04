namespace BigBoxProfile.EmulatorActions
{
	partial class CopyFile_Config
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
			this.txt_sourceDir = new System.Windows.Forms.TextBox();
			this.btn_source = new System.Windows.Forms.Button();
			this.txt_targetDir = new System.Windows.Forms.TextBox();
			this.btn_target = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.num_maxSize = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.chk_useRamDisk = new System.Windows.Forms.CheckBox();
			this.chk_deleteOnExit = new System.Windows.Forms.CheckBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.num_maxSize)).BeginInit();
			this.SuspendLayout();
			// 
			// txt_sourceDir
			// 
			this.txt_sourceDir.Location = new System.Drawing.Point(146, 12);
			this.txt_sourceDir.Name = "txt_sourceDir";
			this.txt_sourceDir.Size = new System.Drawing.Size(343, 20);
			this.txt_sourceDir.TabIndex = 0;
			// 
			// btn_source
			// 
			this.btn_source.Location = new System.Drawing.Point(505, 9);
			this.btn_source.Name = "btn_source";
			this.btn_source.Size = new System.Drawing.Size(35, 23);
			this.btn_source.TabIndex = 1;
			this.btn_source.Text = "...";
			this.btn_source.UseVisualStyleBackColor = true;
			this.btn_source.Click += new System.EventHandler(this.btn_source_Click);
			// 
			// txt_targetDir
			// 
			this.txt_targetDir.Location = new System.Drawing.Point(146, 38);
			this.txt_targetDir.Name = "txt_targetDir";
			this.txt_targetDir.Size = new System.Drawing.Size(343, 20);
			this.txt_targetDir.TabIndex = 2;
			// 
			// btn_target
			// 
			this.btn_target.Location = new System.Drawing.Point(505, 38);
			this.btn_target.Name = "btn_target";
			this.btn_target.Size = new System.Drawing.Size(35, 23);
			this.btn_target.TabIndex = 3;
			this.btn_target.Text = "...";
			this.btn_target.UseVisualStyleBackColor = true;
			this.btn_target.Click += new System.EventHandler(this.btn_target_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(143, 130);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(173, 13);
			this.label2.TabIndex = 31;
			this.label2.Text = "Max Size To use Ramdisk (In MB) :";
			// 
			// num_maxSize
			// 
			this.num_maxSize.Location = new System.Drawing.Point(322, 128);
			this.num_maxSize.Name = "num_maxSize";
			this.num_maxSize.Size = new System.Drawing.Size(120, 20);
			this.num_maxSize.TabIndex = 30;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(92, 13);
			this.label1.TabIndex = 32;
			this.label1.Text = "Source Directory :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(89, 13);
			this.label3.TabIndex = 33;
			this.label3.Text = "Target Directory :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 66);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(118, 13);
			this.label4.TabIndex = 35;
			this.label4.Text = "Only if an arg contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(146, 63);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(343, 20);
			this.txt_filter.TabIndex = 34;
			// 
			// chk_useRamDisk
			// 
			this.chk_useRamDisk.AutoSize = true;
			this.chk_useRamDisk.Location = new System.Drawing.Point(314, 100);
			this.chk_useRamDisk.Name = "chk_useRamDisk";
			this.chk_useRamDisk.Size = new System.Drawing.Size(175, 17);
			this.chk_useRamDisk.TabIndex = 36;
			this.chk_useRamDisk.Text = "Use RamDisk Instead of Target";
			this.chk_useRamDisk.UseVisualStyleBackColor = true;
			// 
			// chk_deleteOnExit
			// 
			this.chk_deleteOnExit.AutoSize = true;
			this.chk_deleteOnExit.Location = new System.Drawing.Point(146, 100);
			this.chk_deleteOnExit.Name = "chk_deleteOnExit";
			this.chk_deleteOnExit.Size = new System.Drawing.Size(152, 17);
			this.chk_deleteOnExit.TabIndex = 37;
			this.chk_deleteOnExit.Text = "Delete File After App Close";
			this.chk_deleteOnExit.UseVisualStyleBackColor = true;
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(384, 160);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 39;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(465, 160);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 38;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// CopyFile_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(563, 196);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.chk_deleteOnExit);
			this.Controls.Add(this.chk_useRamDisk);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.num_maxSize);
			this.Controls.Add(this.btn_target);
			this.Controls.Add(this.txt_targetDir);
			this.Controls.Add(this.btn_source);
			this.Controls.Add(this.txt_sourceDir);
			this.Name = "CopyFile_Config";
			this.Text = "CopyFile_Config";
			this.Load += new System.EventHandler(this.CopyFile_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.num_maxSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txt_sourceDir;
		private System.Windows.Forms.Button btn_source;
		private System.Windows.Forms.TextBox txt_targetDir;
		private System.Windows.Forms.Button btn_target;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown num_maxSize;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.CheckBox chk_useRamDisk;
		private System.Windows.Forms.CheckBox chk_deleteOnExit;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
	}
}