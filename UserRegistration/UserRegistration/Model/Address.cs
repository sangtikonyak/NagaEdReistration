using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Model
{
    public class Address
    {
        [Required]
        public string State { get; set; }

        [Required] 
        public string City { get; set; }

        [Required]
        public string PinCode { get; set; }
    }
}
