using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtTest.Dto;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bus>> GetoneBus(int id)
        {
            var bb = await _context.Buses.FindAsync(id);

            if (bb == null)
            {
                return NotFound();
            }

            return bb;
        }


        [HttpPost]
        public async Task<IActionResult> PostBus(AddBus dto)
        {
            var bus = new Bus()
            {
                Number=dto.Number,
                EmployeeId=dto.EmployeeId,
                TripId=dto.TripId
           
            };
            await _context.AddAsync(bus);
            _context.SaveChanges();
            return Ok(bus);
        }

        [HttpGet]
        public IQueryable<BusDto> GetBuss()
        {
            var bus = from b in _context.Buses.OrderBy(m=>m.Number).Include(m=>m.Trip).Include(m=>m.Employee)
                       select new BusDto()
                       {
                           BusId=b.BusId,
                           EmployeeId=b.EmployeeId,
                           TripId=b.TripId,
                         Number =b.Number,
                         Name=b.Employee.Name,
                         Type=b.Trip.Type,
                         Location=b.Trip.Location

                    
                       };
            return bus;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBus(int id, BusDto dto)
        {
            if (id != dto.BusId )
            {
                return BadRequest();
            }

            var BB = await _context.Buses.FindAsync(id);
            if (BB == null)
            {
                return NotFound();
            }
            BB.Number = dto.Number;



            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (! BusExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(int id)
        {
            var B = await _context.Buses.FindAsync(id);
            if (B == null)
            {
                return NotFound();
            }

            _context.Buses.Remove(B);
            await _context.SaveChangesAsync();

            return NoContent();
        }



        private bool BusExists(int id)
        {
            return _context.Buses.Any(e => e.BusId == id);
        }
    }
}
