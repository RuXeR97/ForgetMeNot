using System;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _mainView;
        public event EventHandler TaskDetailViewBindingDoneEventRaised;
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
        }

        public IMainView GetMainView()
        {
            return _mainView;
        }
    }
}
