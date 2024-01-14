using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;
        public ProductsController(ProductContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            IEnumerable<Product> products = _context.Products;
            if (products == null)
            {
                return NoContent();
            }
            return new OkObjectResult(products);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product,CancellationToken cancellationToken)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Task.Delay(TimeSpan.FromSeconds(5));
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync(cancellationToken);
                    return CreatedAtAction(nameof(GetProductbyID), new { id = product.Id }, product);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProductbyID(int id)
        {
            Product product = _context.Products.Find(id);
            if (product == null)
            {
                return NoContent();
            }
            return new OkObjectResult(product);
        }
        [HttpGet("GetProductbyType/{type}")]
        public IActionResult GetProductbyType(string type)
        {
            IQueryable<Product> products = _context.Products.Where(product => product.ProductCategory == type);
            if(products.Count() > 0)
            {
                return new OkObjectResult(products);
            }
            return NoContent();
            
        }
    }

}
