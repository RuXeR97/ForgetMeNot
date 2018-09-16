using System;
using System.Windows.Forms;

namespace PresentationLayer
{
    public interface IMainView
    {
        Button[] InitializeDays(DateTime currentDate, int width, int height, int sizeX, int sizeY);
        void ShowMainView();
    }
}