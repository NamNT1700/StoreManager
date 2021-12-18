using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.OrdersDTO;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OrdersController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrders([FromBody] OrdersForCreationDto orders)
        {

            try
            {
                if (orders == null)
                {
                    _logger.LogError("orders object sent from client is null.");
                    return BadRequest("orders object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orders object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var ordersEntity = _mapper.Map<Orders>(orders);

                await _repository.Orders.CreateOrders(ordersEntity);
                _repository.Save();

                var createdOrders = _mapper.Map<OrdersDto>(ordersEntity);

                return Ok(createdOrders);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOrders action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateOrders action: {ex.Message}");
            }
        }

        [HttpPut("{orderNumber}")]
        public async Task<IActionResult> UpdateOrder(int orderNumber, [FromBody] OrdersForUpdateDto order)
        {
            try
            {
                if (order == null)
                {
                    _logger.LogError("order object sent from client is null.");
                    return BadRequest("order object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid order object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var orderEntity = await _repository.Orders.GetOrderByNumber(orderNumber);
                if (orderEntity == null)
                {
                    _logger.LogError($"order with number: {orderNumber}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(order, orderEntity);
                await _repository.Orders.UpdateOrders(orderEntity);
                _repository.Save();
                return Ok(orderEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOrder action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdateOrder action: {ex.Message}");
            }
        }
    }
}
