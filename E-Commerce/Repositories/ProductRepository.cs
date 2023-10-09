using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using E_Commerce.Models;
using System.Globalization;
using System.IO;

namespace E_commerce
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["EcommerceDatabase"].ConnectionString;
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Products";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = MapProductFromReader(reader);
                            products.Add(product);
                        }
                    }
                }
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Products WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapProductFromReader(reader);
                        }
                    }
                }
            }
            return null;
        }

        public Product AddProduct(Product product)
        {
            DateTime time = DateTime.Now;
            product.Created_At = time;

            string fileName = Path.GetFileName(product.Image);

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Products (User_ID, Name, Price, Description, Category, Specifications, Image, Created_At) VALUES (@User_ID, @Name, @Price, @Description, @Category, @Specifications, @Image, @Created_At); SELECT SCOPE_IDENTITY();";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_ID", product.User_ID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Image", fileName);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Specifications", product.Specifications);
                    command.Parameters.AddWithValue("@Created_At", product.Created_At);


                    connection.Open();
                    int newProductId = Convert.ToInt32(command.ExecuteScalar());
                    product.Id = newProductId;
                    return product;
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Products WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateProduct(Product product)
        {
            DateTime time = DateTime.Now;
            product.Updated_At = time;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Products SET User_ID = @User_ID, Name = @Name, Price = @Price, Description = @Description, Image = @Image, Category = @Category, Specifications = @Specifications, Updated_At = @Updated_At WHERE Id = @Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@User_ID", product.User_ID);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Price", product.Price);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Image", product.Image);
                    command.Parameters.AddWithValue("@Category", product.Category);
                    command.Parameters.AddWithValue("@Specifications", product.Specifications);
                    command.Parameters.AddWithValue("@Updated_At", product.Updated_At);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private Product MapProductFromReader(SqlDataReader reader)
        {
            DateTime Created_At;
            DateTime Updated_At;
            DateTime.TryParseExact(reader["Created_At"].ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Created_At);
            DateTime.TryParseExact(reader["Updated_At"].ToString(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out Updated_At);
            return new Product
            {
                Id = Convert.ToInt32(reader["Id"]),
                User_ID = Convert.ToInt32(reader["User_ID"]),
                Name = reader["Name"].ToString(),
                Price = Convert.ToDecimal(reader["Price"]),
                Description = reader["Description"].ToString(),
                Image = reader["Image"].ToString(),
                Category = reader["Category"].ToString(),
                Specifications = reader["Specifications"].ToString(),
                Created_At = Created_At,
                Updated_At = Updated_At
            };
        }
    }
}