using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BigBoxProfile.EmulatorActions;
using BigBoxProfile.RomExtractorUtils;
using System.Threading;
using System.Windows.Input;
using GlobalHotKey;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

namespace BigBoxProfile.EmulatorActions
{



	public partial class RomExtractor_Task : Form
	{
		private RomExtractor_ArchiveFile _archiveFile = null;
		private string _cachedir = "";
		private int _cacheMaxSize = 0;

		private HotKeyManager hotKeyManager;
		private CancellationTokenSource countdownCancellation;

		public string OutFile = "";

		public RomExtractor_Task(string archiveFilePath, RomExtractor_PriorityData selectedPriority, string cachedir, int cacheMaxSize, string standaloneExtensions, string metadataExtensions)
		{

			try
			{
				_archiveFile = new RomExtractor_ArchiveFile(archiveFilePath, metadataExtensions, standaloneExtensions, selectedPriority);
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error loading archive : " + ex);

			}
			_cachedir = cachedir;
			_cacheMaxSize = cacheMaxSize;
			InitializeComponent();
		}

		private async void RomExtractor_Task_Load(object sender, EventArgs e)
		{

			/*
			if(_archiveFile!= null && _archiveFile.PriorityFile != "")
			{

				Progress<ExtractionProgress> progress = new Progress<ExtractionProgress>(progressData =>
				{
					progressBar1.Value = progressData.PercentDone;
					lbl_progress.Text = $"Progression : {progressData.PercentDone}%";
				});

				await _archiveFile.ExtractArchiveWithProgressAsync(_archiveFile.PriorityFile, _cachedir, progress);

				//Close();

			}
			*/
			this.FormClosing += (senderClosing,eventClosing) => 
			{
				hotKeyManager = null;
				hotKeyManager.Dispose();
			};


			lbl_file.Text = _archiveFile.ArchiveNameWithoutPath;
			lbl_selected.Text = _archiveFile.PriorityFile;

			lbl_progress.Text = "Lancement du jeu dans 5 secondes";
			hotKeyManager = new HotKeyManager();
			var hotkey_esc = hotKeyManager.Register(System.Windows.Input.Key.Escape, System.Windows.Input.ModifierKeys.None);

			var hotkey_f1 = hotKeyManager.Register(System.Windows.Input.Key.F1, System.Windows.Input.ModifierKeys.None);

			hotKeyManager.KeyPressed += (senderKeypress, eventKeypress) =>
			{
				if (eventKeypress.HotKey.Key == System.Windows.Input.Key.Escape)
				{
					countdownCancellation?.Cancel();
				}
				if (eventKeypress.HotKey.Key == System.Windows.Input.Key.F1)
				{
					countdownCancellation?.Cancel();
					lbl_progress.Text = "";
					var frm = new RomExtractor_BigBoxSelect(_archiveFile,_cachedir);
					var targetProcess = Process.GetProcessesByName("LaunchBox").FirstOrDefault(p => p.MainWindowTitle != "");
					if (targetProcess == null) targetProcess = Process.GetProcessesByName("BigBox").FirstOrDefault(p => p.MainWindowTitle != "");
					if (targetProcess != null)
					{
						var screen = Screen.FromHandle(targetProcess.MainWindowHandle);
						int x = screen.Bounds.Left + (screen.Bounds.Width - frm.Width) / 2;
						int y = screen.Bounds.Top + (screen.Bounds.Height - frm.Height) / 2;
						frm.StartPosition = FormStartPosition.Manual;
						frm.Location = new Point(x, y);
					}
					frm.TopMost = true; // Affiche la fenêtre devant toutes les autres
					frm.ShowDialog();
					frm.Focus(); // Donne le focus à la fenêtre


				}

			};

			StartCountdown();

		}

		private async void StartCountdown()
		{
			countdownCancellation = new CancellationTokenSource();
			for (int i = 5; i >= 0; i--)
			{
				if (countdownCancellation.Token.IsCancellationRequested)
				{
					break;
				}

				Invoke((Action)(() =>
				{
					lbl_progress.Text = $"Lancement du jeu dans {i} secondes";
				}));

				await Task.Delay(1000);
			}

			// Démarrer le jeu si l'annulation n'a pas été demandée.
			if (!countdownCancellation.Token.IsCancellationRequested)
			{
				hotKeyManager.Dispose();
				if (_archiveFile != null && _archiveFile.PriorityFile != "")
				{

					Progress<ExtractionProgress> progress = new Progress<ExtractionProgress>(progressData =>
					{
						progressBar1.Value = progressData.PercentDone;
						lbl_progress.Text = $"Progression : {progressData.PercentDone}%";
					});

					OutFile = await _archiveFile.ExtractArchiveWithProgressAsync(_archiveFile.PriorityFile, _cachedir, progress);

					Close();

				}
			}
		}


		void HotKeyManagerPressed(object sender, KeyPressedEventArgs e)
		{
			MessageBox.Show("Hot key pressed!");
		}


		private void UpdateDisplay()  
		{

			while (true)
			{
				if (_archiveFile.copyStart == false)
				{
					Thread.Sleep(5);
					continue;
				}
				// Vérifier si la copie est terminée
				if (_archiveFile.copyCompleted)
				{
					Thread.Sleep(500);
					Invoke(new Action(() =>
					{
						Close();
					}));
					break;
				}

				// Calculer la progression en pourcentage
				int progress = (int)_archiveFile.percentDone;

				// Mettre à jour la ProgressBar et le label sur le thread de l'interface utilisateur
				Invoke(new Action(() =>
				{
					progressBar1.Value = progress;
					lbl_progress.Text = $"Progression : {progress}%";

				}));

				Thread.Sleep(50); // Attendre 500 millisecondes avant la prochaine mise à jour de l'affichage
			}

		}


	}
}
