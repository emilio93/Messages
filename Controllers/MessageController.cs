using Messages.DataServices;
using Messages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Messages.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        [HttpGet]
        public IEnumerable<IMessage> Get()
        {
            IMessageService messageService = null; // new MessageService()
            IEnumerable<IMessage> messages = messageService.getAllMessages();

            return messages;
        }

        /**
         * Process a post request and returns a success or failure response.
         */
        [HttpPost]
        public IEnumerable<IMessage> Post()
        {
            // Research how to get params from the http request data.
            // String author = request.getParam('Author');
            // ...
            // Research how to convert string to date.
            IMessage newMessage = null; // new Message(author, subject, ..., )

            IMessageService messageService = null; // new MessageService()
            messageService.storeMessage(newMessage);

            return null;
        }
    }
}
