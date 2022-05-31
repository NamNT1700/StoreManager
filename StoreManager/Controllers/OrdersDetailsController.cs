using AutoMapper;
using Entities.DataTransferObjects.OrdersDetailsDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersDetailsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OrdersDetailsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost("CreateOrderdetails")]
        public async Task<IActionResult> CreateOrderdetails([FromBody] OrderDetailsForCreationDto orderdetails)
        {

            try
            {
                if (orderdetails == null)
                {
                    _logger.LogError("orderdetails object sent from client is null.");
                    return BadRequest("orderdetails object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orderdetails object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var orderdetailsEntity = _mapper.Map<OrderDetails>(orderdetails);

                await _repository.OrderDetails.CreateOrderDetails(orderdetailsEntity);
                _repository.Save();

                var createdOrderDetails = _mapper.Map<OrderDetailsDto>(orderdetailsEntity);

                return Ok(createdOrderDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOrderdetails action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateOrderdetails action: {ex.Message}");
            }
        }

        [HttpPut("OrderDetails")]
        public async Task<IActionResult> UpdateOrderDetails(int orderNumber, [FromBody] OrderDetailsForUpdateDto orderdetail)
        {
            try
            {
                if (orderdetail == null)
                {
                    _logger.LogError("orderdetail object sent from client is null.");
                    return BadRequest("orderdetail object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid orderdetail object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var orderdetailEntity = await _repository.OrderDetails.GetOrderByNumber(orderNumber);

                if (orderdetailEntity == null)
                {
                    _logger.LogError($"orderdetail with orderNumber: {orderNumber}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(orderdetail, orderdetailEntity);
                await _repository.OrderDetails.UpdateOrderDetails(orderdetailEntity);
                _repository.Save();
                return Ok(orderdetailEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOrderDetails action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdateOrderDetails action: {ex.Message}");
            }
        }
    }
}
