using DualShock4Lib;
using HidSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static XInput.Wrapper.X.Gamepad;

namespace BigBoxProfile
{
	public class HIDMatcher
	{
		public string RegexToMatch { get; set; }
		public string Suffix { get; set; }
		public string DeviceType { get; set; }
		public bool UseHIDSharp { get; set; }
		public bool UseDS4Lib { get; set; }
		public bool UseBT { get; set; }
		public bool UseXInput { get; set; }

		public HIDMatcher()
		{
			this.RegexToMatch = "";
			this.Suffix = "";
			this.DeviceType = "controller";
			this.UseHIDSharp = false;
			this.UseDS4Lib = false;
			this.UseBT = false;
			this.UseXInput = false;
		}

		public HIDMatcher(string json)
		{
			HIDMatcher DeserializeData = JsonConvert.DeserializeObject<HIDMatcher>(json);
			this.RegexToMatch = DeserializeData.RegexToMatch;
			this.Suffix = DeserializeData.Suffix;
			this.DeviceType = DeserializeData.DeviceType;
			this.UseHIDSharp = DeserializeData.UseHIDSharp;
			this.UseDS4Lib = DeserializeData.UseDS4Lib;
			this.UseBT = DeserializeData.UseBT;
			this.UseXInput = DeserializeData.UseXInput;
		}


		public string[] ToStringArray()
		{
			var arrayString = new string[8];
			arrayString[0] = Serialize();
			arrayString[1] = this.RegexToMatch;
			arrayString[2] = this.Suffix;
			arrayString[3] = this.DeviceType;
			arrayString[4] = (this.UseHIDSharp ? "YES" : "NO");
			arrayString[5] = (this.UseDS4Lib ? "YES" : "NO");
			arrayString[6] = (this.UseBT ? "YES" : "NO");
			arrayString[7] = (this.UseXInput ? "YES" : "NO");
			return arrayString;

		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}

		public string isMatching(bool forceRefresh = false, string logdir = "")
		{
			string suffixOut = this.Suffix;
			string libData = "";
			if(UseHIDSharp) libData += HIDInfo.GetHIDSharpInfo(forceRefresh);
			if(UseDS4Lib) libData += HIDInfo.GetDS4Info(forceRefresh);
			if(UseBT) libData += HIDInfo.GetBluetoothInfo(forceRefresh);
			if(UseXInput) libData += HIDInfo.GetXINPUT(forceRefresh, logdir);

			try
			{
				Match match = Regex.Match(libData, RegexToMatch);
				if (match.Success)
				{
					GroupCollection groups = match.Groups;
					for (int i = 1; i <= groups.Count; i++)
					{
						suffixOut = suffixOut.Replace($"\\{i}", groups[i].Value);
					}
					return suffixOut;
				}
			}
			catch(Exception e)
			{

			}
			return null;


		}

	}
}
