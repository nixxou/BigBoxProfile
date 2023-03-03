using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoxProfile
{
	internal static class Program
	{
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		public static void Main(string[] args)
		{
			if (args.Length== 0)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new Config());
			}
			else
			{
				if(args.Length== 1 && args[0] == "--register")
				{
					bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
					if (isAdmin)
					{
						BigBoxProfile.RegisterApp();
					}
					else
					{
						MessageBox.Show("The command --register must be send with Admin privilege");
					}
					return;
				}
				if (args.Length == 1 && args[0] == "--unregister")
				{
					bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
					if (isAdmin)
					{
						BigBoxProfile.UnregisterApp();
					}
					else
					{
						MessageBox.Show("The command --unregister must be send with Admin privilege");
					}
					return;
				}


				MessageBox.Show("Actif");
			}


		}
	}
}
