using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ArtGallery.Util
{
	/*
	 * This code is possible thanks to Yatendra Sharma @ https://www.c-sharpcorner.com/UploadFile/ca2535/how-to-upload-files-and-save-the-files-into-database-using/
	 *
	 * This utility class serves to make writing code for uploading files easier.
	 * 
	 */
	public class FileUtil
	{
		FileUpload File;
		string StorageLocation;

		public FileUtil(FileUpload File, string StorageLocation)
		{
			this.File = File;
			this.StorageLocation = StorageLocation;
		}

		// Saves the file file into the server
		private void PerformUpload()
		{
			// Saves the file itself
			File.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(StorageLocation) + GetFileName());
		}

		private string GetFileName()
		{
			return File.FileName.ToString();
		}

		private string GetAddress()
		{
			return StorageLocation + GetFileName();
		}

		//Returns the upload address after upload
		// Try to use this method only when uploading files
		public static string Upload(FileUpload File, string StorageLocation)
		{
			FileUtil file = new FileUtil(File, StorageLocation);
			file.PerformUpload();

			return file.GetAddress();
		}
	}
}