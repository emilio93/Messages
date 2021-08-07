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
        private readonly IMessageService _messageService;

        public MessageController(ILogger<MessageController> logger, IMessageService messageService)
        {
            _logger = logger;
            _messageService = messageService;
        }

        /**
         * Process a get request and returns an http response with all the available messages.
         * 
         */
        [HttpGet]
        public async Task<IEnumerable<IMessage>> GetAllMessages()
        {
            Console.WriteLine($"GetAllMessages() started at {DateTime.Now}");
            IEnumerable<IMessage> messages = await _messageService.getAllMessages();
            Console.WriteLine($"GetAllMessages() finished at {DateTime.Now}");
            return messages;
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
}
