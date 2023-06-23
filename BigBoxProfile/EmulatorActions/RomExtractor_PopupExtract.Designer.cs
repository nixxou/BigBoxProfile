namespace BigBoxProfile.EmulatorActions
{
	partial class RomExtractor_PopupExtract
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
			this.lbl_file = new System.Windows.Forms.Label();
			this.lbl_selected = new System.Windows.Forms.Label();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btn_ok = new System.Windows.Forms.Button();
			this.lbl_progress = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl_file
			// 
			this.lbl_file.AutoSize = true;
			this.lbl_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_file.ForeColor = System.Drawing.Color.Black;
			this.lbl_file.Location = new System.Drawing.Point(20, 11);
			this.lbl_file.Name = "lbl_file";
			this.lbl_file.Size = new System.Drawing.Size(60, 24);
			this.lbl_file.TabIndex = 10;
			this.lbl_file.Text = "label1";
			// 
			// lbl_selected
			// 
			this.lbl_selected.AutoSize = true;
			this.lbl_selected.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_selected.ForeColor = System.Drawing.Color.Black;
			this.lbl_selected.Location = new System.Drawing.Point(21, 52);
			this.lbl_selected.Name = "lbl_selected";
			this.lbl_selected.Size = new System.Drawing.Size(46, 18);
			this.lbl_selected.TabIndex = 9;
			this.lbl_selected.Text = "label1";
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(12, 91);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(656, 36);
			this.progressBar1.TabIndex = 8;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(554, 156);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(114, 36);
			this.btn_ok.TabIndex = 11;
			this.btn_ok.Text = "Ok";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// lbl_progress
			// 
			this.lbl_progress.AutoSize = true;
			this.lbl_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_progress.ForeColor = System.Drawing.Color.Black;
			this.lbl_progress.Location = new System.Drawing.Point(12, 147);
			this.lbl_progress.Name = "lbl_progress";
			this.lbl_progress.Size = new System.Drawing.Size(109, 39);
			this.lbl_progress.TabIndex = 12;
			this.lbl_progress.Text = "label1";
			// 
			// RomExtractor_PopupExtract
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(686, 206);
			this.Controls.Add(this.lbl_progress);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.lbl_file);
			this.Controls.Add(this.lbl_selected);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "RomExtractor_PopupExtract";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "RomExtractor_PopupExtract";
			this.Load += new System.EventHandler(this.RomExtractor_PopupExtract_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_file;
		private System.Windows.Forms.Label lbl_selected;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label lbl_progress;
	}
}