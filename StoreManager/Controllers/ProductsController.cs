using AutoMapper;
using Entities.DataTransferObjects.ProductDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store;
using System;
using System.Threading.Tasks;

namespace StoreManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public ProductsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto product)
        {

            try
            {
                if (product == null)
                {
                    _logger.LogError("product object sent from client is null.");
                    return BadRequest("product object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid product object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var productEntity = _mapper.Map<Products>(product);

                await _repository.Products.CreateProducts(productEntity);
                _repository.Save();

                var createdProduct = _mapper.Map<ProductDto>(productEntity);

                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProduct action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside CreateProduct action: {ex.Message}");
            }
        }

        [HttpPut("Product")]
        public async Task<IActionResult> UpdateProducts(Guid productCode, [FromBody] ProductForCreationDto product)
        {
            try
            {
                if (product == null)
                {
                    _logger.LogError("product object sent from client is null.");
                    return BadRequest("product object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid product object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var productEntity = await _repository.Products.GetProducttByCode(productCode);
                if (productEntity == null)
                {
                    _logger.LogError($"product with code: {productCode}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(product, productEntity);
                await _repository.Products.UpdateProducts(productEntity);
                _repository.Save();
                return Ok(productEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateProducts action: {ex.Message}");
                return StatusCode(500, $"Something went wrong inside UpdateProducts action: {ex.Message}");
            }
        }
    }
}
