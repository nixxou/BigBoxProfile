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
using System.Collections.Generic;
using System.Globalization;
using System.Drawing.Text;
using System.Xml.Linq;
using XInput.Wrapper;

namespace BigBoxProfile.EmulatorActions
{



	public partial class RomExtractor_Task : Form
	{
		private RomExtractor_ArchiveFile _archiveFile = null;
		private string _cachedir = "";
		private int _cacheMaxSize = 0;

		private HotKeyManager hotKeyManager;
		private X.Gamepad gamepad = null;

		private CancellationTokenSource countdownCancellation;

		public string OutFile = "";
		private List<HotKey> _hotkeyList = new List<HotKey>();
		private bool _isActiveWindow = true;

		private string _SelectedGame = "";
		private List<string> _ShortListGame = new List<string>();


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
				DisableHotkey();
			};

			this.TopMost = true;
			this.Activate();


			//lbl_file.Text = _archiveFile.ArchiveNameWithoutPath;
			lbl_file.Text = $"{_archiveFile.ArchiveNameWithoutPath} ({_archiveFile.filelist_standalone.Count} games)";
			_SelectedGame = _archiveFile.PriorityFile;

			_ShortListGame.Add(_SelectedGame);
			_ShortListGame.AddRange(_archiveFile.topPriorityFiles.Except(_ShortListGame).ToArray());

			fileListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			fileListBox.MeasureItem += lst_MeasureItem;
			fileListBox.DrawItem += lst_DrawItem;

			fileListBox.Items.Clear();
			//fileListBox.Items.AddRange(_archiveFile.filelist.Except(_archiveFile.filelist_metadata).ToArray());
			fileListBox.Items.AddRange(_ShortListGame.ToArray());
			if (_SelectedGame != string.Empty)
			{
				fileListBox.SelectedItem = _SelectedGame;
			}
			if (fileListBox.SelectedItems.Count == 0)
			{
				fileListBox.SelectedIndex = 0;
			}

			lbl_selected.Text = _SelectedGame;

			lbl_progress.Text = "Game launch countdown : 5 seconds";

			EnableHotkey();

			StartCountdown();

		}

		private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			e.ItemHeight = (int)e.Graphics.MeasureString(fileListBox.Items[e.Index].ToString(), fileListBox.Font, fileListBox.Width).Height;
		}

		private void lst_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();

			Graphics g = e.Graphics;
			Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
							new SolidBrush(Color.FromArgb(0x5F, 0x33, 0x99, 0xFF)) : new SolidBrush(e.BackColor);
			g.FillRectangle(brush, e.Bounds);
			e.DrawFocusRectangle();
			e.Graphics.DrawString(fileListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
		}

		public void Gamepad_StateChanged(object sender, EventArgs e)
		{
			if (gamepad.Back_down)
			{
				LaunchBigBoxSelect();
			}
			if (gamepad.A_down || gamepad.Start_down)
			{
				StopCountDown();
				LaunchGame(_SelectedGame);
			}
			
			/*
			if (gamepad.RBumper_down)
			{
				StopCountDown();
				int indexElement = _ShortListGame.IndexOf(_SelectedGame);
				if (indexElement != -1 && indexElement < _ShortListGame.Count - 1)
				{
					string elementSuivant = _ShortListGame[indexElement + 1];
					_SelectedGame = elementSuivant;
					lbl_selected.Text = _SelectedGame;
				}
			}
			if (gamepad.LBumper_down)
			{
				StopCountDown();
				int indexElement = _ShortListGame.IndexOf(_SelectedGame);
				if (indexElement>0)
				{
					string elementPrecedent = _ShortListGame[indexElement - 1];
					_SelectedGame = elementPrecedent;
					lbl_selected.Text = _SelectedGame;
				}
			}
			*/

		}

		public void Gamepad_KeyDown(object sender, EventArgs e)
		{
			if (gamepad.Dpad_Down_down)
			{
				StopCountDown();
				if (fileListBox.SelectedIndex < fileListBox.Items.Count - 1)
				{
					fileListBox.SelectedIndex++;
					System.Threading.Thread.Sleep(120);
				}

			}
			if (gamepad.Dpad_Up_down)
			{
				StopCountDown();
				if (fileListBox.SelectedIndex > 0)
				{
					fileListBox.SelectedIndex--;
					System.Threading.Thread.Sleep(120);
				}
			}
		}

		private void EnableHotkey()
		{
			if (X.IsAvailable)
			{
				gamepad = X.Gamepad_1;
				X.StartPolling(gamepad);
			}
			if (hotKeyManager == null)
			{
				hotKeyManager = new HotKeyManager();
				RegisterHotkey();

				hotKeyManager.KeyPressed += (senderKeypress, eventKeypress) =>
				{
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.Escape)
					{
						StopCountDown();
					}
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.F1)
					{
						LaunchBigBoxSelect();
					}
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.Enter)
					{
						StopCountDown();
						LaunchGame(_SelectedGame);
					}
				};
			}



			
		}

		private void LaunchBigBoxSelect()
		{
			UnregisterHotkey();
			StopCountDown();
			lbl_progress.Text = "";
			var frm = new RomExtractor_BigBoxSelect(_archiveFile, _cachedir);
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
			var result = frm.ShowDialog();
			frm.Focus(); // Donne le focus à la fenêtre
			RegisterHotkey();
			
			if (result == DialogResult.OK)
			{
				_SelectedGame = frm.Selected;
				lbl_selected.Text = _SelectedGame;

				LaunchGame(frm.Selected);

			}
			
		}

		private async void LaunchGame(string name)
		{
			if (name == "") return;
			Progress<ExtractionProgress> progress = new Progress<ExtractionProgress>(progressData =>
			{
				progressBar1.Value = progressData.PercentDone;
				lbl_progress.Text = $"Progression : {progressData.PercentDone}%";
			});

			OutFile = await _archiveFile.ExtractArchiveWithProgressAsync(name, _cachedir, progress);

			Close();
		}
		

		private void DisableHotkey()
		{
			
			if(hotKeyManager!= null)
			{
				hotKeyManager.Dispose();
				hotKeyManager = null;
			}
			if (gamepad != null)
				X.StopPolling();
			
		}

		private void RegisterHotkey()
		{
			
			if(hotKeyManager != null && _hotkeyList.Count == 0)
			{
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.Escape, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.F1, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.Enter, System.Windows.Input.ModifierKeys.None));
			}
			gamepad.StateChanged += Gamepad_StateChanged;
			gamepad.KeyDown+= Gamepad_KeyDown;

		}

		private void UnregisterHotkey()
		{
			
			if(hotKeyManager != null)
			{
				foreach (var hotkey in _hotkeyList)
				{
					hotKeyManager.Unregister(hotkey);
				}
				_hotkeyList.Clear();

			}
			gamepad.StateChanged -= Gamepad_StateChanged;
			gamepad.KeyDown -= Gamepad_KeyDown;


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
					lbl_progress.Text = $"Game launch countdown : {i} seconds";
				}));

				await Task.Delay(1000);
			}

			// Démarrer le jeu si l'annulation n'a pas été demandée.
			if (!countdownCancellation.Token.IsCancellationRequested)
			{
				DisableHotkey();
				if (_archiveFile != null && _SelectedGame != "")
				{

					LaunchGame(_SelectedGame);

				}
			}
		}

		private void StopCountDown()
		{
			countdownCancellation.Cancel();
			lbl_progress.Text = "";
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

		private void RomExtractor_Task_KeyDown(object sender, KeyEventArgs e)
		{
			/*
			if (e.KeyCode == Keys.Escape)
			{
				countdownCancellation?.Cancel();
			}
			if (e.KeyCode == Keys.F1)
			{
				UnregisterHotkey();
				_isActiveWindow = false;
				this.TopMost = false;
				countdownCancellation?.Cancel();
				lbl_progress.Text = "";
				var frm = new RomExtractor_BigBoxSelect(_archiveFile, _cachedir);
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
				var result = frm.ShowDialog();
				frm.Focus(); // Donne le focus à la fenêtre
				RegisterHotkey();
				if (result == DialogResult.OK)
				{
					LaunchGame(frm.Selected);

				}
				this.TopMost = true;
				this.Activate();
			}
			if (e.KeyCode == Keys.Enter)
			{
				countdownCancellation?.Cancel();
				LaunchGame(_archiveFile.PriorityFile);
			}
			*/
		}



		private void RomExtractor_Task_Deactivate(object sender, EventArgs e)
		{
			//if(_isActiveWindow) this.Focus();
		}

		private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (fileListBox.SelectedIndex >= 0)
			{
				_SelectedGame = fileListBox.SelectedItem.ToString();
				lbl_selected.Text = _SelectedGame;
			}
		}
	}
}
