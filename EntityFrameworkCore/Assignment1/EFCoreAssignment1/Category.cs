using System;
using System.Collections.Generic;
using System.Text;
using EFCoreAssignment1;

namespace ReadMoreBooks.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public List<Book> Books { get; set; } = [];
}