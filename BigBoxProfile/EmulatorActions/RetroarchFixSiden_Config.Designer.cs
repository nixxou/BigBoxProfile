namespace BigBoxProfile.EmulatorActions
{
	partial class RetroarchFixSiden_Config
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetroarchFixSiden_Config));
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btn_manage_exclude = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_filter = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_filter_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_manage_filter = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_exclude = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.label6 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.chk_exclude_comma = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.chk_filter_remove = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonGroupBox1 = new ComponentFactory.Krypton.Toolkit.KryptonGroupBox();
			this.infoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label11 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.label12 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.list_priority = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_priority = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_delete_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_priority = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.txt_priority_res = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.chk_forceDefaultNoFilter = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.txt_showMouse = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_showMouse = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.chk_forceDefaultNoMatch = new ComponentFactory.Krypton.Toolkit.KryptonCheckBox();
			this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
			this.kryptonGroupBox1.Panel.SuspendLayout();
			this.kryptonGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chk_forceDefaultNoFilter);
			this.groupBox2.Controls.Add(this.btn_manage_exclude);
			this.groupBox2.Controls.Add(this.txt_filter);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.chk_filter_comma);
			this.groupBox2.Controls.Add(this.btn_manage_filter);
			this.groupBox2.Controls.Add(this.txt_exclude);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.chk_exclude_comma);
			this.groupBox2.Controls.Add(this.chk_filter_remove);
			this.groupBox2.Location = new System.Drawing.Point(12, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(717, 190);
			this.groupBox2.TabIndex = 96;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Filters";
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// btn_manage_exclude
			// 
			this.btn_manage_exclude.Location = new System.Drawing.Point(541, 112);
			this.btn_manage_exclude.Name = "btn_manage_exclude";
			this.btn_manage_exclude.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_exclude.TabIndex = 78;
			this.btn_manage_exclude.Values.Text = "Manage Items";
			this.btn_manage_exclude.Click += new System.EventHandler(this.btn_manage_exclude_Click);
			// 
			// txt_filter
			// 
			this.txt_filter.Location = new System.Drawing.Point(190, 16);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(442, 23);
			this.txt_filter.TabIndex = 18;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(17, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(150, 20);
			this.label3.TabIndex = 19;
			this.label3.Values.Text = "Only if cmdLine contains :";
			// 
			// chk_filter_comma
			// 
			this.chk_filter_comma.Location = new System.Drawing.Point(190, 45);
			this.chk_filter_comma.Name = "chk_filter_comma";
			this.chk_filter_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_filter_comma.TabIndex = 73;
			this.chk_filter_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_filter_comma.CheckedChanged += new System.EventHandler(this.chk_filter_comma_CheckedChanged);
			// 
			// btn_manage_filter
			// 
			this.btn_manage_filter.Location = new System.Drawing.Point(541, 45);
			this.btn_manage_filter.Name = "btn_manage_filter";
			this.btn_manage_filter.Size = new System.Drawing.Size(91, 24);
			this.btn_manage_filter.TabIndex = 74;
			this.btn_manage_filter.Values.Text = "Manage Items";
			this.btn_manage_filter.Click += new System.EventHandler(this.btn_manage_filter_Click);
			// 
			// txt_exclude
			// 
			this.txt_exclude.Location = new System.Drawing.Point(190, 83);
			this.txt_exclude.Name = "txt_exclude";
			this.txt_exclude.Size = new System.Drawing.Size(442, 23);
			this.txt_exclude.TabIndex = 75;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(17, 86);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(167, 20);
			this.label6.TabIndex = 76;
			this.label6.Values.Text = "Exclude if cmdLine contains :";
			// 
			// chk_exclude_comma
			// 
			this.chk_exclude_comma.Location = new System.Drawing.Point(190, 112);
			this.chk_exclude_comma.Name = "chk_exclude_comma";
			this.chk_exclude_comma.Size = new System.Drawing.Size(255, 20);
			this.chk_exclude_comma.TabIndex = 77;
			this.chk_exclude_comma.Values.Text = "Enable Multiple Entries, Comma Separated";
			this.chk_exclude_comma.CheckedChanged += new System.EventHandler(this.chk_exclude_comma_CheckedChanged);
			// 
			// chk_filter_remove
			// 
			this.chk_filter_remove.Location = new System.Drawing.Point(190, 62);
			this.chk_filter_remove.Name = "chk_filter_remove";
			this.chk_filter_remove.Size = new System.Drawing.Size(237, 20);
			this.chk_filter_remove.TabIndex = 86;
			this.chk_filter_remove.Values.Text = "If match an arg, remove before execute";
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(569, 918);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 98;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(654, 918);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 97;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// kryptonGroupBox1
			// 
			this.kryptonGroupBox1.Location = new System.Drawing.Point(18, 201);
			this.kryptonGroupBox1.Name = "kryptonGroupBox1";
			// 
			// kryptonGroupBox1.Panel
			// 
			this.kryptonGroupBox1.Panel.Controls.Add(this.chk_forceDefaultNoMatch);
			this.kryptonGroupBox1.Panel.Controls.Add(this.infoLabel);
			this.kryptonGroupBox1.Panel.Controls.Add(this.label11);
			this.kryptonGroupBox1.Panel.Controls.Add(this.label12);
			this.kryptonGroupBox1.Panel.Controls.Add(this.list_priority);
			this.kryptonGroupBox1.Panel.Controls.Add(this.txt_priority);
			this.kryptonGroupBox1.Panel.Controls.Add(this.btn_delete_priority);
			this.kryptonGroupBox1.Panel.Controls.Add(this.btn_add_priority);
			this.kryptonGroupBox1.Panel.Controls.Add(this.btn_down_priority);
			this.kryptonGroupBox1.Panel.Controls.Add(this.btn_up_priority);
			this.kryptonGroupBox1.Panel.Controls.Add(this.txt_priority_res);
			this.kryptonGroupBox1.Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonGroupBox1_Panel_Paint);
			this.kryptonGroupBox1.Size = new System.Drawing.Size(711, 509);
			this.kryptonGroupBox1.TabIndex = 99;
			this.kryptonGroupBox1.Values.Heading = "Priority List";
			// 
			// infoLabel
			// 
			this.infoLabel.AutoSize = false;
			this.infoLabel.Location = new System.Drawing.Point(9, 3);
			this.infoLabel.Name = "infoLabel";
			this.infoLabel.Size = new System.Drawing.Size(684, 109);
			this.infoLabel.TabIndex = 34;
			this.infoLabel.Values.Text = resources.GetString("infoLabel.Values.Text");
			this.infoLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.infoLabel_Paint);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(9, 199);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(208, 20);
			this.label11.TabIndex = 30;
			this.label11.Values.Text = "Or you can add and edit them here :";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(9, 149);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(164, 20);
			this.label12.TabIndex = 29;
			this.label12.Values.Text = "Priority list (separate with ,) :";
			this.label12.Paint += new System.Windows.Forms.PaintEventHandler(this.label12_Paint);
			// 
			// list_priority
			// 
			this.list_priority.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.list_priority.HideSelection = false;
			this.list_priority.Location = new System.Drawing.Point(9, 250);
			this.list_priority.MultiSelect = false;
			this.list_priority.Name = "list_priority";
			this.list_priority.Size = new System.Drawing.Size(635, 221);
			this.list_priority.TabIndex = 19;
			this.list_priority.UseCompatibleStateImageBehavior = false;
			this.list_priority.View = System.Windows.Forms.View.Details;
			this.list_priority.SelectedIndexChanged += new System.EventHandler(this.list_priority_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 626;
			// 
			// txt_priority
			// 
			this.txt_priority.Location = new System.Drawing.Point(9, 219);
			this.txt_priority.Name = "txt_priority";
			this.txt_priority.Size = new System.Drawing.Size(635, 23);
			this.txt_priority.TabIndex = 21;
			// 
			// btn_delete_priority
			// 
			this.btn_delete_priority.Enabled = false;
			this.btn_delete_priority.Location = new System.Drawing.Point(650, 383);
			this.btn_delete_priority.Name = "btn_delete_priority";
			this.btn_delete_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_delete_priority.TabIndex = 27;
			this.btn_delete_priority.Values.Text = "Delete";
			this.btn_delete_priority.Click += new System.EventHandler(this.btn_delete_priority_Click);
			// 
			// btn_add_priority
			// 
			this.btn_add_priority.Location = new System.Drawing.Point(650, 217);
			this.btn_add_priority.Name = "btn_add_priority";
			this.btn_add_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_add_priority.TabIndex = 23;
			this.btn_add_priority.Values.Text = "Add";
			this.btn_add_priority.Click += new System.EventHandler(this.btn_add_priority_Click);
			// 
			// btn_down_priority
			// 
			this.btn_down_priority.Enabled = false;
			this.btn_down_priority.Location = new System.Drawing.Point(650, 353);
			this.btn_down_priority.Name = "btn_down_priority";
			this.btn_down_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_down_priority.TabIndex = 26;
			this.btn_down_priority.Values.Text = "Down";
			this.btn_down_priority.Click += new System.EventHandler(this.btn_down_priority_Click);
			// 
			// btn_up_priority
			// 
			this.btn_up_priority.Enabled = false;
			this.btn_up_priority.Location = new System.Drawing.Point(650, 323);
			this.btn_up_priority.Name = "btn_up_priority";
			this.btn_up_priority.Size = new System.Drawing.Size(46, 24);
			this.btn_up_priority.TabIndex = 25;
			this.btn_up_priority.Values.Text = "Up";
			this.btn_up_priority.Click += new System.EventHandler(this.btn_up_priority_Click);
			// 
			// txt_priority_res
			// 
			this.txt_priority_res.Location = new System.Drawing.Point(9, 170);
			this.txt_priority_res.Name = "txt_priority_res";
			this.txt_priority_res.Size = new System.Drawing.Size(687, 23);
			this.txt_priority_res.TabIndex = 7;
			this.txt_priority_res.TextChanged += new System.EventHandler(this.txt_priority_res_TextChanged);
			this.txt_priority_res.Leave += new System.EventHandler(this.txt_priority_res_Leave);
			// 
			// chk_forceDefaultNoFilter
			// 
			this.chk_forceDefaultNoFilter.AutoSize = false;
			this.chk_forceDefaultNoFilter.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.TitleControl;
			this.chk_forceDefaultNoFilter.Location = new System.Drawing.Point(17, 138);
			this.chk_forceDefaultNoFilter.Name = "chk_forceDefaultNoFilter";
			this.chk_forceDefaultNoFilter.Size = new System.Drawing.Size(714, 45);
			this.chk_forceDefaultNoFilter.TabIndex = 87;
			this.chk_forceDefaultNoFilter.Values.Text = "Set Input Driver to DINPUT AND Mouse Index to Default if filters don\'t match";
			// 
			// txt_showMouse
			// 
			this.txt_showMouse.Location = new System.Drawing.Point(18, 740);
			this.txt_showMouse.Multiline = true;
			this.txt_showMouse.Name = "txt_showMouse";
			this.txt_showMouse.Size = new System.Drawing.Size(626, 142);
			this.txt_showMouse.TabIndex = 100;
			this.txt_showMouse.Text = "kryptonTextBox1";
			this.txt_showMouse.TextChanged += new System.EventHandler(this.txt_showMouse_TextChanged);
			// 
			// btn_showMouse
			// 
			this.btn_showMouse.Location = new System.Drawing.Point(650, 740);
			this.btn_showMouse.Name = "btn_showMouse";
			this.btn_showMouse.Size = new System.Drawing.Size(79, 142);
			this.btn_showMouse.TabIndex = 101;
			this.btn_showMouse.Values.Text = "Show\r\nYour\r\nCurrent\r\nMouse\r\nOrder";
			this.btn_showMouse.Click += new System.EventHandler(this.btn_showMouse_Click);
			// 
			// chk_forceDefaultNoMatch
			// 
			this.chk_forceDefaultNoMatch.AutoSize = false;
			this.chk_forceDefaultNoMatch.LabelStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.BoldControl;
			this.chk_forceDefaultNoMatch.Location = new System.Drawing.Point(9, 107);
			this.chk_forceDefaultNoMatch.Name = "chk_forceDefaultNoMatch";
			this.chk_forceDefaultNoMatch.Size = new System.Drawing.Size(541, 36);
			this.chk_forceDefaultNoMatch.TabIndex = 88;
			this.chk_forceDefaultNoMatch.Values.Text = "Set Input Driver to DINPUT AND Mouse Index to Default if priority list don\'t matc" +
    "h";
			this.chk_forceDefaultNoMatch.CheckedChanged += new System.EventHandler(this.chk_forceDefaultNoMatch_CheckedChanged);
			// 
			// kryptonLabel1
			// 
			this.kryptonLabel1.Location = new System.Drawing.Point(18, 716);
			this.kryptonLabel1.Name = "kryptonLabel1";
			this.kryptonLabel1.Size = new System.Drawing.Size(269, 20);
			this.kryptonLabel1.TabIndex = 88;
			this.kryptonLabel1.Values.Text = "Here you can check your current Mouse Order :";
			// 
			// RetroarchFixSiden_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(743, 954);
			this.Controls.Add(this.kryptonLabel1);
			this.Controls.Add(this.btn_showMouse);
			this.Controls.Add(this.txt_showMouse);
			this.Controls.Add(this.kryptonGroupBox1);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.groupBox2);
			this.Name = "RetroarchFixSiden_Config";
			this.Text = "RetroarchFixSiden_Config";
			this.Load += new System.EventHandler(this.RetroarchFixSiden_Config_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
			this.kryptonGroupBox1.Panel.ResumeLayout(false);
			this.kryptonGroupBox1.Panel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
			this.kryptonGroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label3;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_manage_filter;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_exclude;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label6;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_exclude_comma;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_filter_remove;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonGroupBox kryptonGroupBox1;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel infoLabel;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label11;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel label12;
		private System.Windows.Forms.ListView list_priority;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_priority;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_priority_res;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_forceDefaultNoFilter;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_showMouse;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_showMouse;
		private ComponentFactory.Krypton.Toolkit.KryptonCheckBox chk_forceDefaultNoMatch;
		private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
	}
}