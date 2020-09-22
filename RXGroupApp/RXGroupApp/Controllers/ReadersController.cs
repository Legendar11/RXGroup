using RXGroupApp.DatabaseTools;
using RXGroupApp.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RXGroupApp.Controllers
{
    public class ReadersController : Controller
    {
        public async Task<ActionResult> Index()
        {
            using (var db = new LibraryDbContext())
            {
                var readers = await db.Readers.ToListAsync();
                return View(readers);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Filter(string fio)
        {
            ViewBag.FilterFio = fio;

            using (var db = new LibraryDbContext())
            {
                var readersQuery = db.Readers.AsQueryable();

                if (!string.IsNullOrWhiteSpace(fio))
                    readersQuery = readersQuery.Where(x => x.Fio == fio);

                var readers = await readersQuery.ToListAsync();
                return View(nameof(ReadersController.Index), readers);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            using (var db = new LibraryDbContext())
            {
                db.Readers.Add(reader);
                await db.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ReadersController.Index));
        }

        public async Task<ActionResult> Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var reader = await db.Readers.FirstOrDefaultAsync(x => x.Id == id);
                if (reader == null)
                    throw new NullReferenceException("id reader is null");

                return View(reader);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Reader reader)
        {
            if (!ModelState.IsValid)
                return View(reader);

            using (var db = new LibraryDbContext())
            {
                db.Entry(reader).State = EntityState.Modified;
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(ReadersController.Index));
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            using (var db = new LibraryDbContext())
            {
                var reader = await db.Readers.FirstOrDefaultAsync(x => x.Id == id);
                if (reader == null)
                    throw new NullReferenceException("id reader is null");

                db.Readers.Remove(reader);
                await db.SaveChangesAsync();

                return RedirectToAction(nameof(ReadersController.Index));
            }
        }
    }
}