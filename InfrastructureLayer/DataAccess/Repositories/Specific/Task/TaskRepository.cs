using DomainLayer.Models.Task;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Task
{
    public class TaskRepository : BaseSpecificRepository, ITaskRepository
    {
        public TaskRepository()
        {

        }

        public TaskRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<ITaskModel> GetAll()

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

            return taskModelList;
        }

        public void Add(ITaskModel taskModel)
        {
            throw new NotImplementedException();
        }

        public void Update(ITaskModel taskModel)
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

        public TaskModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public TaskModel GetByCreationDate(DateTime creationDate)
        {
            throw new NotImplementedException();
        }
    }
}
