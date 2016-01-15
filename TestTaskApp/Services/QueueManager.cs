

namespace TestTaskApp.Services
{
    using Models;
    using System.Collections.Generic;

    public class QueueManager : IQueueManager
    {
        private readonly Queue<Message> messages;

        public QueueManager()
        {
            this.messages = new Queue<Message>();
        }

        public void Push(Message msg)
        {
            this.messages.Enqueue(msg);
        }

        public Message Pop()
        {
            return null;
        }

        public int Count
        {
            get
            {
                return this.messages.Count;
            }
        }
    }
}
