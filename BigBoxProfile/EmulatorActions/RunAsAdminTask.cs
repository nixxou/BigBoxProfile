using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.TaskScheduler;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;


namespace BigBoxProfile.EmulatorActions
{
	internal class RunAsAdminTask : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		private bool _isTaskRunning = false;
		private string _taskName = "";

		public RunAsAdminTask()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}

		public string ModuleName => "RunAsAdminTask";

		private string _filter = "";
		private string _filterInsideFile = "";

		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public IEmulatorAction CreateNewInstance()
		{
			return new RunAsAdminTask();
		}

		public void Configure()
		{
			var frm = new RunAsAdminTask_Config(this.Options);
			var result = frm.ShowDialog();

			if (result == DialogResult.OK)
			{
				Options["filter"] = frm.filter.Trim();
				Options["filterInsideFile"] = frm.filterInsideFile.Trim();

				UpdateConfig();
			}

		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("filterInsideFile") == false) Options["filterInsideFile"] = "";
			UpdateConfig();

		}

		public bool IsConfigured()
		{
			return true;
		}

		public override string ToString()
		{
			string description = "Run As Admin";


			if (IsConfigured())
			{
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
				if (_filterInsideFile != "") description += $" [Only if file in arg contains {_filterInsideFile}]";
			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";

			//return $"{ModuleName} Instance {_instanceId}";


		}

		public string[] ModifyExemple(string[] args)
		{
			try
			{
				args = Modify(args);
			}
			catch { }

			return args;

		}

		public string[] Modify(string[] args)
		{
			string cmd_original = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd_original.Contains(_filter))
			{
				return args;
			}

			bool change_dispostion = true;
			if (_filterInsideFile != "")
			{
				change_dispostion = false;
				var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
				foreach (string arg in filteredArgs)
				{
					// Vérifier si l'argument est un chemin de fichier valide
					bool isFilePath = BigBoxUtils.IsValidPath(arg);

					if (isFilePath)
					{
						// Vérifier si le fichier existe
						if (File.Exists(arg))
						{
							string fileContent = File.ReadAllText(arg);
							// Vérifier si la chaîne cible est présente dans le contenu du fichier
							if (fileContent.Contains(_filterInsideFile))
							{
								change_dispostion = true;
							}
							break;
						}
					}
					else
					{
						if (arg.Contains("="))
						{
							var exploded = BigBoxUtils.explode(arg, "=");
							if (exploded.Count() > 1)
							{
								string argFromEqual = exploded[1];
								isFilePath = BigBoxUtils.IsValidPath(argFromEqual);

								if (isFilePath)
								{
									// Vérifier si le fichier existe
									if (File.Exists(argFromEqual))
									{
										string fileContent = File.ReadAllText(argFromEqual);
										// Vérifier si la chaîne cible est présente dans le contenu du fichier
										if (fileContent.Contains(_filterInsideFile))
										{
											change_dispostion = true;
										}
										break;
									}
								}
							}
						}
					}
				}
				if (change_dispostion == false) return args;
			}


			args = BigBoxUtils.ArgsToAbsoluteArgs(args);
			string cmd = BigBoxUtils.ArgsToCommandLine(args);

			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(cmd);
				byte[] hashBytes = md5.ComputeHash(inputBytes);
				string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
				string taskName = "RunAdmin_" + hashString;
				string new_cmd = $@"schtasks /run /tn ""{taskName}""";
				args = BigBoxUtils.CommandLineToArgs(new_cmd, true);
			}
			

			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			args = ModifyExemple(args);
			return args;
		}

		private void UpdateConfig()
		{
			_filter = Options["filter"];
			_filterInsideFile = Options["filterInsideFile"];
		}

		public void ExecuteBefore(string[] args)
		{

			string cmd_original = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd_original.Contains(_filter))
			{
				return;
			}

			bool change_dispostion = true;
			if (_filterInsideFile != "")
			{
				change_dispostion = false;
				var filteredArgs = BigBoxUtils.ArgsWithoutFirstElement(args);
				foreach (string arg in filteredArgs)
				{
					// Vérifier si l'argument est un chemin de fichier valide
					bool isFilePath = BigBoxUtils.IsValidPath(arg);

					if (isFilePath)
					{
						// Vérifier si le fichier existe
						if (File.Exists(arg))
						{
							string fileContent = File.ReadAllText(arg);
							// Vérifier si la chaîne cible est présente dans le contenu du fichier
							if (fileContent.Contains(_filterInsideFile))
							{
								change_dispostion = true;
							}
							break;
						}
					}
					else
					{
						if (arg.Contains("="))
						{
							var exploded = BigBoxUtils.explode(arg, "=");
							if(exploded.Count() > 1)
							{
								string argFromEqual = exploded[1];
								isFilePath = BigBoxUtils.IsValidPath(argFromEqual);

								if (isFilePath)
								{
									// Vérifier si le fichier existe
									if (File.Exists(argFromEqual))
									{
										string fileContent = File.ReadAllText(argFromEqual);
										// Vérifier si la chaîne cible est présente dans le contenu du fichier
										if (fileContent.Contains(_filterInsideFile))
										{
											change_dispostion = true;
										}
										break;
									}
								}
							}
						}
					}
				}
				if (change_dispostion == false) return;
			}

			args = BigBoxUtils.ArgsToAbsoluteArgs(args);
			string cmd = BigBoxUtils.ArgsToCommandLine(args);


			using (MD5 md5 = MD5.Create())
			{
				byte[] inputBytes = Encoding.UTF8.GetBytes(cmd);
				byte[] hashBytes = md5.ComputeHash(inputBytes);
				string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
				
				

				string taskName = "RunAdmin_" + hashString;
				using (TaskService taskService = new TaskService())
				{
					if (taskService.GetTask(taskName) == null)
					{
						string JustRunExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "JustRun.exe");

						List<string> arguments = new List<string>();
						arguments.Add(JustRunExe);
						arguments.AddRange(args);
						
						
						//string taskRegExe = @"C:\Users\Mehdi\source\repos\BigBoxProfile\TaskRegForRunAsAdmin\bin\Debug\TaskRegForRunAsAdmin.exe";
						string taskRegExe = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "TaskRegForRunAsAdmin.exe");
						//MessageBox.Show(taskRegExe);
						//string exePath = Assembly.GetEntryAssembly().Location;
						string exePath = taskRegExe;
						string exeDir = Path.GetDirectoryName(exePath);
						ProcessStartInfo startInfo = new ProcessStartInfo();
						startInfo.FileName = exePath;
						startInfo.Arguments = BigBoxUtils.ArgsToCommandLine(arguments.ToArray());
						startInfo.WorkingDirectory = exeDir;
						startInfo.Verb = "runas";
						Process.Start(startInfo);


						_isTaskRunning = true;
						_taskName = taskName;

					}
					else
					{
						_isTaskRunning = true;
						_taskName = taskName;
					}
				}


			}



		}
		public void ExecuteAfter(string[] args)
		{
			if (_isTaskRunning)
			{
				Thread.Sleep(2000);
				string taskName = _taskName;

				// Récupère toutes les instances de la tâche
				TaskService ts = new TaskService();

				Microsoft.Win32.TaskScheduler.Task task = ts.GetTask(taskName);
				Microsoft.Win32.TaskScheduler.RunningTaskCollection instances = task.GetInstances();
				while (instances.Count == 1)
				{
					instances = task.GetInstances();
					Thread.Sleep(100);
				}
				_isTaskRunning= false;
			}
		}

	}
}
