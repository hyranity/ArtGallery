using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FileUtil = ArtGallery.Util.FileUtil;

namespace ArtGallery
{
	public partial class UploadImageTest : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Util.Quick.Print(FileUtil.Upload(FileUpload1, "~/Pics/"));

		}
	}
}