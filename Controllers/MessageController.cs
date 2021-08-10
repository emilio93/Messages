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
         */
        [HttpGet]
        public async Task<IEnumerable<IMessage>> GetAllMessages()
        {
            _logger.LogInformation($"GetAllMessages() started at {DateTime.Now}");
            IEnumerable<IMessage> messages = await _messageService.GetAllMessages();
            _logger.LogInformation($"GetAllMessages() finished at {DateTime.Now}");
            return messages;
        }

        /**
         * Process a post request and returns a success or failure response.
         * On success returns a 200 response, else a 503 response.
         */
        [HttpPost]
        public virtual async Task<ActionResult<Message>> CreateMessage(Message message)
        {
            _logger.LogInformation($"CreateMessage() started at {DateTime.Now}");
            bool storeResult = await this._messageService.StoreMessage(message);
            _logger.LogInformation($"CreateMessage() finished at {DateTime.Now}");
            if (storeResult) return StatusCode(200);
            return StatusCode(503);
        }
    }
}
