namespace BigBoxProfile.EmulatorActions
{
	partial class CopyFile_Task
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lbl_progress = new System.Windows.Forms.Label();
			this.lbl_progressETA = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(110, 157);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(819, 36);
			this.progressBar1.TabIndex = 0;
			// 
			// lbl_progress
			// 
			this.lbl_progress.AutoSize = true;
			this.lbl_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_progress.Location = new System.Drawing.Point(334, 216);
			this.lbl_progress.Name = "lbl_progress";
			this.lbl_progress.Size = new System.Drawing.Size(109, 39);
			this.lbl_progress.TabIndex = 1;
			this.lbl_progress.Text = "label1";
			// 
			// lbl_progressETA
			// 
			this.lbl_progressETA.AutoSize = true;
			this.lbl_progressETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_progressETA.Location = new System.Drawing.Point(334, 267);
			this.lbl_progressETA.Name = "lbl_progressETA";
			this.lbl_progressETA.Size = new System.Drawing.Size(109, 39);
			this.lbl_progressETA.TabIndex = 2;
			this.lbl_progressETA.Text = "label1";
			// 
			// CopyFile_Task
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1208, 475);
			this.Controls.Add(this.lbl_progressETA);
			this.Controls.Add(this.lbl_progress);
			this.Controls.Add(this.progressBar1);
			this.Name = "CopyFile_Task";
			this.Text = "CopyFile_Task";
			this.Load += new System.EventHandler(this.CopyFile_Task_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lbl_progress;
		private System.Windows.Forms.Label lbl_progressETA;
	}
}