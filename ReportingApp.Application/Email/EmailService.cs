﻿using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace ReportingApp.Application.Email
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(EmailModel emailModel, bool mode = true)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");
            var config = configuration.Build();
            var emailAddress = config.GetValue<string>("EmailData:Email");
            var emailPassword = config.GetValue<string>("EmailData:EmailPassword");
            var emailBody = "<!DOCTYPE html>" +
                                "<html> " +
                                    "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                    $"<h1 style=\"color:#051a80;\">Email from {emailModel.UserName} - {emailModel.UserEmail}</h1> " +
                                    "<h2 style=\"color:#000;\">Message:</h2> " +
                                    $"<a style=\"color:#2dca98;\" href=\"{emailModel.Body}\">Click here confirm your email!</a>" +
                                    "</body> " +
                                "</html>";

            emailModel.SetEmailFromAddress(emailAddress);

            if (mode)
            {
                emailModel.SetEmailToAddress(emailAddress);
                emailBody = "<!DOCTYPE html>" +
                                "<html> " +
                                    "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                    $"<h1 style=\"color:#051a80;\">Email from {emailModel.UserName} - {emailModel.UserEmail}</h1> " +
                                    "<h2 style=\"color:#000;\">Message:</h2> " +
                                    $"<h3 style=\"color:#000;\">{emailModel.Body}</h3> " +
                                    "</body> " +
                                "</html>";
            }

            var mailMessage = new MailMessage(emailModel.From, emailModel.To);

            mailMessage.Subject = emailModel.Subject;
            mailMessage.Body = emailBody;
            mailMessage.IsBodyHtml = true;

            using SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;

            var networkCredential = new NetworkCredential(emailModel.From, emailPassword);
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = networkCredential;
            await smtpClient.SendMailAsync(mailMessage);

            return true;
        }
    }
}
