using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UbuntuTest.Controllers
{
    public class EmailEngine : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        public IActionResult SendMail(string name, string email, string msg)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("brian.hanus@outlook.com"));
            message.To.Add(new MailboxAddress("brian.hanus@ecolab.com"));
            message.Subject = name;
            message.Body = new TextPart("html")
            {
                Text = "From: " + name + "<br>" +
                "Contact Information: " + email + "<br>" +
                "Message: " + msg
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp-mail.outlook.com", 587);
                client.Authenticate("brian.hanus@outlook.com", "Bh167471");
                client.Send(message);
                client.Disconnect(false);
            }

            return View("Index");
        }
    }
}
