﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminProductController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            context.Products.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            List<SelectListItem> kategoriler = (from x in context.Categories
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryId.ToString()
                                                }).ToList();
            ViewBag.kategoriler = kategoriler;

            var value = context.Products.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProduct(Product newProduct)
        {
            var old = context.Products.Find(newProduct.ProductId);
            old.ImgUrl = newProduct.ImgUrl;
            old.ProductName = newProduct.ProductName;
            old.Ingredients = newProduct.Ingredients;
            old.Price = newProduct.Price;
            old.CategoryId = newProduct.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> kategoriler = (from x in context.Categories
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryId.ToString()
                                                }).ToList();
            kategoriler.Insert(0, new SelectListItem
            {
                Text = "Lütfen kategori seçiniz.",
                Value = "",
                Selected = true,
                Disabled = true
            });
            ViewBag.kategoriler = kategoriler;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product newProduct)
        {
            context.Products.Add(newProduct);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}