namespace BigBoxProfile.EmulatorActions
{
	partial class HidDeviceDetector_PopupEdit
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
			this.chk_addDevXinput = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_addDevBT = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_addDevDS4Lib = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_addDevHIDSharp = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonLabel12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel10 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel9 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.cmb_addDevType = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.txt_addDevSuffix = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_addDevRegex = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			((System.ComponentModel.ISupportInitialize)(this.cmb_addDevType)).BeginInit();
			this.SuspendLayout();
			// 
			// chk_addDevXinput
			// 
			this.chk_addDevXinput.Location = new System.Drawing.Point(454, 94);
			this.chk_addDevXinput.Name = "chk_addDevXinput";
			this.chk_addDevXinput.Size = new System.Drawing.Size(83, 20);
			this.chk_addDevXinput.TabIndex = 129;
			this.chk_addDevXinput.Values.Text = "Use XInput";
			// 
			// chk_addDevBT
			// 
			this.chk_addDevBT.Location = new System.Drawing.Point(304, 94);
			this.chk_addDevBT.Name = "chk_addDevBT";
			this.chk_addDevBT.Size = new System.Drawing.Size(144, 20);
			this.chk_addDevBT.TabIndex = 128;
			this.chk_addDevBT.Values.Text = "Use Bluetooth (Slow !)";
			// 
			// chk_addDevDS4Lib
			// 
			this.chk_addDevDS4Lib.Location = new System.Drawing.Point(213, 94);
			this.chk_addDevDS4Lib.Name = "chk_addDevDS4Lib";
			this.chk_addDevDS4Lib.Size = new System.Drawing.Size(85, 20);
			this.chk_addDevDS4Lib.TabIndex = 127;
			this.chk_addDevDS4Lib.Values.Text = "Use DS4Lib";
			// 
			// chk_addDevHIDSharp
			// 
			this.chk_addDevHIDSharp.Location = new System.Drawing.Point(108, 94);
			this.chk_addDevHIDSharp.Name = "chk_addDevHIDSharp";
			this.chk_addDevHIDSharp.Size = new System.Drawing.Size(99, 20);
			this.chk_addDevHIDSharp.TabIndex = 126;
			this.chk_addDevHIDSharp.Values.Text = "Use HIDSharp";
			// 
			// kryptonLabel12
			// 
			this.kryptonLabel12.Location = new System.Drawing.Point(2, 93);
			this.kryptonLabel12.Name = "kryptonLabel12";
			this.kryptonLabel12.Size = new System.Drawing.Size(93, 20);
			this.kryptonLabel12.TabIndex = 125;
			this.kryptonLabel12.Values.Text = "Search Library :";
			// 
			// kryptonLabel11
			// 
			this.kryptonLabel11.Location = new System.Drawing.Point(4, 67);
			this.kryptonLabel11.Name = "kryptonLabel11";
			this.kryptonLabel11.Size = new System.Drawing.Size(82, 20);
			this.kryptonLabel11.TabIndex = 124;
			this.kryptonLabel11.Values.Text = "Device Type :";
			// 
			// kryptonLabel10
			// 
			this.kryptonLabel10.Location = new System.Drawing.Point(4, 41);
			this.kryptonLabel10.Name = "kryptonLabel10";
			this.kryptonLabel10.Size = new System.Drawing.Size(69, 20);
			this.kryptonLabel10.TabIndex = 123;
			this.kryptonLabel10.Values.Text = "Suffix Arg :";
			// 
			// kryptonLabel9
			// 
			this.kryptonLabel9.Location = new System.Drawing.Point(4, 15);
			this.kryptonLabel9.Name = "kryptonLabel9";
			this.kryptonLabel9.Size = new System.Drawing.Size(50, 20);
			this.kryptonLabel9.TabIndex = 122;
			this.kryptonLabel9.Values.Text = "Regex :";
			// 
			// cmb_addDevType
			// 
			this.cmb_addDevType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_addDevType.DropDownWidth = 464;
			this.cmb_addDevType.Location = new System.Drawing.Point(108, 67);
			this.cmb_addDevType.Name = "cmb_addDevType";
			this.cmb_addDevType.Size = new System.Drawing.Size(464, 21);
			this.cmb_addDevType.TabIndex = 120;
			// 
			// txt_addDevSuffix
			// 
			this.txt_addDevSuffix.Location = new System.Drawing.Point(108, 38);
			this.txt_addDevSuffix.Name = "txt_addDevSuffix";
			this.txt_addDevSuffix.Size = new System.Drawing.Size(464, 23);
			this.txt_addDevSuffix.TabIndex = 119;
			// 
			// txt_addDevRegex
			// 
			this.txt_addDevRegex.Location = new System.Drawing.Point(108, 12);
			this.txt_addDevRegex.Name = "txt_addDevRegex";
			this.txt_addDevRegex.Size = new System.Drawing.Size(464, 23);
			this.txt_addDevRegex.TabIndex = 118;
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(416, 120);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 131;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(497, 120);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 130;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// HidDeviceDetector_PopupEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(605, 158);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.chk_addDevXinput);
			this.Controls.Add(this.chk_addDevBT);
			this.Controls.Add(this.chk_addDevDS4Lib);
			this.Controls.Add(this.chk_addDevHIDSharp);
			this.Controls.Add(this.kryptonLabel12);
			this.Controls.Add(this.kryptonLabel11);
			this.Controls.Add(this.kryptonLabel10);
			this.Controls.Add(this.kryptonLabel9);
			this.Controls.Add(this.cmb_addDevType);
			this.Controls.Add(this.txt_addDevSuffix);
			this.Controls.Add(this.txt_addDevRegex);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "HidDeviceDetector_PopupEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Hid Device Matcher";
			this.Load += new System.EventHandler(this.HidDeviceDetector_PopupEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmb_addDevType)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_addDevXinput;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_addDevBT;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_addDevDS4Lib;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_addDevHIDSharp;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel12;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel11;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel10;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel9;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_addDevType;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_addDevSuffix;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_addDevRegex;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
	}
}