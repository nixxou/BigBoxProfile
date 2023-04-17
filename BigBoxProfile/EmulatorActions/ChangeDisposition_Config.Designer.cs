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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeDisposition_Config));
			this.button1 = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.cmb_DispositionList = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_filter_inside_file = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(12, 146);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(285, 24);
			this.button1.TabIndex = 10;
			this.button1.Text = "Create new Screen Disposition based on your current monitor Setup";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(413, 146);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 9;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(494, 146);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 8;
			this.btn_ok.Text = "Save";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// cmb_DispositionList
			// 
			this.cmb_DispositionList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_DispositionList.FormattingEnabled = true;
			this.cmb_DispositionList.Location = new System.Drawing.Point(225, 12);
			this.cmb_DispositionList.Name = "cmb_DispositionList";
			this.cmb_DispositionList.Size = new System.Drawing.Size(344, 21);
			this.cmb_DispositionList.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 13);
			this.label3.TabIndex = 21;
			this.label3.Text = "Only if cmdLine contains :";
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(225, 39);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(344, 20);
			this.txt_filter.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(207, 13);
			this.label1.TabIndex = 23;
			this.label1.Text = "Only if the first file passed as arg contains :";
			// 
			// txt_filter_inside_file
			// 
			this.txt_filter_inside_file.Location = new System.Drawing.Point(225, 65);
			this.txt_filter_inside_file.Name = "txt_filter_inside_file";
			this.txt_filter_inside_file.Size = new System.Drawing.Size(344, 20);
			this.txt_filter_inside_file.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 88);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(419, 13);
			this.label2.TabIndex = 24;
			this.label2.Text = "Beware, this option will do a full text read on the first argument that match an " +
    "existing file";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 20);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(98, 13);
			this.label4.TabIndex = 25;
			this.label4.Text = "Disposition to Use :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 104);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(416, 13);
			this.label5.TabIndex = 26;
			this.label5.Text = "Only use it when are sure that this argument is a text file (like config or xml)," +
    " not a binary";
			// 
			// ChangeDisposition_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 177);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_filter_inside_file);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txt_filter);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.cmb_DispositionList);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ChangeDisposition_Config";
			this.Text = "ChangeDisposition_Config";
			this.Load += new System.EventHandler(this.ChangeDisposition_Config_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.ComboBox cmb_DispositionList;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txt_filter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txt_filter_inside_file;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}