//using BigBoxProfile;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstallerLib
{
	[RunInstaller(true)]
	public partial class Installer1 : System.Configuration.Install.Installer
	{
		public Installer1()
		{


		}

		public override void Install(System.Collections.IDictionary stateSaver)
		{
			bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (isAdmin)
			{

				try
				{
					string PathMainProfileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BigBoxProfile");
					string ExeFullPath = Path.Combine(Context.Parameters["Path"].TrimEnd('\\'), "BigBoxProfile.exe");
					var r = new RegisteryManager(PathMainProfileDir, ExeFullPath);
					r.FixRegistery();
				}
				catch { }


			}

			base.Install(stateSaver);
		}

		public override void Uninstall(System.Collections.IDictionary stateSaver)
		{
			bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (isAdmin)
			{


				try
				{
					string PathMainProfileDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "BigBoxProfile");
					string ExeFullPath = Path.Combine(Context.Parameters["Path"].TrimEnd('\\'), "BigBoxProfile.exe");
					var r = new RegisteryManager(PathMainProfileDir, ExeFullPath);
					r.DeleteAllDebuggerKeys();
				}
				catch { }

			}
			base.Uninstall(stateSaver);
		}

	}
}
