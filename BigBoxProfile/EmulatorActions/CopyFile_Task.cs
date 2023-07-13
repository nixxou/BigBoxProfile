﻿using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class CopyFile_Task : Form
	{
		string inPath;
		public string outPath;
		private DateTime startTime;
		private bool copyCompleted = false;
		private bool copyStart = false;
		long fileSize = 0;
		long totalBytesRead = 0;

		bool useRamDisk = false;
		bool deleteOnExit = false;
		int maxSize = 0;
		RamDiskLauncher RamDisk = null;

		public CopyFile_Task(string inPath, string outPath, bool useRamDisk, bool deleteOnExit, int maxSize, RamDiskLauncher ramDisk)
		{
			this.RamDisk = ramDisk;
			this.inPath = inPath;
			this.outPath = outPath;
			copyCompleted = false;
			copyStart = false;
			fileSize = 0;
			totalBytesRead = 0;

			this.useRamDisk = useRamDisk;
			this.deleteOnExit = deleteOnExit;
			this.maxSize = maxSize;

			InitializeComponent();
			lbl_file.Text = Path.GetFileName(inPath);
			lbl_source.Text = $"Source : {inPath}";
			lbl_dest.Text = $"Destination : {outPath}";
		}



		private void CopyFile_Task_Load(object sender, EventArgs e)
		{
			Screen screen = Screen.FromControl(this);
			int tailleSourceHeight = 1080;
			double multiplicateur = (double)screen.Bounds.Height / (double)tailleSourceHeight;
			if (multiplicateur > 0.6)
			{
				this.Height = (int)Math.Round((double)this.Height * multiplicateur);
				this.Width = (int)Math.Round((double)this.Width * multiplicateur);
				this.StartPosition = FormStartPosition.Manual;
				this.Left = (screen.Bounds.Width - this.Width) / 2;
				this.Top = (screen.Bounds.Height - this.Height) / 2;
				foreach (Control control in this.Controls)
				{
					// Faire quelque chose avec chaque contrôle (par exemple, afficher le nom)
					Console.WriteLine("Nom du contrôle : " + control.Name);
					control.Height = (int)Math.Round((double)control.Height * multiplicateur);
					control.Width = (int)Math.Round((double)control.Width * multiplicateur);
					control.Left = (int)Math.Round((double)control.Left * multiplicateur);
					control.Top = (int)Math.Round((double)control.Top * multiplicateur);

					PropertyInfo fontProperty = control.GetType().GetProperty("Font");
					if (fontProperty != null)
					{
						var f = control.Font;
						control.Font = new Font(f.Name, f.SizeInPoints * (float)multiplicateur);
					}
				}
			}

			lbl_progress.Text = "";
			lbl_progressETA.Text = "";


			// Vérifier si les chemins d'entrée et de sortie sont valides
			if (!File.Exists(inPath))
			{
				MessageBox.Show("Le fichier d'entrée n'existe pas.");
				return;
			}
			var fileSizeIn = new FileInfo(inPath).Length;
			if (File.Exists(outPath))
			{

				var fileSizeOut = new FileInfo(outPath).Length;
				if (fileSizeIn == fileSizeOut)
				{
					Invoke(new Action(() =>
					{
						Close();
					}));
					return;
				}
				else
				{
					File.Delete(outPath);
				}
			}

			if (useRamDisk)
			{

				int fileSizeMB = (int)((fileSizeIn / 1024 / 1024) * 1.03);
				fileSizeMB += 30;
				fileSizeMB = BigBoxUtils.GetDiskSize(fileSizeMB);

				if (fileSizeMB < maxSize)
				{
					bool resMount = RamDisk.Mount(fileSizeMB);
					if (resMount)
					{
						outPath = Path.Combine(RamDisk.RamDriveLetter + ":\\", Path.GetFileName(inPath));
						lbl_dest.Text = $"Destination : {outPath}";
					}
				}

			}

			Thread displayThread = new Thread(UpdateDisplay);
			displayThread.Start();

			Thread copyThread = new Thread(() => CopyFileWithProgress(inPath, outPath));
			copyThread.Start();

		}



		private void CopyFileWithProgress(string inPath, string outPath)
		{
			fileSize = new FileInfo(inPath).Length;
			totalBytesRead = 0;

			startTime = DateTime.Now;
			try
			{
				using (FileStream inFile = new FileStream(inPath, FileMode.Open, FileAccess.Read))
				{
					using (FileStream outFile = new FileStream(outPath, FileMode.Create, FileAccess.Write))
					{
						copyStart = true;
						byte[] buffer = new byte[40096];
						int bytesRead;

						while ((bytesRead = inFile.Read(buffer, 0, buffer.Length)) > 0)
						{
							outFile.Write(buffer, 0, bytesRead);
							totalBytesRead += bytesRead;
						}
					}
				}
				copyCompleted = true;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


		}

		private void UpdateDisplay()
		{

			while (true)
			{
				if (copyStart == false || fileSize == 0)
				{
					Thread.Sleep(50);
					continue;
				}
				// Vérifier si la copie est terminée
				if (copyCompleted)
				{
					Thread.Sleep(500);
					Invoke(new Action(() =>
					{
						Close();
					}));
					break;
				}

				// Calculer la progression en pourcentage
				int progress = (int)((progressBar1.Maximum * totalBytesRead) / fileSize);

				// Mettre à jour la ProgressBar et le label sur le thread de l'interface utilisateur
				Invoke(new Action(() =>
				{
					progressBar1.Value = progress;
					double elapsedSeconds = (DateTime.Now - startTime).TotalSeconds;
					if (progress > 0)
					{

						double remainingSeconds = (elapsedSeconds / progress) * (100 - progress);
						TimeSpan remainingTime = TimeSpan.FromSeconds(remainingSeconds);
						lbl_progressETA.Text = $"Temps restant : {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}";

					}
					else
					{
						lbl_progressETA.Text = "";
					}

					double transferSpeed = 0;
					if (elapsedSeconds > 0)
					{
						transferSpeed = totalBytesRead / (1024 * 1024 * elapsedSeconds); // Convertir les octets en Mo

					}

					double copiedSizeMB = (double)totalBytesRead / (1024 * 1024);
					double totalSizeMB = (double)fileSize / (1024 * 1024);
					lbl_progress.Text = $"Progression : {progress}% ({copiedSizeMB:F2} MB / {totalSizeMB:F2} MB) {transferSpeed:F2} Mo/s";

				}));

				Thread.Sleep(100); // Attendre 500 millisecondes avant la prochaine mise à jour de l'affichage
			}

		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}
	}
}
