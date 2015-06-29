namespace ManagementSystem.Data
{
    using ManagementSystem.Data.Repositories;
    using ManagementSystem.Models;

    public interface IManagementSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Task> Tasks { get; }

        IRepository<Comment> Comments { get; }

        int SaveChanges();
    }
}
