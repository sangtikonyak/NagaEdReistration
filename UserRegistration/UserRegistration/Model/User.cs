using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Model
{
    public class User
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Address Address { get; set; }

    }
}
