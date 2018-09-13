using System;
using System.ComponentModel.DataAnnotations;

namespace DomainLayer.Models.Task
{
    public class TaskModel : ITaskModel
    {
        // https://www.completecsharptutorial.com/asp-net-mvc5/data-annotation-validation-with-example-in-asp-net-mvc.php
        public int TaskId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id is required!")]

        public DateTime TimeOfCreation { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Your string has to have between 1 and 30 characters")]
        //[RegularExpression()] poczytaj i dodaj odpowiednie regular expressiony
        public string Description { get; set; }
    }
}
