using Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.DataServices
{
    public class TestMessageService : IMessageService
    {
        /**
         * Probability of get and store methods to succed.
         */
        private readonly double SUCCESS_PROBABILITY = 0.95;

        /**
         * Random object to generate random numbers.
         */
        private readonly Random _random = new Random();

        /**
         * Default constructor indicates the instantiation of the 
         * object.
         */
        public TestMessageService()
        {
            Console.WriteLine("TestMessageService Instantiated.");
        }

        /**
         * Returns a list of predefined IMessage items.
         */
        public async Task<IEnumerable<IMessage>> GetAllMessages()
        {
            IList<IMessage> messages = new List<IMessage>();
            if (this.ProbabilityTest())
            {
                for (int i = 1; i < 10; i++)
                {
                    IMessage newMessage = new Message(
                        i,
                        $"subject {i}",
                        $"content {i}",
                        $"author {i}",
                        DateTime.Now
                    );
                    messages.Add(newMessage);
                }

            }
            await Task.Delay(1000);
            return messages;
        }

        /**
         * Being a test class, the storage service is dummy 
         * and doesn't store the IMessage anywhere.
         */
        public async Task<bool> StoreMessage(IMessage message)
        {
            await Task.Delay(1000);
            if (this.ProbabilityTest()) return true;
            return false;

        }

        /**
         * Returns true or false depending on SUCCESS_PROBABILITY.
         * For example, if SUCCESS_PROBABILITY IS 0.6, 3 out of 5 
         * times, the result will be true,
         */
        private bool ProbabilityTest()
        {
            if (SUCCESS_PROBABILITY > 1) return true;
            if (SUCCESS_PROBABILITY < 0) return false;
            return this._random.NextDouble() < SUCCESS_PROBABILITY;
        }
    }
}
