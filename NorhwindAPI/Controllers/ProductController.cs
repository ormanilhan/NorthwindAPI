using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorhwindAPI.Models;

namespace NorhwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NorthwindAPIDBContext _context;

        public ProductController(NorthwindAPIDBContext context)
        {
            _context = context;
        }
        // GET api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Products.ToList();
        }


        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var product = _context.Products.FirstOrDefault(t => t.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        // POST api/Product
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //TODO
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(t => t.ProductID == id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
        }
    }
}
