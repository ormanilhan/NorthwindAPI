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
    public class EmployeeController : ControllerBase
    {
        private readonly NorthwindAPIDBContext _context;

        public EmployeeController(NorthwindAPIDBContext context)
        {
            _context = context;
        }
        // GET api/Employee
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return _context.Employees.ToList();
        }


        // GET api/Employee/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var product = _context.Employees.FirstOrDefault(t => t.EmployeeID == id);
            if (product == null)
            {
                return NotFound();
            }
            return new ObjectResult(product);
        }

        // POST api/Employee
        [HttpPost]
        public void Post([FromBody] string value)
        {
            //TODO
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            //TODO
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = _context.Employees.FirstOrDefault(t => t.EmployeeID == id);
            if (product != null)
            {
                _context.Employees.Remove(product);
            }
        }
    }
}
