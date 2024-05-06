using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoxLibrary.Data;
using RoxLibrary.Models;

namespace RoxLibrary.Controllers
{
    public class BorrowsController : Controller
    {
        private readonly AppDbContext _context;

        public BorrowsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Start()
        {
            return View();
        }
        // GET: Borrows
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Borrows.Include(b => b.Book).Include(b => b.Customer);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Borrows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // GET: Borrows/Create
        public IActionResult Create()
        {
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookTitle");
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            return View();
        }

        // POST: Borrows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BorrowId,FkCustomerId,FkBookId")] Borrow borrow)
        {
            if (ModelState.IsValid)
            {
                borrow.BorrowStatus = BookStatus.Borrowed;
                borrow.BorrowDate = DateTime.Now;
                borrow.BorrowReturnDate = null;
                _context.Add(borrow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookTitle", borrow.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", borrow.FkCustomerId);
            return View(borrow);
        }

        // GET: Borrows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow == null)
            {
                return NotFound();
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookTitle", borrow.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", borrow.FkCustomerId);
            return View(borrow);
        }

        // POST: Borrows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BorrowId,BorrowDate,BorrowReturnDate,BorrowStatus,FkCustomerId,FkBookId")] Borrow borrow)
        {
            if (id != borrow.BorrowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BorrowExists(borrow.BorrowId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FkBookId"] = new SelectList(_context.Books, "BookId", "BookId", borrow.FkBookId);
            ViewData["FkCustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", borrow.FkCustomerId);
            return View(borrow);
        }

        // GET: Borrows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var borrow = await _context.Borrows
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BorrowId == id);
            if (borrow == null)
            {
                return NotFound();
            }

            return View(borrow);
        }

        // POST: Borrows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var borrow = await _context.Borrows.FindAsync(id);
            if (borrow != null)
            {
                _context.Borrows.Remove(borrow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BorrowExists(int id)
        {
            return _context.Borrows.Any(e => e.BorrowId == id);
        }
    }
}
