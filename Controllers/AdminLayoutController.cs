using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YummyProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AdminLayoutNavbar()
        {
            // Navbar içeriği buraya eklenebilir
            return PartialView();
        }

        public ActionResult AdminLayoutSidebar()
        {
            // Sidebar içeriği buraya eklenebilir
            return PartialView();
        }
    }
}