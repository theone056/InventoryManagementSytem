using System.Net;
using System.Net.Mail;

namespace InventoryManagementSystem.API.Services
{
    public class EmailHelper
    {
        public bool SendEmail(string UserEmail, string confirmationLink)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("cittheone@gmail.com");
            message.To.Add(new MailAddress(UserEmail));

            message.Subject = "Confirm your email";
            message.IsBodyHtml = true;
            message.Body = confirmationLink;

            try
            {
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("cittheone@gmail.com", "Maytatlongbibe06@");

                    smtp.Send(message);

                    return true;
                }
            }
            catch (Exception ex) {
               Console.Error.WriteLine(ex.Message);
            }

            return false;

        }
    }
}
