using DomainLayer.Models.Task;
using Ical.Net.CalendarComponents;
using Ical.Net.Proxies;
using ServiceLayer.Services.TaskServices;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Task
{
    public class TaskDbRepository : BaseSpecificRepository, ITaskRepository
    {
        public TaskDbRepository()
        {

        }

        public TaskDbRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IUniqueComponentList<CalendarEvent> GetAll()

        {
            List<TaskModel> taskModelList = new List<TaskModel>();

            using (SQLiteConnection sqLiteConnection = new SQLiteConnection(_connectionString))
            {
                try
                {
                    string sql = "SELECT * FROM Tasks";
                    sqLiteConnection.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(sql, sqLiteConnection))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                TaskModel taskModel = new TaskModel();
                                taskModel.Description = reader["Description"].ToString();
                                // blabla
                                // 9 minuta, 44 sekunda

                                taskModelList.Add(taskModel);
                            }
                        }

                        sqLiteConnection.Close();
                    }
                }
                catch (SQLiteException e)
                {

                }
            }

            return null;
        }

        public void Add(Ical.Net.CalendarComponents.RecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }

        public void Update(Ical.Net.CalendarComponents.RecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Ical.Net.CalendarComponents.RecurringComponent taskModel)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int taskModelId)
        {
            throw new NotImplementedException();
        }
        public IUniqueComponentList<CalendarEvent> GetByMonth(DateTime month)
        {
            throw new NotImplementedException();
        }

        public IUniqueComponentList<CalendarEvent> GetByCreationDate(DateTime creationDate)
        {
            throw new NotImplementedException();
        }

        IUniqueComponentList<CalendarEvent> ITaskRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        IUniqueComponentList<CalendarEvent> ITaskRepository.GetByMonth(DateTime month)
        {
            throw new NotImplementedException();
        }
    }
}
