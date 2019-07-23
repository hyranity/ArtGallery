using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace ArtGallery.Util
{
	public class Email
	{

		/* Following code is possible thanks to:
		* Sarwar Erfan & Jon @ https://stackoverflow.com/questions/4677258/send-email-using-system-net-mail-through-gmail
		* Also https://asp.net-tutorials.com/misc/sending-mails/
		*/
		public static void SendEmail(string To, string Subject, string Body)
		{
			// Create mail object
			MailMessage Mail = new MailMessage();

			// Set relevant Mail properties
			Mail.To.Add(To);
			Mail.From = new MailAddress("galleryartx@gmail.com");
			Mail.Subject = Subject;
			Mail.Body = Body;
			Mail.IsBodyHtml = true;

			// Configuring smtp 
			using (SmtpClient smtp = new SmtpClient())
			{
				smtp.Port = 587;
				smtp.EnableSsl = true;
				smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
				smtp.Credentials = new NetworkCredential("galleryartx@gmail.com", "artx2019");
				smtp.Host = "smtp.gmail.com";

				// Send the mail itself
				smtp.Send(Mail);
			}
		}
	}
}