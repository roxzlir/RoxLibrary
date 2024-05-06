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
        public DateTime BorrowDate { get; set;}
        [AllowNull]
        public DateTime? BorrowReturnDate { get; set; }
        public BookStatus BorrowStatus { get; set; }
        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }
        [ForeignKey("Book")]
        public int FkBookId { get; set; }
        public Book? Book { get; set; }
    }
}
