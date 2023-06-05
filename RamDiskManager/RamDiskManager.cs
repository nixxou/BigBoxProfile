using RamDisk;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RamDiskManager
{
	public class RamDiskManager : IDisposable
	{
		public char RamDriveLetter { get; private set; }

		public RamDiskManager()
		{
			//Mount(size);
		}



		public void Mount(int size)
		{
			var listFreeDriveLetters = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i + ":").Except(DriveInfo.GetDrives().Select(s => s.Name.Replace("\\", ""))).ToList();
			RamDriveLetter = listFreeDriveLetters.Last()[0];
			RamDrive.Mount(size, FileSystem.NTFS, RamDriveLetter);
		}


		public void UnMount()
		{
			RamDrive.Unmount(RamDriveLetter);
		}


		protected virtual void Dispose(Boolean disposing)
		{
			if (disposing)
			{
				if (RamDriveLetter != '\0' && Directory.Exists(RamDriveLetter + ":\\"))
				{
					RamDrive.Unmount(RamDriveLetter);
					RamDriveLetter = '\0';
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);

			GC.SuppressFinalize(this);

		}

	}
}
