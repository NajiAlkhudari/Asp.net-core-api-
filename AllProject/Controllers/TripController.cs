using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtTest.Dto;
using System.Collections;

[Route("api/[controller]")]
[ApiController]
    public class TripController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
            var tripp = await _context.Trips.FindAsync(id);

            if (tripp == null)
            {
                return NotFound();
            }

            return tripp;
        }

        [HttpPost]
        public async Task<IActionResult> PostTrip(TripDto dto)
        {
            var tripp = new Trip()
            {
               Type=dto.Type,
               Location=dto.Location,
               Hour=dto.Hour
            };
            await _context.AddAsync(tripp);
            _context.SaveChanges();
            return Ok(tripp);
        }

    [HttpGet]
    public IQueryable<TripDto> GetTrip()
    {
        var tripp = from b in _context.Trips
                    select new TripDto()
                    {
                        TripId = b.TripId,
                        Type = b.Type,
                        Hour = b.Hour,
                        Location = b.Location,
                    };
        return tripp;
    }
    [Route("Inbound")]
    [HttpGet]
    public IQueryable<TripDto> Inbound()
    {
        var tripp1 = from b in _context.Trips.Where(s => s.Type == "inbound")
                     select new TripDto()
                     {
                         TripId = b.TripId,
                         Type = b.Type,
                         Hour = b.Hour,
                         Location = b.Location,
                     };
        return tripp1;
    }
    [Route("Outbound")]
    [HttpGet]
    public IQueryable<TripDto> Outbound()
    {
        var tripp2 = from b in _context.Trips
                     .Where(s => s.Type == "outbound")
                     select new TripDto()
                     {
                         TripId = b.TripId,
                         Type = b.Type,
                         Hour = b.Hour, 
                         Location = b.Location,
                     };
        return tripp2;
    }




    [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(int id, TripDto dto)
        {
            if (id != dto.TripId)
            {
                return BadRequest();
            }

            var emp = await _context.Trips.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            emp.Type = dto.Type;
            emp.Location = dto.Location;
            emp.Hour = dto.Hour;

         

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (! TripExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            var trii = await _context.Trips.FindAsync(id);
            if (trii == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trii);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }

