namespace TestMSU.database.enitity
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Sender { get; set; }
        public string Body { get; set; }
    }
}
