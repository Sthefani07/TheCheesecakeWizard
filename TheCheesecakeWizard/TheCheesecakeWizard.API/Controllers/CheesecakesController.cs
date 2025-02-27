using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheCheesecakeWizard.BL.Services.Interfaces;
using TheCheesecakeWizard.DAL;
using TheCheesecakeWizard.DAL.Repository.Entities;

namespace TheCheesecakeWizard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheesecakesController : ControllerBase
    {
        private readonly ICheesecakeService _cheesecakeService;
        

        public CheesecakesController(ICheesecakeService cheesecakeService)
        {
            _cheesecakeService = cheesecakeService;
        }

        // GET: api/Cheesecakes
        [HttpGet]
        public async Task<IEnumerable<Cheesecake>> GetCheesecakes()
        {
            return await _cheesecakeService.GetAllCheesecakesAsync();
        }

        // GET: api/Cheesecakes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cheesecake>> GetCheesecake(int id)
        {
            var cheesecake = await _cheesecakeService.GetCheesecakeByIdAsync(id);

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
           await _cheesecakeService.UpdateCheesecakeAsync(id, cheesecake);
           return NoContent();
        }

        // POST: api/Cheesecakes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cheesecake>> PostCheesecake(Cheesecake cheesecake)
        {
            await _cheesecakeService.CreateCheesecakeAsync(cheesecake);
            return CreatedAtAction("GetCheesecake", new { id = cheesecake.Id }, cheesecake);
        }

        // DELETE: api/Cheesecakes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCheesecake(int id)
        {
            try
            {
                await _cheesecakeService.DeleteCheesecakeAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _cheesecakeService.GetCheesecakeByIdAsync(id) == null)
                {
                    return NotFound();
                }
                throw;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

            return NoContent();
        }
    }
}
