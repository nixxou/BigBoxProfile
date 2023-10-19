using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BigBoxProfile;
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
			if (BigBoxUtils.Base64Decode(code_base64, out decodedString))
			{
				var customBrowser = (CustomBrowser)chromiumWebBrowser;
				customBrowser.ParentForm.Invoke(new Action(() =>
				{
					customBrowser.ParentForm.SetAHKCodeToExecute(decodedString);
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

	public override CefReturnValue ProcessRequestAsync(IRequest request, ICallback callback)
	{
		string prefixToRemove = "localfolder://cefsharp/ahk.get?";
		string code_base64 = request.Url.Substring(prefixToRemove.Length);
		string decodedString = "";
		if (BigBoxUtils.Base64Decode(code_base64, out decodedString))
		{
			var ahk_session = new AutoHotkey.Interop.AutoHotkeyEngine();
			string resultatfinal = "";
			try
			{
				ahk_session.ExecRaw(decodedString);
				resultatfinal = ahk_session.GetVar("returnvalue");
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return CefReturnValue.Cancel;
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

