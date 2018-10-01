using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public interface IMainView
    {
        event MouseEventHandler ButtonOfArrowLeftMouseDownEventRaised;
        event MouseEventHandler ButtonOfArrowRightMouseDownEventRaised;

        Label[] InitializeDateLabels(int width, int height, int sizeX, int sizeY, DateTime date);
        Button[] InitializeDays(DateTime currentDate, int width, int height, int sizeX, int sizeY);
        Label[] InitializeLabelsOfDays(int countOfDaysInWeek, int width, int height, int sizeX);
        Button InitializeLeftArrow(int sizeX, int sizeY);
        Button InitializeRightArrow(int sizeX, int sizeY);
        void ShowMainView();
    }
}