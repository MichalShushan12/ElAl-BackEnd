using AutoMapper;
using ElAlAIR.API.Models;
using ElAlAIR.BusinessLogic.Interfaces;
using ElAlAIR.BusinessLogic.Services;
using ElAlAIR.DataAccess.Entities;
using ElAlAIR.DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace ElAlAIR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderService _orderService;
        private IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> GetNewOrder([FromBody] CreateOrderRequest order)
        {
            try
            {
                var newOrder = await _orderService.GetNewOrder(_mapper.Map<OrderDTO>(order));
                
                if (newOrder == null) 
                {
                    return NotFound();
                }
                
                return Ok(newOrder);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDTO>>> GetAllOrders()
        {
            try
            {
                var OrdList = await _orderService.GetAllOrders();

                if(OrdList == null)
                {
                    return NotFound();
                }

                return Ok(OrdList);

            }

            catch (Exception)
            {
                throw;
            }
        }

        //[HttpGet("{orderId}")]
        //public async Task<ActionResult<OrderDTO>> GetOrderById(Guid orderId)
        //{
        //    try
        //    {
        //        var ordId = await _orderService.GetOrderById(orderId);

        //        if (ordId == null)
        //        {
        //            return NotFound();
        //        }

        //        return Ok(ordId);  
        //    }

        //    catch(Exception)
        //    {
        //        throw;
        //    }
        //}

        [HttpDelete("{orderId}")]
        public async Task DeleteOrder(Guid orderId)
        {
            try
            {
                _orderService.DeleteOrder(orderId);
            }

            catch (Exception)
            {
                throw;
            }
        }


        [HttpPut]
        public async Task<ActionResult<OrderDTO>> UpdateOrder([FromBody] OrderDTO order)
        {
            try
            {
                var ordUpdate = await _orderService.UpdateOrder(order);

                if (ordUpdate == null)
                {
                    return NotFound();
                }

                return Ok(ordUpdate);
            }

            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersByUserId(Guid userId)
        {
            try
            {
                var ordersByUser = await _orderService.GetOrdersByUserId(userId);


                /*
                
                if (ordersByUser == null || ordersByUser.Count == 0)
                {
                    return Ok("You haven't purchased anything yet."); // Or return a more structured response if needed
                }
                
                */

                return Ok(ordersByUser);
            }
            catch (Exception ex)
            {
                // Log the exception (you can do this via a logging service)
                return StatusCode(500, "An error occurred while retrieving your orders.");
            }
        }
      


    }
}
