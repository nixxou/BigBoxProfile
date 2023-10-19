using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PauseMenu
{
	internal static class Program
	{
		public static int InstanceID = 0;
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			//MessageBox.Show("pausemenu.exe");
			if(args.Length > 0)
			{
				int instance_id = int.Parse(args[0]);
				InstanceID = instance_id;
				string jsonResumeData = "";
				try
				{
					using (MemoryMappedFile mmf = MemoryMappedFile.OpenExisting($"PauseMenu_Instance{instance_id}"))
					{
						using (MemoryMappedViewAccessor accessor = mmf.CreateViewAccessor())
						{
							long length = accessor.Capacity;
							byte[] jsonDataBytes = new byte[length];
							accessor.ReadArray(0, jsonDataBytes, 0, (int)length);
							jsonResumeData = Encoding.UTF8.GetString(jsonDataBytes).TrimEnd('\0');
						}
					}
				}
				catch { }
				if(jsonResumeData != "")
				{
					Dictionary<string, object> configData = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonResumeData);
					if (configData != null)
					{
						if (configData.ContainsKey("HtmlContent"))
						{
							Application.EnableVisualStyles();
							Application.SetCompatibleTextRenderingDefault(false);
							Application.Run(new Form1(configData));
						}
					}
				}
			}
		}
	}
}
