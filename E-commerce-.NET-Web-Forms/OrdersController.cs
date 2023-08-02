using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;

namespace E_commerce
{
    public class OrdersController : ApiController
    {
        static readonly OrderRepository orderRepository = new OrderRepository();

        public IEnumerable<Order> GetAllOrders()
        {
            return orderRepository.GetOrders();
        }

        public Order GetOrder(int id)
        {
            Order order = orderRepository.GetOrder(id);
            if (order == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return order;
        }


        public HttpResponseMessage PostOrder(Order order)
        {
            order = orderRepository.AddOrder(order);
            var response = Request.CreateResponse<Order>(HttpStatusCode.Created, order);
            string uri = Url.Link("DefaultApi", new { id = order.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutOrder(int id, Order order)
        {
            order.Id = id;
            if (!orderRepository.UpdateOrder(order))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteOrder(int id)
        {
            orderRepository.DeleteOrder(id);
        }
    }
}