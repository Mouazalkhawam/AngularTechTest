using System.Data.Entity;
using AngularTechTest.Models;

namespace AngularTechTest.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext,
                Migrations.Configuration>());
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }                
        public DbSet<EmployeeTask> EmployeeTasks { get; set; } 
    }
}