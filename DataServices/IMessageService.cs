using Messages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.DataServices
{
    /**
     * This interface connects with the adequate storage servide to retrieve 
     * and store messages.
     */
    public interface IMessageService
    {
        /**
         * Gets all the stored messages from the adequate storage service.
         */
        Task<IEnumerable<IMessage>> getAllMessages();

        /**
         * Stores an IMessage representation in the adequate storage
         * service.
         */
        Task<bool> storeMessage(IMessage message);
    }
}