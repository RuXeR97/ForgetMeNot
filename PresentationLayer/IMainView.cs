using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public interface IMainView
    {
        event MouseEventHandler MainViewMouseUpEventRaised;
        event MouseEventHandler MainViewMouseDownEventRaised;
        event MouseEventHandler MainViewMouseMoveEventRaised;
        event MouseEventHandler ButtonOfArrowRightMouseDownEventRaised;
        event MouseEventHandler ButtonOfArrowLeftMouseDownEventRaised;
        Button[] InitializeDays(DateTime currentDate, int width, int height, int sizeX, int sizeY);
        void ShowMainView();
    }
}