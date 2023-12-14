using AvSBookStore.Web.App;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AvSBookStore.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;

        public BookController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = await bookService.GetByIdAsync(id);

            return View(model);
        }
    }
}
