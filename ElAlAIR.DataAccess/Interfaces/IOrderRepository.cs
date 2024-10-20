using ElAlAIR.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        public Task<Order> GetNewOrder(Order order);

        public Task<List<Order>> GetAllOrders();

        //public Task <Order> GetOrderById(Guid orderId);

        public Task DeleteOrder(Guid orderId);
        public Task<Order> UpdateOrder(Order order);


        public Task<List<Order>> GetOrdersByUserId(Guid userId);



    }
}
