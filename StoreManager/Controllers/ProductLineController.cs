using AutoMapper;
using Entities.DataTransferObjects.ProductLinesDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
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
        [HttpPost("CreateProductLines")]
        public async Task<IActionResult> CreateProductLines([FromBody] ProductLinesForCreationDto productLines)
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

                await _repository.ProductLines.CreateProductLines(productlinesEntity);
                _repository.Save();

                var createdproductlines = _mapper.Map<ProductLinesDto>(productlinesEntity);

                return Ok(createdproductlines);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProductLines action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateProductLines action: {ex.Message}");
            }
        }

        [HttpPut("ProductLines")]
        public async Task<IActionResult> UpdateProductLines(int productID, [FromBody] ProductLinesForCreationDto productLines)
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
                var productLinesEntity = await _repository.ProductLines.GetProductbyLine(productID);
                if (productLinesEntity == null)
                {
                    _logger.LogError($"product with Line: {productID}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(productLines, productLinesEntity);
                await _repository.ProductLines.UpdateProductLines(productLinesEntity);
                _repository.Save();
                return Ok(productLinesEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProductLines action: {ex.Message}");
                return StatusCode(500, "Something went wrong inside UpdateProductLines action: {ex.Message}");
            }
        }
    }
}
