namespace BigBoxProfile.EmulatorActions
{
	partial class ChangeDisposition_Config
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeDisposition_Config));
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.cmb_DispositionList = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_filter_inside_file = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label5 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			((System.ComponentModel.ISupportInitialize)(this.cmb_DispositionList)).BeginInit();
			this.SuspendLayout();
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(445, 238);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 9;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(526, 238);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 8;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// cmb_DispositionList
			// 
			this.cmb_DispositionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_DispositionList.DropDownWidth = 344;
			this.cmb_DispositionList.FormattingEnabled = true;
			this.cmb_DispositionList.Location = new System.Drawing.Point(257, 12);
			this.cmb_DispositionList.Name = "cmb_DispositionList";
			this.cmb_DispositionList.Size = new System.Drawing.Size(344, 21);
			this.cmb_DispositionList.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 42);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 21;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(257, 39);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(344, 23);
			this.txt_filter.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 160);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(243, 20);
			this.label1.TabIndex = 23;
			this.label1.Values.Text = "Only if the first file passed as arg contains :";
			// 
			// txt_filter_inside_file
			// 
			this.txt_filter_inside_file.Location = new System.Drawing.Point(257, 157);
			this.txt_filter_inside_file.Name = "txt_filter_inside_file";
			this.txt_filter_inside_file.Size = new System.Drawing.Size(344, 23);
			this.txt_filter_inside_file.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 180);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(499, 20);
			this.label2.TabIndex = 24;
			this.label2.Values.Text = "Beware, this option will do a full text read on the first argument that match an " +
    "existing file";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 13);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 20);
			this.label4.TabIndex = 25;
			this.label4.Values.Text = "Disposition to Use :";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(9, 196);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(493, 20);
			this.label5.TabIndex = 26;
			this.label5.Values.Text = "Only use it when are sure that this argument is a text file (like config or xml)," +
    " not a binary";
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(257, 62);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 27;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(510, 63);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 28;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(12, 104);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 30;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(257, 101);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(344, 23);
			this.txt_exclude.TabIndex = 29;
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(510, 125);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 32;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(257, 125);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 31;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(257, 81);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 33;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			// 
			// ChangeDisposition_Config
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(616, 271);
			this.Controls.Add(this.chk_filter_remove);
			this.Controls.Add(this.btn_manage_exclude);
			this.Controls.Add(this.chk_exclude_comma);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txt_exclude);
			this.Controls.Add(this.btn_manage_filter);
			this.Controls.Add(this.chk_filter_comma);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_filter_inside_file);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.cmb_DispositionList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChangeDisposition_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Configuration Module : Change Disposition";
			this.Load += new System.EventHandler(this.ChangeDisposition_Config_Load);
			((System.ComponentModel.ISupportInitialize)(this.cmb_DispositionList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_DispositionList;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter_inside_file;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label5;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
	}
}