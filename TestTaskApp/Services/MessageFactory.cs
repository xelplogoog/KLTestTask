

namespace TestTaskApp.Services
{
    using System;
    using System.Threading;
    using TestTaskApp.Models;

    public class MessageFactory : IMessageFactory
    {
        public Message CreateMessage()
        {
            return new Message(
                string.Format(
                    "Message created by Thread#{0} at {1}",
                    Thread.CurrentThread.ManagedThreadId,
                    DateTime.Now));
        }
    }
}
