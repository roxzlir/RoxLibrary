namespace RoxLibrary.Models
{
    public class BookInfoViewModel
    {
        public int BorrowId { get; set; }
        public string BookTitle { get; set; }
        public DateTime BorrowDate { get; set; }
        public BookStatus BorrowStatus { get; set; }
    }
}
