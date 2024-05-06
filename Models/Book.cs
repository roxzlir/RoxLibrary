using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RoxLibrary.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [DisplayName("Title")]
        [StringLength(50)]
        public string BookTitle { get; set; }
        [DisplayName("Author")]
        [StringLength(30)]
        public string BookAuthor { get; set; }
        [DisplayName("Genre")]
        [StringLength(15)]
        public string BookGenre { get; set; }
        [DisplayName("Quantity")]
        public int BookQuantity { get; set; }
        public List<Borrow>? Borrows { get; set; }
    }
}
