

namespace TestTaskApp.Services
{
    using Models;
    using System.Collections.Generic;
    using System.Threading;

    public class QueueManager : IQueueManager
    {
        private readonly Queue<Message> messages;
        private readonly object lockObject = new object();

        public QueueManager()
        {
            this.messages = new Queue<Message>();
        }

        public void Push(Message msg)
        {
            lock (lockObject)
            {
                this.messages.Enqueue(msg);
                Monitor.Pulse(lockObject);
            }
            
        }

        public Message Pop()
        {
            lock (lockObject)
            {
                while (messages.Count == 0)
                {
                    Monitor.Wait(lockObject);
                }

                return messages.Dequeue();
            }
        }

        public void Clear()
        {
            lock (lockObject)
            {
                this.messages.Clear();
            }
        }

        public int Count
        {
            get
            {
                lock (lockObject)
                {
                    return this.messages.Count;
                }
            }
        }
    }
}
