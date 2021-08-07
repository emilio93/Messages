using Messages.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.DataServices
{
    public class DBService : IDBService
    {
        /**
         * Query to retrieve all the messages using a view.
         */
        private readonly string GET_QUERY = @"
            SELECT 
                * 
            FROM 
                messages_view;
        ";

        /**
         * Query to insert a new message using a stored procedure.
         */
        private readonly string POST_QUERY = $@"
            CALL insert_message_procedure(
                @author,
                @subject,
                @content,
                @sentAt
            );
        ";

        /**
         * MySqlConnection object, used to open and close connections to 
         * the database.
         */
        private MySqlConnection _mySqlConnection;

        /**
         * The constructor reads the connection string from the configuration and
         * initializes the MySqlConnection object.
         */
        public DBService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("MessagesDBConnection");
            this._mySqlConnection = new MySqlConnection(connectionString);
        }

        /**
         * Make sure the connection ends up closed upon object destruction 
         * and disposes the MySqlConnection object.
         */
        ~DBService()
        {
            this.CloseConnection();
            _mySqlConnection.Dispose();
        }
        
        /**
         * Obtains all the messages from the database.
         */
        public async Task<DataTable> getAllMessages()
        {
            DataTable table = new DataTable();
            this.OpenConnection();
            MySqlCommand command = new MySqlCommand(GET_QUERY, this._mySqlConnection);
            MySqlDataReader reader = command.ExecuteReader();
            table.Load(reader);
            reader.Close();
            this.CloseConnection();
            return table;
        }

        /**
         * Inserts a message in the database.
         */
        public async Task<bool> StoreMessage(IMessage message)
        {
            try
            {
                this.OpenConnection();
                MySqlCommand command = new MySqlCommand(POST_QUERY, this._mySqlConnection);
                command.Parameters.AddWithValue("@author", message.Author);
                command.Parameters.AddWithValue("@subject", message.Subject);
                command.Parameters.AddWithValue("@content", message.Content);
                command.Parameters.AddWithValue("@sentAt", message.SentAt);
                MySqlDataReader reader = command.ExecuteReader();
                reader.Close();
                this.CloseConnection();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        private void OpenConnection()
        {
            this._mySqlConnection.Open();
        }

        private void CloseConnection()
        {
            this._mySqlConnection.Close();
        }
    }
}
