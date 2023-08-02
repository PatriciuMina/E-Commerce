using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace E_commerce
{
    public class AddressRepository : IAddressRepository
    {
        private readonly string _connectionString;

        public AddressRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EcommerceDatabase"].ConnectionString;
        }

        public IEnumerable<Address> GetAddresses()
        {
            List<Address> addresses = new List<Address>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Addresses";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Address address = MapAddressFromReader(reader);
                            addresses.Add(address);
                        }
                    }
                }
            }
            return addresses;
        }

        public Address GetAddress(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Addresses WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapAddressFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Address AddAddress(Address address)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Addresses (User_Id, Address_line1, Address_line2, City, Postal_code, Country, Region) VALUES (@User_Id, @Address_line1, @Address_line2, @City, @Postal_code, @Country, @Region); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_Id", address.User_Id);
                    command.Parameters.AddWithValue("@Address_line1", address.Address_line1);
                    command.Parameters.AddWithValue("@Address_line2", address.Address_line2);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@Postal_code", address.Postal_code);
                    command.Parameters.AddWithValue("@Country", address.Country);
                    command.Parameters.AddWithValue("@Region", address.Region);

                    connection.Open();
                    int newAddressId = Convert.ToInt32(command.ExecuteScalar());
                    address.Id = newAddressId;
                    return address;
                }
            }
        }

        public void DeleteAddress(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Addresses WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateAddress(Address address)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Addresses SET User_Id = @User_Id, Address_line1 = @Address_line1, Address_line2 = @Address_line2, City = @City, Postal_code = @Postal_code, Country = @Country, Region = @Region WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", address.Id);
                    command.Parameters.AddWithValue("@User_Id", address.User_Id);
                    command.Parameters.AddWithValue("@Address_line1", address.Address_line1);
                    command.Parameters.AddWithValue("@Address_line2", address.Address_line2);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@Postal_code", address.Postal_code);
                    command.Parameters.AddWithValue("@Country", address.Country);
                    command.Parameters.AddWithValue("@Region", address.Region);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private Address MapAddressFromReader(SqlDataReader reader)
        {
            return new Address
            {
                Id = (int)reader["Id"],
                User_Id = (int)reader["User_Id"],
                Address_line1 = (string)reader["Address_line1"],
                Address_line2 = reader["Address_line2"] != DBNull.Value ? (string)reader["Address_line2"] : null,
                City = (string)reader["City"],
                Postal_code = (string)reader["Postal_code"],
                Country = (string)reader["Country"],
                Region = reader["Region"] != DBNull.Value ? (string)reader["Region"] : null
            };
        }
    }
}