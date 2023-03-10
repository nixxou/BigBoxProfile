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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorPriorityConfig));
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
			this.SuspendLayout();
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
			this.txt_result.Location = new System.Drawing.Point(71, 221);
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
			this.label7.Location = new System.Drawing.Point(24, 224);
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
			this.ClientSize = new System.Drawing.Size(485, 263);
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
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MonitorPriorityConfig";
			this.Text = "Monitor Priority Configuration";
			this.Load += new System.EventHandler(this.HelpMonitor_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
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