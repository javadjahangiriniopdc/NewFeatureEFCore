using System.ComponentModel.DataAnnotations;

namespace NewFeatureEFCore.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
