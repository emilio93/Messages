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

        public Message()
        {

        }
    }
}
