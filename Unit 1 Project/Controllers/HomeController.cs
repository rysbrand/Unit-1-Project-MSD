using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Microsoft.Identity.Client;
using Unit_1_Project.Models;

namespace Unit_1_Project.Controllers
{
    public class HomeController : Controller
    {
        private BookContext context {  get; set; }

        public HomeController(BookContext ctx) => context = ctx;

        public IActionResult Index()
        {
            var books = context.Books.Include(b => b.Genre).OrderBy(b => b.title).ToList();
            return View(books);
        }
    }
}
