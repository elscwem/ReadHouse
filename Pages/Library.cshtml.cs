using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReadHouse.Pages
{
    public class LibraryModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;
  
    public List<Book> Books { get; set; } = new();

        public void OnGet()
        {
            var allBooks = new List<Book>
        {
            new Book { Title = "Harry Potter and the Philosopher's Stone", Author = "J. K. Rowling", Language = "English" },
            new Book { Title = "The Little Prince", Author = "Antoine de Saint-Exupéry", Language = "English" },
            new Book { Title = "1984", Author = "George Orwell", Language = "English" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Language = "English" },
            new Book { Title = "Alice's Adventures in Wonderland", Author = "Lewis Carroll", Language = "English" }
        };

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                Books = allBooks
                    .Where(book =>
                        book.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                        book.Author.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else
            {
                Books = allBooks;
            }
        }

        public class Book
        {
            public string Title { get; set; } = string.Empty;
            public string Author { get; set; } = string.Empty;
            public string Language { get; set; } = string.Empty;
        }
    }


}
