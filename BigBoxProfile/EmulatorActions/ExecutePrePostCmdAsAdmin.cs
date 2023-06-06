using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace BigBoxProfile.EmulatorActions
{
	internal class ExecutePrePostCmdAsAdmin : IEmulatorAction
	{
		private static int _instanceCount = 0;
		private int _instanceId;

		public ExecutePrePostCmdAsAdmin()
		{
			_instanceCount++;
			_instanceId = _instanceCount;
		}


		public string ModuleName => "ExecutePrePostCmdAsAdmin";

		private string _filter = "";
		private string _commandList = "";
		private bool _onStart = true;




		public Dictionary<string, string> Options { get; set; } = new Dictionary<string, string>();

		public void Configure()
		{
			var frm = new ExecutePrePostCmdAsAdmin_Config(this.Options);
			var result = frm.ShowDialog();
			if (result == DialogResult.OK)
			{
				Options["commandList"] = frm.commandList;
				Options["filter"] = frm.filter.Trim();

				if (frm.onStart) Options["onStart"] = "yes";
				else Options["onStart"] = "no";


				UpdateConfig();
			}
		}

		public IEmulatorAction CreateNewInstance()
		{
			return new ExecutePrePostCmdAsAdmin();
		}

		public bool IsConfigured()
		{
			if (Options.ContainsKey("commandList") == false || Options["commandList"] == "")
			{
				return false;
			}
			return true;
		}

		public void LoadConfiguration(Dictionary<string, string> options)
		{
			this.Options = options;
			if (Options.ContainsKey("commandList") == false) Options["commandList"] = "";
			if (Options.ContainsKey("filter") == false) Options["filter"] = "";
			if (Options.ContainsKey("onStart") == false) Options["onStart"] = "yes";
			UpdateConfig();
		}

		public string[] ModifyExemple(string[] args)
		{
			return args;
		}

		public string[] ModifyReal(string[] args)
		{
			return args;
		}

		public override string ToString()
		{
			string description = "";


			if (IsConfigured())
			{
				var cmdToExecute = BigBoxUtils.explode(_commandList, "|||");
				description = $"Execute {cmdToExecute.Length} Commands as Admin on Process ";
				if (_onStart) description += "Start";
				else description += "Stop";
				if (_filter != "") description += $" [Only if command line contains {_filter}]";
			}
			else
			{
				description = "NON-CONFIGURED !";
			}

			return $"{ModuleName} => {description}";
		}

		private void UpdateConfig()
		{
			_commandList = Options["commandList"];
			_filter = Options["filter"];
			_onStart = Options["onStart"] == "yes" ? true : false;
		}


		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured() == false)
			{
				return;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd.Contains(_filter))
			{
				return;
			}

			if (_onStart)
			{
				var cmdlist = BigBoxUtils.explode(_commandList, "|||");
				foreach (var cmdv in cmdlist)
				{
					if (!String.IsNullOrEmpty(cmdv.Trim()))
					{
						string taskName = BigBoxUtils.GetTaskName(cmdv);
						if (BigBoxUtils.CheckTaskExist(taskName))
						{
							BigBoxUtils.ExecuteTask(taskName);
						}
						else
						{
							BigBoxUtils.RegisterTask(cmdv, "TaskRunNormal");
							Thread.Sleep(1000);
							BigBoxUtils.ExecuteTask(taskName);
						}
					Thread.Sleep(1000);
					}

				}
			}

		}
		public void ExecuteAfter(string[] args)
		{
			if (IsConfigured() == false)
			{
				return;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			if (_filter != "" && !cmd.Contains(_filter))
			{
				return;
			}

			if (!_onStart)
			{
				var cmdlist = BigBoxUtils.explode(_commandList, "|||");
				foreach (var cmdv in cmdlist)
				{
					if (!String.IsNullOrEmpty(cmdv.Trim()))
					{

						string taskName = BigBoxUtils.GetTaskName(cmdv);
						if (BigBoxUtils.CheckTaskExist(taskName))
						{
							BigBoxUtils.ExecuteTask(taskName);
						}
						else
						{
							BigBoxUtils.RegisterTask(cmdv, "TaskRunNormal");
							Thread.Sleep(1000);
							BigBoxUtils.ExecuteTask(taskName);
							
						}
						Thread.Sleep(1000);
					}

				}
			}
		}

		public bool UseM3UContent()
		{
			return false;
		}

	}
}
