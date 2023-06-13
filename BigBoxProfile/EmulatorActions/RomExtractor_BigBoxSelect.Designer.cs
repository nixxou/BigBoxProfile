namespace BigBoxProfile.EmulatorActions
{
	partial class RomExtractor_BigBoxSelect
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
			this.Texture_Label = new System.Windows.Forms.Label();
			this.fakebrowser_txt = new System.Windows.Forms.TextBox();
			this.fileListBox = new System.Windows.Forms.ListBox();
			this.archiveNameLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Texture_Label
			// 
			this.Texture_Label.BackColor = System.Drawing.Color.Black;
			this.Texture_Label.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Texture_Label.ForeColor = System.Drawing.Color.White;
			this.Texture_Label.Location = new System.Drawing.Point(-3, 606);
			this.Texture_Label.Margin = new System.Windows.Forms.Padding(0);
			this.Texture_Label.Name = "Texture_Label";
			this.Texture_Label.Size = new System.Drawing.Size(794, 62);
			this.Texture_Label.TabIndex = 14;
			this.Texture_Label.Text = "3 Hi Res Textures files available !";
			this.Texture_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// fakebrowser_txt
			// 
			this.fakebrowser_txt.Location = new System.Drawing.Point(794, 2);
			this.fakebrowser_txt.Multiline = true;
			this.fakebrowser_txt.Name = "fakebrowser_txt";
			this.fakebrowser_txt.Size = new System.Drawing.Size(635, 666);
			this.fakebrowser_txt.TabIndex = 13;
			this.fakebrowser_txt.Visible = false;
			// 
			// fileListBox
			// 
			this.fileListBox.BackColor = System.Drawing.Color.Black;
			this.fileListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fileListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.fileListBox.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fileListBox.ForeColor = System.Drawing.Color.White;
			this.fileListBox.FormattingEnabled = true;
			this.fileListBox.IntegralHeight = false;
			this.fileListBox.ItemHeight = 44;
			this.fileListBox.Location = new System.Drawing.Point(0, 64);
			this.fileListBox.Margin = new System.Windows.Forms.Padding(0);
			this.fileListBox.Name = "fileListBox";
			this.fileListBox.Size = new System.Drawing.Size(794, 542);
			this.fileListBox.TabIndex = 9;
			this.fileListBox.SelectedIndexChanged += new System.EventHandler(this.fileListBox_SelectedIndexChanged);
			// 
			// archiveNameLabel
			// 
			this.archiveNameLabel.BackColor = System.Drawing.Color.Black;
			this.archiveNameLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.archiveNameLabel.ForeColor = System.Drawing.Color.White;
			this.archiveNameLabel.Location = new System.Drawing.Point(-3, 2);
			this.archiveNameLabel.Margin = new System.Windows.Forms.Padding(0);
			this.archiveNameLabel.Name = "archiveNameLabel";
			this.archiveNameLabel.Size = new System.Drawing.Size(794, 62);
			this.archiveNameLabel.TabIndex = 10;
			this.archiveNameLabel.Text = "Game.zip";
			this.archiveNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// RomExtractor_BigBoxSelect
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(1430, 669);
			this.Controls.Add(this.Texture_Label);
			this.Controls.Add(this.fakebrowser_txt);
			this.Controls.Add(this.fileListBox);
			this.Controls.Add(this.archiveNameLabel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "RomExtractor_BigBoxSelect";
			this.Text = "RomExtractor_BigBoxSelect";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RomExtractor_BigBoxSelect_FormClosing);
			this.Load += new System.EventHandler(this.RomExtractor_BigBoxSelect_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label Texture_Label;
		private System.Windows.Forms.TextBox fakebrowser_txt;
		private System.Windows.Forms.ListBox fileListBox;
		private System.Windows.Forms.Label archiveNameLabel;
	}
}