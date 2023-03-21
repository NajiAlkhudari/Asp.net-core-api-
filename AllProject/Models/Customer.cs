using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JwtTest.Models
{
    public class Customer 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CustomerId { get; set; }

  
        public  int QrCode { get; set; }
        public string Name { get; set; }    
        public string Nickname { get; set; }
        public string College { set; get; }


        public List<Register> Registers { get; set; }


        public int SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

    }
}
