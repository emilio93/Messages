using Messages.DataServices;
using Messages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Messages.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        private readonly ILogger<MessageController> _logger;

        public MessageController(ILogger<MessageController> logger)
        {
            _logger = logger;
        }

        /**
         * Process a get request and returns an http response with all the available messages.
         * 
         */
        /*
        [HttpGet]
        public IEnumerable<IMessage> Get()
        {
            IMessageService messageService = null; // new MessageService()
            IEnumerable<IMessage> messages = messageService.getAllMessages();
            
            return messages;
        }
        */
        /*
        [HttpGet]
        public string Get()
        {
            List<Test> list = new List<Test>();
            list.Add(new Test("1", "Saludo", "Hola mundo", "Joy", "2021-08-04"));
            string a = JsonSerializer.Serialize(list);
            return a;
        }*/
        [HttpGet]
        public virtual ActionResult<IEnumerable<Message>> GetAllMessages()
        {
            var response = new List<Message>
            {
                new Message
                {
                    Id = 123,
                    Subject = "Nada",
                    Content = "Hola mundo", 
                    Author = "Joy",
                    SendAt = DateTime.Now
                },
                new Message
                {
                    Id = 321,
                    Subject = "Todo",
                    Content = "Hola mundo",
                    Author = "Joy",
                    SendAt = DateTime.Now
                }
            };

            return this.Ok(response);
        }

        /**
         * Process a post request and returns a success or failure response.
         */
        [HttpPost]
        public virtual ActionResult<Message> CreateMessage(Message message)
        {
            // Research how to get params from the http request data.
            // String author = request.getParam('Author');
            // ...
            // Research how to convert string to date.

            
            
            return this.NoContent();
        }
    }
    public class Message
    {
        public long Id { get; set; }
        public string Subject { get; set; }

        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime SendAt { get; set; }

    }

}
