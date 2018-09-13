using System;

namespace DomainLayer.Models.Task
{
    public interface ITaskModel
    {
        string Description { get; set; }
        DateTime EndTime { get; set; }
        DateTime StartTime { get; set; }
        int TaskId { get; set; }
        DateTime TimeOfCreation { get; set; }
        string Title { get; set; }
    }
}