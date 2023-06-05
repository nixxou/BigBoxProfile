using Microsoft.VisualBasic.Devices;
using RamDisk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RamDiskManager
{
	internal class RamDiskMount
	{
		public int SizeInMb { get; set; }
		public char DriveLetter { get; set; }
		public bool RamClean { get; set; }
		public string VolumeLabel { get; set; }

		public string Command = "";


		public RamDiskMount(string[] args)
		{
			SizeInMb = 0;
			DriveLetter = '\0';
			VolumeLabel = "Ramdisk";

			if (args.Length == 1 && args[0] == "mount")
			{
				readConfigFile();
				Command = args[0];

				if (SizeInMb > 0 && DriveLetter != '\0')
				{
					if (!Directory.Exists(DriveLetter + ":\\"))
					{
						int freeRamInMB = getFreeRamMb();
						if (SizeInMb < freeRamInMB)
						{
							RamCleaner.Program.Run();
							Thread.Sleep(2000);
						}
						freeRamInMB = getFreeRamMb();
						if (freeRamInMB > SizeInMb)
						{
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
		}

		public static int getFreeRamMb()
		{
			ulong freeMemory = new ComputerInfo().AvailablePhysicalMemory;
			int freeMemoryInMb = (int)(freeMemory / 1024 / 1024);
			return freeMemoryInMb;
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
				// Le fichier de configuration n'existe pas encore
				// Gérer l'absence du fichier selon vos besoins
			}
		}

	}
}
