using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WelcomeController : Controller
    {
        // GET: Welcome
        public ActionResult Index()
        {
            ViewBag.AA = "haha";
            return View();
        }

        public ActionResult RedirectToAction()
        {
            TempData["Welcome"] = ".net mvc";
            return RedirectToAction("Details");
        }

        public ActionResult RedirectToController()
        {
            TempData["Welcome"] = ".net mvc";
            return RedirectToAction("About", "Home");
        }

        // GET: Welcome/Details/5
        public ActionResult Details()
        {
            return View();
        }

        // GET: Welcome/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Welcome/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Welcome/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Welcome/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Welcome/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Welcome/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
