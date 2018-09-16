using System;
using System.Windows.Forms;

namespace PresentationLayer.Views
{
    public partial class ErrorMessageView : Form, IErrorMessageView
    {
        public ErrorMessageView()
        {
            InitializeComponent();
        }

        public void ShowErrorMessageView(string windowTitle, string errorMessage)
        {
            this.Text = windowTitle;
            this.messageTextBox.Text = errorMessage;
            this.ShowDialog();
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (messageTextBox.Text != String.Empty)
            {
                Clipboard.SetText(messageTextBox.Text);
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
