using System.ComponentModel.DataAnnotations;

namespace BuildMonitor.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageDetail { get; set; }

        public virtual Feature Feature { get; set; }
    }
}