using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repositories
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetMessagesFromAConversation(string sender_Id, string receiver_Id);
        Message SendMessage(Message message);
    }
}