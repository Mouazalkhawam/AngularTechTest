using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularTechTest.Models;

namespace AngularTechTest.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult EmployeeSupplies()
        {
            return View("~/Views/Employees/EmployeeSupplies.cshtml");
        }

        public JsonResult GetEmployees()
        {
            try
            {
                var employees = db.Employees.ToList();

                if (!employees.Any())
                {
                    var initialEmployees = new List<Employee>
                    {
                        new Employee { Name = "John", Department = "IT", Salary = 100000 },
                        new Employee { Name = "Rimi", Department = "HR", Salary = 200000 },
                        new Employee { Name = "Jim", Department = "Operation", Salary = 50000 },
                        new Employee { Name = "Dev", Department = "IT", Salary = 150000 },
                        new Employee { Name = "Sarah", Department = "HR", Salary = 60000 },
                        new Employee { Name = "Seteve", Department = "IT", Salary = 170000 },
                        new Employee { Name = "Henry", Department = "Operation", Salary = 60000 },
                        new Employee { Name = "Tony", Department = "IT", Salary = 80000 },
                        new Employee { Name = "Ema", Department = "IT", Salary = 85000 },
                        new Employee { Name = "Dani", Department = "Operation", Salary = 90000 }
                    };

                    db.Employees.AddRange(initialEmployees);
                    db.SaveChanges();
                    employees = initialEmployees;
                }

                return Json(employees, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEmployee(int id)
        {
            try
            {
                var employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return Json(new { success = false, message = "Employee not found" }, JsonRequestBehavior.AllowGet);
                }
                
                return Json(new
                {
                    employee.Id,
                    employee.Name,
                    employee.Department,
                    employee.Salary
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdateSalary(int id, decimal salary)
        {
            try
            {
                var employee = db.Employees.Find(id);
                if (employee != null)
                {
                    employee.Salary = salary;
                    db.Entry(employee).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, employee = employee });
                }
                return Json(new { success = false, message = "Employee not found" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
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