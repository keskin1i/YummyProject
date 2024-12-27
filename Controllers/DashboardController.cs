using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
  
    public class DashboardController : Controller
    {
        YummyContext context = new YummyContext();

      
        public ActionResult Index()
        {
            ViewBag.AperatifCount = context.Products.Count(x => x.Category.CategoryId == 3);
            ViewBag.BreakfastCount = context.Products.Count(x => x.Category.CategoryId == 1);
            ViewBag.LunchCount = context.Products.Count(x => x.Category.CategoryId == 4);
            ViewBag.DinnerCount = context.Products.Count(x => x.Category.CategoryId == 2);
            ViewBag.CommentCount = context.Testimonials.Count();
            ViewBag.MaxPriceProduct = context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.MinPriceProduct = context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.AvgPrice = context.Products.Average(x => x.Price);
            return View();
        }
    }
}