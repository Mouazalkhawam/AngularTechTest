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

            if (!context.EmployeeTasks.Any())
            {
              
                var employees = context.Employees.OrderBy(e => e.Id).Take(5).ToList();

           
                var tasks = context.Tasks.OrderBy(t => t.Id).ToList();

                if (employees.Count == 5 && tasks.Count == 5)
                {
                    
                    context.EmployeeTasks.AddOrUpdate(
                        et => new { et.EmployeeId, et.TaskId },
                        new EmployeeTask { EmployeeId = employees[0].Id, TaskId = tasks[0].Id },
                        new EmployeeTask { EmployeeId = employees[0].Id, TaskId = tasks[1].Id }
                    );

                    context.EmployeeTasks.AddOrUpdate(
                        et => new { et.EmployeeId, et.TaskId },
                        new EmployeeTask { EmployeeId = employees[1].Id, TaskId = tasks[1].Id },
                        new EmployeeTask { EmployeeId = employees[1].Id, TaskId = tasks[2].Id }
                    );

                    context.EmployeeTasks.AddOrUpdate(
                        et => new { et.EmployeeId, et.TaskId },
                        new EmployeeTask { EmployeeId = employees[2].Id, TaskId = tasks[2].Id },
                        new EmployeeTask { EmployeeId = employees[2].Id, TaskId = tasks[3].Id }
                    );

        
                    context.EmployeeTasks.AddOrUpdate(
                        et => new { et.EmployeeId, et.TaskId },
                        new EmployeeTask { EmployeeId = employees[3].Id, TaskId = tasks[3].Id },
                        new EmployeeTask { EmployeeId = employees[3].Id, TaskId = tasks[4].Id }
                    );

                    
                    context.EmployeeTasks.AddOrUpdate(
                        et => new { et.EmployeeId, et.TaskId },
                        new EmployeeTask { EmployeeId = employees[4].Id, TaskId = tasks[0].Id },
                        new EmployeeTask { EmployeeId = employees[4].Id, TaskId = tasks[4].Id }
                    );

                    context.SaveChanges();
                }
            }

           
        }
    }
}