using Microsoft.AspNetCore.Mvc;
using TestMSU.database.enitity;
using TestMSU.service;

namespace TestMSU.Controllers
{
    [Route("api/message")]
    [ApiController]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetAllMessages()
        {
            var messages = await _messageService.GetAllMessages();
            if (messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        [HttpGet("{sender}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesBySender(string sender)
        {
            if (string.IsNullOrEmpty(sender))
            {
                return BadRequest("Sender cannot be empty");
            }

            var messages = await _messageService.GetMessagesBySender(sender);
            if (messages == null)
            {
                return NotFound();
            }
            return Ok(messages);
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessagesByPeriod(DateTime startDate, DateTime endDate)
        {
            if (startDate == default || endDate == default || startDate > endDate)
            {
                return BadRequest("Invalid date range");
            }

            var messages = await _messageService.GetMessagesByPeriod(startDate, endDate);
            if (messages == null)
            {
                return NotFound();
            }
            
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> AddMessage([FromBody] Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            await _messageService.AddMessage(message);
            return Ok();
        }
    }
}
