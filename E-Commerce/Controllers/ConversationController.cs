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
    public class ConversationController : ApiController
    {
        static readonly ConversationRepository conversationRepository = new ConversationRepository();

        public IEnumerable<Conversation> GetMyConversations(string userId)
        {
            return conversationRepository.GetMyConversations(userId);
        }

        public Conversation StartConversation(Conversation conversation)
        {
            conversation = conversationRepository.StartConversation(conversation);
            return conversation;
        }

        public bool VerifyExistingConversation(string userId1, string userId2)
        {
            return conversationRepository.VerifyExistingConversation(userId1, userId2);
        }
    }
}
