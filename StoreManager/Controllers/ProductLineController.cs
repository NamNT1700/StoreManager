using AutoMapper;
using Entities.DataTransferObjects.ProductLinesDTO;
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
    public class ProductLineController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductLineController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateProductLines([FromBody] ProductLinesForCreationDto productLines)
        {

            try
            {
                if (productLines == null)
                {
                    _logger.LogError("productLines object sent from client is null.");
                    return BadRequest("productLines object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid productLines object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var productlinesEntity = _mapper.Map<ProductLines>(productLines);

                _repository.ProductLines.CreateProductLines(productlinesEntity);
                _repository.Save();

                var createdproductlines = _mapper.Map<ProductLinesDto>(productlinesEntity);

                return Ok(createdproductlines);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProductLines action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
