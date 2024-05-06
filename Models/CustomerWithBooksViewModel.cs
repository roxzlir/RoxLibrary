namespace RoxLibrary.Models
{
    public class CustomerWithBooksViewModel
    {
        public string CustomerName { get; set; }
        public IEnumerable<BookInfoViewModel> Books { get; set; }
    }
}
