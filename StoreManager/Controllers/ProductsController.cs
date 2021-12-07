using AutoMapper;
using Entities.DataTransferObjects.ProductDTO;
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
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductForCreationDto product)
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

                _repository.Products.CreateProducts(productEntity);
                _repository.Save();

                var createdProduct = _mapper.Map<ProductDto>(productEntity);

                return Ok(createdProduct);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateProduct action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
