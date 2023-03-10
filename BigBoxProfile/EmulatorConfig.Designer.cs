namespace BigBoxProfile
{
	partial class EmulatorConfig
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmulatorConfig));
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.btn_delete = new System.Windows.Forms.Button();
			this.btn_down = new System.Windows.Forms.Button();
			this.btn_up = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_exempleOut = new System.Windows.Forms.TextBox();
			this.txt_exempleIn = new System.Windows.Forms.TextBox();
			this.lv_selectedActions = new System.Windows.Forms.ListView();
			this.NameModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_add = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.cmb_selectAction = new System.Windows.Forms.ComboBox();
			this.txt_emulatorExe = new System.Windows.Forms.TextBox();
			this.txt_profileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.btn_delete);
			this.groupBox3.Controls.Add(this.btn_down);
			this.groupBox3.Controls.Add(this.btn_up);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.label3);
			this.groupBox3.Controls.Add(this.txt_exempleOut);
			this.groupBox3.Controls.Add(this.txt_exempleIn);
			this.groupBox3.Controls.Add(this.lv_selectedActions);
			this.groupBox3.Controls.Add(this.btn_save);
			this.groupBox3.Controls.Add(this.btn_add);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.cmb_selectAction);
			this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(12, 77);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(648, 512);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Modify Emulators cmd";
			this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
			// 
			// btn_delete
			// 
			this.btn_delete.Enabled = false;
			this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_delete.Location = new System.Drawing.Point(556, 269);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(75, 21);
			this.btn_delete.TabIndex = 5;
			this.btn_delete.Text = "Delete";
			this.btn_delete.UseVisualStyleBackColor = true;
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// btn_down
			// 
			this.btn_down.Enabled = false;
			this.btn_down.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_down.Location = new System.Drawing.Point(556, 240);
			this.btn_down.Name = "btn_down";
			this.btn_down.Size = new System.Drawing.Size(75, 23);
			this.btn_down.TabIndex = 4;
			this.btn_down.Text = "Down";
			this.btn_down.UseVisualStyleBackColor = true;
			this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
			// 
			// btn_up
			// 
			this.btn_up.Enabled = false;
			this.btn_up.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_up.Location = new System.Drawing.Point(556, 211);
			this.btn_up.Name = "btn_up";
			this.btn_up.Size = new System.Drawing.Size(75, 23);
			this.btn_up.TabIndex = 3;
			this.btn_up.Text = "Up";
			this.btn_up.UseVisualStyleBackColor = true;
			this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(19, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(130, 13);
			this.label4.TabIndex = 19;
			this.label4.Text = "Emulator Command OUT :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(19, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(118, 13);
			this.label3.TabIndex = 18;
			this.label3.Text = "Exemple Command IN :";
			// 
			// txt_exempleOut
			// 
			this.txt_exempleOut.Location = new System.Drawing.Point(155, 75);
			this.txt_exempleOut.Name = "txt_exempleOut";
			this.txt_exempleOut.ReadOnly = true;
			this.txt_exempleOut.Size = new System.Drawing.Size(382, 21);
			this.txt_exempleOut.TabIndex = 30;
			// 
			// txt_exempleIn
			// 
			this.txt_exempleIn.Location = new System.Drawing.Point(155, 46);
			this.txt_exempleIn.Name = "txt_exempleIn";
			this.txt_exempleIn.Size = new System.Drawing.Size(382, 21);
			this.txt_exempleIn.TabIndex = 2;
			this.txt_exempleIn.TextChanged += new System.EventHandler(this.txt_exempleIn_TextChanged);
			// 
			// lv_selectedActions
			// 
			this.lv_selectedActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameModule});
			this.lv_selectedActions.HideSelection = false;
			this.lv_selectedActions.Location = new System.Drawing.Point(22, 98);
			this.lv_selectedActions.Name = "lv_selectedActions";
			this.lv_selectedActions.Size = new System.Drawing.Size(528, 394);
			this.lv_selectedActions.TabIndex = 6;
			this.lv_selectedActions.UseCompatibleStateImageBehavior = false;
			this.lv_selectedActions.View = System.Windows.Forms.View.Details;
			this.lv_selectedActions.SelectedIndexChanged += new System.EventHandler(this.lv_selectedActions_SelectedIndexChanged);
			// 
			// NameModule
			// 
			this.NameModule.Text = "Name";
			this.NameModule.Width = 521;
			// 
			// btn_save
			// 
			this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_save.Location = new System.Drawing.Point(556, 466);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(86, 26);
			this.btn_save.TabIndex = 6;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.button8_Click);
			// 
			// btn_add
			// 
			this.btn_add.Enabled = false;
			this.btn_add.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btn_add.Location = new System.Drawing.Point(347, 19);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(36, 23);
			this.btn_add.TabIndex = 1;
			this.btn_add.Text = "Add";
			this.btn_add.UseVisualStyleBackColor = true;
			this.btn_add.Click += new System.EventHandler(this.button6_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(19, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(69, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Select Action";
			// 
			// cmb_selectAction
			// 
			this.cmb_selectAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_selectAction.FormattingEnabled = true;
			this.cmb_selectAction.Location = new System.Drawing.Point(155, 19);
			this.cmb_selectAction.Name = "cmb_selectAction";
			this.cmb_selectAction.Size = new System.Drawing.Size(186, 21);
			this.cmb_selectAction.TabIndex = 0;
			this.cmb_selectAction.SelectedIndexChanged += new System.EventHandler(this.cmb_selectAction_SelectedIndexChanged);
			// 
			// txt_emulatorExe
			// 
			this.txt_emulatorExe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_emulatorExe.Location = new System.Drawing.Point(115, 12);
			this.txt_emulatorExe.Name = "txt_emulatorExe";
			this.txt_emulatorExe.ReadOnly = true;
			this.txt_emulatorExe.Size = new System.Drawing.Size(238, 21);
			this.txt_emulatorExe.TabIndex = 14;
			// 
			// txt_profileName
			// 
			this.txt_profileName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_profileName.Location = new System.Drawing.Point(115, 38);
			this.txt_profileName.Name = "txt_profileName";
			this.txt_profileName.ReadOnly = true;
			this.txt_profileName.Size = new System.Drawing.Size(238, 21);
			this.txt_profileName.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 13);
			this.label1.TabIndex = 16;
			this.label1.Text = "Emulator Exe File :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(9, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 17;
			this.label2.Text = "BigBox Profile :";
			// 
			// EmulatorConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(672, 597);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txt_profileName);
			this.Controls.Add(this.txt_emulatorExe);
			this.Controls.Add(this.groupBox3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EmulatorConfig";
			this.Text = "Emulator Hijacking : Edit commandline send to Emulators";
			this.Load += new System.EventHandler(this.EmulatorConfig_Load);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmb_selectAction;
		private System.Windows.Forms.TextBox txt_emulatorExe;
		private System.Windows.Forms.TextBox txt_profileName;
		private System.Windows.Forms.ListView lv_selectedActions;
		private System.Windows.Forms.ColumnHeader NameModule;
		private System.Windows.Forms.TextBox txt_exempleOut;
		private System.Windows.Forms.TextBox txt_exempleIn;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.Button btn_down;
		private System.Windows.Forms.Button btn_up;
	}
}