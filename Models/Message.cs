using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.Models
{
    public class Message : IMessage
    {
        public int Id { get ; set ; }
        public string Subject { get  ; set ; }
        public string Content { get  ; set ; }
        public string Author { get  ; set ; }
        public DateTime SentAt { get ; set ; }

        /*
         * Get data
         */
        public Message(int id, string subject, string content, string author, DateTime sentAt)
        {
            this.Id = id;
            this.Subject = subject;
            this.Content = content;
            this.Author = author;
            this.SentAt = sentAt;
        }

        /*
         * insert database
         */
        public Message(string subject, string content, string author, DateTime sentAt)
        {
            this.Id = 0;
            this.Subject = subject;
            this.Content = content;
            this.Author = author;
            this.SentAt = sentAt;
        }
    }
}
