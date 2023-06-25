using BigBoxProfile.RomExtractorUtils;
using GlobalHotKey;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
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
		public string OutTarget = "";

		private List<HotKey> _hotkeyList = new List<HotKey>();
		private bool _isActiveWindow = true;

		private string _SelectedGame = "";
		private List<string> _ShortListGame = new List<string>();

		List<string> Args = new List<string>();
		public string RetroarchDir = "";
		public string RetroarchCore = "";

		public RomExtractor_Task(List<string> args, string archiveFilePath, RomExtractor_PriorityData selectedPriority, string cachedir, int cacheMaxSize, string standaloneExtensions, string metadataExtensions, string[] prioritySubDirFullList, RamDiskLauncher ramDisk)
		{
			Args = args;

			string executableWithPath = args[0];
			string executableExe = Path.GetFileName(executableWithPath);
			if (executableExe.ToLower() == "retroarch.exe")
			{
				string retroarchDir = Path.GetDirectoryName(executableWithPath);
				RetroarchDir = retroarchDir;
				int i = 0;
				string core = "";
				foreach (var arg in args)
				{
					if (arg.ToLower() == "-l")
					{
						if (args.Count() > i + 1)
						{
							core = args[i + 1];
							break;
						}
					}
					i++;
				}
				if (core != "")
				{
					core = Path.GetFileName(core);
					RetroarchCore = core;
				}
			}


			try
			{
				_archiveFile = new RomExtractor_ArchiveFile(archiveFilePath, metadataExtensions, standaloneExtensions, selectedPriority, cachedir, cacheMaxSize, prioritySubDirFullList, ramDisk);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error loading archive : " + ex);

			}
			_cachedir = cachedir;
			_cacheMaxSize = cacheMaxSize;
			InitializeComponent();
		}

		private async void RomExtractor_Task_Load(object sender, EventArgs e)
		{
			this.FormClosing += (senderClosing, eventClosing) =>
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
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.F2)
					{
						LaunchDesktopSelect();
					}
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.Enter)
					{
						StopCountDown();
						LaunchGame(_SelectedGame);
					}
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.Down)
					{
						StopCountDown();
						if (fileListBox.SelectedIndex < fileListBox.Items.Count - 1)
						{
							fileListBox.SelectedIndex++;
							System.Threading.Thread.Sleep(120);
						}
					}
					if (eventKeypress.HotKey.Key == System.Windows.Input.Key.Up)
					{
						StopCountDown();
						if (fileListBox.SelectedIndex > 0)
						{
							fileListBox.SelectedIndex--;
							System.Threading.Thread.Sleep(120);
						}
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

		private void LaunchDesktopSelect()
		{
			UnregisterHotkey();
			StopCountDown();
			lbl_progress.Text = "";
			var frm = new RomExtractor_DesktopSelect(Args, _archiveFile, _cachedir);
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
			OutTarget = _archiveFile.OutTarget;

			if (RetroarchCore != "" && RetroarchDir != "")
			{
				RomExtractor_ArchiveFile.fix_bezel(RetroarchDir, RetroarchCore, _archiveFile.ArchiveNameWithoutPath, Path.GetFileName(OutFile));
			}
			Close();
		}


		private void DisableHotkey()
		{

			if (hotKeyManager != null)
			{
				hotKeyManager.Dispose();
				hotKeyManager = null;
			}
			if (gamepad != null)
				X.StopPolling();

		}

		private void RegisterHotkey()
		{

			if (hotKeyManager != null && _hotkeyList.Count == 0)
			{
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.Escape, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.F1, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.F2, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.Enter, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.Up, System.Windows.Input.ModifierKeys.None));
				_hotkeyList.Add(hotKeyManager.Register(System.Windows.Input.Key.Down, System.Windows.Input.ModifierKeys.None));
			}
			gamepad.StateChanged += Gamepad_StateChanged;
			gamepad.KeyDown += Gamepad_KeyDown;

		}

		private void UnregisterHotkey()
		{

			if (hotKeyManager != null)
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
