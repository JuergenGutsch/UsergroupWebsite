using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Web;
using CommunitySite.Web.Data.Models;

namespace CommunitySite.Web.Services
{
    public interface IEmailService
    {
        void SendGlobalSubscriptionActivationMessage(Subscription subscription);
    }

    public class EmailService : IEmailService
    {
        private readonly ISmtpService _smtpService;
        private const string SubscriptionActivationLink = "http://{1}/Reminder/Activate/{0}";
        private const string SubscriptionUnsubscribeLink = "http://{1}/Reminder/Unsubscribe/{0}";

        //https://github.com/sendgrid/sendgrid-csharp

        public EmailService(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }

        public void SendGlobalSubscriptionActivationMessage(Subscription subscription)
        {
            const string validationMessage = @"<p>Hallo,</p>

<p>Sie haben sich auf www.dotnetkk.de für die Terminerinnerungen registriert. <br />
Um die Registrierung zu bestätigen und die Richtigkeit der E-Mailadresse zu prüfen, bitten wir Sie die Registrierug mit folgendem Link zu bestätigen: <br />
{0}</p>

<p>Sollte die Registrierung falsch sein, so können Sie die Registrierung unter folgendem Link komplett löschen: <br />
{1}</P>

<p>Viele Grüße <br />
Das .NET-Stammtisch Team <br />
(Jürgen, Tilo, Stefan und Roberto)</p>";

            var message = string.Format(validationMessage,
                                           String.Format(SubscriptionActivationLink, subscription.ValidationKey, HttpContext.Current.Request.Url.Authority),
                                           String.Format(SubscriptionUnsubscribeLink, subscription.ValidationKey, HttpContext.Current.Request.Url.Authority));

            _smtpService.SendEmail(subscription.Email, "Terminerinnerungen - .NET-Stammtisch Konstanz-Kreuzlingen", message);
        }
    }

    public interface ISmtpService
    {
        void SendEmail(string email, string subject, string message);
    }

    public class SmtpService : ISmtpService
    {
        public void SendEmail(string email, string subject, string message)
        {
            var myMessage = SendGrid.Mail.GetInstance();
            myMessage.From = new MailAddress(ConfigurationManager.AppSettings["sendgrid_sender"]);
            myMessage.AddTo(email);
            myMessage.Subject = subject;

            //Add the HTML and Text bodies
            myMessage.Html = message;

            var credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["sendgrid_username"],
                ConfigurationManager.AppSettings["sendgrid_password"]);

            // Create an Web transport for sending email.
            var transportWeb = SendGrid.Transport.Web.GetInstance(credentials);

            // Send the email.
            transportWeb.Deliver(myMessage);

            //var smtpClient = new SmtpClient();
            //var mailMessage = new MailMessage("dotnetkk@outlook.com", email, subject, message);
            //smtpClient.Send(mailMessage);
        }
    }
}
