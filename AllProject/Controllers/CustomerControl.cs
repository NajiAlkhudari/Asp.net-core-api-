using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JwtTest.Dto;
using System.Collections;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerControl : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerControl(ApplicationDbContext context)
        {
            _context = context;
        }


        //[HttpGet("{name}")]
        //public async Task<ActionResult<Customer>> GetCustomer(string name)
        //{

        //    var mydata = from Register in _context.Registers
        //           .Where(s => s.Customer.Name == name)
        //                 join Customer in _context.customers
        //                 on Register.CustomerId equals Customer.CustomerId
        //                 select new
        //                 {
        //                     //Name = Register.Customer.Name,
        //                     //PearsonId =Register.CustomerId,
        //                     DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")

        //                 };
          

        //    //var custom = await _context.customers.FindAsync(id);

        //    if (mydata == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(mydata);
        //}

     


        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomeraddDto customer)
        {
            var dto = new Customer()

            {
                CustomerId=customer.CustomerId,
                SubscriptionId=customer.SubscriptionId,
                QrCode = customer.QrCode,
                Name = customer.Name,
                Nickname = customer.Nickname,
                College = customer.College,
                
            };
            await _context.AddAsync(dto);
            _context.SaveChanges();
            return Ok(dto);
        }


        [HttpGet]
        public IQueryable<CustomerDto> GetAll()
        {
            var emp = from b in _context.customers
                      select new CustomerDto ()
                      {
                          CustomerId = b.CustomerId,
                          Name = b.Name,
                          QrCode = b.QrCode,
                          Nickname=b.Nickname,
                          College=b.College,
                          nameSub=b.Subscription.Name,
                          city=b.Subscription.City
                          
                       
                      };
            return emp;
        }





        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomeraddDto dto)
        {
            if (id != dto.CustomerId)
            {
                return BadRequest();
            }

            var custom = await _context.customers.FindAsync(id);
            if (custom == null)
            {
                return NotFound();
            }
            custom.QrCode = dto.QrCode;
            custom.Name = dto.Name;
            custom.Nickname = dto.Nickname;
            custom.College = dto.College;
            custom.SubscriptionId = dto.SubscriptionId;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (! CustomerExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var custom = await _context.customers.FindAsync(id);
            if (custom == null)
            {
                return NotFound();
            }

            _context.customers.Remove(custom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.customers.Any(e => e.CustomerId == id);
        }
    }
}