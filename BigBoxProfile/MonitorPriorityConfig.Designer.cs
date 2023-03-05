namespace BigBoxProfile
{
	partial class MonitorPriorityConfig
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.MainMonitor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DeviceName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.FriendlyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.TargetID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listView_monitor = new System.Windows.Forms.ListView();
			this.val = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.cmb_add = new System.Windows.Forms.ComboBox();
			this.btn_add = new System.Windows.Forms.Button();
			this.txt_result = new System.Windows.Forms.TextBox();
			this.btn_up = new System.Windows.Forms.Button();
			this.btn_down = new System.Windows.Forms.Button();
			this.btn_delete = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(293, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "The result Textbox is used to input the priority list for Monitors";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(446, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "On bigbox launch, it will go over the list and take the first one that match a co" +
    "nnected monitor";
			// 
			// listView1
			// 
			this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MainMonitor,
            this.DeviceName,
            this.FriendlyName,
            this.TargetID});
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(17, 124);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(426, 253);
			this.listView1.TabIndex = 11;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// MainMonitor
			// 
			this.MainMonitor.Text = "MainMonitor";
			this.MainMonitor.Width = 76;
			// 
			// DeviceName
			// 
			this.DeviceName.Text = "DeviceName";
			this.DeviceName.Width = 114;
			// 
			// FriendlyName
			// 
			this.FriendlyName.Text = "FriendlyName";
			this.FriendlyName.Width = 174;
			// 
			// TargetID
			// 
			this.TargetID.Text = "TargetID";
			this.TargetID.Width = 57;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(7, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "&";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 70);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 13);
			this.label5.TabIndex = 14;
			this.label5.Text = "For exemple :";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(92, 70);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(285, 20);
			this.textBox1.TabIndex = 15;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 94);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(50, 13);
			this.label6.TabIndex = 16;
			this.label6.Text = "It will use";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listView1);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Location = new System.Drawing.Point(12, 256);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(461, 448);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Help";
			// 
			// listView_monitor
			// 
			this.listView_monitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.val});
			this.listView_monitor.FullRowSelect = true;
			this.listView_monitor.HideSelection = false;
			this.listView_monitor.Location = new System.Drawing.Point(29, 49);
			this.listView_monitor.Name = "listView_monitor";
			this.listView_monitor.Size = new System.Drawing.Size(358, 161);
			this.listView_monitor.TabIndex = 18;
			this.listView_monitor.UseCompatibleStateImageBehavior = false;
			this.listView_monitor.View = System.Windows.Forms.View.Details;
			this.listView_monitor.SelectedIndexChanged += new System.EventHandler(this.listView_monitor_SelectedIndexChanged);
			// 
			// val
			// 
			this.val.Width = 0;
			// 
			// cmb_add
			// 
			this.cmb_add.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_add.FormattingEnabled = true;
			this.cmb_add.Location = new System.Drawing.Point(29, 12);
			this.cmb_add.Name = "cmb_add";
			this.cmb_add.Size = new System.Drawing.Size(363, 21);
			this.cmb_add.TabIndex = 19;
			// 
			// btn_add
			// 
			this.btn_add.Location = new System.Drawing.Point(398, 12);
			this.btn_add.Name = "btn_add";
			this.btn_add.Size = new System.Drawing.Size(75, 23);
			this.btn_add.TabIndex = 20;
			this.btn_add.Text = "Add";
			this.btn_add.UseVisualStyleBackColor = true;
			this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
			// 
			// txt_result
			// 
			this.txt_result.Location = new System.Drawing.Point(73, 216);
			this.txt_result.Name = "txt_result";
			this.txt_result.ReadOnly = true;
			this.txt_result.Size = new System.Drawing.Size(235, 20);
			this.txt_result.TabIndex = 21;
			// 
			// btn_up
			// 
			this.btn_up.Enabled = false;
			this.btn_up.Location = new System.Drawing.Point(398, 51);
			this.btn_up.Name = "btn_up";
			this.btn_up.Size = new System.Drawing.Size(75, 23);
			this.btn_up.TabIndex = 22;
			this.btn_up.Text = "Up";
			this.btn_up.UseVisualStyleBackColor = true;
			this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
			// 
			// btn_down
			// 
			this.btn_down.Enabled = false;
			this.btn_down.Location = new System.Drawing.Point(398, 80);
			this.btn_down.Name = "btn_down";
			this.btn_down.Size = new System.Drawing.Size(75, 23);
			this.btn_down.TabIndex = 23;
			this.btn_down.Text = "Down";
			this.btn_down.UseVisualStyleBackColor = true;
			this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
			// 
			// btn_delete
			// 
			this.btn_delete.Enabled = false;
			this.btn_delete.Location = new System.Drawing.Point(398, 109);
			this.btn_delete.Name = "btn_delete";
			this.btn_delete.Size = new System.Drawing.Size(75, 23);
			this.btn_delete.TabIndex = 24;
			this.btn_delete.Text = "Delete";
			this.btn_delete.UseVisualStyleBackColor = true;
			this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 219);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(43, 13);
			this.label7.TabIndex = 25;
			this.label7.Text = "Result :";
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(397, 219);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(75, 23);
			this.btn_save.TabIndex = 26;
			this.btn_save.Text = "Save";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(312, 219);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 27;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// MonitorPriorityConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(485, 643);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btn_delete);
			this.Controls.Add(this.btn_down);
			this.Controls.Add(this.btn_up);
			this.Controls.Add(this.txt_result);
			this.Controls.Add(this.btn_add);
			this.Controls.Add(this.cmb_add);
			this.Controls.Add(this.listView_monitor);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MonitorPriorityConfig";
			this.Text = "Monitor Priority Configuration";
			this.Load += new System.EventHandler(this.HelpMonitor_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader MainMonitor;
		private System.Windows.Forms.ColumnHeader DeviceName;
		private System.Windows.Forms.ColumnHeader FriendlyName;
		private System.Windows.Forms.ColumnHeader TargetID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView listView_monitor;
		private System.Windows.Forms.ComboBox cmb_add;
		private System.Windows.Forms.Button btn_add;
		private System.Windows.Forms.TextBox txt_result;
		private System.Windows.Forms.Button btn_up;
		private System.Windows.Forms.Button btn_down;
		private System.Windows.Forms.Button btn_delete;
		private System.Windows.Forms.ColumnHeader val;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_cancel;
	}
}