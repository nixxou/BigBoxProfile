using BigBoxProfile.RomExtractorUtils;
using System;
using System.IO;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{

	public partial class RomExtractor_PopupExtract : Form
	{
		private RomExtractor_ArchiveFile _archiveFile;
		private string _fileToExtract;
		private string _dirOut;
		private string _saveAs;
		private long _romSize;

		public RomExtractor_PopupExtract(RomExtractor_ArchiveFile archiveFile, string fileToExtract, string saveAs, long romSize)
		{
			_archiveFile = archiveFile;
			_fileToExtract = fileToExtract;
			_saveAs = saveAs;
			_romSize = romSize;
			InitializeComponent();
			btn_ok.Enabled = false;
			lbl_progress.Text = "";

			Extract();


		}

		private async void Extract()
		{
			string dir_out = Path.GetDirectoryName(_saveAs);
			string file_out = Path.GetFileName(_saveAs);
			string temp_out = dir_out + "\\" + _fileToExtract;

			lbl_file.Text = _fileToExtract;
			lbl_selected.Text = _saveAs;

			Progress<ExtractionProgress> progress = new Progress<ExtractionProgress>(progressData =>
			{
				progressBar1.Value = progressData.PercentDone;
				lbl_progress.Text = $"Progression : {progressData.PercentDone}%";
			});

			//Check free space
			ulong FreeBytesAvailable;
			ulong TotalNumberOfBytes;
			ulong TotalNumberOfFreeBytes;
			bool success = BigBoxUtils.GetDiskFreeSpaceEx(dir_out, out FreeBytesAvailable, out TotalNumberOfBytes, out TotalNumberOfFreeBytes);
			if (!success) throw new System.ComponentModel.Win32Exception();
			if (FreeBytesAvailable < (ulong)_romSize)
			{
				MessageBox.Show("Not enought free space");
				btn_ok.Enabled = true;
				return;
			}

			if (file_out == _fileToExtract)
			{
				if (File.Exists(_saveAs))
				{
					File.Delete(_saveAs);
				}
				//new ArchiveCacheManager.Zip().Extract(this.ArchiveDir + "\\" + this.ArchiveName, dir_out, includelist, null);
				//var TaskProcess = System.Threading.Tasks.Task.Run(() => _archiveFile.ExtractFileFromArchive(_fileToExtract, dir_out));
				//TaskProcess.Wait();

				_ = await _archiveFile.SimpleExtractArchiveWithProgressAsync(_fileToExtract, dir_out, progress);
				btn_ok.Enabled = true;
			}
			else
			{
				//Ok, so to extract and rename a file with a single command line, maybe something like this would be better :   7z e my-compressed-file.7z -so readme.txt > new-filename.txt
				//But i don't want to bother and just use the Zip class, so i will use Rename & Move
				if (File.Exists(_saveAs))
				{
					File.Delete(_saveAs);
				}

				//If the temp file already exist, we rename it, and we will restore it after
				string restore_file = "";
				if (File.Exists(temp_out))
				{
					int i = 0;
					restore_file = temp_out + ".bak" + i.ToString();
					while (File.Exists(restore_file))
					{
						i++;
						restore_file = temp_out + ".bak" + i.ToString();
					}
					File.Move(temp_out, restore_file);
				}

				_ = await _archiveFile.SimpleExtractArchiveWithProgressAsync(_fileToExtract, dir_out, progress);

				File.Move(temp_out, _saveAs);

				if (restore_file != "")
				{
					File.Move(restore_file, temp_out);
				}
				btn_ok.Enabled = true;
			}
		}

		private void btn_ok_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void RomExtractor_PopupExtract_Load(object sender, EventArgs e)
		{
			this.ControlBox = false;
		}
	}
}
