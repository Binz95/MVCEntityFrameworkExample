using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityFrameworkEg.Models;
namespace EntityFrameworkEg.Controllers
{
    public class HomeController : Controller
    {
        ContactManagementSimplifiedEntities ctx = new ContactManagementSimplifiedEntities();
        public ActionResult Index()
        {
            return View(ctx.Contacts.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Create(Contact c)
        {
            ctx.Contacts.Add(c);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}