using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailOTPSystem
{
    public class EmailHelper
    {
        public static bool SendEmail(string emailAddress, string emailBody)
        {
            var to = emailAddress;
            var from = ConfigurationManager.AppSettings["smtp_username"];
            var password = ConfigurationManager.AppSettings["smtp_password"];

            if (string.IsNullOrEmpty(from) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("SMTP username/password cannot be null or empty.");
            }

            MailMessage message = new(from, to)
            {
                Subject = "dso-otp",
                Body = emailBody
            };
            SmtpClient client = new("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(from, password)
            };

            try
            {
                client.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in SendEmail(): {0}",
                    ex.ToString());
                return false;
            }
        }
    }
}
