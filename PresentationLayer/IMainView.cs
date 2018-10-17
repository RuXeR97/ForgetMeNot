using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public interface IMainView
    {
        event MouseEventHandler ButtonOfArrowLeftMouseClickEventRaised;
        event MouseEventHandler ButtonOfArrowRightMouseClickEventRaised;
        event EventHandler AddEventToolStripButtonClickEventRaised;
        event EventHandler MainViewLoadEventRaised;
        event EventHandler MainViewFormClosingEventRaised;

        Label[] InitializeDateLabels(int width, int height, int sizeX, int sizeY, DateTime date);
        Button[] InitializeDays(DateTime currentDate, int width, int height, int sizeX, int sizeY);
        Label[] InitializeLabelsOWeekfDays(int countOfDaysInWeek, int width, int height, int sizeX);

        void InitializeToolTips(string[] text, int height = 400, int width = 160);
        void HighlightDaysButtonsWithTasks(string[] text);
        Button InitializeLeftArrow(int sizeX, int sizeY);
        Button InitializeRightArrow(int sizeX, int sizeY);
        void ShowMainView();
        void SetMenuPosition();
        void SaveMenuPosition();
    }
}