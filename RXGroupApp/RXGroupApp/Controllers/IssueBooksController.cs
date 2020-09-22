using RXGroupApp.DatabaseTools;
using RXGroupApp.Models;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RXGroupApp.Controllers
{
    public class IssueBooksController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var db = new LibraryDbContext())
            {
                var issuedBooks = await db.IssueBooks
                    .Include(x => x.Book)
                    .Include(x => x.Reader)
                    .ToListAsync();

                return View(issuedBooks);
            }
        }

        public async Task<ActionResult> Create()
        {
            using (var db = new LibraryDbContext())
            {
                var books = await db.Books.Select(x => new
                {
                    Value = x.Id,
                    Text = x.Name
                })
                .ToListAsync();
                var readers = await db.Readers.Select(x => new
                {
                    Value = x.Id,
                    Text = x.Fio
                }).ToListAsync();

                ViewBag.Books = new SelectList(books, "Value", "Text");
                ViewBag.Readers = new SelectList(readers, "Value", "Text");

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IssueBook issueBook)
        {
            if (!ModelState.IsValid)
                return View(issueBook);

            using (var db = new LibraryDbContext())
            {
                db.IssueBooks.Add(issueBook);
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(IssueBooksController.Index));
        }
    }
}