using TestMSU.database.enitity;
using TestMSU.repository;

namespace TestMSU.service
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> GetAllMessages()
        {
            return await _messageRepository.GetAll();
        }

        public async Task<IEnumerable<Message>> GetMessagesBySender(string user)
        {
            return await _messageRepository.GetMessagesBySender(user);
        }

        public async Task<IEnumerable<Message>> GetMessagesByPeriod(DateTime startDate, DateTime endDate)
        {
            return await _messageRepository.GetMessagesByPeriod(startDate, endDate);
        }

        public async Task AddMessage(Message message)
        {
            await _messageRepository.Add(message);
        }
    }
}
