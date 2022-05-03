using AutoMapper;
using Entities.DataTransferObjects.OfficesDTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Collections.Generic;
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
        [HttpPost("CreateOffice")]
        public async Task<IActionResult> CreateOffice([FromBody] OfficesForCreationDto offices)
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

                await _repository.Offices.CreateOffices(officesEntity);
                _repository.Save();

                var createdOffices = _mapper.Map<OfficesDto>(officesEntity);

                return Ok(createdOffices);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOffices action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateOffices action: {ex.Message}");
            }
        }
        [HttpPut("{OfficesID}")]
        public async Task<IActionResult> UpdateOffices(int OfficesID, [FromBody] OfficesForUpdateDto offices)
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
                var officesEntity = await _repository.Offices.GetOfficesByOfficesCode(OfficesID);
                if (officesEntity == null)
                {
                    _logger.LogError($"offices with code: {OfficesID}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(offices, officesEntity);
                await _repository.Offices.UpdateOffices(officesEntity);
                _repository.Save();
                return Ok(officesEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOffices action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdateOffices action: {ex.Message}");
            }
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAllOffices()
        {
            try
            {
                var offices = _repository.Offices.GetAllOffices();
                _logger.LogInfo($"Returned all offices from database.");
                var officesResult = _mapper.Map<IEnumerable<OfficesDto>>(offices);
                return Ok(officesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOffices action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside GetAllOffices action: {ex.Message}");
            }
        }


        [HttpGet("{OfficesID}")]
        public async Task<IActionResult> GetOfficesByOfficesCode(int OfficesID)
        {
            try
            {
                var office = await _repository.Offices.GetOfficesByOfficesCode(OfficesID);
                if (office == null)
                {
                    _logger.LogError($"office with code: {OfficesID}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned office with id: {OfficesID}");
                    var officeResult = _mapper.Map<OfficesDto>(office);
                    return Ok(officeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOfficesByOfficesCode action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside GetOfficesByOfficesCode action: {ex.Message}");
            }
        }

    }
}
