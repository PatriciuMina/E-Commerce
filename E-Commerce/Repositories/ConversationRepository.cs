using E_Commerce.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;

namespace E_Commerce.Repositories
{
    public class ConversationRepository
    {
        private readonly string _connectionString;

        public ConversationRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EcommerceDatabase"].ConnectionString;
        }

        public IEnumerable<Conversation> GetMyConversations(string userId)
        {
            List<Conversation> conversations = new List<Conversation>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Conversations WHERE User_Id1= @userId OR User_Id2 = @userId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Conversation conversation = MapConversationFromReader(reader);
                            conversations.Add(conversation);
                        }
                    }
                }
            }
            return conversations;
        }

        public Conversation StartConversation(Conversation conversation)
        {
            DateTime time = DateTime.Now;
            conversation.Created_At = time;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Conversations (User_Id1, UserName1, User_Id2, UserName2, Created_At) VALUES (@User_Id1, @UserName1, @User_Id2, @UserName2, @Created_At); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_Id1", conversation.User_Id1);
                    command.Parameters.AddWithValue("@UserName1", conversation.UserName1);
                    command.Parameters.AddWithValue("@User_Id2", conversation.User_Id2);
                    command.Parameters.AddWithValue("@UserName2", conversation.UserName2);
                    command.Parameters.AddWithValue("@Created_At", conversation.Created_At);


                    connection.Open();
                    int newConversationId = Convert.ToInt32(command.ExecuteScalar());
                    conversation.Id = newConversationId;
                    return conversation;
                }
            }
        }

        public bool VerifyExistingConversation(string userId1, string userId2)
        {
            Conversation conversation =null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Conversations WHERE (User_Id1 = @userId1 AND User_Id2 = @userId2) OR (User_Id1 = @userId2 AND User_Id2 = @userId1)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId1", userId1);
                    command.Parameters.AddWithValue("@userId2", userId2);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            conversation = MapConversationFromReader(reader);
                        }
                    }
                }
            }
            if(conversation == null)
            {
                return true;
            }
            else
            {
                return false;
            }          
        }

        private Conversation MapConversationFromReader(SqlDataReader reader)
        {
            DateTime Created_At;
            DateTime.TryParseExact(reader["Created_At"].ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Created_At);
            return new Conversation
            {
                Id = Convert.ToInt32(reader["Id"]),
                User_Id1 = reader["User_Id1"].ToString(),
                UserName1 = reader["UserName1"].ToString(),
                User_Id2 = reader["User_Id2"].ToString(),
                UserName2 = reader["UserName2"].ToString(),             
                Created_At = Created_At
            };
        }
    }
}