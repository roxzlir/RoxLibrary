using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RoxLibrary.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        [DisplayName("Name")]
        [StringLength(45, MinimumLength = 10)]
        public string CustomerName { get; set; }
        [Required]
        [DisplayName("Phone number")]
        [StringLength(15)]
        public string CustomerPhone { get; set; }
        [DisplayName("Email")]
        [StringLength(120)]
        public string CustomerEmail { get; set; }
        public List<Borrow>? Borrows { get; set; }

    }
}
