namespace BigBoxProfile
{
	partial class MonitorDispositionConfig
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorDispositionConfig));
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.cmb_DispositionList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.button1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.cmb_DispositionList)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(349, 12);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 5;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(430, 12);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 4;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// cmb_DispositionList
			// 
			this.cmb_DispositionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_DispositionList.DropDownWidth = 331;
			this.cmb_DispositionList.FormattingEnabled = true;
			this.cmb_DispositionList.Location = new System.Drawing.Point(12, 14);
			this.cmb_DispositionList.Name = "cmb_DispositionList";
			this.cmb_DispositionList.Size = new System.Drawing.Size(331, 21);
			this.cmb_DispositionList.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 41);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(493, 31);
			this.button1.TabIndex = 6;
			this.button1.Values.Text = "Create new Screen Disposition based on your current monitor Setup";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MonitorDispositionConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(521, 85);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.cmb_DispositionList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MonitorDispositionConfig";
			this.Text = "Monitor Disposition : Select or Register Monitor Layouts";
			this.Load += new System.EventHandler(this.MonitorDispositionConfig_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmb_DispositionList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_DispositionList;
		private ComponentFactory.Krypton.Toolkit.KryptonButton button1;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}