namespace PauseMenu
{
	partial class Form1
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.fakebrowser_txt = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.timer_pause = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// fakebrowser_txt
			// 
			this.fakebrowser_txt.Location = new System.Drawing.Point(411, 192);
			this.fakebrowser_txt.Multiline = true;
			this.fakebrowser_txt.Name = "fakebrowser_txt";
			this.fakebrowser_txt.Size = new System.Drawing.Size(319, 231);
			this.fakebrowser_txt.TabIndex = 1;
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// timer_pause
			// 
			this.timer_pause.Interval = 1000;
			this.timer_pause.Tick += new System.EventHandler(this.timer_pause_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1141, 615);
			this.Controls.Add(this.fakebrowser_txt);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox fakebrowser_txt;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Timer timer_pause;
	}
}

