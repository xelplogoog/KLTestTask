

namespace TestTaskApp.ViewModels
{
    using TestTaskApp.Services;

    public class MainWindowViewModel : IMainWindowViewModel
    {
        private IQueueManager queueManager;

        public MainWindowViewModel(IQueueManager queueManager)
        {
            this.queueManager = queueManager;
        }

        public int MessagesCount
        {
            get { return this.queueManager.Count; }
        }
    }
}
