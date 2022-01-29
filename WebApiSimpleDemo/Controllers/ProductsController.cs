using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiSimpleDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static List<Product> _products;
        private readonly ILogger<ProductsController> _logger;
        private readonly IRandom _random;

        static ProductsController()
        {
            _products = new List<Product>();
        }

        public ProductsController(ILogger<ProductsController> logger,
            IRandom random)
        {
            _logger = logger;
            _random = random;
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if(product == null ||
                product.Count <= 0 ||
                product.Price <= 0 ||
                string.IsNullOrEmpty(product.Title))
            {
                return BadRequest();
            }

            product.ProductId = Guid.NewGuid();
            _products.Add(product);

            return Created($"{product.ProductId}", product);
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            _logger.LogInformation($"{_random.GetRandom(10, 100)}");

            return _products;
        }

        [HttpGet("{productId}")]
        public Product GetById(Guid productId)
        {
            return _products.FirstOrDefault
                (x => x.ProductId == productId);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var productFromDB = GetById(product.ProductId);
            if(productFromDB != null)
            {
                var index = _products.IndexOf(productFromDB);
                _products[index] = product;

                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteById(Guid productId)
        {
            Product product = GetById(productId);
            if(product != null)
            {
                _products.Remove(product);

                return Accepted();
            }

            return NotFound();
        }
    }
}
