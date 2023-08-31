using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvSBookStore.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBookRepository bookRepository;
        public SearchController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IActionResult Index(string query)
        {
            var books = bookRepository.getAllByTitle(query);
            return View(books);
        }
    }
}
