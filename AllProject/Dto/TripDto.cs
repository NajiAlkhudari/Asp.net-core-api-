using System.ComponentModel.DataAnnotations;

namespace JwtTest.Dto
{
    public class TripDto
    {
        public int TripId { get; set; }
        public string Type { get; set; }
        public int CustomerId { get; set; }

          //[DataType(DataType.Date)]
           public string Hour { get; set; }
           public string Location { set; get; }




    }
}
