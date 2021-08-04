using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.Models
{
    public interface IMessage
    {
        public int Id { get; set; }
        public String Subject { get; set; }
        public String Content { get; set; }
        public String Author { get; set; }
        public DateTime SentAt { get; set; }
    }
}
