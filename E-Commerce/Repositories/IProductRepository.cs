using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using E_Commerce.Models;

namespace E_commerce
{
    interface IProductRepository
    {

        IEnumerable<Product> GetProducts();
        Product GetProduct(int id);
        Product AddProduct(Product product);
        void DeleteProduct(int id);
        bool UpdateProduct(Product product);
    }
}
