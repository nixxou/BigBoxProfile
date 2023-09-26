using Microsoft.VisualBasic;
using Microsoft.Win32.SafeHandles;
using PS3IsoLauncher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class PS3Mount : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public static string PathRPCS = "";

		public static string PathGame = "";

		public static string PathBackup = "";

		public static string PathRap = "";

		public static bool IsoMounted = false;
		public static bool VHDXMounted = false;
		public static PS3Tool ps3tool = null;

		public static VHDXTool vhdxtool = null;

		public PS3Mount()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "PS3Mount";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		//public Dictionary<string, string> Options = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new PS3Mount();
		}

		public void Configure()
		{

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{

		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "Mount and Play PS3 ISO";

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		public string[] ModifyExemple(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}
		public string[] Modify(string[] args)
		{

			return args;
		}




		public string[] ModifyReal(string[] args)
		{
			MessageBox.Show("debug PS3");
			string isopath = "";
			string vhdxpath = "";
			bool mountvhdxasreadonly = false;

			List<string> filteredArgs = new List<string>();
			foreach (string arg in args)
			{
				bool hideThisArg = false;
				if (arg.ToLower().EndsWith(".iso"))
				{
					if (File.Exists(arg))
					{
						isopath = Path.GetFullPath(arg);
					}
				}
				if (arg.ToLower().EndsWith(".vhdx"))
				{
					if (File.Exists(arg))
					{
						vhdxpath = Path.GetFullPath(arg);
					}
				}
				if (arg.ToLower() == "--readonly")
				{
					hideThisArg = true;
					mountvhdxasreadonly = true;
				}

				if (!hideThisArg) filteredArgs.Add(arg);
			}
			if (isopath == "" && vhdxpath == "") return args;

			args = filteredArgs.ToArray();

			string[] nullargs = new string[1];
			nullargs[0] = args[0];





			PathRPCS = Path.GetFullPath(args[0]);
			PathGame = Path.GetDirectoryName(PathRPCS);
			PathGame = Path.Combine(PathGame, "dev_hdd0", "game");
			PathGame = Path.GetFullPath(PathGame);
			PathBackup = Path.Combine(Path.GetDirectoryName(PathRPCS), "GameBackup");
			PathRap = Path.Combine(Path.GetDirectoryName(PathRPCS), "dev_hdd0", "home", "00000001", "exdata");

			if (!Directory.Exists(PathGame)) Directory.CreateDirectory(PathGame);
			if (!Directory.Exists(PathRap)) Directory.CreateDirectory(PathRap);
			VHDXTool.CleanJunctions(PathGame);



			if (isopath != "")
			{

				var targetProcess = Process.GetProcessesByName("rpcs3").FirstOrDefault(p => p.MainWindowTitle != "");
				if (targetProcess != null)
				{
					if (args[0].ToLower() == targetProcess.MainModule.FileName.ToLower())
					{
						return nullargs;
					}
				}
				
				try
				{
					ps3tool = new PS3Tool(isopath);
				}
				catch (Exception ex)
				{
					MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"{ex.Message}");
					return nullargs;
				}

				if (ps3tool.Mount())
				{
					IsoMounted = true;
					string ebootpath = Path.Combine(ps3tool.IsoMountDrive + ":\\", "PS3_GAME", "USRDIR", "EBOOT.BIN");
					string iconpath = Path.Combine(ps3tool.IsoMountDrive + ":\\", "PS3_GAME", "ICON0.PNG");
					if (File.Exists(ebootpath))
					{
						var arglist = new List<string>();
						foreach (string arg in args)
						{
							if (File.Exists(arg) && Path.GetFullPath(arg) == isopath) arglist.Add(ebootpath);
							else arglist.Add(arg);
						}
						return arglist.ToArray();
					}
					else
					{
						MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"Can't find {ebootpath}");

					}
				}
				else
				{
					MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"Mount failed");
				}
				return nullargs;
			}

			if (vhdxpath != "")
			{
				try
				{
					vhdxtool = new VHDXTool(vhdxpath);
				}
				catch (Exception ex)
				{
					MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"{ex.Message}");
				}

				var targetProcess = Process.GetProcessesByName("rpcs3").FirstOrDefault(p => p.MainWindowTitle != "");
				if (targetProcess != null)
				{
					if (args[0].ToLower() == targetProcess.MainModule.FileName.ToLower())
					{
						MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"RPCS3 is already running");
						return nullargs;
					}
				}

				//Thread.Sleep(10000);
				if (vhdxtool.Mount(mountvhdxasreadonly))
				{

					VHDXTool.CopyRap(PathRap, vhdxtool.IsoMountDrive + ":\\");
					string ebootpath = VHDXTool.FindEboot(vhdxtool.IsoMountDrive + ":\\");
					ebootpath = VHDXTool.LinkBackToGameDir(PathGame, vhdxtool.IsoMountDrive + ":\\", ebootpath);

					if (File.Exists(ebootpath) && ebootpath != "")
					{
						var arglist = new List<string>();
						foreach (string arg in args)
						{
							if (File.Exists(arg) && Path.GetFullPath(arg) == vhdxpath) arglist.Add(ebootpath);
							else arglist.Add(arg);
						}
						VHDXMounted = true;
						return arglist.ToArray();
					}
					else
					{
						MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"Can't find {ebootpath}");

					}
				}
				else
				{
					MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"Mount failed");
				}
			}
			return nullargs;
		}

		private void UpdateConfig()
		{

		}

		public void ExecuteBefore(string[] args)
		{

		}
		public void ExecuteAfter(string[] args)
		{
			if(IsoMounted && ps3tool != null)
			{
				if (!ps3tool.Umount())
				{
					MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"Error Unmounting {ps3tool.IsoFilePath}");
				}
			}
			if (VHDXMounted && vhdxtool != null)
			{
				if (!vhdxtool.Umount())
				{
					MessageBox.Show("IsoEnablerForRPCS3 ERROR", $"Error Unmounting {vhdxtool.IsoFilePath}");
				}
				if(PathGame != "") VHDXTool.CleanJunctions(PathGame);
			}

		}

		public bool UseM3UContent()
		{
			return false;
		}
	}
}
