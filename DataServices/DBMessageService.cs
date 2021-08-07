using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Messages.Models;

namespace Messages.DataServices
{
    public class DBMessageService : IMessageService
    {
        /**
         * The database service object.
         */
        private IDBService _db;

        /**
         * Sets the database service object to the provided one.
         */
        public DBMessageService(IDBService db)
        {
            this._db = db;
        }

        /**
         * Request all messages from the database service.
         */
        public async Task<IEnumerable<IMessage>> getAllMessages()
        {
            DataTable table = await this._db.getAllMessages();
            IList<IMessage> messages = new List<IMessage>();
            foreach (DataRow row in table.Rows)
            {
                IMessage message = new Message(
                    Convert.ToInt32(row["idmessages"]),
                    row["author"].ToString(),
                    row["subject"].ToString(),
                    row["content"].ToString(),
                    DateTime.Now
                );
                messages.Add(message);
            }

            return messages;
        }

        /**
         * Stores a message thru the database service.
         */
        public async Task<bool> storeMessage(IMessage message)
        {
            try
            {
                await this._db.StoreMessage(message);
            } catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}
