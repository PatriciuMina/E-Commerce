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
    public class MessageRepository
    {
        private readonly string _connectionString;

        public MessageRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EcommerceDatabase"].ConnectionString;
        }

        public IEnumerable<Message> GetMessagesFromAConversation(string sender_Id, string receiver_Id)
        {
            List<Message> messages = new List<Message>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Messages WHERE (Sender_Id = @Sender_Id AND Receiver_Id = @Receiver_Id) OR (Sender_Id = @Receiver_Id AND Receiver_Id = @Sender_Id)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Sender_Id", sender_Id);
                    command.Parameters.AddWithValue("@Receiver_Id", receiver_Id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Message message = MapMessageFromReader(reader);
                            messages.Add(message);
                        }
                    }
                }
            }
            return messages;
        }

        public Message SendMessage(Message message)
        {
            DateTime time = DateTime.Now;
            message.Created_At = time;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Messages (Sender_Id, Receiver_Id, Body, Created_At) VALUES (@Sender_Id, @Receiver_Id, @Body, @Created_At); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Sender_Id", message.Sender_Id);
                    command.Parameters.AddWithValue("@Receiver_Id", message.Receiver_Id);
                    command.Parameters.AddWithValue("@Body", message.Body);
                    command.Parameters.AddWithValue("@Created_At", message.Created_At);

                    connection.Open();
                    int newMessageId = Convert.ToInt32(command.ExecuteScalar());
                    message.Id = newMessageId;
                    return message;
                }
            }
        }

        private Message MapMessageFromReader(SqlDataReader reader)
        {
            DateTime Created_At;
            DateTime.TryParseExact(reader["Created_At"].ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Created_At);
            return new Message
            {
                Id = Convert.ToInt32(reader["Id"]),
                Sender_Id = reader["Sender_Id"].ToString(),
                Receiver_Id = reader["Receiver_Id"].ToString(),
                Body = reader["Body"].ToString(),
                Created_At = Created_At
            };
        }


    }
}