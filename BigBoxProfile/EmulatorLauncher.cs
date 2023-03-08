using CliWrap;
using MonitorSwitcherGUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
				if(exp != null && exp.Length == 2 && exp[0].ToLower() == "bigbox")
				{

					if (Profile.ProfileList.ContainsKey(exp[1]))
					{
						SelectedProfile= Profile.ProfileList[exp[1]];
					}
				}
			}
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
					.WithArguments(ArgsWithoutFirstElement())
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
			if (SelectedProfile == null)
			{
				Execute();
			}
			else
			{

				ExecutePrelaunch();
				Execute();
				Thread.Sleep(1000);
				ExecutePostlaunch();
			}
			

			
		}

		public string[] ArgsWithoutFirstElement()
		{
			string[] filteredArgs;

			if (Args.Length > 1)
			{
				filteredArgs = new string[Args.Length - 1];

				for (int i = 1; i < Args.Length; i++)
				{
					filteredArgs[i - 1] = Args[i];
				}
			}
			else
			{
				filteredArgs = new string[0];
			}

			return filteredArgs;

		}

	}
}
