using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Interfaces
{
    public interface IOrderService
    {
        public Task<OrderDTO> GetNewOrder(OrderDTO orderDto);
        public Task<List<OrderDTO>> GetAllOrders();
        //public Task <OrderDTO> GetOrderById(Guid orderId);
        public Task DeleteOrder(Guid orderId);

        public Task<List<OrderDTO>> GetOrdersByUserId(Guid userId);


        public Task<OrderDTO> UpdateOrder(OrderDTO order);


    }
}
