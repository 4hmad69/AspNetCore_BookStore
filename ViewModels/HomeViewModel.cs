using AspNetCore_BookStore.Models;
using System.Collections.Generic;

namespace AspNetCore_BookStore.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel> Books { get; set; }
        public List<Author> Authors { get; set; }
    }
}
