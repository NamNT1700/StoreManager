using AutoMapper;
using Entities.DataTransferObjects.OfficesDTO;
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
    public class OfficesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public OfficesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateOffice([FromBody] OfficesForCreationDto offices)
        {

            try
            {
                if (offices == null)
                {
                    _logger.LogError("offices object sent from client is null.");
                    return BadRequest("offices object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid offices object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var officesEntity = _mapper.Map<Offices>(offices);

                _repository.Offices.CreateOffices(officesEntity);
                _repository.Save();

                var createdOffices = _mapper.Map<OfficesDto>(officesEntity);

                return Ok(createdOffices);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOffices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpPut]
        public IActionResult UpdateCustomer(string OfficesCode, [FromBody] OfficesForUpdateDto offices)
        {
            try
            {
                if (offices == null)
                {
                    _logger.LogError("customers object sent from client is null.");
                    return BadRequest("customers object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid customers object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var officesEntity = _repository.Offices.GetOfficesByOfficesCode(OfficesCode);
                if (officesEntity == null)
                {
                    _logger.LogError($"customers with number: {OfficesCode}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(offices, officesEntity);
                _repository.Offices.UpdateOffices(officesEntity);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateCustomers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
