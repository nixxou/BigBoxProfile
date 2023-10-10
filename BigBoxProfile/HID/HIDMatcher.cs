using DualShock4Lib;
using HidSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
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
		public int MaxMatch { get; set; }
		public bool UniqueMatch { get; set; }
		public bool UseDInput { get; set; }
		public bool UseSDL { get; set; }

		public HIDMatcher()
		{
			this.RegexToMatch = "";
			this.Suffix = "";
			this.DeviceType = "controller";
			this.UseHIDSharp = false;
			this.UseDS4Lib = false;
			this.UseBT = false;
			this.UseXInput = false;
			this.MaxMatch = 1;
			this.UniqueMatch = false;
			this.UseDInput = false;
			this.UseSDL = false;
		}

		public HIDMatcher(string json)
		{
			try
			{
				HIDMatcher DeserializeData = JsonConvert.DeserializeObject<HIDMatcher>(json);
				this.RegexToMatch = DeserializeData.RegexToMatch;
				this.Suffix = DeserializeData.Suffix;
				this.DeviceType = DeserializeData.DeviceType;
				this.UseHIDSharp = DeserializeData.UseHIDSharp;
				this.UseDS4Lib = DeserializeData.UseDS4Lib;
				this.UseBT = DeserializeData.UseBT;
				this.UseXInput = DeserializeData.UseXInput;
				this.MaxMatch = DeserializeData.MaxMatch;
				this.UniqueMatch = DeserializeData.UniqueMatch;
				this.UseDInput = DeserializeData.UseDInput;
				this.UseSDL = DeserializeData.UseSDL;
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message);
			}

		}


		public string[] ToStringArray()
		{
			var arrayString = new string[12];
			arrayString[0] = Serialize();
			arrayString[1] = this.RegexToMatch;
			arrayString[2] = this.Suffix;
			arrayString[3] = this.DeviceType;
			arrayString[4] = (this.UseHIDSharp ? "YES" : "NO");
			arrayString[5] = (this.UseDS4Lib ? "YES" : "NO");
			arrayString[6] = (this.UseBT ? "YES" : "NO");
			arrayString[7] = (this.UseXInput ? "YES" : "NO");
			arrayString[8] = this.MaxMatch.ToString();
			arrayString[9] = (this.UniqueMatch ? "YES" : "NO");
			arrayString[10] = (this.UseDInput ? "YES" : "NO");
			arrayString[11] = (this.UseSDL ? "YES" : "NO");
			return arrayString;

		}

		public string Serialize()
		{
			string json = JsonConvert.SerializeObject(this, Formatting.Indented);
			return json;
		}

		public string[] isMatching(bool forceRefresh = false, string logdir = "")
		{
			
			string libData = "";
			if(UseHIDSharp) libData += HIDInfo.GetHIDSharpInfo(forceRefresh);
			if(UseDS4Lib) libData += HIDInfo.GetDS4Info(forceRefresh);
			if(UseBT) libData += HIDInfo.GetBluetoothInfo(forceRefresh);
			if(UseXInput) libData += HIDInfo.GetXINPUT(forceRefresh, logdir);
			if(UseDInput) libData += HIDInfo.GetDInputInfo(forceRefresh);
			if(UseSDL) libData += HIDInfo.GetSDLInfo(forceRefresh);

			List<string> suffixList = new List<string>();
			int currentMatchCount = 0;

			using (StringReader reader = new StringReader(libData))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{
					try
					{
						Match match = Regex.Match(line, RegexToMatch);
						if (match.Success)
						{
							string suffixOut = this.Suffix;
							GroupCollection groups = match.Groups;
							for (int i = 1; i <= groups.Count; i++)
							{
								suffixOut = suffixOut.Replace($"\\{i}", groups[i].Value);
							}
							if (UniqueMatch)
							{
								if (!suffixList.Contains(suffixOut))
								{
									suffixList.Add(suffixOut);
									currentMatchCount++;
								}
							}
							else
							{
								suffixList.Add(suffixOut);
								currentMatchCount++;
							}
							if (currentMatchCount == MaxMatch) return suffixList.ToArray();
						}
					}
					catch (Exception e)
					{

					}

				}
			}
			if(suffixList.Count > 0)
			{
				return suffixList.ToArray();
			}
			return null;
		}

	}
}
