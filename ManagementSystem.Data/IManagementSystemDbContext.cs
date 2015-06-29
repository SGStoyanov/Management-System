namespace ManagementSystem.Data
{
    using System.Data.Entity;

    using ManagementSystem.Models;

    public interface IManagementSystemDbContext
    {
        IDbSet<User> Users { get; }

        IDbSet<Task> Tasks { get; }

        IDbSet<Comment> Comments { get; }

        int SaveChanges();
    }
}