
using System.Collections.Generic;
using AspNetCore_BookStore.Models;

namespace AspNetCore_BookStore.ViewModels
{
    public class HomeViewModel
    {
        public List<BookCardViewModel> Books { get; set; }

        public List<Author> Authors { get; set; }
    }
}
