using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestMSU.database.enitity;

namespace TestMSU.database
{
    public class MessageContext : DbContext
    {
        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
    }
}
