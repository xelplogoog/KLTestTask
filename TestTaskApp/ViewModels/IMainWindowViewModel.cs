

using System.Windows.Input;

namespace TestTaskApp.ViewModels
{
    public interface IMainWindowViewModel
    {
        int MessagesCount { get; }

        ICommand PushMsgToQueue { get; } 
    }
}
