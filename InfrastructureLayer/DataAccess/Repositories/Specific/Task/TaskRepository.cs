using DomainLayer.Models.Task;
using System.Collections.Generic;
using System.Data.SQLite;

namespace InfrastructureLayer.DataAccess.Repositories.Specific.Task
{
    public class TaskRepository
    {
        private string _connectionString;
        enum TypeOfExistence
        {
            DoesExistInDb,
            DOesNotExistInDb
        }

        enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelete
        }

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

    }
}
