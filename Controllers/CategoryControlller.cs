using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BookService _bookService;

        public CategoryController(BookService bookService)
        {
            _bookService = bookService;
        }
        // [HttpGet("Category/Detail/{id}")]
        // GET: /<controller>/
        public IActionResult Index(int id , int page=1, int pageSize=1)
        {
           // int page = Convert.ToInt32(HttpContext.Request.Query["page"]);
            // int page = ConverIn HttpContext.Request.Query["page"];
            int totalRecord = 0;
            ViewData["GetAllBookOfCategory"] = _bookService.GetAllBookOfCategory(id,ref totalRecord,page,pageSize);
            
            ViewData["list1"] = _bookService.GetCountCategory();
            var books = _bookService.ListAllBooks();
            // var books = _bookService.GetAllBookOfCategory(id,ref totalRecord,page,pageSize);
            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.IdCategory = id;
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(books);
        }
        
    }
}