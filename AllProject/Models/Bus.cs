using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtTest.Models
{
    public class Bus
    {
     

        [Key]
        public int BusId { get; set; }
        public string Number { get; set; }

        public int TripId { get; set; }
        public Trip Trip { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

    }
}
