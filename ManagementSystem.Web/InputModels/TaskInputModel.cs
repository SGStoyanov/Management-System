namespace ManagementSystem.Web.InputModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ManagementSystem.Common;
    using ManagementSystem.Common.Mappings;
    using ManagementSystem.Models;

    public class TaskInputModel : IMapTo<Task>
    {
        private ICollection<User> assignedToUsers;

        public TaskInputModel()
        {
            this.assignedToUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [StringLength(maximumLength: 200)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        public DateTime CreatedDate { get; set; }

        public Status Status { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = GlobalConstants.RequiredValidationMessage)]
        [Display(Name = "Task Type")]
        public TaskType TaskType { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Next Action Date")]
        public DateTime? NextActionDate { get; set; }

        [Display(Name = "Assign to User")]
        public ICollection<User> AssignedToUsers
        {
            get { return this.assignedToUsers; }
            set { this.assignedToUsers = value; }
        }
    }
}