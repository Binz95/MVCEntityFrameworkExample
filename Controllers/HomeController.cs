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
            if (ModelState.IsValid)
            {
                ctx.Contacts.Add(c);
                ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
        public ActionResult Detail(int? id)
        {
            var c = ctx.Contacts.Find(id);
            return View(c);
           // var c = (from p in ctx.Contacts
             //        where p.ContactId == id
               //      select p).FirstOrDefault();
        }
        public ActionResult Delete(int? id)
        {
            var c = ctx.Contacts.Find(id);
            return View(c);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteContact(int? id)
        {
            var c = ctx.Contacts.Find(id);
            ctx.Contacts.Remove(c);
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id)
        {
            var c = ctx.Contacts.Find(id);
            return View(c);
        }
        [HttpPost]
        
        public ActionResult Edit(Contact co)
        {
            var c = ctx.Contacts.Find(co.ContactId);
            c.ContactName = co.ContactName;
            c.Location = co.Location;
            ctx.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}