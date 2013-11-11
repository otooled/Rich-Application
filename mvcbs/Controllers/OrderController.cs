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
           
            var q = from a in db.Albums
                    join oid in db.OrderDetails on a.AlbumId equals oid.AlbumId
                    where oid.OrderId == id
                    select a;

            ViewBag.Message = String.Format("Albums for <span class='strong text-info'>{0}</span>", id);
            return View("Albums", q);
            
        }

        public ActionResult ViewArtist(int id)
        {
            var qA = from a in db.Artists
                     join aid in db.Albums on a.ArtistId equals aid.ArtistId
                     where aid.AlbumId == id
                     select a;
            return View("ViewArtist", qA);
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
