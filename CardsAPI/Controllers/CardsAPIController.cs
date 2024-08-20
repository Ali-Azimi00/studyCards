using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardsAPI.Data;
using CardsAPI.Models;

namespace CardsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsAPIController : ControllerBase
    {
        private readonly CardsAPIContext _context;

        public CardsAPIController(CardsAPIContext context)
        {
            _context = context;
        }

        // GET: api/CardsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SCards>>> GetsCards()
        {
            return await _context.sCards.ToListAsync();
        }

        // GET: api/CardsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SCards>> GetSCards(Guid id)
        {
            var sCards = await _context.sCards.FindAsync(id);

            if (sCards == null)
            {
                return NotFound();
            }

            return sCards;
        }

        // PUT: api/CardsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSCards(Guid id, SCards sCards)
        {
            if (id != sCards.CardId)
            {
                return BadRequest();
            }

            _context.Entry(sCards).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SCardsExists(id))
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

        // POST: api/CardsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddCard")]
        public async Task<ActionResult<SCards>> PostSCards(SCards sCards)
        {
            _context.sCards.Add(sCards);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSCards", new { id = sCards.CardId }, sCards);
        }

        // DELETE: api/CardsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSCards(Guid id)
        {
            var sCards = await _context.sCards.FindAsync(id);
            if (sCards == null)
            {
                return NotFound();
            }

            _context.sCards.Remove(sCards);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SCardsExists(Guid id)
        {
            return _context.sCards.Any(e => e.CardId == id);
        }
    }
}
