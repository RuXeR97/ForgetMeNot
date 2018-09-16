using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Task
{
    public class TaskModel : ITaskModel
    {
        public int TaskId { get; set; }


        public DateTime TimeOfCreation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Task title is required")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Task title must be between 1 and 30 characters")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(100, ErrorMessage = "Task title must be below 100 characters")]
        public string Description { get; set; }
    }
}
