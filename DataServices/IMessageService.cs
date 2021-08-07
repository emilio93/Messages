using Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.DataServices
{
    /**
     * This interface connects with the database to retrieve and store
     * messages.
     */
    public interface IMessageService
    {
        Task<IEnumerable<IMessage>> getAllMessages();

        Task<bool> storeMessage(IMessage message);
    }

}