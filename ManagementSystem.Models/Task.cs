namespace ManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ManagementSystem.Common;

    public class Task
    {
        private ICollection<User> users;

        private ICollection<Comment> comments;

        public Task()
        {
            this.users = new HashSet<User>();
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }

        [Required]
        public TaskType TaskType { get; set; }

        public DateTime NextActionDate { get; set; }

        public virtual ICollection<User> AssignedToUsers
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        } 
    }
}