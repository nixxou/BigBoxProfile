using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RamDiskManager
{
	internal static class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			RamDiskMount ramDiskMount = new RamDiskMount(args);
			/*
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1(args));
			*/
		}
	}
}
