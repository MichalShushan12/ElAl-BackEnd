using Azure.Core;
using ElAlAIR.DataAccess.DataContext;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private ElalDbContext _elalContext;

        public OrderRepository(ElalDbContext elalContext)
        {
            _elalContext = elalContext;
        }

        public async Task DeleteOrder(Guid orderId)
        {
            try
            {
                Order orderToDelete = _elalContext.Orders.SingleOrDefault(o => o.OrderId == orderId);
                _elalContext.Orders.Remove(orderToDelete);
                await _elalContext.SaveChangesAsync();        
            }

            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Order>> GetAllOrders()
        {
            try
            {
                return await _elalContext.Orders.ToListAsync();
            }

            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }

        public async Task<Order> GetNewOrder(Order order)
        {
            try
            {
                await _elalContext.Orders.AddAsync(order);
                //_elalContext.SaveChangesAsync();
                await _elalContext.SaveChangesAsync();
                return order;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error creating order", ex);
            }
        }


        //public async Task <Order> GetOrderById(Guid orderId)
        //{
        //    try
        //    {

        //        return _elalContext.Orders.FirstOrDefault(o => o.OrderId == orderId);
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException("Error creating order", ex);
        //    }
        //}

        public async Task<List<Order>> GetOrdersByUserId(Guid userId)
        {
            try
            {
                // Filter orders by userId
                return await _elalContext.Orders
                                         .Where(o => o.UserId == userId)
                                         .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error retrieving orders for the user", ex);
            }
        }

       
        public async Task<Order> UpdateOrder(Order order)
        {
            try
            {

                if (order.PaymentStatus == "half paid" || order.PaymentStatus == "paid")
                {
                    _elalContext.Orders.Entry(order).State = EntityState.Modified;
                    //_elalContext.SaveChanges();
                    await _elalContext.SaveChangesAsync();
                }
                return order;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
