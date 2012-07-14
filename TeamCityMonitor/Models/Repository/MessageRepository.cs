using System.Collections.Generic;
using System.Web;
using Simple.Data;

namespace BuildMonitor.Models.Repository
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessages();
        Message GetMessage(int messageId);
        Message GetMessage(string messageName);
        void Update(Message message);
        void Delete(Message message);
        void Create(Message message);
    }

    public class MessageRepository : IMessageRepository
    {
        private static dynamic GetDatabase()
        {
            var dbFile = HttpContext.Current.Server.MapPath("~/App_Data/ApplicationData.db");
            var db = Database.OpenFile(dbFile);

            return db;
        }

        public List<Message> GetAllMessages()
        {
            var messages = new List<Message>();
            var queryResponse = GetDatabase().Messages.All();
            foreach (var response in queryResponse)
            {
                messages.Add(new Message
                                 {
                                     MessageDetails = response.MessageDetails,
                                     MessageId =  response.MessageId,
                                     MessageImage = response.MessageImage,
                                     MessageName = response.MessageName
                                 });
            }
            return messages;
        }

        public Message GetMessage(int messageId)
        {
            return GetDatabase().Messages.FindByMessageId(messageId);
        }

        public Message GetMessage(string messageName)
        {
            return GetDatabase().Messages.FindByMessageName(messageName);
        }

        public void Create(Message message)
        {
            GetDatabase().Messages.Insert(MessageName: message.MessageName, MessageDetails: message.MessageDetails, MessageImage: message.MessageImage);
        }

        public void Update(Message message)
        {
            GetDatabase().Messages.Update(message);
        }

        public void Delete(Message message)
        {
            GetDatabase().Messages.Delete(Message: message.MessageId);
        }
    }
}