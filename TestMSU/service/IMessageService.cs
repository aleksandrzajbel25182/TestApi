using TestMSU.database.enitity;

namespace TestMSU.service
{
    public interface IMessageService
    {
        Task<IEnumerable<Message>> GetAllMessages();
        Task<IEnumerable<Message>> GetMessagesBySender(string sender);
        Task<IEnumerable<Message>> GetMessagesByPeriod(DateTime startDate, DateTime endDate);
        Task AddMessage(Message message);
    }
}