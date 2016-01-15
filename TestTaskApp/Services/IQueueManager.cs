

namespace TestTaskApp.Services
{
    using TestTaskApp.Models;

    public interface IQueueManager
    {
        int Count { get; }

        void Push(Message msg);

        Message Pop();
    }
}
