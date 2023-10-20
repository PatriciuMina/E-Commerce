using E_Commerce.Models;
using E_Commerce.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace E_Commerce.Controllers
{
    public class MessageController : ApiController
    {
        static readonly MessageRepository messageRepository = new MessageRepository();

        public IEnumerable<Message> GetMessagesFromAConversation(string sender_Id, string receiver_Id)
        {
            return messageRepository.GetMessagesFromAConversation(sender_Id, receiver_Id);
        }

        public Message SendMessage(Message message)
        {
            message = messageRepository.SendMessage(message);
            return message;
        }
    }
}
