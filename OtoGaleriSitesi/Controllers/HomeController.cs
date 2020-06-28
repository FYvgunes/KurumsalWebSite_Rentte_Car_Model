using System;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using OtoGaleriSitesi.Models;

namespace OtoGaleriSitesi.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Mail m)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("webdeveloperr3@gmail.com", "1q2w3e4r5T*-?");
                client.EnableSsl = true;

                MailMessage msj = new MailMessage();
                msj.From = new MailAddress(m.Email, m.Adi + " " + m.Soyadi);
                msj.To.Add("webdeveloperr3@gmail.com");
                msj.Subject = m.Konu + "" + m.Email;
                msj.Body = m.Mesaj;
                client.Send(msj);

                MailMessage msj1 = new MailMessage();
                msj1.From = new MailAddress("webdeveloperr3@gmail.com", "Rent A Car");
                msj1.To.Add(m.Email);
                msj1.Subject = "Mail'inize Cevap";
                msj1.Body = "Size En kısa zamanda Döneceğiz. Teşekkür Ederiz Bizi tercih ettiğiniz için";

                client.Send(msj1);

                ViewBag.Succes = "teşekkürler Mailniz başarı bir şekilde gönderildi";
                return View();
            }
            catch (Exception)
            {
                ViewBag.Error = "Mesaj Gönderilken hata olıuştu";
                return View();
            }
        }
    }
}