using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Data
{
    
    public class BookService
    {
        public static List<Book> BookList { get; set; }

        private AppDataContext appDataContext;

        public BookService(AppDataContext appDataContext)
        {
            this.appDataContext = appDataContext;
        }

        public ICollection<Book> ListAllBooks()
        {
            return appDataContext.Book.ToList();
        }

        public List<Category> GetAllCategories()
        {
            return appDataContext.Category.ToList();
        }
        // phân trang: chạy xem

        public List<Book> GetAllBookOfCategory(int categoryId,ref int totalRecord ,int page=1, int pageSize=1)
        {
            var query = from b in appDataContext.Book
                        join cb in appDataContext.Categorybook on b.Id equals cb.BookId
                        where cb.CategoryId == categoryId
                        select b;
            totalRecord = query.ToList().Count();
            var rs = query.Skip((page -1) * pageSize).Take(pageSize);
            return rs.ToList();
        }

        public Book GetById(int id)
        {
            return appDataContext.Book.Find(id);
        }

        public Dictionary<Book, int> FindAll(Dictionary<int, int> bookIds)
        {
            var query = from kv in bookIds
                select new KeyValuePair<Book, int>(appDataContext.Book.Find(kv.Key), kv.Value);
            return query.ToDictionary(v => v.Key, v => v.Value);
        }

        public Dictionary<Category, int> GetCountCategory()
        {
            var query = from c in appDataContext.Category
                select new KeyValuePair<Category ,int>(c , (from d in appDataContext.Categorybook where c.Id == d.CategoryId select d).Count() );
 
            return query.ToDictionary(v => v.Key, v => v.Value);
        }
       
    }
}