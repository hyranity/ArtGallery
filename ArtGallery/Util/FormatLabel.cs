using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ArtGallery.Util
{
	// This class allows the generation of label messages as feedback
	public class FormatLabel
	{
		private Label Label;
		public FormatLabel(Label Label)
		{
			this.Label = Label;
		}
		public Label Error(string message)
		{

			// Set text
			Label.Text = message;

			// Set inline CSS
			// Note: Code is possible thanks to Matthew Verstraete @ https://stackoverflow.com/questions/19578858/how-to-change-label-font-in-code-behind-using-c-sharp
			Label.Attributes.Add("style", "color: #b04141; font-size: 20px;");

			return Label;
		}

		public Label Success(string message)
		{

			// Set text
			Label.Text = message;

			// Set inline CSS
			// Note: Code is possible thanks to Matthew Verstraete @ https://stackoverflow.com/questions/19578858/how-to-change-label-font-in-code-behind-using-c-sharp
			Label.Attributes.Add("style", "color: #9ef542; font-size: 20px;");
			
			return Label;
		}

		public static Label Reset(Label Label)
		{
			Label.Text = "";
			Label.Attributes.Remove("style");

			return Label;
		}

		// Experimental 
		public static string PrintLabel(Label label)
		{
			return "<asp:Label ID="+label.ID+" runat=server></asp:Label>";
		}
	}
}