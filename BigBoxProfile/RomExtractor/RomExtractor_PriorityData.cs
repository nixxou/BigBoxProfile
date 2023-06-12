using Newtonsoft.Json;
using SevenZip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

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

		public Dictionary<string, RomExtractor_ArchiveFileData> FileDataWithoutPath = new Dictionary<string, RomExtractor_ArchiveFileData>();
		public Dictionary<string, RomExtractor_ArchiveFileData> FileDataWithPath = new Dictionary<string, RomExtractor_ArchiveFileData>(); 
		//public SevenZipExtractor sevenZipExtractor = null;

		
		public bool IsSmart = false;
		public string archiveSignature = "";
		public string Signature = "";
		public string SignatureShort = "";
		public string PriorityFile = "";

		public DateTime startTime;
		public bool copyStart = false;
		public bool copyCompleted = false;
		public byte percentDone = 0;

		public string outFile;

		public List<string> filelist = new List<string>();
		public List<string> filelist_standalone = new List<string>();
		public List<string> filelist_metadata = new List<string>();



		public RomExtractor_ArchiveFile(string archiveFilePath,string metadata, string standalone,RomExtractor_PriorityData priority)
		{
			if (!File.Exists(archiveFilePath)) throw (new Exception($"File {archiveFilePath} does not exist"));


			ArchiveFilePath = archiveFilePath;
			ArchiveNameWithoutPath = Path.GetFileName(ArchiveFilePath);
			Priority = priority;
			StandaloneList = SplitExtensions(standalone).ToList();
			MetadataList = SplitExtensions(metadata).ToList();

			SevenZipExtractor.SetLibraryPath(@"C:\Program Files\7-Zip-Zstandard\7z.dll");
			//sevenZipExtractor = new SevenZipExtractor(archiveFilePath);

			string signature_data = Path.GetFileName(archiveFilePath).ToLower() + "_";


			IsSmart = true;

			using (var sevenZipExtractor = new SevenZipExtractor(ArchiveFilePath))
			{
				foreach (var s in sevenZipExtractor.ArchiveFileData)
				{
					if (!s.IsDirectory)
					{
						var archiveFile = new RomExtractor_ArchiveFileData(s, StandaloneList, MetadataList);
						if (archiveFile.IsMetadata == false && archiveFile.IsStandalone == false) IsSmart = false;
						signature_data += "C" + archiveFile.Crc.ToString() + "S" + archiveFile.Size.ToString();

						FileDataWithPath.Add(archiveFile.FileNameWithPath, archiveFile);
						if (!FileDataWithoutPath.ContainsKey(archiveFile.FileNameWithoutPath))
						{
							filelist.Add(archiveFile.FileNameWithoutPath);
							FileDataWithoutPath.Add(archiveFile.FileNameWithoutPath, archiveFile);
							if(archiveFile.IsMetadata) filelist_metadata.Add(archiveFile.FileNameWithoutPath);
							if(archiveFile.IsStandalone) filelist_standalone.Add(archiveFile.FileNameWithoutPath);
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
			Signature= hashString;

			string cleanedString = Regex.Replace(ArchiveNameWithoutPath, "[^A-Za-z0-9_ ]", "");
			cleanedString = cleanedString.Trim().Trim('_').Trim();
			SignatureShort = cleanedString.Substring(0, (cleanedString.Length >= 10) ? 10 : cleanedString.Length) + "_" + hashString.Substring(0, 8).ToUpper();

			PriorityFile = find_priority_file(filelist_standalone.ToArray(), Priority);

		}


		public void ExtractArchiveWithProgress(string fileToExtract, string dirOut)
		{

			dirOut = Path.Combine(dirOut, Priority.CacheSubDir);
			if (IsSmart==false || Priority.SmartExtract == false) dirOut = Path.Combine(dirOut, SignatureShort);
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

		public async Task<string> ExtractArchiveWithProgressAsync(string fileToExtract, string dirOut, IProgress<ExtractionProgress> progress)
		{
			dirOut = Path.Combine(dirOut, Priority.CacheSubDir);
			if (IsSmart == false || Priority.SmartExtract == false)
				dirOut = Path.Combine(dirOut, SignatureShort);
			Directory.CreateDirectory(dirOut);

			copyCompleted = false;
			copyStart = false;
			startTime = DateTime.Now;
			percentDone = 0;
			outFile = "";
			try
			{
				SevenZipExtractor.SetLibraryPath(@"C:\Program Files\7-Zip-Zstandard\7z.dll");
				using (var extractor = new SevenZipExtractor(ArchiveFilePath))
				{
					extractor.PreserveDirectoryStructure = (IsSmart && Priority.SmartExtract) ? false : true;
					copyStart = true;

					extractor.Extracting += (senderExtractor, eExtractor) =>
					{
						percentDone = eExtractor.PercentDone;
						progress.Report(new ExtractionProgress { PercentDone = eExtractor.PercentDone });
					};

					if (IsSmart && Priority.SmartExtract)
					{
						extractor.ExtractFiles(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithPath);
						outFile = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithoutPath);
					}
					else
					{
						extractor.ExtractArchive(dirOut);
						outFile = Path.Combine(dirOut, FileDataWithoutPath[fileToExtract].FileNameWithPath);
					}
					
						


					copyCompleted = true;
					percentDone = 100;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return outFile;
		}



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
