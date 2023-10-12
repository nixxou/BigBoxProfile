namespace BigBoxProfile.EmulatorActions
{
	partial class PauseMenu_Show
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
			this.fakebrowser_txt = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// fakebrowser_txt
			// 
			this.fakebrowser_txt.Location = new System.Drawing.Point(368, 117);
			this.fakebrowser_txt.Multiline = true;
			this.fakebrowser_txt.Name = "fakebrowser_txt";
			this.fakebrowser_txt.Size = new System.Drawing.Size(319, 231);
			this.fakebrowser_txt.TabIndex = 0;
			// 
			// PauseMenu_Show
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.fakebrowser_txt);
			this.Name = "PauseMenu_Show";
			this.Text = "PauseMenu_Show";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox fakebrowser_txt;
		private System.Windows.Forms.Timer timer1;
	}
}