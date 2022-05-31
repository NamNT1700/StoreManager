using AutoMapper;
using Entities.DataTransferObjects.EmployeesDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
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
        [HttpPost("CreateEmployees")]
        public async Task<IActionResult> CreateEmployees([FromBody] EmployeesForCreationDto employees)
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

                await _repository.Employees.CreateEmployees(employeesEntity);

                _repository.Save();

                var createdEmployees = _mapper.Map<EmployeesDto>(employeesEntity);

                return Ok(createdEmployees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateEmployees action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateEmployees action: {ex.Message}");
            }
        }
        [HttpPut("Employee")]
        public async Task<IActionResult> UpdateEmployees(int employeeID, [FromBody] EmployeesForUpdateDto employees)
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
                var employeesEntity = await _repository.Employees.GetEmployeeByNumber(employeeID);
                if (employeesEntity == null)
                {
                    _logger.LogError($"employees with number: {employeeID}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(employees, employeesEntity);
                await _repository.Employees.UpdateEmployees(employeesEntity);
                _repository.Save();
                return Ok(employeesEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateEmployees action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdateEmployees action: {ex.Message}");
            }
        }
    }
}
