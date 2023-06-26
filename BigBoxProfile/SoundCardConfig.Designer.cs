namespace BigBoxProfile
{
	partial class SoundCardConfig
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoundCardConfig));
			this.cmb_SoundCardList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.cmb_SoundCardList)).BeginInit();
			this.SuspendLayout();
			// 
			// cmb_SoundCardList
			// 
			this.cmb_SoundCardList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_SoundCardList.DropDownWidth = 331;
			this.cmb_SoundCardList.FormattingEnabled = true;
			this.cmb_SoundCardList.Location = new System.Drawing.Point(12, 12);
			this.cmb_SoundCardList.Name = "cmb_SoundCardList";
			this.cmb_SoundCardList.Size = new System.Drawing.Size(331, 21);
			this.cmb_SoundCardList.TabIndex = 0;
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(430, 10);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 1;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(349, 10);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 2;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// SoundCardConfig
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(517, 46);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.cmb_SoundCardList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SoundCardConfig";
			this.Text = "Select Sound Card to use as Main Soundcard";
			this.Load += new System.EventHandler(this.SoundCardConfig_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmb_SoundCardList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_SoundCardList;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
	}
}