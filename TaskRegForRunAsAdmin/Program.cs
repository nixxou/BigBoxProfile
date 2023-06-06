using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskRegForRunAsAdmin
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var UsersRights = TaskLogonType.InteractiveToken;

			string JustRunExe = args[0];
			var filteredArgs = ArgsWithoutFirstElement(args);


			string cmd = ArgsToCommandLine(filteredArgs);
			if (cmd.Contains("RamDiskManager.exe"))
			{
				UsersRights = TaskLogonType.S4U;
			}
			/*
			var UsersRights = TaskLogonType.InteractiveToken;
			if (cmd.Contains("RamDiskManager.exe"))
			{
				UsersRights = TaskLogonType.S4U;
			}
			*/
			Console.WriteLine("CMD=" + cmd);
			string taskName = "";
			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(cmd);
				byte[] hashBytes = md5.ComputeHash(inputBytes);
				string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();



				taskName = "RunAdmin_" + hashString;
				Console.WriteLine("Task=" + taskName);

			}
			

			if (JustRunExe.Contains("TaskRunNormal"))
			{
				UsersRights = TaskLogonType.InteractiveToken;
				args = filteredArgs;
				JustRunExe = filteredArgs[0];
				filteredArgs = ArgsWithoutFirstElement(args);
				cmd = ArgsToCommandLine(filteredArgs);
			}
			if (JustRunExe.Contains("TaskRunHidden"))
			{
				UsersRights = TaskLogonType.S4U;
				args = filteredArgs;
				JustRunExe = filteredArgs[0];
				filteredArgs = ArgsWithoutFirstElement(args);
				cmd = ArgsToCommandLine(filteredArgs);
			}

			Console.WriteLine("Exec=" + JustRunExe);
			Console.WriteLine("Arg=" + cmd);
			//Console.ReadLine();


			if (!String.IsNullOrEmpty(taskName))
			{
				using (TaskService ts = new TaskService())
				{
					TaskDefinition td = ts.NewTask();
					td.RegistrationInfo.Description = "Task as admin";

					td.Principal.RunLevel = TaskRunLevel.Highest;
					td.Principal.LogonType = UsersRights;

					// Create an action that will launch Notepad whenever the trigger fires
					td.Actions.Add(JustRunExe, cmd, null);

					// Register the task in the root folder
					ts.RootFolder.RegisterTaskDefinition(taskName, td, TaskCreation.CreateOrUpdate, Environment.GetEnvironmentVariable("USERNAME"), null, UsersRights, null);

				}

			}


			//Console.ReadLine();

		}

		public static string ArgsToCommandLine(string[] arguments)
		{
			var sb = new StringBuilder();
			foreach (string argument in arguments)
			{
				bool needsQuoting = argument.Any(c => char.IsWhiteSpace(c) || c == '\"');
				if (!needsQuoting)
				{
					sb.Append(argument);
				}
				else
				{
					sb.Append('\"');
					foreach (char c in argument)
					{
						int backslashes = 0;
						while (backslashes < argument.Length && argument[backslashes] == '\\')
						{
							backslashes++;
						}
						if (c == '\"')
						{
							sb.Append('\\', backslashes * 2 + 1);
							sb.Append(c);
						}
						else if (c == '\0')
						{
							sb.Append('\\', backslashes * 2);
							break;
						}
						else
						{
							sb.Append('\\', backslashes);
							sb.Append(c);
						}
					}
					sb.Append('\"');
				}
				sb.Append(' ');
			}
			return sb.ToString().TrimEnd();
		}

		public static string[] ArgsWithoutFirstElement(string[] args)
		{
			string[] filteredArgs;
			if (args.Length > 1)
			{
				filteredArgs = new string[args.Length - 1];

				for (int i = 1; i < args.Length; i++)
				{
					filteredArgs[i - 1] = args[i];
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
