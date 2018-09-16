namespace InfrastructureLayer.DataAccess.Repositories.Specific
{
    public abstract class BaseSpecificRepository
    {
        protected string _connectionString;

        public enum TypeOfExistenceCheck
        {
            DoesExistInDB,
            DoesNotExistInDB
        }
        public enum RequestType
        {
            Add,
            Update,
            Read,
            Delete,
            ConfirmAdd,
            ConfirmDelete
        }
    }
}
