using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtTest.Dto;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeConstroller : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeeConstroller(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        [HttpGet]
        public IQueryable<EmployeeDto> GetAllEmployee()
        {
            var emp = from b in _context.employees
                      select new EmployeeDto()
                      {
                         EmployeeId=b.EmployeeId,
                          Name=b.Name,
                          Nickname=b.Nickname,
                          Phone=b.Phone

                      };
            return emp;
        }


        [HttpPost]
        public async Task<IActionResult> PostEmployee(EmployeeDto dto)
        {
            var emp = new Employee()
            {
                Name = dto.Name,
                Nickname = dto.Nickname,
                Phone = dto.Phone,          
            };
            await _context.AddAsync(emp);
            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.EmployeeId)
            {
                return BadRequest();
            }

            var emp = await _context.employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            emp.Name = employeeDto.Name;
            emp.Nickname = employeeDto.Nickname;
            emp.Phone = employeeDto.Phone;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EmployeeExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var emp = await _context.employees.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            _context.employees.Remove(emp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.employees.Any(e => e.EmployeeId == id);
        }
    }
}
