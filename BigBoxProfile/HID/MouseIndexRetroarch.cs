using CefSharp.DevTools.BackgroundService;
using HidSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile.HID
{
	internal class MouseIndexRetroarch
	{

		public struct MouseRetroarch
		{
			public int Index;
			public string Name;
			public string Path;
		}

		const uint FILE_SHARE_READ = 0x00000001;
		const uint FILE_SHARE_WRITE = 0x00000002;
		const uint OPEN_EXISTING = 3;

		const uint RIM_TYPEMOUSE = 0;
		const uint RIDI_DEVICENAME = 0x20000007;

		[StructLayout(LayoutKind.Sequential)]
		public struct RAWINPUTDEVICELIST
		{
			public IntPtr hDevice;
			public uint dwType;
		}

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		static extern uint GetRawInputDeviceInfoA(IntPtr hDevice, uint uiCommand, [Out] StringBuilder pData, ref uint pcbSize);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		static extern uint GetRawInputDeviceList(IntPtr pRawInputDeviceList, ref uint uiNumDevices, uint cbSize);


		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool CloseHandle(IntPtr hObject);

		[DllImport("hid.dll", SetLastError = true, CharSet = CharSet.Auto)]
		static extern bool HidD_GetProductString(IntPtr h, StringBuilder buf, uint length);

		public static List<MouseRetroarch> ListMouse()
		{
			List<MouseRetroarch> mouseList = new List<MouseRetroarch>();

			try
			{
				uint deviceCount = 0;
				uint size = (uint)Marshal.SizeOf(typeof(RAWINPUTDEVICELIST));

				// Obtient le nombre de périphériques d'entrée RAW
				uint result = GetRawInputDeviceList(IntPtr.Zero, ref deviceCount, size);

				if (result == uint.MaxValue || deviceCount == 0)
				{
					return mouseList;
				}

				if (deviceCount > 0)
				{
					IntPtr deviceList = Marshal.AllocHGlobal((int)(size * deviceCount));
					Marshal.WriteInt32(deviceList, (int)(size * deviceCount));
					result = GetRawInputDeviceList(deviceList, ref deviceCount, size);
					int z = 1;
					for (int i = 0; i < deviceCount; i++)
					{
						RAWINPUTDEVICELIST deviceInfo = (RAWINPUTDEVICELIST)Marshal.PtrToStructure(new IntPtr(deviceList.ToInt64() + (size * i)), typeof(RAWINPUTDEVICELIST));

						if (deviceInfo.dwType == RIM_TYPEMOUSE)
						{
							string DevicePath = "";
							// Obtient la taille du nom du périphérique
							uint nameSize = 256;
							StringBuilder name = new StringBuilder((int)nameSize);
							result = GetRawInputDeviceInfoA(deviceInfo.hDevice, RIDI_DEVICENAME, name, ref nameSize);

							if (result == uint.MaxValue || result == 0)
							{
								name.Clear();
							}

							StringBuilder prodName = new StringBuilder(128);
							StringBuilder prodBuf = new StringBuilder(128);
							if (name.Length > 0)
							{
								DevicePath = name.ToString();
								IntPtr hhid = CreateFile(name.ToString(), 0, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
								Console.WriteLine(name.ToString());
								if (hhid != IntPtr.Zero)
								{
									if (HidD_GetProductString(hhid, prodBuf, (uint)prodBuf.Capacity))
									{
										prodName.Append(prodBuf.ToString());
									}
									CloseHandle(hhid);
								}
							}

							if (prodName.Length > 0)
							{
								name.Clear();
								name.Append(prodName.ToString());
							}

							if (name.Length == 0)
							{
								name.Append("<name not found>");
							}

							if (!String.IsNullOrEmpty(DevicePath))
							{
								DevicePath = DevicePath.Trim();
								if (DevicePath.StartsWith(@"\\?\")) DevicePath = DevicePath.Substring(4);

								string pattern = @"(.+)#{([a-zA-Z0-9\-]+)}";
								Regex regex = new Regex(pattern);
								Match match = regex.Match(DevicePath);
								if (match.Success)
								{
									DevicePath = match.Groups[1].Value;
								}
								DevicePath = DevicePath.ToUpper();
								DevicePath = SanitizeForCommand(DevicePath);
								DevicePath = DevicePath.Replace("__", "_");
								DevicePath = DevicePath.Replace("__", "_");
								DevicePath = DevicePath.Replace("__", "_");

							}


							mouseList.Add(new MouseRetroarch { Index = z, Name = name.ToString(), Path = DevicePath });
							z++;
						}
					}
					// Libère la mémoire allouée pour la liste des périphériques
					Marshal.FreeHGlobal(deviceList);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return mouseList;
		}

		public static string SanitizeForCommand(string input)
		{
			// Les caractères interdits dans une ligne de commande sous Windows
			string forbiddenCharsPattern = @"[\x00-\x1F<>:\""/\\|?*]";

			// Remplacer les caractères interdits par "_"
			string sanitizedString = Regex.Replace(input, forbiddenCharsPattern, "_");

			return sanitizedString;
		}

	}
}
