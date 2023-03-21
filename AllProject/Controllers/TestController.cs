using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable> Gettest()
        {


            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate).Include(m => m.Customer).ThenInclude(m => m.Subscription).Include(m => m.Trip).AsEnumerable()
    .Where(s =>   s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.FirstDay ||
                     s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.SecondDay||
                     s.Trip.Location != s.Customer.Subscription.City )
                             .Where(s => s.DayDate.Day == DateTime.Now.Day)
                             //.Where(s => s.Customer.Subscription.Name != "Daily")

                         select new
                         {
                             DayDate = Register.DayDate.DayOfWeek.ToString(),
                             Name = Register.Customer.Name,
                             CustomerQrcode = Register.Customer.QrCode,
                             Location = Register.Trip.Location,
                             city =Register.Customer.Subscription.City
                         }
                             ;
            return mydata;
        }
    }

}
