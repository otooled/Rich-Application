using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcbs.Controllers
{
    public class OrdersController : Controller
    {
        //make database connection
        private MvcMusicStoreEntities db = new MvcMusicStoreEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        //
        // GET: /Default1/

        public ActionResult Index(int id = 0)
        {
            var alList = db.Albums.SingleOrDefault(alb => alb.AlbumId == id);
            if (alList != null)
            {
                return View(new List<Album> {alList});
            }
            return View(db.Albums);
        }

        //
        

        public ActionResult OrderIndex(int id)
        {
            var selectOrder = db.OrderDetails.SingleOrDefault(ord => ord.OrderId == id);
            if(selectOrder != null)
            {
                ViewBag.

            }
            return View();
        }

        //
        // GET: /Default1/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Default1/Create

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
        // GET: /Default1/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Default1/Edit/5

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
        // GET: /Default1/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Default1/Delete/5

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
