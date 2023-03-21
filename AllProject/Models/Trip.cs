using System.ComponentModel.DataAnnotations;

namespace JwtTest.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Type { get; set; }
        [DataType(DataType.Date)]
        public string Hour { get; set; }
        public string Location { set; get; }

           public List<Bus>Buses { get; set;}
        public List<Register> Registers { get; set; }

       
            
        }
    }

