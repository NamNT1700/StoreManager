using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public CustomersController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost("CreateCustomers")]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomersForCreationDto customers)
        {

            try
            {
                if (customers == null)
                {
                    _logger.LogError("customer object sent from client is null.");
                    return BadRequest("customer object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var customersEntity = _mapper.Map<Customers>(customers);

                await _repository.Customers.CreateCustomers(customersEntity);
                _repository.Save();

                var createdCustomers = _mapper.Map<CustomersDto>(customersEntity);

                return Ok(createdCustomers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateCustomers action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateCustomers action: {ex.Message}");
            }
        }

        [HttpPut("Customer")]
        public async Task<IActionResult> UpdateCustomer(int customerID, [FromBody] CustomersForUpdateDto customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogError("customer object sent from client is null.");
                    return BadRequest("customer object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customer object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var customerEntity = await _repository.Customers.GetCumstomersByID(customerID);
                if (customerEntity == null)
                {
                    _logger.LogError($"customer with number: {customerID}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(customer, customerEntity);
                await _repository.Customers.UpdateCustomers(customerEntity);
                _repository.Save();
                return Ok(customerEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCustomer action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdateCustomer action: {ex.Message}");
            }
        }
    }
}
