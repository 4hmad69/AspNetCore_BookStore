
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AspNetCore_BookStore.Models;
using AspNetCore_BookStore.ViewModels;

namespace AspNetCore_BookStore.Controllers
{
    public class HomeController : Controller
    {
        

        private static List<Author> authors = new List<Author>
        {
            new Author
            {
                Id = 1,
                Name = "J.K. Rowling",
                Country = "United Kingdom"
            },

            new Author
            {
                Id = 2,
                Name = "George R.R. Martin",
                Country = "United States"
            }
        };

        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Harry Potter",
                Price = 20.50m,
                AuthorId = 1
            },

            new Book
            {
                Id = 2,
                Title = "Game of Thrones",
                Price = 25.00m,
                AuthorId = 2
            },

            new Book
            {
                Id = 3,
                Title = "Chamber of Secrets",
                Price = 22.00m,
                AuthorId = 1
            }
        };

        

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            model.Authors = authors;

            model.Books = books.Select(b => new BookCardViewModel
            {
                Id = b.Id,
                Title = b.Title,
                Price = b.Price,

                AuthorName = authors
                    .FirstOrDefault(a => a.Id == b.AuthorId)?.Name
                    ?? "Unknown Author"

            }).ToList();

            return View(model);
        }

   

        [HttpPost]
        public IActionResult AddBook(string title, decimal price, int authorId)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                int newId = books.Count == 0
                    ? 1
                    : books.Max(b => b.Id) + 1;

                Book newBook = new Book
                {
                    Id = newId,
                    Title = title,
                    Price = price,
                    AuthorId = authorId
                };

                if (authors.Any(a => a.Id == authorId))
                {
                    books.Add(newBook);
                }
            }

            return RedirectToAction("Index");
        }

       
        [HttpPost]
        public IActionResult AddAuthor(string name, string country)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                int newId = authors.Count == 0
                    ? 1
                    : authors.Max(a => a.Id) + 1;

                Author newAuthor = new Author
                {
                    Id = newId,
                    Name = name,
                    Country = country
                };

                authors.Add(newAuthor);
            }

            return RedirectToAction("Index");
        }

    

        [HttpPost]
        public IActionResult RemoveBook(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                books.Remove(book);
            }

            return RedirectToAction("Index");
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
