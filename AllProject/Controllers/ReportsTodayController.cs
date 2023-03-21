using JwtTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace JwtTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsTodayController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsTodayController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("outbound")]
        [HttpGet]
        public async Task<IEnumerable> GetOutboundToday()
        {
            var mydata = from Register in _context.Registers
                      .Where(s => s.Trip.Type == "outbound" && s.DayDate.Day == DateTime.Now.Day)
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")

                         };
            return mydata;
        }


        [Route("outboundhoms")]
        [HttpGet]
        public async Task<IEnumerable> GetOutboundhomsToday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                         .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "homs" && s.DayDate.Day == DateTime.Now.Day)
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Register.Trip.Location,
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;

        }


        [Route("outboundtoday")]
        [HttpGet]
        public async Task<IEnumerable> outboundtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.DayDate.Day == DateTime.Now.Day)
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.CustomerId,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")

                         };
            return mydata;
        }


        [Route("outboundhomstoday")]
        [HttpGet]
        public async Task<IEnumerable> GetOutboundhomstoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                         .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "homs" && s.DayDate.Day == DateTime.Now.Day)
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId

                         select new

                         {
                             Location = Register.Trip.Location,
                             Name = Register.Customer.Name,
                             QrCode = Register.Customer.QrCode,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")
                         };
            return mydata;
        }


        [Route("outbounddamascustoday")]
        [HttpGet]
        public async Task<IEnumerable> GetOutbounddamascustoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "damascus" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("outbounddeiratiyahtoday")]
        [HttpGet]
        public async Task<IEnumerable> outbounddeiratiyahtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "Dier Atyah" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("outboundqaratoday")]
        [HttpGet]
        public async Task<IEnumerable> outboundqaratoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "qara" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("outboundalnabektoday")]
        [HttpGet]
        public async Task<IEnumerable> outboundalnabektoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "al nabek" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("outboundyabroudtoday")]
        [HttpGet]
        public async Task<IEnumerable> outboundyabroudtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "outbound" && s.Trip.Location == "yabroud" && s.DayDate.Day == DateTime.Now.Day)
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

        [Route("inboundtoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Type == "inbound" && s.DayDate.Day == DateTime.Now.Day)
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

        [Route("inboundhomstoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundhomstoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "homs" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("inbounddamascustoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInbounddamascustoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "damascus" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("inbounddayratiyahtoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInbounddayratiyahtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "Dier Atyah" && s.DayDate.Day == DateTime.Now.Day)
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



        [Route("inboundqaratoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundqaratoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "qara" && s.DayDate.Day == DateTime.Now.Day)
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




        [Route("inboundyabroudtoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundyabroudtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "yabroud" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("inboundalnabektoday")]
        [HttpGet]
        public async Task<IEnumerable> GetInboundalnabektoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Type == "inbound" && s.Trip.Location == "al nabek" && s.DayDate.Day == DateTime.Now.Day)
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


        [Route("homstoday")]
        [HttpGet]
        public async Task<IEnumerable> Gethomstoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Location == "homs" && s.DayDate.Day == DateTime.Now.Day)
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




        [Route("damascustoday")]
        [HttpGet]
        public async Task<IEnumerable> Getdamascustoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                       .Where(s => s.Trip.Location == "damascus" && s.DayDate.Day == DateTime.Now.Day)
                         join Trip in _context.Trips
                         on Register.TripId equals Trip.TripId
                         select new
                         {
                             Location = Trip.Location,
                             Name = Register.Customer.Name,
                             Nickname = Register.Customer.Nickname,
                             QrCode = Register.Customer.CustomerId,
                             DayDate = Register.DayDate.ToUniversalTime().ToString("yyyy-MM-dd")

                         };
            return mydata;
        }

        [Route("DayrAtiyahtoday")]
        [HttpGet]
        public async Task<IEnumerable> GetDayrAtiyahtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Location == "Dayr Atiyah" && s.DayDate.Day == DateTime.Now.Day)
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

        [Route("qaratoday")]
        [HttpGet]
        public async Task<IEnumerable> Getqaratoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                     .Where(s => s.Trip.Location == "qara" && s.DayDate.Day == DateTime.Now.Day)
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

        [Route("yabroudtoday")]
        [HttpGet]
        public async Task<IEnumerable> Getyabroudtoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                      .Where(s => s.Trip.Location == "yabroud" && s.DayDate.Day == DateTime.Now.Day)
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

        [Route("alnabektoday")]
        [HttpGet]
        public async Task<IEnumerable> Getalnabektoday()
        {
            var mydata = from Register in _context.Registers.OrderByDescending(t => t.DayDate)
                    .Where(s => s.Trip.Location == "al nabek" && s.DayDate.Day == DateTime.Now.Day)
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

    }
}