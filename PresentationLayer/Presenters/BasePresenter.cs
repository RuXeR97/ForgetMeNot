using PresentationLayer.Views;

namespace PresentationLayer.Presenters
{
    public class BasePresenter : IBasePresenter
    {
        public IErrorMessageView _errorMessageView;
        public BasePresenter(IErrorMessageView errorMessageView)
        {
            _errorMessageView = errorMessageView;
        }

        public void ShowErrorMessage(string windowTitle, string errorMessage)
        {
            _errorMessageView.ShowErrorMessageView(windowTitle, errorMessage);
        }
    }
}
