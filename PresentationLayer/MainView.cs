using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public void ShowMainView()
        {
            Show();
        }
    }
}
