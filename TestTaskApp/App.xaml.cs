

namespace TestTaskApp
{
    using Microsoft.Practices.Unity;
    using Services;
    using System.Windows;
    using TestTaskApp.ViewModels;
    using TestTaskApp.Views;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var container = new UnityContainer();
            container.RegisterType<IQueueManager, QueueManager>(
                new ContainerControlledLifetimeManager());
            container.RegisterType<IMainWindowViewModel, MainWindowViewModel>();

            var mainWindow = new MainWindow
            {
                DataContext = container.Resolve<IMainWindowViewModel>()
            };

            MainWindow.Show();
        }
    }
}
