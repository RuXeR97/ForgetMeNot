using System;

namespace PresentationLayer.Presenters
{
    public interface IMainPresenter
    {
        event EventHandler TaskDetailViewBindingDoneEventRaised;
        DateTime CurrentDate { get; set; }

        IMainView GetMainView();
    }
}