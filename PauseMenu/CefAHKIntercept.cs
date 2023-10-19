using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.SchemeHandler;

public class CefAHKIntercept : ILifeSpanHandler
{
	// Load new URL (when clicking a link with target=_blank) in the same frame
	public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
	{
		if (targetUrl.StartsWith("ahk:"))
		{

			string code_base64 = targetUrl.Substring(4);
			string decodedString = "";
			if (Utils.Base64Decode(code_base64, out decodedString))
			{
				var customBrowser = (CustomBrowser)chromiumWebBrowser;
				customBrowser.ParentForm.Invoke(new Action(() =>
				{
					//customBrowser.ParentForm.SetAHKCodeToExecute(decodedString);
					customBrowser.ParentForm.SetCommandToHostProgram("ahkclose", decodedString);
					customBrowser.ParentForm.Close();
				}));
				Thread.Sleep(200);
				//ahk.ExecRaw(decodedString);

				newBrowser = null;
				return true;
			}
			else
			{
				browser.MainFrame.LoadUrl(targetUrl);
				newBrowser = null;
				return true;
			}


		}
		else
		{
			browser.MainFrame.LoadUrl(targetUrl);
			newBrowser = null;
			return true;
		}


	}


	// If you don't implement all of the interface members in the custom class
	// you will find:
	// Error CS0535	'MyCustomLifeSpanHandler' does not implement interface member 'ILifeSpanHandler.OnAfterCreated(IWebBrowser, IBrowser)'

	public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
	{
		// throw new NotImplementedException();
		return true;
	}

	public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
	{
		// throw new NotImplementedException();
	}

	public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
	{
		// throw new NotImplementedException();
	}



}

public class CustomFolderSchemeHandlerFactory : FolderSchemeHandlerFactory
{
	
	public CustomFolderSchemeHandlerFactory(string rootFolder, string schemeName = null, string hostName = null, string defaultPage = "index.html", FileShare resourceFileShare = FileShare.Read) : base(rootFolder, schemeName, hostName, defaultPage, resourceFileShare)
	{

	}

	protected override IResourceHandler Create(IBrowser browser, IFrame frame, string schemeName, IRequest request)
	{

		string FileName = "";
		try
		{
			FileName = Path.GetFileName(request.Url);
		}
		catch (Exception ex) { }
		if (ArtCustomShemeHandler.ArtOverride.ContainsKey(FileName.ToLower().Trim()))
		{
			return new ArtCustomShemeHandler();
		}

		if (request.Url.StartsWith("localfolder://cefsharp/ahk.get?"))
		{
			return new MyCustomSchemeHandler();
		}


		return base.Create(browser, frame, schemeName, request);
	}


}

internal class MyCustomSchemeHandler : ResourceHandler
{
	public static bool ahkFromExe = false;

	public static string AHK_argsPrefix = "";
	public static string AHK_gamedataPrefix = "";

	private static string GetAHKCode(string code)
	{
		string code_prefix_gamedata = "";
		string code_prefix_args = "";
		if (code.Contains("#includegamedata"))
		{
			code = code.Replace("#includegamedata", "");
			code_prefix_gamedata = AHK_gamedataPrefix;
		}

		if (code.Contains("#includeargs"))
		{
			code = code.Replace("#includeargs", "");
			code_prefix_args = AHK_argsPrefix;
		}

		return code_prefix_gamedata + "\n" + code_prefix_args + "\n" + code;
	}

	public static string AHKExecuteFromExe(string decodedString, string returnvaluename = "returnvalue")
	{
		string currentDir = Path.GetFullPath(Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName));
		string ahkExe = Path.Combine(currentDir, "AutoHotkeyU32.exe");
		string tempFilePath = Path.Combine(Path.GetTempPath(), Path.GetTempFileName() + ".ahk");
		string tempFileRes = tempFilePath + ".res.txt";

		string code = GetAHKCode(decodedString);

		if(returnvaluename != "")
		{
			code += "\n";
			code += @"FileAppend, %" + returnvaluename + @"%, " + tempFileRes;
			code += "\n";
		}

		File.WriteAllText(tempFilePath, code);
		Thread.Sleep(200);
		if (File.Exists(tempFilePath))
		{
			Process process = new Process();
			process.StartInfo.FileName = ahkExe;
			process.StartInfo.Arguments = tempFilePath;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;

			// Démarrer le processus
			process.Start();
			process.WaitForExit();


			File.Delete(tempFilePath);
		}
		

		string result = "";
		if (returnvaluename != "")
		{
			if (File.Exists(tempFileRes))
			{
				result = File.ReadAllText(tempFileRes);
				File.Delete(tempFileRes);
			}
		}
		return result;

	}

	public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
	{
		string prefixToRemove = "localfolder://cefsharp/ahk.get?";
		string code_base64 = request.Url.Substring(prefixToRemove.Length);
		string decodedString = "";
		if (Utils.Base64Decode(code_base64, out decodedString))
		{
			string resultatfinal = "";

			if (ahkFromExe)
			{
				try
				{
					resultatfinal = AHKExecuteFromExe(decodedString, "returnvalue");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return CefReturnValue.Cancel;
				}

			}
			else
			{
				var ahk_session = new AutoHotkey.Interop.AutoHotkeyEngine();
				try
				{
					string code = GetAHKCode(decodedString);
					File.WriteAllText(@"E:\debugcode.ahk", code);
					ahk_session.ExecRaw(code);
					resultatfinal = ahk_session.GetVar("returnvalue");
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					return CefReturnValue.Cancel;
				}
			}


			Task.Run(() =>
			{
				using (callback)
				{
					string responseContent = resultatfinal; // La réponse que vous souhaitez renvoyer

					var stream = new MemoryStream(Encoding.UTF8.GetBytes(responseContent));

					// Reset the stream position to 0 so the stream can be copied into the underlying unmanaged buffer
					stream.Position = 0;

					// Populate les valeurs de la réponse
					ResponseLength = stream.Length;
					MimeType = "text/plain; charset=utf-8";
					StatusCode = (int)HttpStatusCode.OK;
					Stream = stream;

					callback.Continue();
				}
			});
			return CefReturnValue.ContinueAsync;
		}
		else
		{
			return CefReturnValue.Cancel;
		}

	}
}

public class ArtCustomShemeHandler : ResourceHandler
{
	public static Dictionary<string, string> ArtOverride = new Dictionary<string, string>();

	public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
	{
		string FileName = "";
		try
		{
			FileName = Path.GetFileName(request.Url);
		}
		catch (Exception ex) { }
		if (ArtCustomShemeHandler.ArtOverride.ContainsKey(FileName.ToLower().Trim()))
		{

			Task.Run(() =>
			{

				using (callback)
				{
					var requestedFilePath = ArtCustomShemeHandler.ArtOverride[FileName.ToLower().Trim()];

					if (File.Exists(requestedFilePath))
					{
						byte[] bytes = File.ReadAllBytes(requestedFilePath);
						Stream = new MemoryStream(bytes);

						var fileExtension = Path.GetExtension(requestedFilePath);
						MimeType = GetMimeType(fileExtension);

						callback.Continue();
					}
				}

			});
			return CefReturnValue.ContinueAsync;

		}
		return CefReturnValue.Cancel;
	}
}

