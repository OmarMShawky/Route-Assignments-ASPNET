using Microsoft.EntityFrameworkCore;
using ReadMoreBooks.Data;
using ReadMoreBooks.Models;

using ReadMoreBooks;
namespace EFCoreAssignment1;

public class Program
{
    public static void Main()
    {
        using var context = new BookstoreContext();
        Console.WriteLine("Creating database");
        bool created = context.Database.EnsureCreated();
        Console.WriteLine(created
            ? "Database created successfully!"
            : "Database already exists.");

        if (!context.Categories.Any())
        {
            var fiction = new Category
            {
                Name = "Fiction",
                Description = "Novels and fictional stories",
                IsActive = true
            };

            var author = new Author
            {
                FirstName = "J.K.",
                LastName = "Rowling",
                Email = "JKRowling@outlook.com",
                Biography = "British female author",
                DateOfBirth = new DateTime(1965, 7, 31)
            };

            var book = new Book
            {
                Title = "Harry Potter and the Half-Blood Prince",
                ISBN = "123456789",
                Price = 20.00m,
                NumberOfPages = 400,
                PublicationYear = 2005,
                InStock = true,
                Category = fiction,
                Authors = new List<Author> { author }
            };

            context.Books.Add(book);
            context.SaveChanges();
            Console.WriteLine("New data added.");
        }

        // Verify the data
        Console.WriteLine("\n--- Current Books ---");
        var books = context.Books
            .Include(b => b.Category)
            .Include(b => b.Authors)
            .ToList();

        foreach (var b in books)
        {
            var authors = string.Join(", ", b.Authors.Select(a => $"{a.FirstName} {a.LastName}"));
            Console.WriteLine($"{b.Title} ({b.PublicationYear}) - {authors} - Category: {b.Category.Name}");
        }
    }
}