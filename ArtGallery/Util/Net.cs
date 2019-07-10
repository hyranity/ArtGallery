using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArtGallery.Util
{
	public class Net
	{

		/*
		 * This utility class is made to shorten code related to web-related operations such as Session and Redirect.
		 */


		// Return an object from session
		public static object GetSession(string name)
		{
			// Code is possible thanks to M4N @ https://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net

			return HttpContext.Current.Session[name];
		}

		// Set an object to session
		public static void SetSession(string name, object obj)
		{
			// Code is possible thanks to M4N @ https://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net

			HttpContext.Current.Session[name] = obj;
		}

		// Return a string from Query String
		public static string GetQueryStr(string name)
		{
			// Code is possible thanks to Sajeetharan @ https://stackoverflow.com/questions/39062071/getting-query-string-value-in-a-class

			return HttpContext.Current.Request.QueryString[name];
		}

		// Perform a redirect
		public static void Redirect(string url)
		{
			HttpContext.Current.Response.Redirect(url);
		}

		// Return a querystring url (Experimental)
		public static string GenQueryStr(string[] query)
		{
			string queryStr = "?";

			for (int i = 0; i < query.Length; i++)
			{
				queryStr += query[i];

				if (i != query.Length - 1)
					queryStr += "&";
			}

			return queryStr;
		}

		
		public static void RefreshPage()
		{
			// Code is possible thanks to chris @ https://stackoverflow.com/questions/1206507/how-do-i-refresh-the-page-in-asp-net-let-it-reload-itself-by-code

			HttpContext.Current.Response.Redirect(HttpContext.Current.Request.RawUrl);
		}

		
		//EXPERIMENTAL
		private static void GoNextPage()
		{
			bool hasError = false;

			//Get pageNo from URL
			string pageStr = GetQueryStr("page");

			int pageNo = 1;

			// Attempt to get page number
			try
			{
				pageNo = Convert.ToInt32(pageStr);
			}
			catch (Exception ex)
			{
				pageNo = 1;
				hasError = true;
				
			}

			string url = HttpContext.Current.Request.RawUrl;

			//Cut out page part if got page as parameter
			if(pageStr != null)
				url = url.Substring(url.IndexOf("&page"), url.Length - url.IndexOf("&page"));


			Redirect(url + "&page=" + (pageNo + 1));
		}

		//EXPERIMENTAL
		private static void GoPrevPage()
		{
			bool hasError = false;

			//Get pageNo from URL
			string pageStr = GetQueryStr("page");

			int pageNo = 1;

			// Attempt to get page number
			try
			{
				pageNo = Convert.ToInt32(pageStr);
			}
			catch (Exception ex)
			{
				pageNo = 1;
				hasError = true;
			}

			string url = HttpContext.Current.Request.RawUrl;

			//Cut out page part if got page as parameter
			if (!hasError)
				url = url.Substring(url.IndexOf("&page"), url.Length - url.IndexOf("&page"));


			Redirect(url + "&page=" + (pageNo - 1));
		}

	}
}