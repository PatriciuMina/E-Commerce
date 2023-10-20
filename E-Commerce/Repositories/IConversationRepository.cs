using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Commerce.Repositories
{
    public interface IConversationRepository
    {
        IEnumerable<Conversation> GetMyConversations(string userId);
        Conversation StartConversation(Conversation conversation);
        bool VerifyExistingConversation(string userId1, string userId2);
    }
}