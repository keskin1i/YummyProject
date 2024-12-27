using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext(); 

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProduct()
        {
           var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEvent()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultChef()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }
        // GET: DefaultBooking
        [HttpGet]
        public ActionResult DefaultBooking()
        {
            return PartialView("DefaultBooking");
        }

        // POST: DefaultBooking
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DefaultBooking(Booking model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Veritabanına kaydetme işlemi
                    context.Bookings.Add(model);
                    context.SaveChanges(); 

                    // Başarılı mesajını ViewBag'e ekleyin
                    ViewBag.Message = "Rezervasyonunuz başarıyla gönderildi.";
                }
                catch (Exception ex)
                {
                    // Hata mesajını ViewBag'e ekleyin
                    ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doğru doldurduğunuzdan emin olun.";
            }

            // Form verilerini ekranda göstermemek için boş bir model döndürün
            ModelState.Clear();
            return PartialView("DefaultBooking",model);
        }

        public PartialViewResult DefaultPhotoGalery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultContact()
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult DefaultMessage()
        {
            return PartialView(new Message());
        }

        // POST: DefaultMessage
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult DefaultMessage(Message model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Mesajı veritabanına kaydet
                    context.Messages.Add(model);
                    context.SaveChanges();

                    // Başarı mesajı
                    ViewBag.Message = "Mesajınız başarıyla gönderildi.";
                }
                catch (Exception ex)
                {
                    // Hata mesajı
                    ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Lütfen tüm alanları doğru doldurduğunuzdan emin olun.";
            }

            return PartialView(model);
        }

       



    }
}