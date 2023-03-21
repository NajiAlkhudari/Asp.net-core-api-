using System.ComponentModel.DataAnnotations.Schema;

namespace JwtTest.Models
{
    public class Work
    {
      

        public int WorkId    { get; set; }
            public string Name { get; set; }
           public string Task { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }



    }
}
