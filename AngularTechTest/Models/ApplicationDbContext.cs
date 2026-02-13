using System.Data.Entity;
using AngularTechTest.Models;
using static System.Data.Entity.Migrations.Model.UpdateDatabaseOperation;

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
    }
}