using Microsoft.AspNetCore.Mvc;

namespace AvSBookStore.Web.Controllers
{
    public class BookController : Controller
    {
        public readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public IActionResult Index(int id)
        {
            Book book = bookRepository.GetById(id);

            return View(book);
        }
    }
}
