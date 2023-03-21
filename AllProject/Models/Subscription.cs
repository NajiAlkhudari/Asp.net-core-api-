using System.ComponentModel.DataAnnotations;

namespace JwtTest.Models
{
    public class Subscription
    {
          [Key]
        public int SubscriptionId { get; set;  }
        public string Name { set; get; }
        public string City { set; get; }
        public int Price { set; get; }
        public string FirstDay { get; set; }
        public string SecondDay { get; set; }

        public List<Customer> Customers { get; set; }



    }
}
