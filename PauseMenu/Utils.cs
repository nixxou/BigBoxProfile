using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Utils
{
	public static bool Base64Decode(string base64txt, out string result)
	{
		try
		{
			byte[] data = Convert.FromBase64String(base64txt);
			result = System.Text.Encoding.UTF8.GetString(data);
			return true;
		}
		catch (FormatException)
		{
			result = "";
			return false;
		}
	}
}

