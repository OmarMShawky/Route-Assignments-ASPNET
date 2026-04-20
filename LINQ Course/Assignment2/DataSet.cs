using System.Collections.Generic;

namespace LinqAssignment2;


public static class DataSet
{
    public static List<Product> Products { get; } = new List<Product>
    {
        new Product { ProductID = 1,  ProductName = "Chai",                            Category = "Beverages",    UnitPrice = 18.00m, UnitsInStock = 39 },
        new Product { ProductID = 2,  ProductName = "Chang",                           Category = "Beverages",    UnitPrice = 19.00m, UnitsInStock = 17 },
        new Product { ProductID = 3,  ProductName = "Aniseed Syrup",                   Category = "Condiments",   UnitPrice = 10.00m, UnitsInStock = 13 },
        new Product { ProductID = 4,  ProductName = "Chef Anton's Cajun Seasoning",    Category = "Condiments",   UnitPrice = 22.00m, UnitsInStock = 53 },
        new Product { ProductID = 5,  ProductName = "Chef Anton's Gumbo Mix",          Category = "Condiments",   UnitPrice = 21.35m, UnitsInStock = 0  },
        new Product { ProductID = 6,  ProductName = "Grandma's Boysenberry Spread",    Category = "Condiments",   UnitPrice = 25.00m, UnitsInStock = 120},
        new Product { ProductID = 7,  ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce",      UnitPrice = 30.00m, UnitsInStock = 15 },
        new Product { ProductID = 8,  ProductName = "Northwoods Cranberry Sauce",      Category = "Condiments",   UnitPrice = 40.00m, UnitsInStock = 6  },
        new Product { ProductID = 9,  ProductName = "Mishi Kobe Niku",                 Category = "Meat/Poultry", UnitPrice = 97.00m, UnitsInStock = 29 },
        new Product { ProductID = 10, ProductName = "Ikura",                           Category = "Seafood",      UnitPrice = 31.00m, UnitsInStock = 31 },
        new Product { ProductID = 11, ProductName = "Queso Cabrales",                  Category = "Dairy",        UnitPrice = 21.00m, UnitsInStock = 22 },
        new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora",       Category = "Dairy",        UnitPrice = 38.00m, UnitsInStock = 86 },
        new Product { ProductID = 13, ProductName = "Konbu",                           Category = "Seafood",      UnitPrice = 6.00m,  UnitsInStock = 24 },
        new Product { ProductID = 14, ProductName = "Tofu",                            Category = "Produce",      UnitPrice = 23.25m, UnitsInStock = 35 },
        new Product { ProductID = 15, ProductName = "Genen Shouyu",                    Category = "Condiments",   UnitPrice = 15.50m, UnitsInStock = 39 },
        new Product { ProductID = 16, ProductName = "Pavlova",                         Category = "Confections",  UnitPrice = 17.45m, UnitsInStock = 29 },
        new Product { ProductID = 17, ProductName = "Alice Mutton",                    Category = "Meat/Poultry", UnitPrice = 39.00m, UnitsInStock = 0  },
        new Product { ProductID = 18, ProductName = "Carnarvon Tigers",                Category = "Seafood",      UnitPrice = 62.50m, UnitsInStock = 42 },
        new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits",      Category = "Confections",  UnitPrice = 9.20m,  UnitsInStock = 25 },
        new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade",          Category = "Confections",  UnitPrice = 81.00m, UnitsInStock = 40 }
    };

    public static List<Customer> Customers { get; } = new List<Customer>
    {
        new Customer { CustomerID = 1,  CompanyName = "Alfreds Futterkiste",        Country = "Germany" },
        new Customer { CustomerID = 2,  CompanyName = "Ana Trujillo Emparedados",   Country = "Mexico"  },
        new Customer { CustomerID = 3,  CompanyName = "Antonio Moreno Taqueria",    Country = "Mexico"  },
        new Customer { CustomerID = 4,  CompanyName = "Around the Horn",            Country = "UK"      },
        new Customer { CustomerID = 5,  CompanyName = "Berglunds snabbkop",         Country = "Sweden"  },
        new Customer { CustomerID = 6,  CompanyName = "Blauer See Delikatessen",    Country = "Germany" },
        new Customer { CustomerID = 7,  CompanyName = "Blondesddsl pere et fils",   Country = "France"  },
        new Customer { CustomerID = 8,  CompanyName = "Bolido Comidas preparadas",  Country = "Spain"   },
        new Customer { CustomerID = 9,  CompanyName = "Bon app'",                   Country = "France"  },
        new Customer { CustomerID = 10, CompanyName = "Bottom-Dollar Markets",      Country = "Canada"  }
    };

    public static List<Order> Orders { get; } = new List<Order>
    {
        new Order { OrderID = 1,  CustomerID = 1,  Total = 250m },
        new Order { OrderID = 2,  CustomerID = 1,  Total = 100m },
        new Order { OrderID = 3,  CustomerID = 2,  Total = 75m  },
        new Order { OrderID = 4,  CustomerID = 3,  Total = 300m },
        new Order { OrderID = 5,  CustomerID = 4,  Total = 500m },
        new Order { OrderID = 6,  CustomerID = 5,  Total = 220m },
        new Order { OrderID = 7,  CustomerID = 6,  Total = 180m },
        new Order { OrderID = 8,  CustomerID = 7,  Total = 90m  },
        new Order { OrderID = 9,  CustomerID = 8,  Total = 410m },
        new Order { OrderID = 10, CustomerID = 9,  Total = 60m  },
        new Order { OrderID = 11, CustomerID = 9,  Total = 145m },
        new Order { OrderID = 12, CustomerID = 10, Total = 320m }
    };
}