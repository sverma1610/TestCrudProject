using CRUD.Data;
using CRUD.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

       // GET: api/<ProductsController>
        [HttpGet("{id}")]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        // GET api/<ProductsController>/5
        [HttpGet]
        public Product Get(int id)
        {
            
            return _context.Products.Where(x => x.Id == id).FirstOrDefault();
           
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            try
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.Id == id);
                if (existingProduct != null)
                {
                    existingProduct.Name = updatedProduct.Name;
                    existingProduct.Description = updatedProduct.Description;
                    existingProduct.Price = updatedProduct.Price;

                    _context.SaveChanges();
                    return Ok(existingProduct);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var productToDelete = _context.Products.FirstOrDefault(p => p.Id == id);
                if (productToDelete != null)
                {
                    _context.Products.Remove(productToDelete);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}

