using System;
using System.Net;
using System.Net.Mail;

public class sendEmail
    {
        public static bool Send(string to, string subject, string body)
        {
            try
            {
            MailMessage message = new MailMessage("shkala.info@gmail.com", to);
            message.Body = body;
            message.Subject = subject;
            message.IsBodyHtml = true;
            NetworkCredential mailAuthentication = new NetworkCredential("shkala.info@gmail.com", "9898.9898");
            SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
            mailClient.EnableSsl = true;
            mailClient.UseDefaultCredentials = false;
            mailClient.Credentials = mailAuthentication;
            mailClient.Send(message);
            return true;
        }
            catch (Exception)
            {
                return false;
            }
        }

        public static void sendsms(string to, string Message)
        {
        var sender = "1000596446" ;
        var receptor = to ;
        var message = Message ;
        var api = new Kavenegar.KavenegarApi("776F2B764B5167442F736C62346F4162345534554E2F516F57417239446B5A30326B6271573469662B71383D");
        api.Send(sender, receptor, message ); 
        }
}