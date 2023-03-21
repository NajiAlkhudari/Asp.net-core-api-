using JwtTest.Dto;
using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportFinesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportFinesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Route("Getfinesall")]
        [HttpGet]
        public async Task<IEnumerable> Getfinesall()
        {


            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate).Include(m => m.Customer).ThenInclude(m=>m.Subscription).Include(m=>m.Trip).AsEnumerable()
                         //.Where(s=>s.Customer.Subscription.Name != "Daily")
                     .Where(s => s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.FirstDay 
                     ||
                     s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.SecondDay  || s.Trip.Location != s.Customer.Subscription.City)


                         select new
                         {
                             DayDate = Register.DayDate.DayOfWeek.ToString(),
                             Name = Register.Customer.Name,
                             CustomerQrcode = Register.Customer.QrCode,
                             FirstDay = Register.Customer.Subscription.FirstDay,
                             SecondDay = Register.Customer.Subscription.SecondDay,
                             Location = Register.Trip.Location,
                             Type = Register.Trip.Type
                         }
                             ;
            return mydata;
        }


        [Route("Getfinestoday")]
        [HttpGet]
        public async Task<IEnumerable> Getfinestoday()
        {


            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate).Include(m => m.Customer).ThenInclude(m=>m.Subscription).Include(m => m.Trip).AsEnumerable()
                      .Where(s => s.Customer.Subscription.Name != "Daily")
                     .Where(s => s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.FirstDay ||
                     s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.SecondDay||
                     s.Trip.Location != s.Customer.Subscription.City)
                     .Where(s => s.DayDate.Day == DateTime.Now.Day)


                         select new
                         {
                             DayDate = Register.DayDate.DayOfWeek.ToString(),
                             Name = Register.Customer.Name,
                             CustomerQrcode = Register.Customer.QrCode,
                             FirstDay = Register.Customer.Subscription.FirstDay,
                             SecondDay = Register.Customer.Subscription.SecondDay,
                             Location = Register.Trip.Location,
                             Type = Register.Trip.Type,
                             SubscriptionName= Register.Customer.Subscription.Name
                         }
                             ;
            return mydata;
        }

        [Route("Getfinesyesterday")]
        [HttpGet]
        public async Task<IEnumerable> Getfinesyesterday()
        {


            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate).Include(m => m.Customer).ThenInclude(m=>m.Subscription).Include(m => m.Trip).AsEnumerable()
                           //.Where(s => s.Customer.Subscription.Name != "Daily")
                     .Where(s => s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.FirstDay ||
                     s.DayDate.DayOfWeek.ToString() != s.Customer.Subscription.SecondDay ||
                      s.Trip.Location != s.Customer.Subscription.City

                     )
                             .Where(s => s.DayDate.Day == DateTime.Now.Day - 1)


                         select new
                         {
                             DayDate = Register.DayDate.DayOfWeek.ToString(),
                             Name = Register.Customer.Name,
                             CustomerQrcode = Register.Customer.QrCode,
                             FirstDay = Register.Customer.Subscription.FirstDay,
                             SecondDay = Register.Customer.Subscription.SecondDay,
                             Location = Register.Trip.Location,
                             Type = Register.Trip.Type,
                            
                         }
                             ;
            return mydata;
        }






    }

}
