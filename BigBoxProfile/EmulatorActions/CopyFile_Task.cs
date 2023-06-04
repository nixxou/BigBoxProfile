using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	public partial class CopyFile_Task : Form
	{
		string inPath;
		string outPath;
		private DateTime startTime;
		private bool copyCompleted = false;
		private bool copyStart = false;
		long fileSize = 0;
		long totalBytesRead = 0;


		public CopyFile_Task(string inPath, string outPath)
		{
			this.inPath = inPath;
			this.outPath = outPath;
			copyCompleted = false;
			copyStart = false;
			fileSize = 0;
			totalBytesRead = 0;
			InitializeComponent();
			lbl_file.Text = Path.GetFileName(inPath);
			lbl_source.Text = $"Source : {inPath}";
			lbl_dest.Text = $"Destination : {outPath}";
		}



		private void CopyFile_Task_Load(object sender, EventArgs e)
		{
			lbl_progress.Text = "";
			lbl_progressETA.Text = "";
			

			// Vérifier si les chemins d'entrée et de sortie sont valides
			if (!File.Exists(inPath))
			{
				MessageBox.Show("Le fichier d'entrée n'existe pas.");
				return;
			}

			if (File.Exists(outPath))
			{
				var fileSizeIn = new FileInfo(inPath).Length;
				var fileSizeOut = new FileInfo(outPath).Length;
				if(fileSizeIn == fileSizeOut)
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
			Thread displayThread = new Thread(UpdateDisplay);
			displayThread.Start();
			// Démarrer le thread de copie de fichier
			Thread copyThread = new Thread(() => CopyFileWithProgress(inPath, outPath));
			copyThread.Start();

			// Démarrer le thread d'affichage


			//CopyFileWithProgress(inPath, outPath);
			/*
			// Démarrer une tâche en arrière-plan pour augmenter le pourcentage
			ThreadPool.QueueUserWorkItem((state) =>
			{
				int progress = 0;
				while (progress <= 100)
				{
					// Mettre à jour la ProgressBar sur le thread de l'interface utilisateur
					Invoke(new Action(() =>
					{
						progressBar1.Value = progress;
					}));

					progress++;

					// Attendre 50 millisecondes avant la prochaine mise à jour
					Thread.Sleep(50);
				}
			});
			*/

			/*
			ThreadPool.QueueUserWorkItem((state) =>
			{
				long fileSize = new FileInfo(inPath).Length;
				long totalBytesRead = 0;

				using (FileStream inFile = new FileStream(inPath, FileMode.Open, FileAccess.Read))
				{
					using (FileStream outFile = new FileStream(outPath, FileMode.Create, FileAccess.Write))
					{
						byte[] buffer = new byte[40096]; // Taille du tampon pour la copie du fichier
						int bytesRead;

						while ((bytesRead = inFile.Read(buffer, 0, buffer.Length)) > 0)
						{
							outFile.Write(buffer, 0, bytesRead);
							totalBytesRead += bytesRead;

							// Calculer la progression en pourcentage
							int progress = (int)((totalBytesRead * 100) / fileSize);

							// Mettre à jour la ProgressBar sur le thread de l'interface utilisateur
							progressBar1.Invoke(new Action(() =>
							{
								progressBar1.Value = progress;
							}));

							// Mettre à jour le label avec le pourcentage de progression et le nombre de Mo copiés
							double copiedSizeMB = (double)totalBytesRead / (1024 * 1024);
							double totalSizeMB = (double)fileSize / (1024 * 1024);
							lbl_progress.Invoke(new Action(() =>
							{
								lbl_progress.Text = $"Progression : {progress}% ({copiedSizeMB:F2} MB / {totalSizeMB:F2} MB)";
							}));
						}

						Invoke(new Action(() =>
						{
							Close();
						}));


					}
				}
			});
			*/


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
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


		}

		private void UpdateDisplay()
		{
			
			while (true)
			{
				if(copyStart == false || fileSize == 0)
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




	}
}
