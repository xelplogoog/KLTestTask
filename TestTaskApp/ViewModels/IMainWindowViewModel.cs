
namespace TestTaskApp.ViewModels
{
    using System.Windows.Input;

    public interface IMainWindowViewModel
    {
        int MessagesCount { get; }

        string PoppedMessage { get; }

        ICommand PushMsgToQueueCmd { get; }

        ICommand PushMsgToQueueAsyncCmd { get; }

        ICommand PopMsdCmd { get; }

        ICommand ClearCmd { get; }
    }
}
