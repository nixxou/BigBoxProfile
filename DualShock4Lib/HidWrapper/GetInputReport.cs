using System.Runtime.InteropServices;
using System.Threading;

namespace HidWrapper
{
	public static partial class Devices
	{
		public static byte[] GetInputReport(HidDevice device)
		{
			// Create buffer for native call
			byte[] buffer = new byte[device.Capabilities.InputReportByteLength];

			// Empty OVERLAPPED structure
			var overlapped = new NativeOverlapped();

			// Create handle with read access and no overlapped IO
			using (var handle = CreateFileHandle(device.DevicePath, NativeMethods.EFileAccess.GenericRead))
			{
				// Read data
				if (!NativeMethods.ReadFile(handle, buffer, (uint)buffer.Length, out uint bytesRead, ref overlapped))
				{
					Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
				}
			}

			// Return data
			return buffer;
		}
	}
}