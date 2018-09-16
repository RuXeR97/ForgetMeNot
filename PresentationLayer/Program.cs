using PresentationLayer.Presenters;
using PresentationLayer.Views;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace PresentationLayer
{

    static class Program
    {
        [STAThread]
        static void Main()
        {
            IUnityContainer UnityC;

            string connectionString = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                @"\ForgetMeNot\nazwa;Version = 3";
            UnityC = new UnityContainer()
                .RegisterType<IMainView, MainView>(new ContainerControlledLifetimeManager())
                .RegisterType<IMainPresenter, MainPresenter>(new ContainerControlledLifetimeManager())
                .RegisterType<IErrorMessageView, ErrorMessageView>(new ContainerControlledLifetimeManager());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IMainPresenter mainPresenter = UnityC.Resolve<MainPresenter>();
            IMainView mainView = mainPresenter.GetMainView();


            Application.Run((MainView)mainView);
        }
    }
}
