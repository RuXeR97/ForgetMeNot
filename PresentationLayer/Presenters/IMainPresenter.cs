using System;

namespace PresentationLayer.Presenters
{
    public interface IMainPresenter
    {
        DateTime CurrentDate { get; set; }
        IMainView GetMainView();
    }
}