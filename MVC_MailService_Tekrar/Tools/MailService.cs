﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MVC_MailService_Tekrar.Tools
{
    public static class MailService
    {

        public static void Send(string receiver, string password="34243424", string body="Test mesajıdır",string subject="Email Testi",string sender = "yms34243423@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Bizim email işlemlerimiz SMTP'ye göre yapılır... 
            //Kullandığınız Gmail hesabının başka uygulamalar tarafından mesaj gönderme özelliğini açmalısınız...

            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };

            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body,
            })
            {
                smtp.Send(message);
            }
        }
    }
}