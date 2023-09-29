namespace BigBoxProfile
{
	partial class Manage_Variables_PopupEdit
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
			this.txt_value = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.txt_regex = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
			this.btn_file = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_file = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.radio_file = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_cmd = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.radio_arg = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
			this.kryptonLabel4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_variableName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.SuspendLayout();
			// 
			// txt_value
			// 
			this.txt_value.Location = new System.Drawing.Point(157, 227);
			this.txt_value.Name = "txt_value";
			this.txt_value.Size = new System.Drawing.Size(560, 126);
			this.txt_value.TabIndex = 136;
			this.txt_value.Text = "";
			// 
			// txt_regex
			// 
			this.txt_regex.Location = new System.Drawing.Point(157, 109);
			this.txt_regex.Name = "txt_regex";
			this.txt_regex.Size = new System.Drawing.Size(560, 102);
			this.txt_regex.TabIndex = 135;
			this.txt_regex.Text = "";
			// 
			// btn_file
			// 
			this.btn_file.Location = new System.Drawing.Point(682, 73);
			this.btn_file.Name = "btn_file";
			this.btn_file.Size = new System.Drawing.Size(35, 24);
			this.btn_file.TabIndex = 134;
			this.btn_file.Values.Text = "...";
			this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
			// 
			// txt_file
			// 
			this.txt_file.Location = new System.Drawing.Point(157, 74);
			this.txt_file.Name = "txt_file";
			this.txt_file.Size = new System.Drawing.Size(519, 23);
			this.txt_file.TabIndex = 133;
			// 
			// radio_file
			// 
			this.radio_file.Location = new System.Drawing.Point(367, 48);
			this.radio_file.Name = "radio_file";
			this.radio_file.Size = new System.Drawing.Size(86, 20);
			this.radio_file.TabIndex = 132;
			this.radio_file.Values.Text = "Specific File";
			// 
			// radio_cmd
			// 
			this.radio_cmd.Location = new System.Drawing.Point(272, 48);
			this.radio_cmd.Name = "radio_cmd";
			this.radio_cmd.Size = new System.Drawing.Size(89, 20);
			this.radio_cmd.TabIndex = 131;
			this.radio_cmd.Values.Text = "the cmdLine";
			// 
			// radio_arg
			// 
			this.radio_arg.Checked = true;
			this.radio_arg.Location = new System.Drawing.Point(160, 48);
			this.radio_arg.Name = "radio_arg";
			this.radio_arg.Size = new System.Drawing.Size(106, 20);
			this.radio_arg.TabIndex = 130;
			this.radio_arg.Values.Text = "Each Argument";
			// 
			// kryptonLabel4
			// 
			this.kryptonLabel4.Location = new System.Drawing.Point(21, 109);
			this.kryptonLabel4.Name = "kryptonLabel4";
			this.kryptonLabel4.Size = new System.Drawing.Size(97, 20);
			this.kryptonLabel4.TabIndex = 129;
			this.kryptonLabel4.Values.Text = "Variable Regex :";
			// 
			// kryptonLabel3
			// 
			this.kryptonLabel3.Location = new System.Drawing.Point(21, 48);
			this.kryptonLabel3.Name = "kryptonLabel3";
			this.kryptonLabel3.Size = new System.Drawing.Size(130, 20);
			this.kryptonLabel3.TabIndex = 128;
			this.kryptonLabel3.Values.Text = "Variable Data Source :";
			// 
			// txt_variableName
			// 
			this.txt_variableName.Location = new System.Drawing.Point(157, 12);
			this.txt_variableName.Name = "txt_variableName";
			this.txt_variableName.Size = new System.Drawing.Size(296, 23);
			this.txt_variableName.TabIndex = 127;
			// 
			// kryptonLabel2
			// 
			this.kryptonLabel2.Location = new System.Drawing.Point(25, 227);
			this.kryptonLabel2.Name = "kryptonLabel2";
			this.kryptonLabel2.Size = new System.Drawing.Size(95, 20);
			this.kryptonLabel2.TabIndex = 126;
			this.kryptonLabel2.Values.Text = "Varibale Value :";
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(23, 15);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(97, 20);
			this.kryptonLabel1.TabIndex = 125;
			this.kryptonLabel1.Values.Text = "Variable Name :";
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(561, 372);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 138;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(642, 372);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 137;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// Manage_Variables_PopupEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(748, 408);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.txt_value);
			this.Controls.Add(this.txt_regex);
			this.Controls.Add(this.btn_file);
			this.Controls.Add(this.txt_file);
			this.Controls.Add(this.radio_file);
			this.Controls.Add(this.radio_cmd);
			this.Controls.Add(this.radio_arg);
			this.Controls.Add(this.kryptonLabel4);
			this.Controls.Add(this.kryptonLabel3);
			this.Controls.Add(this.txt_variableName);
			this.Controls.Add(this.kryptonLabel2);
			this.Controls.Add(this.kryptonLabel1);
			this.Name = "Manage_Variables_PopupEdit";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_value;
		private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox txt_regex;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_file;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_file;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_file;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_cmd;
		private ComponentFactory.Krypton.Toolkit.KryptonRadioButton radio_arg;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_variableName;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
	}
}