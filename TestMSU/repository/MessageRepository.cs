using TestMSU.database.enitity;
using TestMSU.database;
using Microsoft.EntityFrameworkCore;

namespace TestMSU.repository
{
    public class MessageRepository : IMessageRepository
    {
        private MessageContext _messageContext;
        public MessageRepository(MessageContext messageContext)
        {
            _messageContext = messageContext;
        }

        public async Task Add(Message entity)
        {
            _messageContext.Messages.Add(entity);
            await _messageContext.SaveChangesAsync();
        }

        public async Task Delete(Message entity)
        {
            _messageContext.Messages.Remove(entity);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            return await _messageContext.Messages.ToListAsync();
        }

        public async Task Update(Message entity)
        {
            _messageContext.Messages.Update(entity);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Message>> GetMessagesBySender(string sender)
        {
            return _messageContext.Messages.Where(m => m.Sender == sender);
        }

        public async Task<IEnumerable<Message>> GetMessagesByPeriod(DateTime startDate, DateTime endDate)
        {
            return _messageContext.Messages.Where(m => m.DateTime >= startDate && m.DateTime <= endDate);
        }

    }
}
