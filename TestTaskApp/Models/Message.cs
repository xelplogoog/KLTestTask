

namespace TestTaskApp.Models
{
    public class Message
    {
        public Message(string msg)
        {
            this.Text = msg;
        }

        public string Text { get; private set; }
    }
}
