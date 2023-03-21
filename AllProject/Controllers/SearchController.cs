using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public SearchController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("{qrcode}")]
        public async Task<ActionResult<Customer>> GetCustomerall(int qrcode)
        {

            var mydata = from Register in _context.Registers
                   .Where(s => s.Customer.QrCode == qrcode)
                         join Customer in _context.customers
                         on Register.CustomerId equals Customer.QrCode
                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd"),
                             city=Register.Customer.Subscription.City,
                             location =Register.Trip.Location

                         };



            if (mydata == null)
            {
                return NotFound();
            }
            return Ok(mydata);
        }

    }
}
