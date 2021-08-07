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
        public Task<DataTable> getAllMessages();
        public Task<bool> StoreMessage(IMessage message);
    }
}
