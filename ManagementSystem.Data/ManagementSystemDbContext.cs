namespace ManagementSystem.Data
{
    using System.Data.Entity;

    using ManagementSystem.Data.Migrations;
    using ManagementSystem.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ManagementSystemDbContext : IdentityDbContext<User>, IManagementSystemDbContext
    {
        public ManagementSystemDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ManagementSystemDbContext, Configuration>());
        }

        public static ManagementSystemDbContext Create()
        {
            return new ManagementSystemDbContext();
        }

        public IDbSet<Task> Tasks { get; set; }

        public IDbSet<Comment> Comments { get; set; } 
    }
}