using Messages.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.DataServices
{
    public interface IDBService
    {
        /**
         * Obtains all the records within the messages table in the
         * database.
         */
        public Task<DataTable> GetAllMessages();

        /**
         * Inserts a new record within the messages table in the
         * database.
         */
        public Task<bool> StoreMessage(IMessage message);
    }
}
