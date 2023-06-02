using CliWrap;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace BigBoxProfile
{
	public class EmulatorLauncher
	{
		Profile SelectedProfile = null;
		bool useAlternativeLaunch = false;
		string LaunchFromDir;
		string ExeFileFull;
		string ExeFile;
		string NewExe;
		string Dir;
		string[] Args;


		public EmulatorLauncher(string[] args)
		{
			var p = ParentProcessUtilities.GetParentProcess();
			if (p != null)
			{
				string process_name = p.ProcessName;
				var exp = BigBoxUtils.explode(process_name,"_");
				//foreach(var x in exp) { MessageBox.Show(x); }


				if(exp != null && exp.Length == 2 && (exp[0].ToLower() == "bigbox" || exp[0].ToLower() == "launchbox"))
				{

					if (Profile.ProfileList.ContainsKey(exp[1]))
					{
						SelectedProfile= Profile.ProfileList[exp[1]];
					}
				}
				else
				{
					if (process_name.ToLower() == "bigbox" || process_name.ToLower() == "launchbox")
					{
						if (Profile.ProfileList.ContainsKey("default"))
						{
							SelectedProfile = Profile.ProfileList["default"];
						}
					}

				}



			}

			//MessageBox.Show(SelectedProfile.ProfileName);

			LaunchFromDir = Environment.CurrentDirectory;
			ExeFileFull = args[0];
			Dir = Path.GetDirectoryName(ExeFileFull);
			ExeFile = Path.GetFileName(ExeFileFull);
			NewExe = Path.Combine(Dir, Path.GetFileNameWithoutExtension(ExeFileFull) + "_.exe");
			Args = args;



		}

		public void ExecutePrelaunch()
		{
			
		}

		public void ExecutePostlaunch()
		{

		}

		public async Task ExecuteJustRun()
		{
			try
			{
				string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");
				//JustRunExe = @"C:\LaunchBox\Emulators\SimpleFowarder.exe";

				var ResultRPCS = await Cli.Wrap(JustRunExe)
					.WithArguments(Args)
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}


		public async Task ExecuteWithLink()
		{

			try
			{

				BigBoxUtils.MakeLink(ExeFileFull, NewExe);
				var ResultRPCS = await Cli.Wrap(NewExe)
					.WithArguments(BigBoxUtils.ArgsWithoutFirstElement(Args))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardOutput()))
					.WithStandardOutputPipe(PipeTarget.ToStream(Console.OpenStandardError()))
					.WithValidation(CommandResultValidation.None)
					.ExecuteAsync();
				File.Delete(NewExe);

			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		public void Execute()
		{
			Task task;
			if (useAlternativeLaunch) task = ExecuteWithLink();
			else task = ExecuteJustRun();
			task.Wait();
		}

		public void Exec()
		{
			Emulator emulator = null;
			if (SelectedProfile == null)
			{
				if (Emulator.Exist("default", ExeFile))
				{
					var default_emulator = new Emulator("default", ExeFile);
					if (default_emulator.ApplyWithoutLaunchbox)
					{
						emulator = default_emulator;
						SelectedProfile = Profile.ProfileList["default"];
					}
				}
			}
			else
			{
				if (Emulator.Exist(SelectedProfile.ProfileName, ExeFile))
				{
					emulator = new Emulator(SelectedProfile.ProfileName, ExeFile);
				}
			}



			if (emulator == null)
			{
				Execute();
			}
			else
			{

				//var argstring = BigBoxUtils.ArgsToCommandLine(Args);
				//MessageBox.Show(argstring);

				ExecutePrelaunch();

				string m3uFile = BigBoxUtils.HaveLaunchboxM3U(Args);
				if (String.IsNullOrEmpty(m3uFile))
				{
					foreach (var module in emulator._selectedModules)
					{
						if (module.IsConfigured())
						{
							module.ExecuteBefore(Args);
							Args = module.ModifyReal(Args);

						}

					}
					
					Execute();
					Thread.Sleep(1000);

					for (int i = emulator._selectedModules.Count - 1; i >= 0; i--)
					{
						var module = emulator._selectedModules[i];
						if (module.IsConfigured())
						{
							module.ExecuteAfter(Args);
						}
					}

				}
				else
				{
					string m3uNew = BigBoxUtils.GetLaunchboxM3UNewPath(m3uFile);
					List<string> m3uFileListOriginal = BigBoxUtils.GetLaunchboxM3UContent(m3uFile);
					string m3uFirstFile = m3uFileListOriginal.First();
					List<string> m3uFileListNew = new List<string>();

					int nbM3U = BigBoxUtils.CountFileInArg(Args, m3uFile);
					var ArgsWithFirstFileInsteadOfM3U = BigBoxUtils.RemplaceFileInArg(Args, m3uFile, m3uFirstFile);
					var ArgsWithFirstFileInsteadOfM3U_Copy = new string[ArgsWithFirstFileInsteadOfM3U.Length];
					ArgsWithFirstFileInsteadOfM3U.CopyTo(ArgsWithFirstFileInsteadOfM3U_Copy, 0);

					foreach (var module in emulator._selectedModules)
					{
						if (module.IsConfigured() && module.UseM3UContent() == false)
						{
							module.ExecuteBefore(ArgsWithFirstFileInsteadOfM3U);
							ArgsWithFirstFileInsteadOfM3U = module.ModifyReal(ArgsWithFirstFileInsteadOfM3U);
							//Si il y a une modification du fichier passé en paramettre, on accepte pas la modif et on restaure
							if(BigBoxUtils.CountFileInArg(ArgsWithFirstFileInsteadOfM3U,m3uFirstFile) != nbM3U)
							{
								ArgsWithFirstFileInsteadOfM3U = new string[ArgsWithFirstFileInsteadOfM3U_Copy.Length];
								ArgsWithFirstFileInsteadOfM3U_Copy.CopyTo(ArgsWithFirstFileInsteadOfM3U, 0);
							}

						}
					}
					Args = BigBoxUtils.RemplaceFileInArg(ArgsWithFirstFileInsteadOfM3U, m3uFirstFile , m3uNew);

					foreach (var fileInM3U in m3uFileListOriginal)
					{
						var ForgedArgList = new List<string>();
						ForgedArgList.Add(Args[0]);
						ForgedArgList.Add(fileInM3U);
						if(Args.Length > 2)
						{
							for(int i = 1; i < Args.Length; i++)
							{
								if (Args[i] != m3uNew)
								{
									ForgedArgList.Add(Args[i]);
								}
							}
						}
						var ForgedArg = ForgedArgList.ToArray();

						foreach (var module in emulator._selectedModules)
						{
							if (module.IsConfigured() && module.UseM3UContent() == true)
							{
								ForgedArg = module.ModifyReal(ForgedArg);
							}
						}
						m3uFileListNew.Add(ForgedArg[1]);
					}

					string directoryPath = Path.GetDirectoryName(m3uNew);
					if (!Directory.Exists(directoryPath))
					{
						Directory.CreateDirectory(directoryPath);
					}
					File.WriteAllLines(m3uNew, m3uFileListNew.ToArray());

					Execute();
					Thread.Sleep(1000);

					File.Delete(m3uNew);

					for (int i = emulator._selectedModules.Count - 1; i >= 0; i--)
					{
						var module = emulator._selectedModules[i];
						if (module.IsConfigured())
						{
							module.ExecuteAfter(Args);
						}
					}



					//MessageBox.Show(M3UFile);
				}

				/*
				Si M3U


				*/




			}
			ExecutePostlaunch();
			

			
		}



	}
}
