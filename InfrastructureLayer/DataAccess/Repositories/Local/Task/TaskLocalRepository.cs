using DomainLayer.Models.Task;
using Newtonsoft.Json;
using ServiceLayer.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace InfrastructureLayer.DataAccess.Repositories.Local.Task
{
    public class TaskLocalRepository : ITaskRepository
    {
        private string path;
        private string fileName;

        public TaskLocalRepository(string userLogin)
        {
            fileName = userLogin + "Tasks.txt";

            // change later
            path = fileName;


            DomainLayer.Models.MonthTasks.IMonthTasksModel mod = new DomainLayer.Models.MonthTasks.MonthTasksModel();

            List<TaskModel> lol = new List<TaskModel>();
            lol.Add(new TaskModel()
            {
                TaskId = 1,
                Description = "asd",
                StartTime = DateTime.Now.AddHours(-3),
                EndTime = DateTime.Now.AddHours(1),
                Title = "LOLEK"
            });
            mod.PreviousMonthTasks = new SortedDictionary<DateTime, List<TaskModel>>();
            mod.PreviousMonthTasks.Add(DateTime.Now, lol);
            File.WriteAllText(path, JsonConvert.SerializeObject(mod.PreviousMonthTasks));
        }

        public void Add(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int taskModelId)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetAll()
        {
            string input = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<SortedDictionary<DateTime, List<TaskModel>>>(input);
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetByCreationDate(DateTime creationDate)
        {
            var taskModels = GetAll().Where(i => i.Key.Day == creationDate.Day &&
            i.Key.Month == creationDate.Month &&
            i.Key.Year == creationDate.Year);
            return (SortedDictionary<DateTime, List<TaskModel>>)taskModels;
        }

        public ITaskModel GetById(int id)
        {
            return (TaskModel)GetAll().Select(i => i.Value.First(j => j.TaskId == id));
        }

        public SortedDictionary<DateTime, List<TaskModel>> GetByMonth(DateTime date)
        {
            var taskModels = GetAll();

            var taskModelsReturned = new SortedDictionary<DateTime, List<TaskModel>>();
            foreach (var lol in taskModels)
            {
                taskModelsReturned.Add(lol.Key, lol.Value);
            }

            return taskModels;
        }

        public void Update(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }
    }
}
