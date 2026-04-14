using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LinqAssignment1;

// instead of repeating List<Product> every time in every question
// the list is called from this class
// we assume that we have list of objects 'products'
// each product has name , price, category
public class GetData
{
    public static List<Product> ProductList()
    {
        return new List<Product>
        {
            new Product {Name = "Fish", Category = "SeaFood" , Price = 30, UnitsInStock=2},
            new Product {Name = "Shrimp", Category = "SeaFood" , Price = 50, UnitsInStock=3},
            new Product {Name = "Meat", Category = "RedMeat" , Price = 40, UnitsInStock=10},
            new Product {Name = "Chicken", Category = "poultry" , Price = 4, UnitsInStock=0},
            new Product {Name = "Apple", Category = "Fruit" , Price = 20, UnitsInStock=0},
            new Product {Name = "Lettuce", Category = "Vegetables" , Price = 10, UnitsInStock=5},
            new Product {Name = "Coca Cola", Category = "Beverages" , Price = 5, UnitsInStock=8}
        };
    }

    public static List<Customer> CustomerList()
    {
        return new List<Customer>
            {
                new Customer
                {
                    CustomerID = "ALFKI", CompanyName = "Alfreds Futterkiste",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10643, OrderDate = new DateTime(1997, 8, 25), Total = 814.50m },
                        new Order { OrderID = 10692, OrderDate = new DateTime(1997, 10, 3), Total = 878.00m },
                        new Order { OrderID = 10702, OrderDate = new DateTime(1997, 10, 13), Total = 330.00m },
                    }
                },
                new Customer
                {
                    CustomerID = "ANATR", CompanyName = "Ana Trujillo Emparedados",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10308, OrderDate = new DateTime(1996, 9, 18), Total = 88.80m },
                        new Order { OrderID = 10625, OrderDate = new DateTime(1997, 8, 8), Total = 479.75m },
                    }
                },
                new Customer
                {
                    CustomerID = "BONAP", CompanyName = "Bon App'",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10331, OrderDate = new DateTime(1996, 10, 16), Total = 88.50m },
                        new Order { OrderID = 10340, OrderDate = new DateTime(1996, 10, 29), Total = 2436.18m },
                        new Order { OrderID = 10663, OrderDate = new DateTime(1997, 9, 10), Total = 1930.40m },
                    }
                },
                new Customer
                {
                    CustomerID = "CONSH", CompanyName = "Consolidated Holdings",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10435, OrderDate = new DateTime(1997, 2, 4), Total = 631.60m },
                        new Order { OrderID = 10462, OrderDate = new DateTime(1997, 3, 3), Total = 156.00m },
                    }
                },
                new Customer
                {
                    CustomerID = "DRACD", CompanyName = "Drachenblut Delikatessen",
                    Orders = new List<Order>
                    {
                        new Order { OrderID = 10363, OrderDate = new DateTime(1996, 11, 26), Total = 447.20m },
                        new Order { OrderID = 10391, OrderDate = new DateTime(1996, 12, 23), Total = 86.40m },
                        new Order { OrderID = 10797, OrderDate = new DateTime(1997, 12, 25), Total = 854.00m },
                    }
                },
            };
    }
}
