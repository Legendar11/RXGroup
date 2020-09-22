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
            // TODO: определить фабрику инстанцирования контекста / перенести в DI-контейнер
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
                var booksQuery = db.Books.AsQueryable();

                if (!string.IsNullOrWhiteSpace(name))
                    booksQuery = booksQuery.Where(x => x.Name == name);

                var books = await booksQuery.ToListAsync();
                return View(nameof(BooksController.Index), books);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

            using (var db = new LibraryDbContext())
            {
                db.Books.Add(book);
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(BooksController.Index));
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Book book)
        {
            if (!ModelState.IsValid)
                return View(book);

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