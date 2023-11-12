using AvSBookStore.Web.App;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace AvSBookStore.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;

        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> Index(string query)
        {
            var books = await bookService.GetAllByQueryAsync(query);

            return View("Index", books);
        }
    }
}
