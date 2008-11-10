using System;
using System.IO;
using System.Net;
using System.Text;

namespace TravianPlayer.Framework
{
	public class Http
	{
		public static HttpWebResponse SendData(string pageUrl,
		                                       string postData,
		                                       CookieContainer cookieContainer)
		{
			Console.WriteLine("SendData '{1}' to '{0}'", pageUrl, postData);

			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(pageUrl);
			httpWebRequest.Method = "GET";
			httpWebRequest.UserAgent =
				"Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.17) Gecko/20080829 Firefox/2.0.0.17 (.NET CLR 3.5.30729)";
			httpWebRequest.CookieContainer = cookieContainer;

			if (postData != null)
			{
				UTF8Encoding encoding = new UTF8Encoding();
				byte[] data = encoding.GetBytes(postData);
				
				httpWebRequest.Method = "POST";
				httpWebRequest.ContentType = "application/x-www-form-urlencoded";
				httpWebRequest.ContentLength = data.Length;
				
				Stream postStream = httpWebRequest.GetRequestStream();
				postStream.Write(data, 0, data.Length);
				postStream.Close();
			}

			HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			return webResponse;
		}
	}
}