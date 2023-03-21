using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtTest.Models
{
    public class Register
    {

        public int RegisterId { get; set; }
            public string Result { get; set; }

            public DateTime DayDate { get; set; }

            public int TripId { get; set; }
            public Trip Trip { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
