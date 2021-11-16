using AutoMapper;
using Entities.DataTransferObjects;
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
        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            try
            {
                var customers = _repository.Customers.GetAllCustomers();
                _logger.LogInfo($"Returned all customers from database.");
                var customersResult = _mapper.Map<IEnumerable<CustomersDto>>(customers);
                return Ok(customersResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{custumersNumber}")]
        public IActionResult GetOwnerById(int custumersNumber)
        {
            try
            {
                var customers = _repository.Customers.GetCumstomersByNumber(custumersNumber);
                if (customers == null)
                {
                    _logger.LogError($"customers with custumersNumber: {custumersNumber}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned customers with custumersNumber: {custumersNumber}");
                    var custumersResult = _mapper.Map<CustomersDto>(customers);
                    return Ok(custumersResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCumstomersByNumber action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{custumersNumber}/orders")]
        public IActionResult GetOwnerWithDetails(int custumersNumber)
        {
            try
            {
                var customers = _repository.Customers.GetCustomersWithDetails(custumersNumber);
                if (customers == null)
                {
                    _logger.LogError($"Customers with custumersNumber: {custumersNumber}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned customers with details for custumersNumber: {custumersNumber}");

                    var customersResult = _mapper.Map<CustomersDto>(customers);
                    return Ok(customersResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetCustomersWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut("{PostalCode}")]
        public IActionResult UpdateCustomer(Guid PostalCode, [FromBody] CustomersForUpdateDto customers)
        {
            try
            {
                if (customers == null)
                {
                    _logger.LogError("customers object sent from client is null.");
                    return BadRequest("customers object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customers object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var customersEntity = _repository.Customers.GetCumstomersByPostalCode(PostalCode);
                if (customersEntity == null)
                {
                    _logger.LogError($"customers with number: {PostalCode}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(customers, customersEntity);
                _repository.Customers.UpdateCustomers(customersEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCustomers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomersForUpdateDto customers)
        {
            try
            {
                if (customers == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var customersEntity = _mapper.Map<Customers>(customers);

                _repository.Customers.CreateCustomers(customersEntity);
                _repository.Save();

                var createdCustomers = _mapper.Map<CustomersDto>(customersEntity);

                return CreatedAtRoute("CustomersByNumber", new { CustomersNumber = createdCustomers.CustomersNumber }, createdCustomers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
