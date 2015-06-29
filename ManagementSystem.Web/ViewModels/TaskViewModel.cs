namespace ManagementSystem.Web.ViewModels
{
    using System;

    using ManagementSystem.Common.Mappings;
    using ManagementSystem.Models;

    public class TaskViewModel : IMapFrom<Task>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }

        public TaskType TaskType { get; set; }

        public DateTime NextActionDate { get; set; }

        //public virtual IEnumerable<User> AssignedToUsers { get; set; }

        //public virtual IEnumerable<Comment> Comments { get; set; }
    }
}