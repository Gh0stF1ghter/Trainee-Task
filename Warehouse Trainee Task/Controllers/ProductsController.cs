using AutoMapper;
using Logic.Models;
using Logic.Services;
using Microsoft.AspNetCore.Mvc;
using Services;
using Warehouse_Trainee_Task.Resources;
using Warehouse_Trainee_Task.Validators;

namespace Warehouse_Trainee_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductsController(ILogger<ProductService> logger, IMapper mapper, IProductService productService)
        {
            _logger = logger;
            _mapper = mapper;
            _service = productService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResource>>> GetProducts()
        {
            _logger.LogDebug("LogDebug ---------- GET Products");

            var products = await _service.GetProducts();

            var productsResources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);

            return Ok(productsResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResource>> GetProduct(int id)
        {
            _logger.LogDebug("LogDebug ---------- GET ProductById");

            var product = await _service.GetProductById(id);

            if (product == null)
            {
                return NotFound();
            }

            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPost]
        public async Task<ActionResult<ProductResource>> PostProduct(SaveProductResource saveProductResource)
        {
            var validator = new SaveProductResourceValidator();
            var validationResult = validator.Validate(saveProductResource);

            if (!validationResult.IsValid)
            {
                _logger.LogError("LogError ---------- POST Product");
                return BadRequest();
            }

            _logger.LogDebug("LogDebug ---------- POST Product");

            var mappedProduct = _mapper.Map<SaveProductResource, Product>(saveProductResource);
            var newProduct = await _service.CreateProduct(mappedProduct);

            var product = await _service.GetProductById(newProduct.Id);
            var productResource = _mapper.Map<Product, ProductResource>(product);

            return Ok(productResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] SaveProductResource saveProductResource)
        {
            var validator = new SaveProductResourceValidator();

            var validationResult = validator.Validate(saveProductResource);

            var invalidResult = id == 0 || !validationResult.IsValid;

            if (invalidResult)
            {
                _logger.LogError("LogError ---------- PUT Product");
                return BadRequest(validationResult.Errors);
            }

            _logger.LogDebug("LogDebug ---------- PUT Product");


            var oldProduct = await _service.GetProductById(id);

            if (oldProduct == null)
                return NotFound();

            var newProduct = _mapper.Map<SaveProductResource, Product>(saveProductResource);
            await _service.UpdateProduct(newProduct, oldProduct);

            var product = _mapper.Map<Product, ProductResource>(newProduct);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _logger.LogDebug("LogDebug ---------- DELETE Product");

            var product = await _service.GetProductById(id);

            if (product == null)
                return NotFound();

            await _service.DeleteProduct(product);

            return NoContent();
        }
    }
}
