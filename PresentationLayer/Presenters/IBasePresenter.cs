namespace PresentationLayer.Presenters
{
    public interface IBasePresenter
    {
        void ShowErrorMessage(string windowTitle, string errorMessage);
    }
}