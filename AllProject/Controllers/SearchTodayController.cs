using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchTodayController : ControllerBase
    {


        private readonly ApplicationDbContext _context;

        public SearchTodayController(ApplicationDbContext context)
        {
            _context = context;
        }




        [HttpGet("{qrcode}")]
        public async Task<ActionResult<Customer>> GetCustomertoday(int qrcode)
        {

            var mydata = from Register in _context.Registers
                   .Where(s => s.Customer.QrCode == qrcode && s.DayDate.Day == DateTime.Now.Day)
                         join Customer in _context.customers
                         on Register.CustomerId equals Customer.QrCode
                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd"),
                             city = Register.Customer.Subscription.City,
                             location = Register.Trip.Location


                         };


            //var custom = await _context.customers.FindAsync(id);

            if (mydata == null)
            {
                return NotFound();
            }
            return Ok(mydata);
        }


    }
}


