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
    interface IMessageService
    {
        IEnumerable<IMessage> getAllMessages();

        bool storeMessage(IMessage message);
    }

}
