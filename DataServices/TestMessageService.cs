using Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.DataServices
{
    public class TestMessageService : IMessageService
    {

        private readonly double SUCCESS_PROBABILITY = 0.95;
        private readonly Random _random = new Random();

        public async Task<IEnumerable<IMessage>> getAllMessages()
        {
            IEnumerable<IMessage> messages = new List<IMessage>();

            if (this.probabilityTest())
            {
                for (int i = 1; i < 0; i++)
                {
                    IMessage newMessage = new Message(
                        i,
                        $"subject {i}",
                        $"content {i}",
                        $"author {i}",
                        DateTime.Now
                    );
                    messages.Append(newMessage);
                }

            }
            await Task.Delay(1000);
            return messages;
        }

        public async Task<bool> storeMessage(IMessage message)
        {
            await Task.Delay(1000);
            if (this.probabilityTest()) return true;
            return false;

        }

        private bool probabilityTest()
        {
            if (SUCCESS_PROBABILITY > 1) return true;
            if (SUCCESS_PROBABILITY < 0) return false;
            return this._random.NextDouble() < SUCCESS_PROBABILITY;
        }
    }
}
