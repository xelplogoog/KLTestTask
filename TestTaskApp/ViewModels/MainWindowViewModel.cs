

namespace TestTaskApp.ViewModels
{
    using System.Threading;
    using Models;
    using System.Windows.Input;
    using TestTaskApp.Services;
    using System.ComponentModel;

    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private IQueueManager queueManager;

        public MainWindowViewModel(IQueueManager queueManager)
        {
            this.queueManager = queueManager;
        }

        #region Implement INotyfyPropertyChanged members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public int MessagesCount
        {
            get { return this.queueManager.Count; }
        }

        public ICommand PushMsgToQueue
        {
            get
            {
                return new Command(_ =>
                {
                    this.queueManager.Push(new Message(Thread.CurrentThread.ManagedThreadId.ToString()));
                    OnPropertyChanged("MessagesCount");
                });
            }
        }
    }
}
