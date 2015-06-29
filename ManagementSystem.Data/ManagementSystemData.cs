namespace ManagementSystem.Data
{
    using System;
    using System.Collections.Generic;

    using ManagementSystem.Data.Repositories;
    using ManagementSystem.Models;

    public class ManagementSystemData : IManagementSystemData
    {
        private IManagementSystemDbContext context;
        private IDictionary<Type, object> repositories;

        public ManagementSystemData(IManagementSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Task> Tasks
        {
            get { return this.GetRepository<Task>(); }
        }


        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(GenericRepository<T>);
                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}