using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CA2.Controllers
{
    public class HomeController : Controller
    {
        private northwndEntities db = new northwndEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var orders = db.Orders.OrderBy(o => o.OrderDate);
            return View(orders);
        }

        //Action to get employee details for Employee display window
        public  ActionResult EmpDetails(int id = 0)
        {
            var details = from eDets in db.Employees
                          where eDets.EmployeeID == id
                          select eDets;

            return PartialView("_EmpDetails", details);
        }

        //Action to get orders of employee selected from Employee display window
        public  ActionResult EmpOrders(int id = 0)
        {
            var empOrd = from od in db.Orders
                         where od.OrderID == id
                         select od;
            return View("Index", empOrd);
        }
        //
       
        //// GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.EmployeeID = new SelectList(db.Employees, "EmployeeID", "LastName", order.EmployeeID);
            ViewBag.ShipVia = new SelectList(db.Shippers, "ShipperID", "CompanyName", order.ShipVia);
            return View(order);
        }

        ////
        //// GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //I need to delete the order from the order detail table before I can actually delete the order.
            //I don't know how to do that.  I tried the following code.

            //Order_Detail orderDetail = db.Order_Details.Find(id);
            //db.Order_Details.Remove(orderDetail);

            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}