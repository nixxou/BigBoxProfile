using Microsoft.VisualBasic.Devices;
using RamDisk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RamDiskManager
{

	public partial class Form1 : Form
	{

		public int SizeInMb { get; set; }
		public char DriveLetter { get; set; }
		public bool RamClean { get; set; }
		public string VolumeLabel { get; set; }

		public string Command = "";


		public Form1(string[] args)
		{
			SizeInMb = 0;
			DriveLetter = '\0';
			VolumeLabel = "Ramdisk";

			if (args.Length == 1 && args[0] == "mount")
			{
				readConfigFile();
				Command = args[0];

				MessageBox.Show("ReadFile Done");
				if(SizeInMb > 0 && DriveLetter != '\0')
				{
					if(!Directory.Exists(DriveLetter + ":\\"))
					{
						MessageBox.Show("Check Ram");
						int freeRamInMB = getFreeRamMb();
						if (SizeInMb < freeRamInMB)
						{
							RamCleaner.Program.Run();
							Thread.Sleep(2000);
						}
						freeRamInMB = getFreeRamMb();
						if (freeRamInMB > SizeInMb)
						{
							MessageBox.Show("Mount");
							RamDrive.Mount(SizeInMb, FileSystem.NTFS, DriveLetter, VolumeLabel);
						}
					}
				}
			}
			if (args.Length == 1 && args[0] == "umount")
			{
				Command = args[0];
				readConfigFile();
				if (SizeInMb > 0 && DriveLetter != '\0')
				{
					if (Directory.Exists(DriveLetter + ":\\"))
					{
						RamDrive.Unmount(DriveLetter);
					}
				}
			}
			InitializeComponent();
		}

		public static int getFreeRamMb()
		{
			ulong freeMemory = new ComputerInfo().AvailablePhysicalMemory;
			int freeMemoryInMb = (int)(freeMemory / 1024 / 1024);
			return freeMemoryInMb;
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		public void readConfigFile()
		{
			string configFilePath = Path.Combine(Path.GetTempPath(), "RamDiskManager.ini");
			if (File.Exists(configFilePath))
			{
				// Lecture du contenu du fichier
				string iniContent = File.ReadAllText(configFilePath);
				//MessageBox.Show(iniContent);
				// Analyse du contenu pour récupérer les valeurs
				string[] lines = iniContent.Split('\n');
				foreach (string line in lines)
				{
					string[] parts = line.Split('=');
					if (parts.Length == 2)
					{
						string key = parts[0].Trim();
						string value = parts[1].Trim();

						// Utilisation des valeurs récupérées
						switch (key)
						{
							case "SizeInMb":
								SizeInMb = int.Parse(value);
								// Faire quelque chose avec sizeInMb...
								break;
							case "DriveLetter":
								DriveLetter = value[0];
								// Faire quelque chose avec driveLetter...
								break;
							case "VolumeLabel":
								VolumeLabel = value;
								// Faire quelque chose avec volumeLabel...
								break;
							case "CleanRam":
								RamClean = bool.Parse(value);
								// Faire quelque chose avec cleanRam...
								break;
							default:
								// Clé inconnue, ignorer ou gérer l'erreur selon vos besoins
								break;
						}
						
					}
				}
			}
			else
			{
				MessageBox.Show(configFilePath + " not found");
				// Le fichier de configuration n'existe pas encore
				// Gérer l'absence du fichier selon vos besoins
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			MessageBox.Show(getFreeRamMb().ToString());
			Console.WriteLine("Clean Ram !");
			RamCleaner.Program.Run();
			Thread.Sleep(1000);
			MessageBox.Show(getFreeRamMb().ToString());
		}
	}
}
