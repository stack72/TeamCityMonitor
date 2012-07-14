namespace BuildMonitor.Models
{
    public class Message
    {
        public long MessageId { get; set; }
        public string MessageName { get; set; }
        public string MessageDetails { get; set; }
        public byte[] MessageImage { get; set; }
    }
}