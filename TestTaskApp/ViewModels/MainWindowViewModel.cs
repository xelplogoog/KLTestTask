

namespace TestTaskApp.ViewModels
{
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using TestTaskApp.Services;

    public class MainWindowViewModel : IMainWindowViewModel, INotifyPropertyChanged
    {
        private IQueueManager queueManager;
        private IMessageFactory messageFactory;

        public MainWindowViewModel(
            IQueueManager queueManager,
            IMessageFactory factory)
        {
            this.queueManager = queueManager;
            this.messageFactory = factory;

            this.PoppedMessage = string.Empty;
        }

        #region INotyfyPropertyChanged members

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

        public string PoppedMessage
        {
            get;
            private set;
        }

        #region Commands

        public ICommand PushMsgToQueueCmd
        {
            get
            {
                return new Command(_ =>
                {
                    this.queueManager.Push(this.messageFactory.CreateMessage());
                    OnPropertyChanged("MessagesCount");
                });
            }
        }

        public ICommand PushMsgToQueueAsyncCmd
        {
            get
            {
                return new Command(_ =>
                {
                    var tasks = new[]
                    {
                        new Task(() => {
                            for (var i = 0; i < 5; i++)
                            {
                                Thread.Sleep(200);
                                this.queueManager.Push(this.messageFactory.CreateMessage());
                                OnPropertyChanged("MessagesCount");
                            }
                        }),
                        new Task(() => {
                            for (var i = 0; i < 5; i++)
                            {
                                Thread.Sleep(100);
                                this.queueManager.Push(this.messageFactory.CreateMessage());
                                OnPropertyChanged("MessagesCount");
                            }
                        })
                    };

                    foreach (var task in tasks)
                    {
                        task.Start();
                    }
                });
            }
        }

        public ICommand PopMsdCmd
        {
            get
            {
                return new Command(_ =>
                {
                    new TaskFactory().StartNew(() =>
                    {
                        this.PoppedMessage = "Waiting for a message...";
                        OnPropertyChanged("PoppedMessage");

                        var msg = this.queueManager.Pop();
                        this.PoppedMessage = msg.Text;
                        OnPropertyChanged("PoppedMessage");
                        OnPropertyChanged("MessagesCount");
                    });
                });
            }
        }

        public ICommand ClearCmd
        {
            get
            {
                return new Command(_ =>
                {
                    this.queueManager.Clear();
                    OnPropertyChanged("MessagesCount");
                });
            }
        }

        #endregion
    }
}
