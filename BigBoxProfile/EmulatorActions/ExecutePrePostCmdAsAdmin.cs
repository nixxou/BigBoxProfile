﻿using System;
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

		private string _exclude = "";
		private bool _commaFilter = false;
		private bool _commaExclude = false;
		private bool _removeFilter = false;
		private bool _matchAllFilter = false;
		private bool _matchAllExclude = false;




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

				Options["exclude"] = frm.exclude.Trim();
				if (frm.commaFilter) Options["commaFilter"] = "yes";
				else Options["commaFilter"] = "no";
				if (frm.commaExclude) Options["commaExclude"] = "yes";
				else Options["commaExclude"] = "no";
				if (frm.removeFilter) Options["removeFilter"] = "yes";
				else Options["removeFilter"] = "no";

				if (frm.matchAllFilter) Options["matchAllFilter"] = "yes";
				else Options["matchAllFilter"] = "no";

				if (frm.matchAllExclude) Options["matchAllExclude"] = "yes";
				else Options["matchAllExclude"] = "no";


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

			if (Options.ContainsKey("exclude") == false) Options["exclude"] = "";
			if (Options.ContainsKey("commaFilter") == false) Options["commaFilter"] = "no";
			if (Options.ContainsKey("commaExclude") == false) Options["commaExclude"] = "no";
			if (Options.ContainsKey("removeFilter") == false) Options["removeFilter"] = "no";

			if (Options.ContainsKey("matchAllFilter") == false) Options["matchAllFilter"] = "no";
			if (Options.ContainsKey("matchAllExclude") == false) Options["matchAllExclude"] = "no";
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
				string matchall = "";
				string matchallexclude = "";
				if (_matchAllFilter) matchall = "[matchall=on]";
				if (_matchAllExclude) matchallexclude = "[matchall=on]";

				var cmdToExecute = BigBoxUtils.explode(_commandList, "|||");
				description = $"Execute {cmdToExecute.Length} Commands as Admin on Process ";
				if (_onStart) description += "Start";
				else description += "Stop";
				if (_filter != "") description += $" [Only if command line contains {_filter}]{matchall}";
				if (_exclude != "") description += $" [Exclude {_exclude}]{matchallexclude}";
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
			_exclude = Options["exclude"];
			_commaFilter = Options["commaFilter"] == "yes" ? true : false;
			_commaExclude = Options["commaExclude"] == "yes" ? true : false;
			_removeFilter = Options["removeFilter"] == "yes" ? true : false;
			_matchAllFilter = Options["matchAllFilter"] == "yes" ? true : false;
			_matchAllExclude = Options["matchAllExclude"] == "yes" ? true : false;
		}


		public void ExecuteBefore(string[] args)
		{
			if (IsConfigured() == false)
			{
				return;
			}
			string cmd = BigBoxUtils.ArgsToCommandLine(args);
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return;
					if (_matchAllFilter && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found)
					{
						return;
					}
					if (_matchAllExclude && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
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
						Thread.Sleep(100);
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
			string cmdlower = cmd.ToLower();
			if (_filter != "")
			{
				if (_commaFilter)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_filter.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (!filter_found) return;
					if (_matchAllFilter && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (!cmdlower.Contains(_filter.ToLower()))
					{
						return;
					}
				}
			}

			if (_exclude != "")
			{
				if (_commaExclude)
				{
					int nbFilter = 0;
					int nbFilterFound = 0;
					bool filter_found = false;
					var liste_filter = BigBoxUtils.explode(_exclude.ToLower(), ",");
					foreach (var filter in liste_filter)
					{
						if (filter.Trim() == "") continue;
						nbFilter++;
						if (cmdlower.Contains(filter.Trim()))
						{
							nbFilterFound++;
							filter_found = true;
						}
					}
					if (filter_found)
					{
						return;
					}
					if (_matchAllExclude && nbFilter > nbFilterFound) return;
				}
				else
				{
					if (cmdlower.Contains(_exclude.ToLower()))
					{
						return;
					}
				}
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
						Thread.Sleep(100);
					}

				}
			}
		}

		public bool UseM3UContent()
		{
			return false;
		}

		public string[] FiltersToRemoveOnFinalPass()
		{
			List<string> emptylist = new List<string>();
			if (_removeFilter)
			{
				return BigBoxUtils.MakeFilterListToRemove(_filter, _commaFilter);
			}
			return emptylist.ToArray();
		}

	}
}
