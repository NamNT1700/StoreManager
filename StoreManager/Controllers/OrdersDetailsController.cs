using AutoMapper;
using Entities.DataTransferObjects.OrdersDetailsDTO;
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
        [HttpPost]
        public IActionResult CreateOrderdetails([FromBody] OrderDetailsForCreationDto orderdetails)
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

                _repository.OrderDetails.CreateOrderDetails(orderdetailsEntity);
                _repository.Save();

                var createdOrderDetails = _mapper.Map<OrderDetailsDto>(orderdetailsEntity);

                return Ok(createdOrderDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOrderdetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
