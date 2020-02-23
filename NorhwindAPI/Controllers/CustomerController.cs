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
    public class CustomerController : ControllerBase
    {
        private readonly NorthwindAPIDBContext _context;

        public CustomerController(NorthwindAPIDBContext context)
        {
            _context = context;
        }
        // GET api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> Get()
        {
            return _context.Customers.ToList();
        }


        // GET api/Customer/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            var product = _context.Customers.FirstOrDefault(t => t.CustomerID == id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        // POST api/Customer
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //TODO
        }

        // PUT api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO
        }

        // DELETE api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var product = _context.Customers.FirstOrDefault(t => t.CustomerID == id);
            if (product != null)
            {
                _context.Customers.Remove(product);
            }
        }
    }
}
