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
using SharpDX.DirectInput;
using SDL2;
using System.Runtime.InteropServices;

namespace BigBoxProfile
{
	public static class HIDInfo
	{
		public static string LastHIDSharpInfo { get; private set; }
		public static string LastDS4Info { get; private set; }

		public static string LastBTInfo { get; private set; }

		public static string LastXInput { get; private set; }

		public static string LastDInput { get; private set; }

		public static string LastSDL { get; private set; }

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
					try
					{
						if (device.GetFriendlyName() != null) friendlyName = device.GetFriendlyName().Trim();
					}
					catch { }
					

					LastHIDSharpInfo += $"{friendlyName}<>{device.VendorID.ToString().Trim()}<>{device.ProductID.ToString().Trim()}<>{device.DevicePath.ToString().Trim()}" + "\r\n";
				}
			}
 
			return LastHIDSharpInfo;
		}

		public static string GetDInputInfo(bool refresh)
		{
			if (!refresh && !String.IsNullOrEmpty(LastDInput)) return LastDInput;

			LastDInput = "";
			DirectInput directInput = new DirectInput();
			var ddevices = directInput.GetDevices();
			foreach (var deviceInstance in ddevices)
			{
				if (!IsStickType(deviceInstance))
					continue;

				var joystick = new Joystick(directInput, deviceInstance.InstanceGuid);
				LastDInput += $"{deviceInstance.ProductName}<>{deviceInstance.Type}<>{deviceInstance.InstanceGuid}<>{deviceInstance.InstanceName}<>{joystick.Properties.InterfacePath}" + "\r\n";

				//deviceList.Add(new DeviceInfo(deviceInstance));
			}

			/*
			SharpDX.XInput.Controller[] controllers = new SharpDX.XInput.Controller[4];

			for (SharpDX.XInput.UserIndex index = SharpDX.XInput.UserIndex.One; index <= SharpDX.XInput.UserIndex.Four; index++)
			{
				controllers[(int)index] = new SharpDX.XInput.Controller(index);
			}


			for (SharpDX.XInput.UserIndex index = SharpDX.XInput.UserIndex.One; index <= SharpDX.XInput.UserIndex.Four; index++)
			{
				SharpDX.XInput.Controller controller = controllers[(int)index];
				var capabilities = controller.GetCapabilities(SharpDX.XInput.DeviceQueryType.Any);
			}
			*/
			

			return LastDInput;
		}

		private static bool IsStickType(DeviceInstance deviceInstance)
		{
			return deviceInstance.Type == SharpDX.DirectInput.DeviceType.Joystick
					|| deviceInstance.Type == SharpDX.DirectInput.DeviceType.Gamepad
					|| deviceInstance.Type == SharpDX.DirectInput.DeviceType.FirstPerson
					|| deviceInstance.Type == SharpDX.DirectInput.DeviceType.Flight
					|| deviceInstance.Type == SharpDX.DirectInput.DeviceType.Driving
					|| deviceInstance.Type == SharpDX.DirectInput.DeviceType.Supplemental;
		}

		public static string GetSDLInfo(bool refresh)
		{
			if (!refresh && !String.IsNullOrEmpty(LastSDL)) return LastSDL;

			LastSDL = "";
			SDL2.SDL.SDL_Init(SDL2.SDL.SDL_INIT_JOYSTICK);
			for (int i = 0; i < SDL2.SDL.SDL_NumJoysticks(); i++)
			{
				var currentJoy = SDL.SDL_JoystickOpen(i);
				string caps = $"{SDL.SDL_JoystickNumAxes(currentJoy)} {SDL.SDL_JoystickNumBalls(currentJoy)} {SDL.SDL_JoystickNumButtons(currentJoy)} {SDL.SDL_JoystickNumHats(currentJoy)}";
				string signature = GetMD5Short(caps);
				LastSDL += $"SDL{i}<>{SDL2.SDL.SDL_JoystickNameForIndex(i)}<>{signature}<>{SDL.SDL_JoystickGetDeviceGUID(i)}<>{SDL.SDL_JoystickGetSerial(currentJoy)}" + "\r\n";
				SDL.SDL_JoystickClose(currentJoy);
			}


			return LastSDL;
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
			LastDInput = null;
		}


	}
}
