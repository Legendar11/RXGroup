using RXGroupApp.DatabaseTools;
using RXGroupApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RXGroupApp.Controllers
{
    public class BooksController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var db = new LibraryDbContext())
            {
                var books = await db.Books.ToListAsync();
                return View(books);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Filter(string name)
        {
            ViewBag.FilterName = name;

            using (var db = new LibraryDbContext())
            {
                var books = await db.Books.Where(x => x.Name == name).ToListAsync();
                return View(nameof(BooksController.Index), books);
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (book == null)
                    throw new NullReferenceException("id book is null");

                return View(book);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                db.Entry(book).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(BooksController.Index));
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            using (var db = new LibraryDbContext())
            {
                var book = await db.Books.FirstOrDefaultAsync(x => x.Id == id);
                if (book == null)
                    throw new NullReferenceException("id book is null");

                db.Books.Remove(book);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(BooksController.Index));
            }
        }
    }
}