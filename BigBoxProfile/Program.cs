using CliWrap;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
						BigBoxUtils.RegisterApp();
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
						BigBoxUtils.UnregisterApp();
					}
					else
					{
						MessageBox.Show("The command --unregister must be send with Admin privilege");
					}
					return;
				}

				if (args.Length >= 1)
				{
					/*
					string argstxt = "";
					foreach(var a in args)
					{
						argstxt+= a + " ";

					}
					MessageBox.Show("execute " + argstxt);
					*/
					if (args[0].EndsWith("BigBox.exe") && File.Exists(args[0]))
					{
						var task = ExecuteBigBox(args[0], "default");
						task.Wait();
					}
				}
				
			}


		}

		public static async Task ExecuteBigBox(string file, string profile)
		{
			try
			{
				string dir = Path.GetDirectoryName(file);
				string exe = Path.GetFileName(file);

				string coreexe = Path.Combine(dir, "Core", exe);

				if (File.Exists(coreexe))
				{
					file = coreexe;
					dir = Path.GetDirectoryName(file);
					exe = Path.GetFileName(file);
				}


				string exeWithoutFilename = Path.GetFileNameWithoutExtension(file);
				string newExe = Path.Combine(dir, exeWithoutFilename + "_" + profile + ".exe" );

				BigBoxUtils.MakeLink(file, newExe);

				//MessageBox.Show("execute " + newExe);
				var ResultRPCS = await Cli.Wrap(newExe)
					.WithArguments("")
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();

				//MessageBox.Show("done");

				File.Delete(newExe);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}


}
