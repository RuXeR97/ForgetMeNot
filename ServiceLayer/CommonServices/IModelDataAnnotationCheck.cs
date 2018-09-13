namespace ServiceLayer.CommonServices
{
    public interface IModelDataAnnotationCheck
    {
        void ValidateModelDataAnnotations<TTaskModel>(TTaskModel taskModel);
    }
}