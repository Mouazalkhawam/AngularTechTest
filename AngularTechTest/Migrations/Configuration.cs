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
            // هذا مثل Seeder في Laravel
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
        }
    }
}