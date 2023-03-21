using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtTest.Dto;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RegisterController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostRegister(RegisterDto dto)
        {
            var rr = new Register()
                {

                    TripId = dto.TripId,
                    DayDate = DateTime.Now,
                    Result =dto.Result,
                    CustomerId = dto.QrCode

                };

                await _context.AddAsync(rr);
                _context.SaveChanges();
                return Ok(rr);

            }
        
      

        [HttpGet]
        public IQueryable<CustomerDto> GetRegister()
        {
            var reg = from b in _context.Registers/*.OrderByDescending(t => t.DayDate)*/
                          //.Where(t=>t.Trip.Type== "outbound")
                      select new CustomerDto()
                      {

                          Name = b.Customer.Name,



                      };
            return reg;
        }

        //private Customer GetCustomer(int qrcode)
        //{
        //    var lista = _context.customers.ToList();
        //    var MYCustomer = new Customer();
        //    foreach(var x in lista)
        //    {
        //        if (x.QrCode==qrcode)
        //        {
        //            MYCustomer = x;
        //        }
        //    }
        //    return MYCustomer;
        //          }

    }
}
