using HidSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using DualShock4Lib;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using Newtonsoft.Json;
using XInput.Wrapper;
using System.Security.Cryptography;

namespace BigBoxProfile
{
	public static class HIDInfo
	{
        public static string LastHIDSharpInfo { get; private set; }
		public static string LastDS4Info { get; private set; }

		public static string LastBTInfo { get; private set; }

		public static string LastXInput { get; private set; }

		public static string GetHIDSharpInfo(bool refresh)
		{
			if(!refresh && !String.IsNullOrEmpty(LastHIDSharpInfo)) return LastHIDSharpInfo;

			LastHIDSharpInfo = "";
			var devices = DeviceList.Local.GetHidDevices();
			if (devices.Count() > 0)
			{
				foreach (var device in devices)
				{

					string friendlyName = "Unknown";
					if (device.GetFriendlyName() != null) friendlyName = device.GetFriendlyName().Trim();

					LastHIDSharpInfo += $"{friendlyName}<>{device.VendorID.ToString().Trim()}<>{device.ProductID.ToString().Trim()}<>{device.DevicePath.ToString().Trim()}" + "\r\n";
				}
			}
			return LastHIDSharpInfo;
		}


		public static string GetDS4Info(bool refresh)
		{
			if (!refresh && !String.IsNullOrEmpty(LastDS4Info)) return LastDS4Info;

			LastDS4Info = "";
			IControllersProvider controllers = new Controllers();
			var dataControllers = controllers.GetAllControllers();
			foreach(var controller in dataControllers)
			{
				//LastHIDSharpInfo += $"{controller.}	{device.VendorID}	{device.ProductID}	{device.DevicePath}" + "\r\n";

				string usbstatus = controller.IsConnectedToUsb ? "USB:YES" : "USB:NO";

				LastDS4Info += $"DS4Controller<>{controller.VendorId.ToString().Trim()}<>{controller.ProductId.ToString().Trim()}<>{controller.DevicePath.ToString().Trim()}<>{usbstatus.ToString().Trim()}" + "\r\n";
			}


			return LastDS4Info;
		}

		public static string GetBluetoothInfo(bool refresh)
		{
			if (!refresh && !String.IsNullOrEmpty(LastBTInfo)) return LastBTInfo;

			LastBTInfo = "";

			var client = new BluetoothClient();
			var devices = client.DiscoverDevices();
			if (devices.Length > 0)
			{
				foreach (var device in devices)
				{
					if (device.Connected)
					{
						LastBTInfo += $"{device.DeviceName}<>{device.ClassOfDevice}<>{device.DeviceAddress}" + "\r\n";
					}
				}
			}
			return LastBTInfo;
		}

		public static string GetXINPUT(bool refresh, string ds4logPath = "")
		{
			
			if (!refresh && !String.IsNullOrEmpty(LastXInput)) return LastXInput;

			List<DS4Controller> ds4winControllers = new List<DS4Controller>();
			if (!string.IsNullOrEmpty(ds4logPath))
			{
				var ds4p = new HIDDS4WinParser(ds4logPath);
				ds4winControllers = ds4p.ControllerList;
			}

			LastXInput = "";

			var gamepad = X.Gamepad_1;
			if (gamepad.Capabilities.Type != 0)
			{
				int slot = 1;
				var caps = gamepad.Capabilities;
				string json = JsonConvert.SerializeObject(caps, Newtonsoft.Json.Formatting.None);
				string signature = GetMD5Short(json);
				string extra = "\r\n";
				var ds4data = ds4winControllers.Where(d => d.ControllerXinputSlot == slot).FirstOrDefault();
				if(ds4data != null)
				{
					signature = "DS4WIN";
					extra = $"<>{ds4data.MacAddress}<>{ds4data.ControllerType}<>{ds4data.ConnectionType}<>{ds4data.ControllerInputSlot}" + "\r\n";
				}
				LastXInput += $"XINPUT{slot}<>{gamepad.Capabilities.SubType.ToString().Trim()}<>{signature}" + extra;
			}


			gamepad = X.Gamepad_2;
			if (gamepad.Capabilities.Type != 0)
			{
				int slot = 2;
				var caps = gamepad.Capabilities;
				string json = JsonConvert.SerializeObject(caps, Newtonsoft.Json.Formatting.None);
				string signature = GetMD5Short(json);
				string extra = "\r\n";
				var ds4data = ds4winControllers.Where(d => d.ControllerXinputSlot == slot).FirstOrDefault();
				if (ds4data != null)
				{
					signature = "DS4WIN";
					extra = $"<>{ds4data.MacAddress}<>{ds4data.ControllerType}<>{ds4data.ConnectionType}<>{ds4data.ControllerInputSlot}" + "\r\n";
				}
				LastXInput += $"XINPUT{slot}<>{gamepad.Capabilities.SubType.ToString().Trim()}<>{signature}" + extra;
			}

			gamepad = X.Gamepad_3;
			if (gamepad.Capabilities.Type != 0)
			{
				int slot = 3;
				var caps = gamepad.Capabilities;
				string json = JsonConvert.SerializeObject(caps, Newtonsoft.Json.Formatting.None);
				string signature = GetMD5Short(json);
				string extra = "\r\n";
				var ds4data = ds4winControllers.Where(d => d.ControllerXinputSlot == slot).FirstOrDefault();
				if (ds4data != null)
				{
					signature = "DS4WIN";
					extra = $"<>{ds4data.MacAddress}<>{ds4data.ControllerType}<>{ds4data.ConnectionType}<>{ds4data.ControllerInputSlot}" + "\r\n";
				}
				LastXInput += $"XINPUT{slot}<>{gamepad.Capabilities.SubType.ToString().Trim()}<>{signature}" + extra;
			}

			gamepad = X.Gamepad_4;
			if (gamepad.Capabilities.Type != 0)
			{
				int slot = 4;
				var caps = gamepad.Capabilities;
				string json = JsonConvert.SerializeObject(caps, Newtonsoft.Json.Formatting.None);
				string signature = GetMD5Short(json);
				string extra = "\r\n";
				var ds4data = ds4winControllers.Where(d => d.ControllerXinputSlot == slot).FirstOrDefault();
				if (ds4data != null)
				{
					signature = "DS4WIN";
					extra = $"<>{ds4data.MacAddress}<>{ds4data.ControllerType}<>{ds4data.ConnectionType}<>{ds4data.ControllerInputSlot}" + "\r\n";
				}
				LastXInput += $"XINPUT{slot}<>{gamepad.Capabilities.SubType.ToString().Trim()}<>{signature}" + extra;
			}
			return LastXInput;
		}

		public static string GetMD5Short(string input)
		{

			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(input);
				byte[] hashBytes = md5.ComputeHash(inputBytes);

				// Convertir les octets du hash en une chaîne hexadécimale
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < hashBytes.Length; i++)
				{
					sb.Append(hashBytes[i].ToString("X2")); // X2 pour obtenir en majuscules
				}

				return sb.ToString().Substring(0, 6);
			}

		}

		public static void ClearCache()
		{
			LastBTInfo = null;
			LastXInput = null;
			LastHIDSharpInfo = null;
			LastDS4Info = null;
		}


	}
}
