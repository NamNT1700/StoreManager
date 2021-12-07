using AutoMapper;
using Entities.DataTransferObjects.EmployeesDTO;
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
    public class EmployeesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public EmployeesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateEmployees([FromBody] EmployeesForCreationDto employees)
        {

            try
            {
                if (employees == null)
                {
                    _logger.LogError("employees object sent from client is null.");
                    return BadRequest("employees object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid employees object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var employeesEntity = _mapper.Map<Employees>(employees);

                _repository.Employees.CreateEmployees(employeesEntity);
                _repository.Save();

                var createdEmployees = _mapper.Map<EmployeesDto>(employeesEntity);

                return Ok(createdEmployees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEmployees action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
