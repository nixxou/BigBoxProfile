using CefSharp.DevTools.Target;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace BigBoxProfile
{
	public class ProfileFileSwitcher
	{
		bool CanUseLink = false;
		bool HasProfileDir = false;
		public bool Active = false;

		string ConfigDir = "";
		string DefaultProfile = "";
		string LastLaunchedFile = "";

		[DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
		//static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);
		static extern bool CreateHardLink(
string lpFileName,
string lpExistingFileName,
IntPtr lpSecurityAttributes
);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		static extern IntPtr FindFirstFileNameW(string lpFileName, uint dwFlags, ref uint StringLength, char[] LinkName);
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		static extern bool FindNextFileNameW(IntPtr hFindStream, ref uint StringLength, char[] LinkName);
		[DllImport("kernel32.dll", SetLastError = true)]
		static extern bool FindClose(IntPtr hFindFile);
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		static extern bool GetVolumePathName(string lpszFileName, [Out] char[] lpszVolumePathName, uint cchBufferLength);
		private static readonly IntPtr INVALID_HANDLE_VALUE = (IntPtr)(-1); // 0xffffffff;
		private const int MAX_PATH = 65535; // Max. NTFS path length.

		public ProfileFileSwitcher(string LaunchboxExe)
		{
			//abord if launchbox is already launched
			string LaunchboxDir = Path.GetDirectoryName(LaunchboxExe);
			string ParentDir = Directory.GetParent(LaunchboxDir).FullName;
			ConfigDir = Path.Combine(ParentDir, "Data");
			LastLaunchedFile = Path.Combine(ConfigDir, "lastlaunchedprofile.txt");

			DefaultProfile = Path.Combine(ConfigDir, "Profile_Default");

			CanUseLink = VerifyHardLinkPermissions(ConfigDir);

			HasProfileDir = Directory.GetDirectories(ConfigDir, "Profile_*").Length > 0 ? true : false;

			if (CanUseLink && HasProfileDir)
			{
				Active = true;
				if (File.Exists(Path.Combine(ConfigDir, "Settings.xml")))
				{
					if (!Directory.Exists(DefaultProfile))
					{
						GenerateDefaultProfile();
					}
				}
			}
		}

		public void GenerateDefaultProfile()
		{
			CloneDirectory(ConfigDir, DefaultProfile, "*.xml", "Profile_");
		}

		/*
		public void OpenProfile(string ProfileName)
		{
			string ProfileDir = Path.Combine(ConfigDir, "Profile_" + ProfileName);
			if (!Directory.Exists(ProfileDir)) OpenProfile("Default");

			string[] fileListActualConfig = Directory.GetFiles(ConfigDir, "*.xml", SearchOption.TopDirectoryOnly);
			string[] fileListProfile = Directory.GetFiles(ProfileDir, "*.xml", SearchOption.TopDirectoryOnly);
			string[] fileListDefault = Directory.GetFiles(DefaultProfile, "*.xml", SearchOption.TopDirectoryOnly);

			List<string> FileOK = new List<string>();
			List<string> FileToDelete = new List<string>();
			List<string> FileInProfileLeft = new List<string>();
			List<string> FileInDefaultLeft = new List<string>();
			List<string> FileToLink = new List<string>();

			foreach(var f in fileListProfile) FileInProfileLeft.Add(Path.GetFileNameWithoutExtension(f));
			foreach (var f in fileListDefault) FileInDefaultLeft.Add(Path.GetFileNameWithoutExtension(f));



			foreach (var f in fileListActualConfig)
			{

				string FileNameWithoutPath = Path.GetFileNameWithoutExtension(f);
				string ExpectedProfileFileName = Path.Combine(ProfileDir, FileNameWithoutPath);
				string ExpectedDefaultFileName = Path.Combine(DefaultProfile, FileNameWithoutPath);

				if (File.Exists(ExpectedProfileFileName))
				{
					if (isFileLinkedToProfile(FileNameWithoutPath, ProfileDir))
					{
						FileOK.Add(f);
						FileInProfileLeft.Remove(FileNameWithoutPath);
						FileInDefaultLeft.Remove(FileNameWithoutPath);
						continue;
					}
					else
					{
						FileToDelete.Add(f);
					}
				}
				else
				{
					if (File.Exists(ExpectedDefaultFileName))
					{
						if (isFileLinkedToProfile(FileNameWithoutPath, DefaultProfile))
						{
							FileOK.Add(f);
							FileInDefaultLeft.Remove(FileNameWithoutPath);
							continue;
						}
						else
						{
							FileToDelete.Add(f);
						}
					}
					else
					{
						FileToDelete.Add(f);
					}
				}
			}

			foreach(var f in FileInProfileLeft)
			{
				FileToLink.Add(Path.Combine(ProfileDir, f));
				FileInDefaultLeft.Remove(f);
			}
			foreach (var f in FileInDefaultLeft)
			{
				FileToLink.Add(Path.Combine(DefaultProfile, f));
				FileInDefaultLeft.Remove(f);
			}

		}
		*/

		public void OpenProfile(string ProfileName)
		{
			MessageBox.Show("ici");
			if (!CanUseLink || !HasProfileDir) return;

			if (File.Exists(LastLaunchedFile))
			{
				string contenuFichier = File.ReadAllText(LastLaunchedFile);
				CloseProfile(contenuFichier);
			}
			File.WriteAllText(LastLaunchedFile, ProfileName);


			string ProfileDir = Path.Combine(ConfigDir, "Profile_" + ProfileName);
			if (!Directory.Exists(ProfileDir)) OpenProfile("Default");

			string[] fileListActualConfig = Directory.GetFiles(ConfigDir, "*.xml", SearchOption.TopDirectoryOnly);
			string[] fileListProfile = Directory.GetFiles(ProfileDir, "*.xml", SearchOption.TopDirectoryOnly);
			string[] fileListDefault = Directory.GetFiles(DefaultProfile, "*.xml", SearchOption.TopDirectoryOnly);

			List<string> FileInProfileLeft = new List<string>();
			List<string> FileInDefaultLeft = new List<string>();
			foreach (var f in fileListProfile) FileInProfileLeft.Add(Path.GetFileName(f));
			foreach (var f in fileListDefault) FileInDefaultLeft.Add(Path.GetFileName(f));

			foreach (var f in fileListActualConfig)
			{
				File.Delete(f);
			}
			foreach(var f in FileInProfileLeft)
			{
				MakeLink(Path.Combine(ProfileDir,f), Path.Combine(ConfigDir, f));
				FileInDefaultLeft.Remove(f);
			}
			foreach (var f in fileListDefault)
			{
				MakeLink(Path.Combine(DefaultProfile, Path.GetFileName(f)), Path.Combine(ConfigDir, Path.GetFileName(f)));
			}

			string[] subdir = new string[2] { "Platforms", "Playlists" };
			foreach(var dir in subdir)
			{
				var ConfigSubFolder = Path.Combine(ConfigDir, dir);
				var ProfileSubFolder = Path.Combine(ProfileDir, dir);
				var DefaultSubFolder = Path.Combine(DefaultProfile, dir);
				if (Directory.Exists(ConfigSubFolder))
				{
					EmptyFolder(ConfigSubFolder);
					Directory.Delete(ConfigSubFolder);
				}
				Directory.CreateDirectory(ConfigSubFolder);
				if (Directory.Exists(ProfileSubFolder))
				{
					string[] fileList = Directory.GetFiles(ProfileSubFolder, "*.xml", SearchOption.TopDirectoryOnly);
					foreach (var f in fileList)
					{
						MakeLink(f, Path.Combine(ConfigSubFolder, Path.GetFileName(f)));
					}
				}
				else
				{
					string[] fileList = Directory.GetFiles(DefaultSubFolder, "*.xml", SearchOption.TopDirectoryOnly);
					foreach (var f in fileList)
					{
						MakeLink(f, Path.Combine(ConfigSubFolder, Path.GetFileName(f)));
					}
				}

			}
		}

		public bool isFileLinkedToProfile(string file, string Dir)
		{
			string expectedFile = Path.Combine(Dir, file);
			var hardlinks = GetHardLinks(file, true);
			if (hardlinks.Count == 0) return false;
			else
			{
				foreach (var h in hardlinks)
				{
					if (expectedFile.ToLower() == h.ToLower())
					{
						return true;
					}
				}
			}
			return false;

		}

		public void CloseProfile(string ProfileName)
		{
			if (!CanUseLink || !HasProfileDir) return;

			string ProfileDir = Path.Combine(ConfigDir, "Profile_" + ProfileName);

			string[] fileListActualConfig = Directory.GetFiles(ConfigDir, "*.xml", SearchOption.TopDirectoryOnly);
			string[] fileListProfile = Directory.GetFiles(ProfileDir, "*.xml", SearchOption.TopDirectoryOnly);
			string[] fileListDefault = Directory.GetFiles(DefaultProfile, "*.xml", SearchOption.TopDirectoryOnly);



			List<string> FileInProfileLeft = new List<string>();
			List<string> FileInDefaultLeft = new List<string>();
			foreach (var f in fileListProfile) FileInProfileLeft.Add(Path.GetFileName(f));
			foreach (var f in fileListDefault) FileInDefaultLeft.Add(Path.GetFileName(f));


			foreach (var f in fileListActualConfig)
			{
				string ConfigFileWithoutPath = Path.GetFileName(f);
				string ProfileFileWithPath = Path.Combine(ProfileDir, ConfigFileWithoutPath);
				string DefaultFileWithPath = Path.Combine(DefaultProfile, ConfigFileWithoutPath);

				if (FileInProfileLeft.Contains(ConfigFileWithoutPath))
				{
					if(!isFileLinkedToProfile(f, ProfileDir))
					{
						var hardlinks = GetHardLinks(f);
						if (!hardlinks.Contains(ProfileFileWithPath)) hardlinks.Add(ProfileFileWithPath);
						foreach(var link in hardlinks)
						{
							File.Delete(link);
							MakeLink(f, link);
						}
						
					}
					FileInDefaultLeft.Remove(ConfigFileWithoutPath);
				}

				if (FileInDefaultLeft.Contains(ConfigFileWithoutPath))
				{
					if (!isFileLinkedToProfile(f, DefaultProfile))
					{
						var hardlinks = GetHardLinks(f);
						if (!hardlinks.Contains(DefaultFileWithPath)) hardlinks.Add(DefaultFileWithPath);
						foreach (var link in hardlinks)
						{
							File.Delete(link);
							MakeLink(f, link);
						}
					}
				}


			}

			string[] subdir = new string[2] { "Platforms", "Playlists" };
			foreach (var dir in subdir)
			{
				var ConfigSubFolder = Path.Combine(ConfigDir, dir);
				var ProfileSubFolder = Path.Combine(ProfileDir, dir);
				var DefaultSubFolder = Path.Combine(DefaultProfile, dir);
				string targetDir = "";

				if (Directory.Exists(ProfileSubFolder) && targetDir == "")
				{
					targetDir = ProfileSubFolder;
				}
				if (Directory.Exists(DefaultSubFolder) && targetDir == "")
				{
					targetDir = DefaultSubFolder;
				}

				if(targetDir != "")
				{
					string[] fileListActualSubDir = Directory.GetFiles(ConfigSubFolder, "*.xml", SearchOption.TopDirectoryOnly);
					string[] fileListProfileSubDir = Directory.GetFiles(targetDir, "*.xml", SearchOption.TopDirectoryOnly);

					List<string> FileInProfileSubDirLeft = new List<string>();
					foreach (var f in fileListProfileSubDir) FileInProfileSubDirLeft.Add(Path.GetFileName(f));

					foreach (var f in fileListActualSubDir)
					{
						string ConfigFileSubDirWithoutPath = Path.GetFileName(f);
						string TargetFile = Path.Combine(targetDir, ConfigFileSubDirWithoutPath);
						if (File.Exists(TargetFile))
						{
							if (!isFileLinkedToProfile(f, targetDir))
							{
								var hardlinks = GetHardLinks(TargetFile);
								if (!hardlinks.Contains(TargetFile)) hardlinks.Add(TargetFile);
								foreach (var link in hardlinks)
								{
									File.Delete(link);
									MakeLink(f, link);
								}
							}
						}
						else
						{
							MakeLink(f, TargetFile);
						}
						FileInProfileSubDirLeft.Remove(ConfigFileSubDirWithoutPath);
					}
					foreach(var f in FileInProfileSubDirLeft)
					{
						File.Delete(Path.Combine(targetDir, f));
					}
				}
			}

			if (File.Exists(LastLaunchedFile))
			{
				File.Delete(LastLaunchedFile);
			}

		}


		public void CloneDirectory(string source, string destination, string include, string exclude)
		{
			//MessageBox.Show("ici");
			if(!Directory.Exists(destination)) Directory.CreateDirectory(destination);
			string[] fileList = Directory.GetFiles(source, include, SearchOption.TopDirectoryOnly);
			foreach(var f in fileList)
			{
				if (!Path.GetFileName(f).Contains(exclude)) MakeLink(f,Path.Combine(destination, Path.GetFileName(f)));
			}
			string[] directoryList = Directory.GetDirectories(source, "*", SearchOption.TopDirectoryOnly);
			foreach(var d in directoryList)
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(d);
				string dernierRepertoire = directoryInfo.Name;

				if (!dernierRepertoire.Contains(exclude))
				{
					CloneDirectory(Path.Combine(source, dernierRepertoire), Path.Combine(destination, dernierRepertoire), include, exclude);
				}
			}
			return;

		}
		/*
		public void RapportEtat(string ProfilePath)
		{
			//MessageBox.Show("zz");
			List<string> inProfileButNotLinked = new List<string>();


			List<string> filesNotLinkedToMyProfile = new List<string>();

			List<string> configDirList = new List<string>();
			configDirList.Add(ConfigDir);
			configDirList.Add(Path.Combine(ConfigDir, "Platforms"));
			configDirList.Add(Path.Combine(ConfigDir, "Playlists"));

			foreach (var dir in configDirList)
			{
				string[] xmlfiles = Directory.GetFiles(dir, "*.xml", SearchOption.TopDirectoryOnly);
				filesNotLinkedToMyProfile.AddRange(xmlfiles);
			}





			string[] fileListProfile = Directory.GetFiles(ProfilePath, "*.xml", SearchOption.AllDirectories);

			foreach (var f in fileListProfile)
			{
				var hardlinks = GetHardLinks(f,true);
				if (hardlinks.Count == 0) inProfileButNotLinked.Add(f);
				else
				{
					foreach(var h in hardlinks)
					{
						if (filesNotLinkedToMyProfile.Contains(h))
						{
							filesNotLinkedToMyProfile.Remove(h);
						}
					}
				}

			}

			string res = "In Profile but not linked :\n";
			foreach(var f in inProfileButNotLinked)
			{
				res += f + "\n";
			}
			res += "In Config but not linked :\n";
			foreach (var f in filesNotLinkedToMyProfile)
			{
				res += f + "\n";
			}
			MessageBox.Show(res);

		}
		*/

		public static List<string> GetHardLinks(string filepath, bool ReturnEmptyListIfOnlyOne = false)
		{
			List<string> links = new List<string>();
			try
			{
				Char[] sbPath = new Char[MAX_PATH + 1];
				uint charCount = (uint)MAX_PATH;
				GetVolumePathName(filepath, sbPath, (uint)MAX_PATH); // Must use GetVolumePathName, because Path.GetPathRoot fails on a mounted drive on an empty folder.
				string volume = new string(sbPath).Trim('\0');
				volume = volume.Substring(0, volume.Length - 1);
				Array.Clear(sbPath, 0, MAX_PATH); // Reset the array because these API's can leave garbage at the end of the buffer.
				IntPtr findHandle;
				if (INVALID_HANDLE_VALUE != (findHandle = FindFirstFileNameW(filepath, 0, ref charCount, sbPath)))
				{
					do
					{
						links.Add((volume + new string(sbPath)).Trim('\0')); // Add the full path to the result list.
						charCount = (uint)MAX_PATH;
						Array.Clear(sbPath, 0, MAX_PATH);
					} while (FindNextFileNameW(findHandle, ref charCount, sbPath));
					FindClose(findHandle);
				}
			}
			catch (Exception ex)
			{
				//Logger.Instance.Info($"GetHardLinks: Exception, file: {filepath}, reason: {ex.Message}, stacktrace {ex.StackTrace}");
			}
			if (ReturnEmptyListIfOnlyOne && links.Count < 2)
				links.Clear();
			return links;
		}

		public static void MakeLink(string source, string target)
		{
			if (!File.Exists(source)) return;
			if (File.Exists(target)) return;

			CreateHardLink(target, source, IntPtr.Zero);
		}

		public static bool EmptyFolder(string pathName)
		{
			bool errors = false;
			DirectoryInfo dir = new DirectoryInfo(pathName);

			foreach (FileInfo fi in dir.EnumerateFiles())
			{
				try
				{
					fi.IsReadOnly = false;
					fi.Delete();

					//Wait for the item to disapear (avoid 'dir not empty' error).
					while (fi.Exists)
					{
						System.Threading.Thread.Sleep(10);
						fi.Refresh();
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine(e.Message);
					errors = true;
				}
			}

			foreach (DirectoryInfo di in dir.EnumerateDirectories())
			{
				try
				{
					EmptyFolder(di.FullName);
					di.Delete();

					//Wait for the item to disapear (avoid 'dir not empty' error).
					while (di.Exists)
					{
						System.Threading.Thread.Sleep(10);
						di.Refresh();
					}
				}
				catch (IOException e)
				{
					Debug.WriteLine(e.Message);
					errors = true;
				}
			}

			return !errors;
		}

		public static bool VerifyHardLinkPermissions(string directoryPath)
		{
			// Vérifier si le répertoire existe
			if (!Directory.Exists(directoryPath))
			{
				Console.WriteLine("Le répertoire spécifié n'existe pas.");
				return false;
			}

			// Obtenir les informations du lecteur
			DriveInfo drive = new DriveInfo(directoryPath);

			// Vérifier le système de fichiers
			if (!drive.DriveFormat.Equals("NTFS", StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine("Le répertoire n'est pas sur un système de fichiers NTFS. Les liens physiques ne sont pas pris en charge.");
				return false;
			}

			// Tout est vérifié avec succès
			return true;
		}

		public bool HasProfileRegisterd()
		{

			return false;
		}


	}

}
