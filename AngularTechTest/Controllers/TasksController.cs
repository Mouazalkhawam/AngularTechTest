using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularTechTest.Models;

namespace AngularTechTest.Controllers
{
    public class TasksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        public JsonResult GetEmployeeTasks(int employeeId)
        {
            try
            {
                var employeeTasks = db.EmployeeTasks
                    .Where(et => et.EmployeeId == employeeId)
                    .Include(et => et.Task)
                    .Select(et => new
                    {
                        et.Task.Id,
                        et.Task.TaskName
                    })
                    .ToList();

                var employee = db.Employees.Find(employeeId);

                return Json(new
                {
                    success = true,
                    employeeName = employee?.Name,
                    tasks = employeeTasks
                }, JsonRequestBehavior.AllowGet);
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