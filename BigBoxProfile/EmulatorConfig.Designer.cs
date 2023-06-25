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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmulatorConfig));
			this.groupBox3 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.btn_delete = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label4 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.txt_exempleOut = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_exempleIn = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.lv_selectedActions = new System.Windows.Forms.ListView();
			this.NameModule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_save = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.label7 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.cmb_selectAction = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
			this.txt_emulatorExe = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.txt_profileName = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_ApplyWithoutLaunchbox = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			((System.ComponentModel.ISupportInitialize)(this.groupBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).BeginInit();
			this.groupBox3.Panel.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.cmb_selectAction)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox3
			// 
			this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.Location = new System.Drawing.Point(12, 96);
			this.groupBox3.Name = "groupBox3";
			// 
			// groupBox3.Panel
			// 
			this.groupBox3.Panel.Controls.Add(this.btn_delete);
			this.groupBox3.Panel.Controls.Add(this.btn_down);
			this.groupBox3.Panel.Controls.Add(this.btn_up);
			this.groupBox3.Panel.Controls.Add(this.label4);
			this.groupBox3.Panel.Controls.Add(this.label3);
			this.groupBox3.Panel.Controls.Add(this.txt_exempleOut);
			this.groupBox3.Panel.Controls.Add(this.txt_exempleIn);
			this.groupBox3.Panel.Controls.Add(this.lv_selectedActions);
			this.groupBox3.Panel.Controls.Add(this.btn_save);
			this.groupBox3.Panel.Controls.Add(this.btn_add);
			this.groupBox3.Panel.Controls.Add(this.label7);
			this.groupBox3.Panel.Controls.Add(this.cmb_selectAction);
			this.groupBox3.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox3_Panel_Paint);
			this.groupBox3.Size = new System.Drawing.Size(882, 537);
			this.groupBox3.TabIndex = 13;
			this.groupBox3.Values.Heading = "Modify Emulators cmd";
			this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
			// 
			// btn_delete
			// 
			this.btn_delete.Enabled = false;
			this.btn_delete.Location = new System.Drawing.Point(789, 269);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(75, 24);
			this.btn_delete.TabIndex = 5;
			this.btn_delete.Values.Text = "Delete";
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// btn_down
			// 
			this.btn_down.Enabled = false;
			this.btn_down.Location = new System.Drawing.Point(789, 240);
			this.btn_down.Name = "btn_down";
			this.btn_down.Size = new System.Drawing.Size(75, 24);
			this.btn_down.TabIndex = 4;
			this.btn_down.Values.Text = "Down";
			this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
			// 
			// btn_up
			// 
			this.btn_up.Enabled = false;
			this.btn_up.Location = new System.Drawing.Point(789, 211);
			this.btn_up.Name = "btn_up";
			this.btn_up.Size = new System.Drawing.Size(75, 24);
			this.btn_up.TabIndex = 3;
			this.btn_up.Values.Text = "Up";
			this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(19, 75);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(153, 20);
			this.label4.TabIndex = 19;
			this.label4.Values.Text = "Emulator Command OUT :";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(19, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(138, 20);
			this.label3.TabIndex = 18;
			this.label3.Values.Text = "Exemple Command IN :";
			// 
			// txt_exempleOut
			// 
			this.txt_exempleOut.Location = new System.Drawing.Point(178, 75);
			this.txt_exempleOut.Name = "txt_exempleOut";
			this.txt_exempleOut.ReadOnly = true;
			this.txt_exempleOut.Size = new System.Drawing.Size(602, 23);
			this.txt_exempleOut.TabIndex = 30;
			// 
			// txt_exempleIn
			// 
			this.txt_exempleIn.Location = new System.Drawing.Point(178, 46);
			this.txt_exempleIn.Name = "txt_exempleIn";
			this.txt_exempleIn.Size = new System.Drawing.Size(602, 23);
			this.txt_exempleIn.TabIndex = 2;
			this.txt_exempleIn.TextChanged += new System.EventHandler(this.txt_exempleIn_TextChanged);
			// 
			// lv_selectedActions
			// 
			this.lv_selectedActions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameModule});
			this.lv_selectedActions.HideSelection = false;
			this.lv_selectedActions.Location = new System.Drawing.Point(22, 104);
			this.lv_selectedActions.Name = "lv_selectedActions";
			this.lv_selectedActions.Size = new System.Drawing.Size(758, 394);
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
			this.btn_save.Location = new System.Drawing.Point(789, 472);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 26);
			this.btn_save.TabIndex = 6;
			this.btn_save.Values.Text = "Save";
			this.btn_save.Click += new System.EventHandler(this.button8_Click);
			// 
			// btn_add
			// 
			this.btn_add.Enabled = false;
			this.btn_add.Location = new System.Drawing.Point(370, 17);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(41, 24);
			this.btn_add.TabIndex = 1;
			this.btn_add.Values.Text = "Add";
			this.btn_add.Click += new System.EventHandler(this.button6_Click);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(22, 20);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(81, 20);
			this.label7.TabIndex = 2;
			this.label7.Values.Text = "Select Action";
			// 
			// cmb_selectAction
			// 
			this.cmb_selectAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_selectAction.DropDownWidth = 186;
			this.cmb_selectAction.FormattingEnabled = true;
			this.cmb_selectAction.Location = new System.Drawing.Point(178, 19);
			this.cmb_selectAction.Name = "cmb_selectAction";
			this.cmb_selectAction.Size = new System.Drawing.Size(186, 21);
			this.cmb_selectAction.TabIndex = 0;
			this.cmb_selectAction.SelectedIndexChanged += new System.EventHandler(this.cmb_selectAction_SelectedIndexChanged);
			// 
			// txt_emulatorExe
			// 
			this.txt_emulatorExe.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_emulatorExe.Location = new System.Drawing.Point(124, 12);
			this.txt_emulatorExe.Name = "txt_emulatorExe";
			this.txt_emulatorExe.ReadOnly = true;
			this.txt_emulatorExe.Size = new System.Drawing.Size(238, 23);
			this.txt_emulatorExe.TabIndex = 14;
			// 
			// txt_profileName
			// 
			this.txt_profileName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_profileName.Location = new System.Drawing.Point(124, 41);
			this.txt_profileName.Name = "txt_profileName";
			this.txt_profileName.ReadOnly = true;
			this.txt_profileName.Size = new System.Drawing.Size(238, 23);
			this.txt_profileName.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 20);
			this.label1.TabIndex = 16;
			this.label1.Values.Text = "Emulator Exe File :";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(92, 20);
			this.label2.TabIndex = 17;
			this.label2.Values.Text = "BigBox Profile :";
			// 
			// chk_ApplyWithoutLaunchbox
			// 
			this.chk_ApplyWithoutLaunchbox.Location = new System.Drawing.Point(17, 70);
			this.chk_ApplyWithoutLaunchbox.Name = "chk_ApplyWithoutLaunchbox";
			this.chk_ApplyWithoutLaunchbox.Size = new System.Drawing.Size(308, 20);
			this.chk_ApplyWithoutLaunchbox.TabIndex = 18;
			this.chk_ApplyWithoutLaunchbox.Values.Text = "Apply even if not launch thought Launchbox/Bigbox";
			// 
			// EmulatorConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(906, 654);
			this.Controls.Add(this.chk_ApplyWithoutLaunchbox);
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
			((System.ComponentModel.ISupportInitialize)(this.groupBox3.Panel)).EndInit();
			this.groupBox3.Panel.ResumeLayout(false);
			this.groupBox3.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupBox3)).EndInit();
			this.groupBox3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.cmb_selectAction)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox groupBox3;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_save;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label7;
		private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmb_selectAction;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_emulatorExe;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_profileName;
		private System.Windows.Forms.ListView lv_selectedActions;
		private System.Windows.Forms.ColumnHeader NameModule;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exempleOut;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exempleIn;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label4;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label2;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_ApplyWithoutLaunchbox;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}