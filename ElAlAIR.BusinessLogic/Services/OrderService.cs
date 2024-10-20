using AutoMapper;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using ElAlAIR.DataAccess.Repositories;
using ElAlAIR.DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.BusinessLogic.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IDestinationRepository _destinationRepository;  
        private IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper, IDestinationRepository destinationRepository)
        {
            _orderRepository = orderRepository; 
            _mapper = mapper;
            _destinationRepository = destinationRepository;
        }

        public async Task DeleteOrder(Guid orderId)
        {
            try
            {
                _orderRepository.DeleteOrder(orderId);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<List<OrderDTO>> GetAllOrders()
        {
            try
            {
                List<Order> orderList = await _orderRepository.GetAllOrders();
                return _mapper.Map<List<OrderDTO>>(orderList);
            }

            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                // You can also consider returning a default or error OrderDTO here
                throw new ApplicationException("Error creating order", ex);
            }
        }
        public async Task<OrderDTO> GetNewOrder(OrderDTO orderDto)
        {
            try
            {
                //Order order = await _orderRepository.GetNewOrder(order);

                /*
                order.OrderId = Guid.NewGuid();
                order.OrderDate = DateTime.UtcNow;
                order.PaymentStatus = order.PaymentStatus;
                return _mapper.Map<OrderDTO>(order);
                */

                var order = _mapper.Map<Order>(orderDto);
                order.OrderId = Guid.NewGuid();
                order.OrderDate = DateTime.UtcNow;
                order.PaymentStatus = order.PaymentStatus;
                var createdOrder = await _orderRepository.GetNewOrder(order);
                return _mapper.Map<OrderDTO>(createdOrder);
                //return _mapper.Map<OrderDTO>(createdOrder);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                // You can also consider returning a default or error OrderDTO here
                throw new ApplicationException("Error creating order", ex);
            }
        }

        //public async Task<OrderDTO> GetNewOrder(OrderDTO order)
        //{
        //    try
        //    {
        //        // Generate a unique OrderId
        //        order.OrderId = Guid.NewGuid();

        //        // Create the order using the repository
        //        //Order sendOrder = await _orderRepository.GetNewOrder(order);

        //        Order sendOrder = _mapper.Map<Order>(order);
        //        //Order createOrder = await _orderRepository.GetNewOrder(order);

        //        // Map the created order to OrderDTO
        //        Order createdOrder = await _orderRepository.GetNewOrder(sendOrder);

        //        //return OrdersMapper.Map(sendOrder);
        //        return _mapper.Map<OrderDTO>(createdOrder);

        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception (e.g., log it)
        //        // You can also consider returning a default or error OrderDTO here
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}

        //public async Task <OrderDTO> GetOrderById(Guid orderId)
        //{
        //    try
        //    {
        //        Order order = await _orderRepository.GetOrderById(orderId);
        //        return _mapper.Map<OrderDTO>(order);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle the exception (e.g., log it)
        //        // You can also consider returning a default or error OrderDTO here
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}

        public async Task<List<OrderDTO>> GetOrdersByUserId(Guid userId)
        {
            try
            {
                List<Order> orders = await _orderRepository.GetOrdersByUserId(userId);

                if (orders == null || orders.Count == 0)
                {
                    // You can handle this scenario in the controller, but here is where you detect the empty list
                    return new List<OrderDTO>(); // Return an empty list if there are no orders
                }

                return _mapper.Map<List<OrderDTO>>(orders);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving orders for the user", ex);
            }
        }


        public async Task<OrderDTO> UpdateOrder(OrderDTO order)
        {
            try
            {
                Order updateOrder = await _orderRepository.UpdateOrder(_mapper.Map<Order>(order));
                return _mapper.Map<OrderDTO>(updateOrder);
            }

            catch (Exception)
            {
                throw;
            }
        }
    }
}
