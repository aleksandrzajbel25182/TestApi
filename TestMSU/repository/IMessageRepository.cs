using TestMSU.database.enitity;

namespace TestMSU.repository
{
    public interface IMessageRepository : IRepositoryBase<Message>
    {
        Task<IEnumerable<Message>> GetMessagesBySender(string sender);
        Task<IEnumerable<Message>> GetMessagesByPeriod(DateTime startDate, DateTime endDate);
    }
}
