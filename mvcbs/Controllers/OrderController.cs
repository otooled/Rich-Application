using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcbs.Controllers
{
    public class OrderController : Controller
    {
        private MvcMusicStoreEntities db = new MvcMusicStoreEntities();

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
        //
        // GET: /OrderedAlbums/

        public ActionResult Index(int id = 0)
        {
            var albQuery = db.Albums.SingleOrDefault(alb => alb.AlbumId == id);
            if(albQuery != null)
            {
                return View(new List<Album> {albQuery});
            }
            return View(db.Albums);
        }

        //
        // GET: /OrderedAlbums/Details/5

        public ActionResult IndexOrder(int id)
        {
            var selectOrd = db.OrderDetails.SingleOrDefault(ord => ord.OrderId == id);

            if(selectOrd != null)
            {
                ViewBag.Message = String.Format("Albums for <span class='strong text-info'>{0}</span>", selectOrd.OrderId);
                return View("OrderedAlbums", selectOrd);
            }
                ViewBag.Message = "No albums listed with this order";
            
            
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /OrderedAlbums/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrderedAlbums/Create

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
        // GET: /OrderedAlbums/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /OrderedAlbums/Edit/5

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
        // GET: /OrderedAlbums/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /OrderedAlbums/Delete/5

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
