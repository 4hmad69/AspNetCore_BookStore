using System.Diagnostics;
using AspNetCore_BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using AspNetCore_BookStore.ViewModels;
using System.Linq;

namespace AspNetCore_BookStore.Controllers
{
    public class HomeController : Controller
    {
 
        private static List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, Name = "J.K. Rowling", Country = "UK" },
            new Author { Id = 2, Name = "George R.R. Martin", Country = "USA" }
        };

        private static List<Book> _books = new List<Book>
        {
            new Book { Id = 1, Title = "Harry Potter", Price = 20.50m, AuthorId = 1 },
            new Book { Id = 2, Title = "Game of Thrones", Price = 25.00m, AuthorId = 2 },
            new Book { Id = 3, Title = "Chamber of Secrets", Price = 22.00m, AuthorId = 1 }
        };
        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Authors = _authors;
            vm.Books = new List<BookCardViewModel>();

            foreach (var book in _books)
            {
                var author = _authors.FirstOrDefault(a => a.Id == book.AuthorId);
                vm.Books.Add(new BookCardViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price,
                    AuthorName = author != null ? author.Name : "Unknown"
                });
            }
            return View(vm);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
