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
			this.lbl_source = new System.Windows.Forms.Label();
			this.lbl_dest = new System.Windows.Forms.Label();
			this.lbl_file = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(79, 176);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(996, 36);
			this.progressBar1.TabIndex = 0;
			// 
			// lbl_progress
			// 
			this.lbl_progress.AutoSize = true;
			this.lbl_progress.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_progress.ForeColor = System.Drawing.Color.White;
			this.lbl_progress.Location = new System.Drawing.Point(72, 256);
			this.lbl_progress.Name = "lbl_progress";
			this.lbl_progress.Size = new System.Drawing.Size(109, 39);
			this.lbl_progress.TabIndex = 1;
			this.lbl_progress.Text = "label1";
			// 
			// lbl_progressETA
			// 
			this.lbl_progressETA.AutoSize = true;
			this.lbl_progressETA.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_progressETA.ForeColor = System.Drawing.Color.White;
			this.lbl_progressETA.Location = new System.Drawing.Point(72, 310);
			this.lbl_progressETA.Name = "lbl_progressETA";
			this.lbl_progressETA.Size = new System.Drawing.Size(109, 39);
			this.lbl_progressETA.TabIndex = 2;
			this.lbl_progressETA.Text = "label1";
			// 
			// lbl_source
			// 
			this.lbl_source.AutoSize = true;
			this.lbl_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_source.ForeColor = System.Drawing.Color.White;
			this.lbl_source.Location = new System.Drawing.Point(75, 76);
			this.lbl_source.Name = "lbl_source";
			this.lbl_source.Size = new System.Drawing.Size(60, 24);
			this.lbl_source.TabIndex = 3;
			this.lbl_source.Text = "label1";
			// 
			// lbl_dest
			// 
			this.lbl_dest.AutoSize = true;
			this.lbl_dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_dest.ForeColor = System.Drawing.Color.White;
			this.lbl_dest.Location = new System.Drawing.Point(75, 112);
			this.lbl_dest.Name = "lbl_dest";
			this.lbl_dest.Size = new System.Drawing.Size(60, 24);
			this.lbl_dest.TabIndex = 4;
			this.lbl_dest.Text = "label2";
			// 
			// lbl_file
			// 
			this.lbl_file.AutoSize = true;
			this.lbl_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_file.ForeColor = System.Drawing.Color.White;
			this.lbl_file.Location = new System.Drawing.Point(75, 22);
			this.lbl_file.Name = "lbl_file";
			this.lbl_file.Size = new System.Drawing.Size(109, 39);
			this.lbl_file.TabIndex = 5;
			this.lbl_file.Text = "label1";
			// 
			// CopyFile_Task
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1166, 385);
			this.Controls.Add(this.lbl_file);
			this.Controls.Add(this.lbl_dest);
			this.Controls.Add(this.lbl_source);
			this.Controls.Add(this.lbl_progressETA);
			this.Controls.Add(this.lbl_progress);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
		private System.Windows.Forms.Label lbl_source;
		private System.Windows.Forms.Label lbl_dest;
		private System.Windows.Forms.Label lbl_file;
	}
}