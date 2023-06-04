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
		public CopyFile_Task(string inPath, string outPath)
		{
			this.inPath = inPath;
			this.outPath = outPath;
			InitializeComponent();
		}



		private void CopyFile_Task_Load(object sender, EventArgs e)
		{
			lbl_progress.Text = "Salut !";
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
		}

		public void CopyFileWithProgress(string inPath, string outPath)
		{
			// Obtenir la taille du fichier
			long fileSize = new FileInfo(inPath).Length;
			long totalBytesRead = 0;

			using (FileStream inFile = new FileStream(inPath, FileMode.Open, FileAccess.Read))
			{
				using (FileStream outFile = new FileStream(outPath, FileMode.Create, FileAccess.Write))
				{
					byte[] buffer = new byte[4096]; // Taille du tampon pour la copie du fichier
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
				}
			}
		}



	}
}
