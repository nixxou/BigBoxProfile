using CliWrap;
using Microsoft.VisualBasic.Devices;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	public class RamDiskLauncher : IDisposable
	{
		public char RamDriveLetter { get; private set; }

		public RamDiskLauncher()
		{
			//Mount(size);
		}

		public static bool isDriverInstalled()
		{
			if (BigBoxUtils.checkInstalled("ImDisk Virtual Disk Driver") == null)
			{
				Console.WriteLine("ImDisk Virtual Disk Driver not installed, can't use ramdisk");
				return false;
			}
			return true;
		}

		public static bool isAdminRight()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		public static int getFreeRamMb()
		{
			ulong freeMemory = new ComputerInfo().AvailablePhysicalMemory;
			int freeMemoryInMb = (int)(freeMemory / 1024 / 1024);
			return freeMemoryInMb;
		}



		public bool Mount(int size, string labelDisk = "RamDisk")
		{
			/*
			var listFreeDriveLetters = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i + ":").Except(DriveInfo.GetDrives().Select(s => s.Name.Replace("\\", ""))).ToList();
			RamDriveLetter = listFreeDriveLetters.Last()[0];
			RamDrive.Mount(size, FileSystem.NTFS, RamDriveLetter);
			MessageBox.Show("done");

			*/
			var listFreeDriveLetters = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => (Char)i + ":").Except(DriveInfo.GetDrives().Select(s => s.Name.Replace("\\", ""))).ToList();
			RamDriveLetter = listFreeDriveLetters.Last()[0];
			setConfigFile(size, RamDriveLetter.ToString(), labelDisk, false);
			return ExecuteRamTask("mount");
		}

		public bool ExecuteRamTask(string command)
		{
			//var _ramDiskManager = new RamDiskManager(1000);
			string RamDiskManagerExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "RamDiskManager.exe");
			string[] args = new string[2];
			args[0] = RamDiskManagerExe;
			args[1] = command;
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			//MessageBox.Show(cmd);
			string taskName = "";
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(cmd);
				byte[] hashBytes = md5.ComputeHash(inputBytes);
				string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
				taskName = "RunAdmin_" + hashString;
			}

			using (TaskService taskService = new TaskService())
			{
				if (taskService.GetTask(taskName) == null)
				{
					string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");

					List<string> arguments = new List<string>();
					arguments.Add(JustRunExe);
					arguments.AddRange(args);


					//string taskRegExe = @"C:\Users\Mehdi\source\repos\BigBoxProfile\TaskRegForRunAsAdmin\bin\Debug\TaskRegForRunAsAdmin.exe";
					string taskRegExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TaskRegForRunAsAdmin.exe");
					//MessageBox.Show(taskRegExe);
					//string exePath = Assembly.GetEntryAssembly().Location;
					string exePath = taskRegExe;
					string exeDir = Path.GetDirectoryName(exePath);
					ProcessStartInfo startInfo = new ProcessStartInfo();
					startInfo.FileName = exePath;
					startInfo.Arguments = BigBoxUtils.ArgsToCommandLine(arguments.ToArray());
					startInfo.WorkingDirectory = exeDir;
					startInfo.Verb = "runas";
					//Process.Start(startInfo);
					var TaskProcess = System.Threading.Tasks.Task.Run(() => Process.Start(startInfo));
					TaskProcess.Wait();
					Thread.Sleep(2000);


				}
			}

			string new_cmd = $@" /run /tn ""{taskName}""";
			args = BigBoxUtils.CommandLineToArgs(new_cmd, false);

			var TaskRun = System.Threading.Tasks.Task.Run(() =>
			Cli.Wrap("schtasks")
			.WithArguments(args)
			.WithValidation(CommandResultValidation.None)
			.ExecuteAsync()
			);
			TaskRun.Wait();

			Thread.Sleep(1000);

			TaskService ts = new TaskService();
			Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskName);
			Microsoft.Win32.TaskScheduler.RunningTaskCollection instances = task.GetInstances();
			while (instances.Count == 1)
			{
				instances = task.GetInstances();
				Thread.Sleep(100);
			}

			if (Directory.Exists(RamDriveLetter + ":\\")) return true;
			else return false;
		}

		public void setConfigFile(int sizeInMb,  string driveLetter, string volumeLabel, bool cleanRam)
		{
			// Création du contenu du fichier INI
			string iniContent = $"SizeInMb={sizeInMb}\n";
			iniContent += $"DriveLetter={driveLetter}\n";
			iniContent += $"VolumeLabel={volumeLabel}\n";
			iniContent += $"CleanRam={cleanRam}";

			// Écriture du contenu dans le fichier
			File.WriteAllText(Path.Combine(Path.GetTempPath(), "RamDiskManager.ini"), iniContent);
		}



		public void UnMount()
		{
			setConfigFile(10, RamDriveLetter.ToString(), "RamdiskRemove", false);
			ExecuteRamTask("umount");
		}


		protected virtual void Dispose(Boolean disposing)
		{
			if (disposing)
			{
				if (RamDriveLetter != '\0' && Directory.Exists(RamDriveLetter + ":\\"))
				{
					UnMount();
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
