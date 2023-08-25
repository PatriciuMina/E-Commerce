using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using E_Commerce.Models;

namespace E_commerce
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EcommerceDatabase"].ConnectionString;
        }

        public IEnumerable<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Orders";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Order order = MapOrderFromReader(reader);
                            orders.Add(order);
                        }
                    }
                }
            }
            return orders;
        }

        public Order GetOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Orders WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapOrderFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Order AddOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Orders (User_ID, Date, Total, Address_Id) VALUES (@User_ID, @Date, @Total, @Address_Id); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_ID", order.User_ID);
                    command.Parameters.AddWithValue("@Date", order.Date);
                    command.Parameters.AddWithValue("@Total", order.Total);
                    command.Parameters.AddWithValue("@Address_Id", order.Address_Id);

                    connection.Open();
                    int newOrderId = Convert.ToInt32(command.ExecuteScalar());
                    order.Id = newOrderId;
                    return order;
                }
            }
        }

        public void DeleteOrder(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Orders WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Orders SET User_ID = @User_ID, Date = @Date, Total = @Total, Address_Id = @Address_Id WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", order.Id);
                    command.Parameters.AddWithValue("@User_ID", order.User_ID);
                    command.Parameters.AddWithValue("@Date", order.Date);
                    command.Parameters.AddWithValue("@Total", order.Total);
                    command.Parameters.AddWithValue("@Address_Id", order.Address_Id);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private Order MapOrderFromReader(SqlDataReader reader)
        {
            return new Order
            {
                Id = (int)reader["Id"],
                User_ID = (int)reader["User_ID"],
                Date = (DateTime)reader["Date"],
                Total = (decimal)reader["Total"],
                Address_Id = (int)reader["Address_Id"]
            };
        }
    }
}