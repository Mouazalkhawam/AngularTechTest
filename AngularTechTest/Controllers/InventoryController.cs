using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularTechTest.Models;

namespace AngularTechTest.Controllers
{
    public class InventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeSupplies()
        {
            return View();
        }

        public JsonResult GetSupplies()
        {
            try
            {
                var supplies = db.Supplies.ToList();
                return Json(supplies, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmployeeSupplies(int employeeId)
        {
            try
            {
                var employeeSupplies = db.EmployeeSupplies
                    .Include(es => es.Supply)
                    .Where(es => es.EmployeeId == employeeId)
                    .Select(es => new
                    {
                        es.Id,
                        es.EmployeeId,
                        es.AssignedDate,
                        es.Status,
                        Supply = new
                        {
                            es.Supply.Id,
                            es.Supply.SupplyName,
                            es.Supply.SupplyType,
                            es.Supply.Price,
                            es.Supply.Quantity
                        }
                    })
                    .ToList();

                return Json(new { success = true, supplies = employeeSupplies }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AssignSupplyToEmployee(int employeeId, int supplyId)
        {
            try
            {
                var employeeSupply = new EmployeeSupply
                {
                    EmployeeId = employeeId,
                    SupplyId = supplyId,
                    AssignedDate = DateTime.Now,
                    Status = "Assigned"
                };

                db.EmployeeSupplies.Add(employeeSupply);
                db.SaveChanges();

                return Json(new { success = true, message = "Supply assigned successfully" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}