using Google.Apis.Requests;
using System;

namespace ServiceLayer.Services.TaskServices
{
    public interface ITaskService
    {
        void Add(IDirectResponseSchema taskModel);
        void Delete(IDirectResponseSchema taskModel);
        void DeleteById(int taskModelId);
        IDirectResponseSchema GetAllEvents();
        IDirectResponseSchema GetEventsByMonth(DateTime month);

        void ValidateModel(IDirectResponseSchema taskModel);
        void ValidateModelDataAnnotations(IDirectResponseSchema taskModel);
        void ValidateTaskTimeOfCreation(IDirectResponseSchema taskModel);
    }
}
