using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoxLibrary.Data;
using RoxLibrary.Models;

namespace RoxLibrary.Controllers
{
    public class CustomerWithBooksController : Controller
    {
        private readonly AppDbContext _context;

        public CustomerWithBooksController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string customerName)
        {
            try
            {
                var query = from borrow in _context.Borrows
                            join book in _context.Books on borrow.FkBookId equals book.BookId
                            join customer in _context.Customers on borrow.FkCustomerId equals customer.CustomerId
                            where customer.CustomerName.Contains(customerName)
                            group new { Book = book, Borrow = borrow } by customer.CustomerName
                            into grp
                            select new CustomerWithBooksViewModel
                            {
                                CustomerName = grp.Key,
                                Books = grp.Select(x => new BookInfoViewModel
                                {
                                    BookTitle = x.Book.BookTitle,
                                    BorrowDate = x.Borrow.BorrowDate,
                                    BorrowStatus = x.Borrow.BorrowStatus,
                                    BorrowId = x.Borrow.BorrowId
                                })
                            };


                var customerWithBooks = await query.ToListAsync();

                return View(customerWithBooks);
            }
            catch (Exception)
            {

                return View(await _context.Customers.ToListAsync());
            }

        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(int borrowId)
        {
            try
            {
                var borrow = await _context.Borrows.FindAsync(borrowId);

                if (borrow == null)
                {
                    return NotFound();
                }

                borrow.BorrowStatus = BookStatus.Returned;
                borrow.BorrowReturnDate = DateTime.Now;

                await _context.SaveChangesAsync();

                return View("ReturnConfirmation");
            }
            catch (Exception)
            {

                return StatusCode(500);
            }
        }
    }
}
