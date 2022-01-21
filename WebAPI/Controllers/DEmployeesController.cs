using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DEmployeesController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DEmployeesController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DEmployees
        [HttpGet]
        public IEnumerable<DEmployee> GetDEmployees()
        {
            return _context.DEmployees;
        }

        // GET: api/DEmployees/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dEmployee = await _context.DEmployees.FindAsync(id);

            if (dEmployee == null)
            {
                return NotFound();
            }

            return Ok(dEmployee);
        }

        // PUT: api/DEmployees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDEmployee([FromRoute] int id, [FromBody] DEmployee dEmployee)
        {
          
            dEmployee.id = id;


            _context.Entry(dEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DEmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DEmployees
        [HttpPost]
        public async Task<IActionResult> PostDEmployee([FromBody] DEmployee dEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DEmployees.Add(dEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDEmployee", new { id = dEmployee.id }, dEmployee);
        }

        // DELETE: api/DEmployees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDEmployee([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dEmployee = await _context.DEmployees.FindAsync(id);
            if (dEmployee == null)
            {
                return NotFound();
            }

            _context.DEmployees.Remove(dEmployee);
            await _context.SaveChangesAsync();

            return Ok(dEmployee);
        }

        private bool DEmployeeExists(int id)
        {
            return _context.DEmployees.Any(e => e.id == id);
        }
    }
}