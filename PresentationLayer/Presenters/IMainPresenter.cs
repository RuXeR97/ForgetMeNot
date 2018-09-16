using System;

namespace PresentationLayer.Presenters
{
    public interface IMainPresenter
    {
        event EventHandler TaskDetailViewBindingDoneEventRaised;

        IMainView GetMainView();
    }
}