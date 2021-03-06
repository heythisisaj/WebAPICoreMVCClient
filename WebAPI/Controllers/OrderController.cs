using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderRepository orderRepository;
        public OrderController(IOrderRepository repo)
        {
            orderRepository = repo;
        }
        [HttpGet]
        public IEnumerable<Order> GetOrders()
        {
            return orderRepository.GetAllOrders();
        }
        [HttpGet("{id}")]
        public Order GetOrderById(int id)
        {
            return orderRepository.GetOrderById(id);
        }
        [HttpPost]
        public Order Create([FromBody] Order order)
        {
            return orderRepository.AddOrder(order);
        }
        [HttpPut]
        public Order Update([FromForm] Order order)
        {
            return orderRepository.UpdateOrder(order);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            orderRepository.DeleteOrder(id);
        }
    }
}
