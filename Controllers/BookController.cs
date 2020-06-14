  
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;


namespace BookStore.Controllers
{
    public class BookController : Controller
    {     private readonly ILogger<HomeController> _logger;
        private readonly BookService _bookService;

        public BookController(ILogger<HomeController> logger, BookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            var books = _bookService.ListAllBooks();
           
            return View(books);
        }

       
    }
}
