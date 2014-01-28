using System;
using System.Net.Mail;
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
        private const string SubscriptionActivationLink = "/Subscription/Activate/{0}";
        private const string SubscriptionUnsubscribeLink = "/Subscription/Unsubscribe/{0}";

        public EmailService(ISmtpService smtpService)
        {
            _smtpService = smtpService;
        }


        public void SendGlobalSubscriptionActivationMessage(Subscription subscription)
        {
            const string validationMessage = @"Halle {0},

Du hast duch auf dotnetkk.de für die Terminerinnerungen registriert.
Um die Registrierung zu bestätigen und die Richtigkeit der E-Mailadresse zu prüfen, bitten wir dich die Registrierug mit folgendem Link zu bestätigen:
{1}

Sollte die Registrierung falsch sein kannst Du die Registrierung unter folgendem Link komplett löschen:
{2}

Viele Grüße
Das .NET-Stammtisch Team
(Jürgen, Tilo, Stefan und Roberto)";

            var message = string.Format(validationMessage,
                                           subscription.Name,
                                           String.Format(SubscriptionActivationLink, subscription.Id),
                                           String.Format(SubscriptionUnsubscribeLink, subscription.Id));

            _smtpService.SendEmail(subscription.Email, "Subject", message);
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
            var smtpClient = new SmtpClient();
            var mailMessage = new MailMessage("dotnetkk@gutsch-online.de", email, subject, message);
            smtpClient.Send(mailMessage);
        }
    }
}
