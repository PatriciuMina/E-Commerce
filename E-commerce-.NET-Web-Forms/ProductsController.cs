using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace E_commerce
{
    public class ProductsController : ApiController
    {
        static readonly ProductRepository productRepository = new ProductRepository();


        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            Product product = productRepository.GetProduct(id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }

        
        public Product PostProduct(Product product)
        {
            product = productRepository.AddProduct(product);
            //var response = Request.CreateResponse<Product>(HttpStatusCode.Created, product);
            //string uri = Url.Link("DefaultApi", new { id = product.Id });
            //response.Headers.Location = new Uri(uri);
            return product;
        }

        public void PutProduct(int id, Product product)
        {
            product.Id = id;
            if (!productRepository.UpdateProduct(product))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }

        /*public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return product;
        }*/

        
    }
}