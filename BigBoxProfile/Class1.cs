using BigBoxProfile.EmulatorActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CustomBrowser : CefSharp.WinForms.ChromiumWebBrowser
{
	public PauseMenu_Show ParentForm = null;
}