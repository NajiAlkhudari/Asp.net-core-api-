using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtTest.Dto;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Work>> GetWork(int id)
        {
            var workk = await _context.Works.FindAsync(id);

            if (workk == null)
            {
                return NotFound();
            }

            return workk;
        }

        [HttpPost]
        public async Task<IActionResult> PostWork([FromBody] WorkDto work)
        {
            Work ww = new Work()
            {
                Name = work.Name,
                Task = work.Task,
                EmployeeId=work.EmployeeId
                
            };
          
            await _context.AddAsync(ww);
            _context.SaveChanges();
            return Ok(ww);
        }
        [HttpGet]
        public IQueryable<WorkDto> GetAllWork()
        {
            var workk = from b in _context.Works
                        select new WorkDto()
                        {
                            Name=b.Name,
                            Task=b.Task
                        };
            return workk;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWork(int id, WorkDto dto)
        {
            if (id != dto.WorkId)
            {
                return BadRequest();
            }

            var wor = await _context.Works.FindAsync(id);
            if (wor == null)
            {
                return NotFound();
            }
            wor.Name = dto.Name;
            wor.Task = dto.Task;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (! WorkExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWork(int id)
        {
            var worr = await _context.Works.FindAsync(id);
            if (worr == null)
            {
                return NotFound();
            }

            _context.Works.Remove(worr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WorkExists(int id)
        {
            return _context.Works.Any(e => e.WorkId == id);
        }


    }
}
