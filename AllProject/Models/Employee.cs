using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtTest.Models
{
    public class Employee 
    {
        public int EmployeeId { get; set; }

        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Phone { get; set; }

  
    }
}
