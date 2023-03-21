using JwtTest.Dto;
using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthValuesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public AuthValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IQueryable<RegisterUserDto> GetAll()
        {
            var emp = from b in _context.Users
                      select new RegisterUserDto()
                      {
                          Id=b.Id,
                          FirstName = b.FirstName,
                          LastName = b.LastName,
                          Email = b.Email,
                          Username = b.UserName,



                      };
            return emp;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(string id)
        {
            var auth = await _context.Users.FindAsync(id);
            if (auth == null)
            {
                return NotFound();
            }

            _context.Users.Remove(auth);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionExists(string id1)
        {
            return _context.Users.Any(e => e.Id == id1);
        }
    }
}
