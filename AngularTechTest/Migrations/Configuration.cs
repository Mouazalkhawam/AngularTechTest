using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using AngularTechTest.Models;

namespace AngularTechTest.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddOrUpdate(
                    e => e.Name,
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
                );

                context.SaveChanges();
            }

            if (!context.Tasks.Any())
            {
                context.Tasks.AddOrUpdate(
                    t => t.TaskName,
                    new Task { TaskName = "Install system" },
                    new Task { TaskName = "Deploy on IIS" },
                    new Task { TaskName = "Training Customers" },
                    new Task { TaskName = "Analysis" },
                    new Task { TaskName = "SRS" }
                );

                context.SaveChanges();
            }

            if (!context.Supplies.Any())
            {
                context.Supplies.AddOrUpdate(
                    s => s.SupplyName,
                    new Supply { SupplyName = "Laptop Dell XPS 13", SupplyType = "Electronics", Price = 1200, Quantity = 15 },
                    new Supply { SupplyName = "Laptop HP EliteBook", SupplyType = "Electronics", Price = 1100, Quantity = 10 },
                    new Supply { SupplyName = "MacBook Pro 14", SupplyType = "Electronics", Price = 2000, Quantity = 5 },
                    new Supply { SupplyName = "Office Chair Ergonomic", SupplyType = "Furniture", Price = 350, Quantity = 20 },
                    new Supply { SupplyName = "Standing Desk", SupplyType = "Furniture", Price = 600, Quantity = 8 },
                    new Supply { SupplyName = "Wireless Mouse Logitech", SupplyType = "Electronics", Price = 25, Quantity = 50 },
                    new Supply { SupplyName = "Mechanical Keyboard", SupplyType = "Electronics", Price = 120, Quantity = 25 },
                    new Supply { SupplyName = "Notebook A4", SupplyType = "Stationery", Price = 5, Quantity = 200 },
                    new Supply { SupplyName = "Pen Set (10 pcs)", SupplyType = "Stationery", Price = 8, Quantity = 150 },
                    new Supply { SupplyName = "Monitor 24 inch Dell", SupplyType = "Electronics", Price = 300, Quantity = 12 },
                    new Supply { SupplyName = "Monitor 27 inch 4K", SupplyType = "Electronics", Price = 500, Quantity = 6 },
                    new Supply { SupplyName = "Desk Lamp LED", SupplyType = "Furniture", Price = 45, Quantity = 15 },
                    new Supply { SupplyName = "Headset with Mic", SupplyType = "Electronics", Price = 85, Quantity = 30 },
                    new Supply { SupplyName = "USB-C Hub", SupplyType = "Electronics", Price = 40, Quantity = 40 },
                    new Supply { SupplyName = "Whiteboard Markers", SupplyType = "Stationery", Price = 12, Quantity = 60 },
                    new Supply { SupplyName = "Printer Paper (500 sheets)", SupplyType = "Stationery", Price = 15, Quantity = 100 }
                );

                context.SaveChanges();
            }

            if (!context.EmployeeTasks.Any())
            {
                var employees = context.Employees.OrderBy(e => e.Id).Take(5).ToList();
                var tasks = context.Tasks.OrderBy(t => t.Id).ToList();

                if (employees.Count >= 5 && tasks.Count >= 5)
                {
                    context.EmployeeTasks.AddOrUpdate(
                        et => new { et.EmployeeId, et.TaskId },
                        new EmployeeTask { EmployeeId = employees[0].Id, TaskId = tasks[0].Id },
                        new EmployeeTask { EmployeeId = employees[0].Id, TaskId = tasks[1].Id },
                        new EmployeeTask { EmployeeId = employees[1].Id, TaskId = tasks[1].Id },
                        new EmployeeTask { EmployeeId = employees[1].Id, TaskId = tasks[2].Id },
                        new EmployeeTask { EmployeeId = employees[2].Id, TaskId = tasks[2].Id },
                        new EmployeeTask { EmployeeId = employees[2].Id, TaskId = tasks[3].Id },
                        new EmployeeTask { EmployeeId = employees[3].Id, TaskId = tasks[3].Id },
                        new EmployeeTask { EmployeeId = employees[3].Id, TaskId = tasks[4].Id },
                        new EmployeeTask { EmployeeId = employees[4].Id, TaskId = tasks[0].Id },
                        new EmployeeTask { EmployeeId = employees[4].Id, TaskId = tasks[4].Id }
                    );

                    context.SaveChanges();
                }
            }

            if (!context.EmployeeSupplies.Any())
            {
                var employees = context.Employees.OrderBy(e => e.Id).ToList();
                var supplies = context.Supplies.OrderBy(s => s.Id).ToList();

                if (employees.Count >= 10 && supplies.Count >= 10)
                {
                    var baseDate = DateTime.Now.AddMonths(-6);

                    var employeeSupplies = new[]
                    {
                        new EmployeeSupply {
                            EmployeeId = employees[0].Id,
                            SupplyId = supplies[0].Id,
                            AssignedDate = baseDate.AddMonths(1),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[0].Id,
                            SupplyId = supplies[5].Id,
                            AssignedDate = baseDate.AddMonths(1),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[0].Id,
                            SupplyId = supplies[9].Id,
                            AssignedDate = baseDate.AddMonths(2),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[0].Id,
                            SupplyId = supplies[12].Id,
                            AssignedDate = baseDate.AddMonths(3),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[1].Id,
                            SupplyId = supplies[7].Id,
                            AssignedDate = baseDate.AddMonths(1),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[1].Id,
                            SupplyId = supplies[8].Id,
                            AssignedDate = baseDate.AddMonths(1),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[1].Id,
                            SupplyId = supplies[14].Id,
                            AssignedDate = baseDate.AddMonths(4),
                            Status = "Returned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[2].Id,
                            SupplyId = supplies[3].Id,
                            AssignedDate = baseDate.AddMonths(0),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[2].Id,
                            SupplyId = supplies[4].Id,
                            AssignedDate = baseDate.AddMonths(0),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[2].Id,
                            SupplyId = supplies[11].Id,
                            AssignedDate = baseDate.AddMonths(2),
                            Status = "Damaged"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[3].Id,
                            SupplyId = supplies[2].Id,
                            AssignedDate = baseDate.AddMonths(1),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[3].Id,
                            SupplyId = supplies[10].Id,
                            AssignedDate = baseDate.AddMonths(1),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[3].Id,
                            SupplyId = supplies[6].Id,
                            AssignedDate = baseDate.AddMonths(2),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[3].Id,
                            SupplyId = supplies[13].Id,
                            AssignedDate = baseDate.AddMonths(2),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[4].Id,
                            SupplyId = supplies[7].Id,
                            AssignedDate = baseDate.AddMonths(3),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[4].Id,
                            SupplyId = supplies[8].Id,
                            AssignedDate = baseDate.AddMonths(3),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[5].Id,
                            SupplyId = supplies[1].Id,
                            AssignedDate = baseDate.AddMonths(4),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[5].Id,
                            SupplyId = supplies[5].Id,
                            AssignedDate = baseDate.AddMonths(4),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[6].Id,
                            SupplyId = supplies[3].Id,
                            AssignedDate = baseDate.AddMonths(5),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[7].Id,
                            SupplyId = supplies[0].Id,
                            AssignedDate = baseDate.AddMonths(2),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[7].Id,
                            SupplyId = supplies[12].Id,
                            AssignedDate = baseDate.AddMonths(2),
                            Status = "Returned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[8].Id,
                            SupplyId = supplies[1].Id,
                            AssignedDate = baseDate.AddMonths(3),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[8].Id,
                            SupplyId = supplies[9].Id,
                            AssignedDate = baseDate.AddMonths(3),
                            Status = "Assigned"
                        },
                        new EmployeeSupply {
                            EmployeeId = employees[9].Id,
                            SupplyId = supplies[15].Id,
                            AssignedDate = baseDate.AddMonths(5),
                            Status = "Assigned"
                        }
                    };

                    foreach (var item in employeeSupplies)
                    {
                        context.EmployeeSupplies.AddOrUpdate(
                            x => new { x.EmployeeId, x.SupplyId },
                            item
                        );
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}