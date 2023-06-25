using CliWrap;
using Newtonsoft.Json;
using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.RomExtractorUtils
{
	public class ExtractionProgress
	{
		public int PercentDone { get; set; }
	}
	public class RomExtractor_ArchiveFile
	{

		public string ArchiveFilePath = "";
		public string ArchiveNameWithoutPath = "";
		public RomExtractor_PriorityData Priority = null;
		public List<string> StandaloneList = new List<string>();
		public List<string> MetadataList = new List<string>();
		public long UnpackedSize = 0;

		public string CacheDir = "";
		public RomExtractor_ArchiveFileMetaData archiveMetaData = null;

		public Dictionary<string, RomExtractor_ArchiveFileData> FileDataWithoutPath = new Dictionary<string, RomExtractor_ArchiveFileData>();
		public Dictionary<string, RomExtractor_ArchiveFileData> FileDataWithPath = new Dictionary<string, RomExtractor_ArchiveFileData>();
		//public SevenZipExtractor sevenZipExtractor = null;

		public int CacheMaxSize;
		public string[] PrioritySubDirFullList;

		public bool IsSmart = false;
		public string archiveSignature = "";
		public string Signature = "";
		public string SignatureShort = "";
		public string PriorityFile = "";
		public string TruePriorityFile = "";

		public DateTime startTime;
		public bool copyStart = false;
		public bool copyCompleted = false;
		public byte percentDone = 0;

		public string outFile;

		public List<string> filelist = new List<string>();
		public List<string> filelist_standalone = new List<string>();
		public List<string> filelist_metadata = new List<string>();

		public List<string> topPriorityFiles = new List<string>();
		public List<string> topPriorityOnlyFiles = new List<string>();

		static IProgress<ExtractionProgress> progress = null;

		RamDiskLauncher RamDisk = null;
		public string OutTarget = "";

		string SevenZipExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "7z.exe");
		string SevenZipDll = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "7z.dll");

		public RomExtractor_ArchiveFile(string archiveFilePath, string metadata, string standalone, RomExtractor_PriorityData priority, string cacheDir, int cacheMaxSize, string[] prioritySubDirFullList, RamDiskLauncher ramDisk)
		{
			if (!File.Exists(archiveFilePath)) throw (new Exception($"File {archiveFilePath} does not exist"));

			CacheDir = cacheDir;
			CacheMaxSize = cacheMaxSize;
			PrioritySubDirFullList = prioritySubDirFullList;
			RamDisk = ramDisk;

			ArchiveFilePath = archiveFilePath;
			ArchiveNameWithoutPath = Path.GetFileName(ArchiveFilePath);
			Priority = priority;
			StandaloneList = SplitExtensions(standalone).ToList();
			MetadataList = SplitExtensions(metadata).ToList();

			SevenZipExtractor.SetLibraryPath(SevenZipDll);
			//sevenZipExtractor = new SevenZipExtractor(archiveFilePath);

			string signature_data = Path.GetFileName(archiveFilePath).ToLower() + "_";


			IsSmart = true;

			using (var sevenZipExtractor = new SevenZipExtractor(ArchiveFilePath))
			{
				foreach (var s in sevenZipExtractor.ArchiveFileData)
				{
					if (!s.IsDirectory)
					{
						UnpackedSize += (long)s.Size;
						var archiveFile = new RomExtractor_ArchiveFileData(s, StandaloneList, MetadataList);
						if (archiveFile.IsMetadata == false && archiveFile.IsStandalone == false) IsSmart = false;
						signature_data += "C" + archiveFile.Crc.ToString() + "S" + archiveFile.Size.ToString();

						FileDataWithPath.Add(archiveFile.FileNameWithPath, archiveFile);
						if (!FileDataWithoutPath.ContainsKey(archiveFile.FileNameWithoutPath))
						{
							filelist.Add(archiveFile.FileNameWithoutPath);
							FileDataWithoutPath.Add(archiveFile.FileNameWithoutPath, archiveFile);
							if (archiveFile.IsMetadata) filelist_metadata.Add(archiveFile.FileNameWithoutPath);
							if (archiveFile.IsStandalone) filelist_standalone.Add(archiveFile.FileNameWithoutPath);
						}
					}
				}
			}


			string hashString = "";
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(signature_data);
				byte[] hashBytes = md5.ComputeHash(inputBytes);
				hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

			}
			Signature = hashString;

			string cleanedString = Regex.Replace(ArchiveNameWithoutPath, "[^A-Za-z0-9_ ]", "");
			cleanedString = cleanedString.Trim().Trim('_').Trim();
			SignatureShort = cleanedString.Substring(0, (cleanedString.Length >= 10) ? 10 : cleanedString.Length) + "_" + hashString.Substring(0, 8).ToUpper();

			archiveMetaData = new RomExtractor_ArchiveFileMetaData(ArchiveNameWithoutPath, SignatureShort, Signature);
			archiveMetaData.Load(cacheDir);

			int nb_extra_favorite = 5;
			if (archiveMetaData.GetMostRecentGame() != null)
			{
				PriorityFile = archiveMetaData.GetMostRecentGame();
			}
			else
			{
				PriorityFile = find_priority_file(filelist_standalone.ToArray(), Priority);
				TruePriorityFile = PriorityFile;
				nb_extra_favorite = 4;
			}


			List<string> filelist_standalone_restant = new List<string>();
			string otherPriorityFile = PriorityFile;
			if (PriorityFile != "")
			{
				topPriorityFiles.Add(PriorityFile);
				filelist_standalone_restant.AddRange(filelist_standalone);
				filelist_standalone_restant.Remove(PriorityFile);
			}

			for (int i = 0; i < nb_extra_favorite; i++)
			{
				if (filelist_standalone_restant.Count == 0) break;
				if (otherPriorityFile == "") break;
				otherPriorityFile = find_priority_file(filelist_standalone_restant.ToArray(), Priority);
				if (otherPriorityFile != "")
				{
					if (TruePriorityFile == "") TruePriorityFile = otherPriorityFile;
					filelist_standalone_restant.Remove(otherPriorityFile);
					topPriorityFiles.Add(otherPriorityFile);
				}
			}
			foreach (var f in archiveMetaData.FavoritesGames)
			{
				if (filelist_standalone_restant.Contains(f))
				{
					filelist_standalone_restant.Remove(f);
					topPriorityFiles.Add(f);
				}
			}
			foreach (var f in archiveMetaData.LastGamesPlayed)
			{
				if (filelist_standalone_restant.Contains(f))
				{
					filelist_standalone_restant.Remove(f);
					topPriorityFiles.Add(f);
				}
			}

			filelist_standalone_restant.Clear();
			filelist_standalone_restant.AddRange(filelist_standalone);
			for (int i = 0; i < 5; i++)
			{
				otherPriorityFile = find_priority_file(filelist_standalone_restant.ToArray(), Priority);
				if (otherPriorityFile != "")
				{
					filelist_standalone_restant.Remove(otherPriorityFile);
					topPriorityOnlyFiles.Add(otherPriorityFile);
				}
			}


		}


		public void ExtractArchiveWithProgress(string fileToExtract, string dirOut)
		{

			dirOut = Path.Combine(dirOut, Priority.CacheSubDir);
			if (IsSmart == false || Priority.SmartExtract == false) dirOut = Path.Combine(dirOut, SignatureShort);
			Directory.CreateDirectory(dirOut);

			copyCompleted = false;
			copyStart = false;
			startTime = DateTime.Now;
			percentDone = 0;
			try
			{
				using (var extractor = new SevenZipExtractor(ArchiveFilePath))
				{
					extractor.PreserveDirectoryStructure = (IsSmart && Priority.SmartExtract) ? false : true;
					copyStart = true;
					extractor.Extracting += (senderExtractor, eExtractor) =>
					{
						percentDone = eExtractor.PercentDone;
						//Console.WriteLine(percentDone.ToString());
						//MessageBox.Show(eExtractor.PercentDone.ToString());
					};

					Thread.Sleep(50);
					//extractor.ExtractArchive(dirOut);

					if (IsSmart && Priority.SmartExtract) extractor.ExtractFiles(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithPath);
					else extractor.ExtractArchive(dirOut);

					copyCompleted = true;
					percentDone = 100;

				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		public async Task<string> ExtractFileFromArchive(string fileToExtract, string dirOut)
		{
			var result = await Cli.Wrap(SevenZipExe)
				.WithArguments(new[] { "e", ArchiveFilePath, FileDataWithoutPath[fileToExtract].FileNameWithPath, @"-o" + dirOut, "-bsp1", "-y" })
				.ExecuteAsync();
			outFile = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithoutPath);
			return outFile;
		}

		public async Task<string> SimpleExtractArchiveWithProgressAsync(string fileToExtract, string dirOut, IProgress<ExtractionProgress> progress)
		{
			RomExtractor_ArchiveFile.progress = progress;
			string outFileResult = "";
			try
			{
				var result = await Cli.Wrap(SevenZipExe)
					.WithArguments(new[] { "e", ArchiveFilePath, FileDataWithoutPath[fileToExtract].FileNameWithPath, @"-o" + dirOut, "-bsp1", "-y" })
					.WithStandardOutputPipe(PipeTarget.ToDelegate(handleStdOut))
					.ExecuteAsync();
				outFileResult = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithoutPath);
				File.SetLastWriteTime(outFileResult, DateTime.Now);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return outFileResult;
		}

		public async Task<string> ExtractArchiveWithProgressAsync(string fileToExtract, string dirOut, IProgress<ExtractionProgress> progress, bool forcedirect = false)
		{
			RomExtractor_ArchiveFile.progress = progress;
			dirOut = Path.Combine(dirOut, Priority.CacheSubDir);
			if (IsSmart == false || Priority.SmartExtract == false)
				dirOut = Path.Combine(dirOut, SignatureShort);

			//Launch direct if file exist
			if (IsSmart == false || Priority.SmartExtract == false)
			{
				if (Directory.Exists(dirOut))
				{
					string FileToExec = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithPath);
					if (File.Exists(FileToExec))
					{
						ulong filesize = (ulong)new FileInfo(FileToExec).Length;
						if (filesize == FileDataWithoutPath[fileToExtract].Size)
						{
							OutTarget = dirOut;
							Directory.SetLastWriteTime(dirOut, DateTime.Now);
							File.SetLastWriteTime(FileToExec, DateTime.Now);
							outFile = FileToExec;
							copyCompleted = true;
							percentDone = 100;
							archiveMetaData.AddGameToLastPlayed(fileToExtract);
							archiveMetaData.Save();
							return outFile;
						}
					}
				}
			}
			else
			{
				if (Directory.Exists(dirOut))
				{
					string FileToExec = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithoutPath);
					if (File.Exists(FileToExec))
					{
						ulong filesize = (ulong)new FileInfo(FileToExec).Length;
						if (filesize == FileDataWithoutPath[fileToExtract].Size)
						{
							OutTarget = FileToExec;
							File.SetLastWriteTime(FileToExec, DateTime.Now);
							outFile = FileToExec;
							copyCompleted = true;
							percentDone = 100;
							archiveMetaData.AddGameToLastPlayed(fileToExtract);
							archiveMetaData.Save();
							return outFile;
						}
					}
				}
			}

			double GameInMb = 0;
			if (IsSmart == false || Priority.SmartExtract == false)
			{
				GameInMb = UnpackedSize / (1024.0 * 1024.0);
			}
			else
			{
				GameInMb = FileDataWithoutPath[fileToExtract].Size / (1024.0 * 1024.0);
			}

			string RamDiskPath = "";
			if (Priority.UseRamdisk && GameInMb < Priority.MaxSize)
			{
				int fileSizeMB = (int)(GameInMb * 1.03);
				fileSizeMB += 30;
				fileSizeMB = BigBoxUtils.GetDiskSize(fileSizeMB);

				if (fileSizeMB < Priority.MaxSize)
				{
					bool resMount = RamDisk.Mount(fileSizeMB);
					if (resMount)
					{
						RamDiskPath = Path.Combine(RamDisk.RamDriveLetter + ":\\");

						dirOut = Path.Combine(RamDiskPath, Priority.CacheSubDir);
						if (IsSmart == false || Priority.SmartExtract == false)
							dirOut = Path.Combine(RamDiskPath, SignatureShort);
					}
				}
			}

			if (CacheMaxSize > 0)
			{
				long maxSizeCache = CacheMaxSize;
				if (RamDiskPath == "") maxSizeCache -= (long)(GameInMb);
				List<String> RepertoireListIn = new List<String>();
				foreach (var subdir in PrioritySubDirFullList) RepertoireListIn.Add(Path.Combine(CacheDir, subdir));
				RomExtractor_RepertoireUtils.KeepCacheUnder(maxSizeCache, RepertoireListIn, CacheDir);
			}

			Directory.CreateDirectory(dirOut);

			copyCompleted = false;
			copyStart = false;
			startTime = DateTime.Now;
			percentDone = 0;
			outFile = "";
			try
			{

				if (IsSmart && Priority.SmartExtract)
				{
					var result = await Cli.Wrap(SevenZipExe)
						.WithArguments(new[] { "e", ArchiveFilePath, FileDataWithoutPath[fileToExtract].FileNameWithPath, @"-o" + dirOut, "-bsp1", "-y" })
						.WithStandardOutputPipe(PipeTarget.ToDelegate(handleStdOut))
						.ExecuteAsync();
					outFile = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithoutPath);
					File.SetLastWriteTime(outFile, DateTime.Now);
					OutTarget = outFile;
				}
				else
				{
					var result = await Cli.Wrap(SevenZipExe)
						.WithArguments(new[] { "x", ArchiveFilePath, @"-o" + dirOut, "-bsp1", "-y" })
						.WithStandardOutputPipe(PipeTarget.ToDelegate(handleStdOut))
						.ExecuteAsync();
					outFile = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithPath);
					File.SetLastWriteTime(outFile, DateTime.Now);
					Directory.SetLastWriteTime(dirOut, DateTime.Now);
					OutTarget = dirOut;
					RomExtractor_ArchiveSizeCache DirData = new RomExtractor_ArchiveSizeCache(SignatureShort, UnpackedSize);
					DirData.Save(CacheDir);
				}





				copyCompleted = true;
				percentDone = 100;
				archiveMetaData.AddGameToLastPlayed(fileToExtract);
				archiveMetaData.Save();



			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return outFile;
		}

		Action<string> handleStdOut = delegate (string msg)
		{
			//Console.WriteLine("MSG= " + msg);
			string pattern = @"([0-9]*)%";
			string input = msg;

			// Utilise la regex pour trouver les correspondances
			Match match = Regex.Match(input, pattern);

			if (match.Success)
			{
				// Récupère la valeur du pourcentage d'avancement
				string percentage = match.Groups[1].Value;

				// Convertit la valeur en entier si nécessaire
				int progress = 0;
				if (int.TryParse(percentage, out progress))
				{
					RomExtractor_ArchiveFile.progress.Report(new ExtractionProgress { PercentDone = progress });
					// Affiche le pourcentage d'avancement
					Console.WriteLine("Pourcentage d'avancement : " + progress + "%");
				}
			}
			if (msg.Contains("Everything is Ok"))
			{
				int progress = 100;
				RomExtractor_ArchiveFile.progress.Report(new ExtractionProgress { PercentDone = progress });
				Console.WriteLine("Pourcentage d'avancement : " + progress + "%");
			}

		};


		public static string[] SplitExtensions(string extensions)
		{
			return extensions.ToLower().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(ex => ex.Trim()).ToArray();
		}

		public static string find_priority_file(string[] fileList, RomExtractor_PriorityData priority)
		{
			foreach (string extension in priority.Priority)
			{
				foreach (string fl in fileList)
				{
					if (Wildcard.Match(fl.ToLower(), string.Format("*{0}", extension.ToLower().Trim())))
					{
						return fl;
					}
				}


			}
			return "";
		}

		public static void fix_bezel(string retroarchdir, string coredll, string archiveName, string extractedfile)
		{
			string corematchFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "corematch.json");
			Dictionary<string, string> corematch = new Dictionary<string, string>();
			string jsonData = File.ReadAllText(corematchFile);
			corematch = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
			if (corematch.ContainsKey(coredll))
			{
				string coredir = Path.Combine(retroarchdir, "config", corematch[coredll]);
				if (Directory.Exists(coredir))
				{
					string cfg_source = Path.Combine(coredir, Path.GetFileNameWithoutExtension(archiveName) + ".cfg");
					string cfg_dest = Path.Combine(coredir, Path.GetFileNameWithoutExtension(extractedfile) + ".cfg");
					if (File.Exists(cfg_source))
					{
						bool valid_dest = true;
						if (File.Exists(cfg_dest))
						{
							if (!BigBoxUtils.IsSoftlink(cfg_dest))
							{
								valid_dest = false;
							}
							else
							{
								File.Delete(cfg_dest);
							}
						}

						if (valid_dest)
						{
							BigBoxUtils.CreateSoftlink(cfg_source, cfg_dest);
						}

					}

				}
			}



		}
	}

	public class RomExtractor_ArchiveFileData
	{
		public string FileNameWithoutPath;
		public string Extension;
		public string FileNameWithPath;
		public ulong Size;
		public uint Crc;
		public bool Encrypted;
		public int Index;
		public bool IsStandalone;
		public bool IsMetadata;

		public RomExtractor_ArchiveFileData(ArchiveFileInfo fileInfo, List<string> standaloneList, List<string> metadataList)
		{
			Size = fileInfo.Size;
			Crc = fileInfo.Crc;
			FileNameWithPath = fileInfo.FileName;
			Encrypted = fileInfo.Encrypted;
			Index = fileInfo.Index;
			FileNameWithoutPath = Path.GetFileName(fileInfo.FileName);
			Extension = Path.GetExtension(fileInfo.FileName).TrimStart(new char[] { '.' }).ToLower();
			IsStandalone = standaloneList.Contains(Extension) ? true : false;
			IsMetadata = metadataList.Contains(Extension) ? true : false;
		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}


	}

	public class RomExtractor_ArchiveFileMetaData
	{
		public string ArchiveName;
		public string SignatureShort;
		public string SignatureLong;
		public List<string> LastGamesPlayed = new List<string>(5);
		public HashSet<string> FavoritesGames = new HashSet<string>();
		public string CacheDir;

		public RomExtractor_ArchiveFileMetaData(string archiveName, string signatureShort, string signatureLong)
		{
			ArchiveName = archiveName;
			SignatureShort = signatureShort;
			SignatureLong = signatureLong;
		}

		public bool Load(string directory)
		{
			CacheDir = directory;
			if (Directory.Exists(directory))
			{
				if (!Directory.Exists(Path.Combine(directory, ".romextractor"))) Directory.CreateDirectory(Path.Combine(directory, ".romextractor"));
				string jsonFile = Path.Combine(directory, ".romextractor", SignatureShort + ".json");
				if (File.Exists(jsonFile))
				{
					string jsonData = File.ReadAllText(jsonFile);
					RomExtractor_ArchiveFileMetaData DeserializeData = JsonConvert.DeserializeObject<RomExtractor_ArchiveFileMetaData>(jsonData);
					this.LastGamesPlayed = DeserializeData.LastGamesPlayed;
					this.FavoritesGames = DeserializeData.FavoritesGames;
				}
			}
			return false;
		}

		public void Save()
		{
			if (CacheDir == "") return;
			string directory = CacheDir;
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}
			if (!Directory.Exists(Path.Combine(directory, ".romextractor"))) Directory.CreateDirectory(Path.Combine(directory, ".romextractor"));

			string jsonFile = Path.Combine(directory, ".romextractor", SignatureShort + ".json");
			File.WriteAllText(jsonFile, Serialize());
		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}

		public void AddGameToLastPlayed(string game)
		{
			if (LastGamesPlayed.Contains(game))
			{
				LastGamesPlayed.Remove(game);
			}

			LastGamesPlayed.Add(game);

			if (LastGamesPlayed.Count > 5)
			{
				LastGamesPlayed.RemoveAt(0);
			}
		}

		public string GetMostRecentGame()
		{
			if (LastGamesPlayed.Count > 0)
			{
				return LastGamesPlayed[LastGamesPlayed.Count - 1];
			}
			else
			{
				return null;
			}
		}


	}

	public class RomExtractor_ArchiveSizeCache
	{
		public string DirName;
		public long Size;

		public RomExtractor_ArchiveSizeCache(string dirName, long size)
		{
			DirName = dirName;
			Size = size;
		}

		public static RomExtractor_ArchiveSizeCache Load(string jsonFile)
		{
			if (File.Exists(jsonFile))
			{
				string jsonData = File.ReadAllText(jsonFile);
				RomExtractor_ArchiveSizeCache DeserializeData = JsonConvert.DeserializeObject<RomExtractor_ArchiveSizeCache>(jsonData);
				return DeserializeData;
			}
			return null;
		}

		public void Save(string cacheDir)
		{
			if (!Directory.Exists(Path.Combine(cacheDir, ".romextractor", "DirCache"))) Directory.CreateDirectory(Path.Combine(cacheDir, ".romextractor", "DirCache"));
			string jsonFile = Path.Combine(cacheDir, ".romextractor", "DirCache", DirName + ".json");
			File.WriteAllText(jsonFile, Serialize());
		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}

	}

	public class RomExtractor_FileOrDirInfo
	{
		public string Nom { get; set; }
		public bool EstFichier { get; set; }
		public DateTime DateModification { get; set; }
		public long Taille { get; set; }
	}

	public class RomExtractor_RepertoireUtils
	{
		public static void KeepCacheUnder(long maxSizeInMb, List<string> repertoireListIn, string BaseCacheDir, string ExcludeFromDelete = "")
		{
			if (ExcludeFromDelete != "") ExcludeFromDelete = Path.GetFullPath(ExcludeFromDelete).TrimEnd('\\').ToLower();

			List<string> repertoireList = new List<string>();
			repertoireList.Add(Path.GetFullPath(BaseCacheDir).TrimEnd('\\').ToLower());
			foreach (var r in repertoireListIn)
			{
				repertoireList.Add(Path.GetFullPath(r).TrimEnd('\\').ToLower());
			}


			List<RomExtractor_FileOrDirInfo> fichiersRepertoires = new List<RomExtractor_FileOrDirInfo>();


			foreach (string repertoire in repertoireList)
			{
				if (Directory.Exists(repertoire))
				{
					string[] fichiers = Directory.GetFiles(repertoire, "*", SearchOption.TopDirectoryOnly);
					string[] repertoires = Directory.GetDirectories(repertoire, "*", SearchOption.TopDirectoryOnly);

					foreach (string fichier in fichiers)
					{
						FileInfo fileInfo = new FileInfo(fichier);
						RomExtractor_FileOrDirInfo info = new RomExtractor_FileOrDirInfo
						{
							Nom = fileInfo.FullName,
							EstFichier = true,
							DateModification = fileInfo.LastWriteTime,
							Taille = fileInfo.Length
						};
						fichiersRepertoires.Add(info);
					}

					foreach (string rep in repertoires)
					{
						var repFormated = Path.GetFullPath(rep).TrimEnd('\\').ToLower();
						if (repFormated == Path.GetFullPath(Path.Combine(BaseCacheDir, ".romextractor")).TrimEnd('\\').ToLower()) continue;
						if (repertoireList.Contains(repFormated)) continue;

						DirectoryInfo directoryInfo = new DirectoryInfo(rep);
						RomExtractor_FileOrDirInfo info = new RomExtractor_FileOrDirInfo
						{
							Nom = directoryInfo.FullName,
							EstFichier = false,
							DateModification = directoryInfo.LastWriteTime,
							Taille = CalculeTailleRepertoire(directoryInfo, BaseCacheDir)
						};
						fichiersRepertoires.Add(info);
					}
				}
			}

			fichiersRepertoires.Sort((fichier1, fichier2) =>
				fichier1.DateModification.CompareTo(fichier2.DateModification));

			long tailleTotale = 0;
			foreach (RomExtractor_FileOrDirInfo fichierRepertoire in fichiersRepertoires)
			{
				tailleTotale += fichierRepertoire.Taille;
			}

			long targetSize = maxSizeInMb * (1024 * 1024);
			if (tailleTotale > targetSize)
			{
				long currentSize = tailleTotale;
				foreach (var elem in fichiersRepertoires)
				{
					if (ExcludeFromDelete != "")
					{
						var elemFormated = Path.GetFullPath(elem.Nom).TrimEnd('\\').ToLower();
						if (elemFormated == ExcludeFromDelete)
						{
							continue;
						}
					}
					if (elem.EstFichier)
					{
						try
						{
							File.Delete(elem.Nom);
						}
						catch { }
					}
					else
					{
						try
						{
							BigBoxUtils.EmptyFolder(elem.Nom);
							if (Directory.Exists(elem.Nom)) Directory.Delete(elem.Nom);
						}
						catch { }


					}
					currentSize -= elem.Taille;
					if (currentSize <= targetSize) break;
				}
			}
		}


		private static long CalculeTailleRepertoire(DirectoryInfo directoryInfo, string BaseCacheDir)
		{
			long taille = 0;
			string JsonFile = Path.Combine(BaseCacheDir, ".romextractor", "DirCache", directoryInfo.Name + ".json");
			if (File.Exists(JsonFile))
			{
				var Data = RomExtractor_ArchiveSizeCache.Load(JsonFile);
				if (Data.Size > 0) return Data.Size;
			}

			FileInfo[] fichiers = directoryInfo.GetFiles("*", SearchOption.AllDirectories);
			foreach (FileInfo fichier in fichiers)
			{
				taille += fichier.Length;
			}
			return taille;
		}
	}


	public class RomExtractor_PriorityData
	{
		public string CacheSubDir { get; set; }
		public List<string> Paths { get; set; }
		public List<string> Priority { get; set; }
		public bool UseRamdisk { get; set; }

		public int MaxSize { get; set; }

		public bool DeleteOnExit { get; set; }

		public bool SmartExtract { get; set; }

		public RomExtractor_PriorityData()
		{
			this.CacheSubDir = "";
			this.Paths = new List<string>();
			this.Priority = new List<string>();
			this.UseRamdisk = false;
			this.MaxSize = 1000;
			this.DeleteOnExit = false;
			this.SmartExtract = true;
		}

		public RomExtractor_PriorityData(string json)
		{
			RomExtractor_PriorityData DeserializeData = JsonConvert.DeserializeObject<RomExtractor_PriorityData>(json);
			this.CacheSubDir = DeserializeData.CacheSubDir;
			this.Paths = DeserializeData.Paths;
			this.Priority = DeserializeData.Priority;
			this.UseRamdisk = DeserializeData.UseRamdisk;
			this.MaxSize = DeserializeData.MaxSize;
			this.DeleteOnExit = DeserializeData.DeleteOnExit;
			this.SmartExtract = DeserializeData.SmartExtract;
		}


		public string[] ToStringArray()
		{
			var arrayString = new string[7];
			arrayString[0] = Serialize();
			arrayString[1] = BigBoxUtils.Join(this.Paths.ToArray(), ",");
			arrayString[2] = BigBoxUtils.Join(this.Priority.ToArray(), ",");
			arrayString[3] = this.CacheSubDir;
			arrayString[4] = (this.UseRamdisk ? "YES : max size = " + this.MaxSize + " Mo" : "NO");
			arrayString[5] = (this.DeleteOnExit ? "YES" : "NO");
			arrayString[6] = (this.SmartExtract ? "YES" : "NO");
			return arrayString;

		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}

	}


}
