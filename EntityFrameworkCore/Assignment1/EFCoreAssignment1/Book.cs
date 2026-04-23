using System;
using System.Collections.Generic;
using System.Text;
using EFCoreAssignment1;

namespace ReadMoreBooks.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public decimal Price { get; set; }
    public int NumberOfPages { get; set; }
    public int PublicationYear { get; set; }
    public bool InStock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public ICollection<Author> Authors { get; set; } = new List<Author>();
}