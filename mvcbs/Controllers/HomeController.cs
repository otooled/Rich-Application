using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcbs.Controllers
{
    public class HomeController : Controller
    {
        //make database connection
        private musicStoreDataContext db = new musicStoreDataContext();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        //
        // GET: /Home/

        public ActionResult Index(string searchTerm)
        {
            var q1 = from o in db.Orders
                     where searchTerm == null || o.LastName.Contains(searchTerm)
                     select o;
            
            return View(q1);
        }

        //
        // GET: /Home/Details/5

        public ActionResult SortSize()
        {
            var q3 = from o in db.Orders
                     orderby o.Total descending
                     select o;
            return View(q3);
        }

        //
        // GET: /Home/Create

        public ActionResult SortDate()
        {
            var q2 = from od in db.Orders
                     orderby od.OrderDate descending
                     select od;
            return View(q2);
        }

        //
        // POST: /Home/Create

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

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
