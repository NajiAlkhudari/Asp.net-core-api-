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
    public class ReportsAllController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsAllController(ApplicationDbContext context)
        {
            _context = context;
        }





        [Route("outbound")]
        [HttpGet]
        public async Task<IEnumerable> GetOutbound()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")

                         };
            return mydata;
        }


        [Route("outboundhoms")]
        [HttpGet]
        public async Task<IEnumerable> GetOutboundhoms()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                         .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "homs")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("outbounddamascus")]
        [HttpGet]
        public async Task<IEnumerable> GetOutbounddamascus()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "damascus")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                        
                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;

        }


        [Route("outbounddeiratiyah")]
        [HttpGet]
        public async Task<IEnumerable> outbounddeiratiyah()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "Dier Atyah")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("outboundqara")]
        [HttpGet]
        public async Task<IEnumerable> outboundqara()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "qara")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("outboundalnabek")]
        [HttpGet]
        public async Task<IEnumerable> outboundalnabek()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "al nabek")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("outboundyabroud")]
        [HttpGet]
        public async Task<IEnumerable> outboundyabroud()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "yabroud")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Register.Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }

        [Route("inbound")]
        [HttpGet]
        public async Task<IEnumerable> GetInbound()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "inbound")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")

                         };
            return mydata;
        }

        [Route("inboundhoms")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundhoms()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "homs")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("inbounddamascus")]
        [HttpGet]
        public async Task<IEnumerable> GetInbounddamascus()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "damascus")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("inbounddayratiyah")]
        [HttpGet]
        public async Task<IEnumerable> GetInbounddayratiyah()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "Dier Atyah")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }



        [Route("inboundqara")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundqara()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "qara")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }




        [Route("inboundyabroud")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundyabroud()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "yabroud")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("inboundalnabek")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundalnabek()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "al nabek")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("homs")]
        [HttpGet]
        public async Task<IEnumerable> Gethoms()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Location == "homs")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate

                         };

            return mydata;
        }




        [Route("damascus")]
        [HttpGet]
        public async Task<IEnumerable> Getdamascus()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                       .Where(s => s.Trip.Location == "damascus")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate

                         };
            return mydata;
        }

        [Route("DayrAtiyah")]
        [HttpGet]
        public async Task<IEnumerable> GetDayrAtiyah()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Location == "Dayr Atiyah")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate

                         };
            return mydata;
        }

        [Route("qara")]
        [HttpGet]
        public async Task<IEnumerable> Getqara()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Location == "qara")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate

                         };
            return mydata;
        }

        [Route("yabroud")]
        [HttpGet]
        public async Task<IEnumerable> Getyabroud()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Location == "yabroud")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate

                         };
            return mydata;
        }

        [Route("alnabek")]
        [HttpGet]
        public async Task<IEnumerable> Getalnabek()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                    .Where(s => s.Trip.Location == "al nabek")
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate

                         };
            return mydata;
        }


        [HttpGet("{name}")]
        public async Task<ActionResult<Customer>> GetCustomerToday(string name)
        {

            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                   .Where(s => s.Customer.Name == name)
                         join Customer in _context.customers
                         on Register.CustomerId equals Customer.CustomerId
                         select new
                         {
                             Name = Customer.Name,
                             Nickname = Customer.Nickname,
                             QrCode = Customer.QrCode,
                             College = Customer.College,
                             type = Register.Trip.Type,
                             location = Register.Trip.Location,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")


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
