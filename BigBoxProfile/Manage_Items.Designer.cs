namespace BigBoxProfile
{
	partial class Manage_Items
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
			this.list_path = new System.Windows.Forms.ListView();
			this.valh = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.txt_path = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
			this.btn_delete_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_add_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_down_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_up_path = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_ok = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.btn_cancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
			this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
			this.SuspendLayout();
			// 
			// list_path
			// 
			this.list_path.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.valh});
			this.list_path.HideSelection = false;
			this.list_path.Location = new System.Drawing.Point(12, 32);
			this.list_path.MultiSelect = false;
			this.list_path.Name = "list_path";
			this.list_path.Size = new System.Drawing.Size(617, 520);
			this.list_path.TabIndex = 28;
			this.list_path.UseCompatibleStateImageBehavior = false;
			this.list_path.View = System.Windows.Forms.View.Details;
			this.list_path.SelectedIndexChanged += new System.EventHandler(this.list_path_SelectedIndexChanged);
			// 
			// valh
			// 
			this.valh.Width = 370;
			// 
			// txt_path
			// 
			this.txt_path.Location = new System.Drawing.Point(12, 4);
			this.txt_path.Name = "txt_path";
			this.txt_path.Size = new System.Drawing.Size(617, 23);
			this.txt_path.TabIndex = 29;
			// 
			// btn_delete_path
			// 
			this.btn_delete_path.Enabled = false;
			this.btn_delete_path.Location = new System.Drawing.Point(635, 173);
			this.btn_delete_path.Name = "btn_delete_path";
			this.btn_delete_path.Size = new System.Drawing.Size(46, 24);
			this.btn_delete_path.TabIndex = 33;
			this.btn_delete_path.Values.Text = "Delete";
			this.btn_delete_path.Click += new System.EventHandler(this.btn_delete_path_Click);
			// 
			// btn_add_path
			// 
			this.btn_add_path.Location = new System.Drawing.Point(635, 3);
			this.btn_add_path.Name = "btn_add_path";
			this.btn_add_path.Size = new System.Drawing.Size(46, 24);
			this.btn_add_path.TabIndex = 30;
			this.btn_add_path.Values.Text = "Add";
			this.btn_add_path.Click += new System.EventHandler(this.btn_add_path_Click);
			// 
			// btn_down_path
			// 
			this.btn_down_path.Enabled = false;
			this.btn_down_path.Location = new System.Drawing.Point(635, 144);
			this.btn_down_path.Name = "btn_down_path";
			this.btn_down_path.Size = new System.Drawing.Size(46, 24);
			this.btn_down_path.TabIndex = 32;
			this.btn_down_path.Values.Text = "Down";
			this.btn_down_path.Click += new System.EventHandler(this.btn_down_path_Click);
			// 
			// btn_up_path
			// 
			this.btn_up_path.Enabled = false;
			this.btn_up_path.Location = new System.Drawing.Point(635, 115);
			this.btn_up_path.Name = "btn_up_path";
			this.btn_up_path.Size = new System.Drawing.Size(46, 24);
			this.btn_up_path.TabIndex = 31;
			this.btn_up_path.Values.Text = "Up";
			this.btn_up_path.Click += new System.EventHandler(this.btn_up_path_Click);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(554, 558);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 24);
			this.btn_ok.TabIndex = 44;
			this.btn_ok.Values.Text = "Save";
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(473, 558);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 24);
			this.btn_cancel.TabIndex = 45;
			this.btn_cancel.Values.Text = "Cancel";
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// Manage_Items
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(687, 589);
			this.Controls.Add(this.btn_ok);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.list_path);
			this.Controls.Add(this.txt_path);
			this.Controls.Add(this.btn_delete_path);
			this.Controls.Add(this.btn_add_path);
			this.Controls.Add(this.btn_down_path);
			this.Controls.Add(this.btn_up_path);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Manage_Items";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manage_Items";
			this.Load += new System.EventHandler(this.Manage_Items_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView list_path;
		private System.Windows.Forms.ColumnHeader valh;
		private ComponentFactory.Krypton.Toolkit.KryptonTextBox txt_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_delete_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_add_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_down_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_up_path;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_ok;
		private ComponentFactory.Krypton.Toolkit.KryptonButton btn_cancel;
		private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
	}
}