using PresentationLayer.Views.UserControls;

namespace PresentationLayer.Presenters
{
    public interface IAddEventPresenter
    {
        IAddEventView GetAddEventView();
        void ShowAddEventView();
    }
}