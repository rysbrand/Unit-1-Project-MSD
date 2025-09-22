using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using Unit_1_Project.Models;

namespace Unit_1_Project.Controllers
{
    public class BookController : Controller
    {
        private BookContext context {  get; set; }

        public BookController(BookContext ctx) => context = ctx;

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genre = context.Genres.OrderBy(g => g.genre).ToList();
            return View("Edit", new Book());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genre = context.Genres.OrderBy(g => g.genre).ToList();
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.bookID == 0)
                {
                    context.Books.Add(book);
                }
                else
                {
                    context.Books.Update(book);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = (book.bookID == 0) ? "Add" : "Edit";
                ViewBag.Genre = context.Genres.OrderBy(g => g.genre).ToList();
                return View(book);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            context.Books.Remove(book);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
            
    }
}
