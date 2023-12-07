﻿using AvSBookStore.Web.App;
using Microsoft.AspNetCore.Mvc;

namespace AvSBookStore.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly BookService bookService;
        public SearchController(BookService bookService)
        {
            this.bookService = bookService;
        }
        public IActionResult Index(string query)
        {
            var books = bookService.GetAllByQuery(query);

            return View("Index", books);
        }
    }
}
