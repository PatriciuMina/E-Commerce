using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using E_Commerce.Models;

namespace E_commerce
{
    interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        Order GetOrder(int id);
        Order AddOrder(Order order);
        void DeleteOrder(int id);
        bool UpdateOrder(Order order);
    }
}
