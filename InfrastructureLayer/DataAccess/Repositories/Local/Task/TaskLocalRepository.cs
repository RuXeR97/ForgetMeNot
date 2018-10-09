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
            List<TaskModel> lol2 = new List<TaskModel>();
            TaskModel taskModel2 = new TaskModel()
            {
                TaskId = 2,
                Description = "Test Description 2",
                StartTime = DateTime.Now.AddHours(-5),
                EndTime = DateTime.Now.AddHours(0),
                Title = "Test Task 2"
            };

            TaskModel taskModel3 = new TaskModel()
            {
                TaskId = 3,
                Description = "Test Description 3",
                StartTime = DateTime.Now.AddHours(-3),
                EndTime = DateTime.Now.AddHours(1),
                Title = "Test Task 3"
            };
            mod.Add(taskModel2);
            mod.Add(taskModel3);

            File.WriteAllText(path, JsonConvert.SerializeObject(mod.GetAll(), Formatting.Indented));
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

        public Dictionary<DateTime, List<TaskModel>> GetAll()
        {
            string input = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Dictionary<DateTime, List<TaskModel>>>(input);
        }

        public Dictionary<DateTime, List<TaskModel>> GetByCreationDate(DateTime creationDate)
        {
            var taskModels = GetAll().Where(i => i.Key.Day == creationDate.Day &&
            i.Key.Month == creationDate.Month &&
            i.Key.Year == creationDate.Year);
            return (Dictionary<DateTime, List<TaskModel>>)taskModels;
        }

        public ITaskModel GetById(int id)
        {
            return (TaskModel)GetAll().Select(i => i.Value.First(j => j.TaskId == id));
        }

        public Dictionary<DateTime, List<TaskModel>> GetByMonth(DateTime date)
        {
            var taskModels = GetAll();

            var taskModelsReturned = new Dictionary<DateTime, List<TaskModel>>();
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
