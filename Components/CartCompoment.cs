using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Data;


namespace BookStore.Components
{
    public class CartComponent : ViewComponent
    {
        private BookService _bookService;

        public CartComponent(BookService bookService)
        {
            _bookService = bookService;
        }

        //[HttpGet("Card/AddProduct/{id}")]
        public async Task<IViewComponentResult> InvokeAsync() 
        {
            Dictionary<int, int> bookIds = CardHelper.GetAllProducts(HttpContext);
            Dictionary<Book, int> books = _bookService.FindAll(bookIds); 
      
    
            string referer = Request.Headers["Referer"].ToString();
            ViewData["returnurl"] = referer;

            return View(books);
        }

    }

    public static class CardHelper
    {
        public static void AddProduct(HttpContext context, Book book)
        {
            string bookstr = context.Session.GetString("cart");
            Dictionary<int, int> books = new Dictionary<int, int>();
            if (!String.IsNullOrEmpty(bookstr))
                books = JsonConvert.DeserializeObject<Dictionary<int, int>>(bookstr);

            if (books.ContainsKey(book.Id))
            {
                books[book.Id]++;
            }
            else
            {
                books[book.Id] = 1;
            }

            bookstr = JsonConvert.SerializeObject(books);
            context.Session.SetString("cart", bookstr);
          
        }
                public static Dictionary<int, int> GetAllProducts(HttpContext context)
        {
            string bookstr = context.Session.GetString("cart");
            if (!String.IsNullOrEmpty(bookstr))
            {
                Dictionary<int, int> books = JsonConvert.DeserializeObject<Dictionary<int, int>>(bookstr);
                return books;
            }
            else
            {
                return new Dictionary<int, int>();
            }
        }

    }
}
