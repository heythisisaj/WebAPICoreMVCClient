using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IOrderRepository
    {

        IEnumerable<Order> GetAllOrders(); 
        Order GetOrderById(int Id); 

        Order AddOrder(Order order); 

        Order UpdateOrder(Order order);  

        void DeleteOrder(int id);   
    }
}
