using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BigBoxProfile
{
	public class DS4Controller
	{
		public int ControllerInputSlot = 0;
		public int ControllerOutputSlot = 0;
		public int ControllerXinputSlot = 0;
		public string MacAddress = "";
		public string Profile = "";
		public string ConnectionType = "";
		public string ControllerType = "";
		public bool Connected = true;
	}
	public class HIDDS4WinParser
	{
		public string LogData = "";
		public List<DS4Controller> ControllerList = new List<DS4Controller>();
		public Dictionary<int, int> XinputSlot = new Dictionary<int, int>();

		public HIDDS4WinParser(string logdir)
		{
			if (!Directory.Exists(logdir)) return;

			Process[] processes = Process.GetProcessesByName("DS4Windows");
			if (processes.Length <= 0) return;

			string logfile = GetMostRecentTxtFile(logdir);
			if (string.IsNullOrEmpty(logfile)) return;

			LogData = GetRelevantLog(logfile);
			int current_controller = 0;
			using (StringReader reader = new StringReader(LogData))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
				{

					string pattern = @"Found Controller: ([0-9A-F:]*) \(([^\)]*)\) \(([^\)]*)\)";
					Match match = Regex.Match(line, pattern);
					if (match.Success)
					{
						DS4Controller controller = new DS4Controller();
						controller.ControllerInputSlot = GetFirstAvailiableIndex();
						current_controller = controller.ControllerInputSlot;
						controller.MacAddress = match.Groups[1].Value;
						controller.ConnectionType = match.Groups[2].Value;
						controller.ControllerType = match.Groups[3].Value;
						ControllerList.Add(controller);
						continue;
					}

					pattern = @"Associated input controller #([0-9]*) \(([^\)]*)\) to virtual X360 Controller in output slot #([0-9]*)";
					match = Regex.Match(line, pattern);
					if (match.Success)
					{
						int parsedControllerIndex = int.Parse(match.Groups[1].Value);
						string parsedConnectionType = match.Groups[2].Value;
						int parsedOutputSlot = int.Parse(match.Groups[3].Value);
						var controller = GetControllerByIndex(parsedControllerIndex);
						if (controller == null) continue;

						if (controller.ControllerType == parsedConnectionType)
						{
							controller.ControllerOutputSlot = parsedOutputSlot;
							if (XinputSlot.ContainsKey(parsedOutputSlot))
							{
								controller.ControllerXinputSlot = XinputSlot[parsedOutputSlot];
							}
						}
						continue;
					}

					pattern = @"Controller ([0-9]*) is using Profile ""([^""]*)""";
					match = Regex.Match(line, pattern);
					if (match.Success)
					{
						int parsedControllerIndex = int.Parse(match.Groups[1].Value);
						string parsedProfile = match.Groups[2].Value;
						var controller = GetControllerByIndex(parsedControllerIndex);
						if (controller == null) continue;

						controller.Profile = parsedProfile;
						continue;
					}

					pattern = @"Disassociated virtual X360 Controller in output slot #([0-9]*) from input controller #([0-9]*)";
					match = Regex.Match(line, pattern);
					if (match.Success)
					{
						int parsedControllerIndex = int.Parse(match.Groups[1].Value);
						int parsedOutputSlot = int.Parse(match.Groups[2].Value);
						var controller = GetControllerByIndex(parsedControllerIndex);
						if (controller == null) continue;

						controller.ControllerOutputSlot = 0;
						continue;
					}

					pattern = @"Controller ([0-9]*) was removed or lost connection";
					match = Regex.Match(line, pattern);
					if (match.Success)
					{
						int parsedControllerIndex = int.Parse(match.Groups[1].Value);

						var controller = GetControllerByIndex(parsedControllerIndex);
						if (controller == null) continue;

						ControllerList.Remove(controller);
						continue;
					}

					pattern = @"Plugging in virtual X360 controller \(XInput slot #([0-9]*)\) in output slot #([0-9]*)";
					match = Regex.Match(line, pattern);
					if (match.Success)
					{
						int parsedXinputSlot = int.Parse(match.Groups[1].Value);
						int parsedOutputSlot = int.Parse(match.Groups[2].Value);
						XinputSlot[parsedOutputSlot] = parsedXinputSlot;

						foreach (DS4Controller controller in ControllerList)
						{
							if (controller.ControllerOutputSlot == parsedOutputSlot)
							{
								controller.ControllerXinputSlot = parsedXinputSlot;
							}
						}

					}

					pattern = @"Unplugging virtual X360 Controller from output slot #([0-9]*)";
					match = Regex.Match(line, pattern);
					if (match.Success)
					{
						int parsedOutputSlot = int.Parse(match.Groups[1].Value);
						if (XinputSlot.ContainsKey(parsedOutputSlot))
						{
							XinputSlot.Remove(parsedOutputSlot);
						}
					}




					// Do something with the line
				}
				//Console.WriteLine(LogData);
			}

		}

		public void Print()
		{
			var json = JsonConvert.SerializeObject(ControllerList, Formatting.Indented);
			Console.WriteLine(json);
		}

		static string GetMostRecentTxtFile(string directoryPath)
		{
			string[] txtFiles = Directory.GetFiles(directoryPath, "*.txt");

			if (txtFiles.Length > 0)
			{
				var fileInfoList = txtFiles.Select(filePath => new FileInfo(filePath)).ToList();
				fileInfoList.Sort((x, y) => DateTime.Compare(y.LastWriteTime, x.LastWriteTime));

				return fileInfoList[0].FullName;
			}

			return null;
		}

		public int GetFirstAvailiableIndex()
		{
			int min_index = 1;
			bool found = true;
			while (found)
			{
				found = false;
				foreach (var controller in ControllerList)
				{
					if (controller.ControllerInputSlot == min_index)
					{
						found = true;
						min_index++;
						break;
					}
				}
			}
			return min_index;
		}

		public DS4Controller GetControllerByIndex(int index)
		{
			foreach (var controller in ControllerList)
			{
				if (controller.ControllerInputSlot == index)
				{
					return controller;
				}
			}
			return null;
		}

		public static string GetRelevantLog(string filePath)
		{

			string startText = "Starting...";
			string stopText = "Stopped DS4Windows";

			string result = "";
			bool isStarted = true;

			using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				byte[] buffer = new byte[4096]; // Taille du buffer en octets

				// Commencez depuis la fin du fichier
				long position = fs.Length;
				int bytesRead;



				while (position > 0)
				{
					position -= buffer.Length;

					if (position < 0)
					{
						buffer = new byte[buffer.Length + (int)position];
						position = 0;
					}

					fs.Seek(position, SeekOrigin.Begin);
					bytesRead = fs.Read(buffer, 0, buffer.Length);

					// Convertissez le contenu du buffer en texte
					string bufferText = Encoding.UTF8.GetString(buffer, 0, bytesRead);

					// Recherchez le texte "Starting..." ou "Stopped DS4Windows" dans le buffer
					int startIdx = bufferText.LastIndexOf(startText);
					int stopIdx = bufferText.LastIndexOf(stopText);

					if (startIdx >= 0 || stopIdx >= 0)
					{
						// L'un des textes a été trouvé
						int startIndex = Math.Max(startIdx, stopIdx); // Prenez le plus grand des deux indices

						result = bufferText.Substring(startIndex) + result;
						if (stopIdx > startIdx)
						{
							return "";
						}
						break; // Sortez de la boucle
					}

					// Si ni "Starting..." ni "Stopped DS4Windows" n'a été trouvé, ajoutez le contenu au résultat
					result = bufferText + result;
				}
			}

			return result;
		}
	}
}