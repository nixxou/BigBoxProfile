using CefSharp;

namespace BigBoxProfile
{
	public class MyCustomLifeSpanHandler : ILifeSpanHandler
	{
		// Load new URL (when clicking a link with target=_blank) in the same frame
		public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
		{
			browser.MainFrame.LoadUrl(targetUrl);
			newBrowser = null;
			return true;
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
}
