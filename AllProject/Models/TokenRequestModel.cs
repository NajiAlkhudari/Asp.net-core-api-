using System.ComponentModel.DataAnnotations;

namespace JwtTest.Models
{
    public class TokenRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
