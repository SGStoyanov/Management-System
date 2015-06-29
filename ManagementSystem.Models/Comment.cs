using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public CommentType Type { get; set; }

        public DateTime ReminderDate { get; set; }

        [Required]
        public int TaskId { get; set; }

        public virtual Task Task { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}