using System;

namespace PresentationLayer.Presenters
{
    public class MainPresenter : IMainPresenter
    {
        private IMainView _mainView;
        public event EventHandler TaskDetailViewBindingDoneEventRaised;

        private readonly int width = -30;
        private readonly int height = 45;
        private readonly int sizeX = 30;
        private readonly int sizeY = 30;
        private const int countOfDaysInWeek = 7;
        public MainPresenter(IMainView mainView)
        {
            _mainView = mainView;
            _mainView.InitializeDays(DateTime.Now, width, height + sizeY / 2, sizeX, sizeY);
        }

        public IMainView GetMainView()
        {
            return _mainView;
        }


    }
}
