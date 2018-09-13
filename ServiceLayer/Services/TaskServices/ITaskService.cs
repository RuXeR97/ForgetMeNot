using DomainLayer.Models.Task;

namespace ServiceLayer.Services.TaskServices
{
    interface ITaskService
    {
        void ValidateModel(ITaskModel taskModel);
        void ValidateModelDataAnnotations(ITaskModel taskModel);
        void ValidateTaskTimeOfCreation(ITaskModel taskModel);
    }
}
