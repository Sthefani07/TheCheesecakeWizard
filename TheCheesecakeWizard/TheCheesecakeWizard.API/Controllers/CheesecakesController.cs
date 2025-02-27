using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCheesecakeWizard.DAL;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheesecakesController : ControllerBase
    {
        private readonly TheCheesecakeWizardDbContext _context;

        public CheesecakesController(TheCheesecakeWizardDbContext context)
        {
            _context = context;
        }

        // GET: api/Cheesecakes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cheesecake>>> GetCheesecakes()
        {
            return await _context.Cheesecakes.ToListAsync();
        }

        // GET: api/Cheesecakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cheesecake>> GetCheesecake(int id)
        {
            var cheesecake = await _context.Cheesecakes.FindAsync(id);

            if (cheesecake == null)
            {
                return NotFound();
            }

            return cheesecake;
        }

        // PUT: api/Cheesecakes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCheesecake(int id, Cheesecake cheesecake)
        {
            if (id != cheesecake.Id)
            {
                return BadRequest();
            }

            _context.Entry(cheesecake).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CheesecakeExists(id))
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

        // POST: api/Cheesecakes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cheesecake>> PostCheesecake(Cheesecake cheesecake)
        {
            _context.Cheesecakes.Add(cheesecake);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCheesecake", new { id = cheesecake.Id }, cheesecake);
        }

        // DELETE: api/Cheesecakes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheesecake(int id)
        {
            var cheesecake = await _context.Cheesecakes.FindAsync(id);
            if (cheesecake == null)
            {
                return NotFound();
            }

            _context.Cheesecakes.Remove(cheesecake);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CheesecakeExists(int id)
        {
            return _context.Cheesecakes.Any(e => e.Id == id);
        }
    }
}
