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
    public class SubscriptionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscription(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);

            if (subscription == null)
            {
                return NotFound();
            }

            return subscription;
        }




        [HttpPost]
        public async Task<IActionResult> PostSubscription(SubscriptionDto subscription)
        {
            var dto = new Subscription()
            {
                Name=subscription.Name,
                City=subscription.City,
                Price=subscription.Price,
                FirstDay=subscription.FirstDay,
                SecondDay=subscription.SecondDay
             
            };
            await _context.AddAsync(dto);
            _context.SaveChanges();
            return Ok(dto);
        }

        [HttpGet]
        public IQueryable<SubscriptionDto> GetAll()
        {
            var emp = from b in _context.Subscriptions
                      select new SubscriptionDto()
                      {
                          SubscriptionId=b.SubscriptionId,
                          Name = b.Name,
                          City = b.City,
                          FirstDay = b.FirstDay,
                          SecondDay = b.SecondDay,
                          Price = b.Price

                      };
            return emp;
        }
        //  [HttpGet]
        //public async Task <IEnumerable> Get()
        //{
        //    var mydata = from Subscription in _context.Subscriptions
        //                 join Customer in _context.customers
        //                 on Subscription.SubscriptionId equals Customer.SubscriptionId
        //                 where Subscription.City == "homs"

        //                 select new
        //                 {
        //                     QrCode=Customer.QrCode,
        //                     Name =Subscription.Name,
        //                     NameCustomer=Customer.Name,
        //                     City=Subscription.City

        //                 };
        //    return mydata;
        //}




        // PUT: api/TodoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSubscription(int id, SubscriptionDto subscriptionDto)
        {
            if (id != subscriptionDto.SubscriptionId)
            {
                return BadRequest();
            }

            var subdto = await _context.Subscriptions.FindAsync(id);
            if (subdto == null)
            {
                return NotFound();
            }

            subdto.Name = subscriptionDto.Name;
            subdto.City = subscriptionDto.City;
            subdto.Price = subscriptionDto.Price;
            subdto.FirstDay = subscriptionDto.FirstDay;
            subdto.SecondDay = subscriptionDto.SecondDay;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (! SubscriptionExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscription(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.SubscriptionId == id);
        }
    }
}
