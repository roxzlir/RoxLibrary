using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace RoxLibrary.Models
{
    public enum BookStatus
    {
        Borrowed, Returned
    }
    public class Borrow
    {
        [Key]
        public int BorrowId { get; set; }
        [Required]
        [DisplayName("Checked out Date")]
        public DateTime BorrowDate { get; set;}
        [AllowNull]
        [DisplayName("Return Date")]
        public DateTime? BorrowReturnDate { get; set; }
        [DisplayName("Status")]
        public BookStatus BorrowStatus { get; set; }
        [ForeignKey("Customer")]
        [DisplayName("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Book")]
        [DisplayName("Book")]
        public int FkBookId { get; set; }
        public Book? Book { get; set; }
    }
}
