using System;
using System.Collections.Generic;

public class Exercise3
{
    public static void PhoneBook()
    {
        var phoneBook = new Dictionary<string, string>();

        phoneBook.Add("Ahmed", "01011111111");
        phoneBook.Add("Sara", "01022222222");
        phoneBook.Add("Ali", "01033333333");
        phoneBook.Add("Mona", "01044444444");

        phoneBook["Omar"] = "01055555555";
        phoneBook["Ahmed"] = "01099999999";

        try
        {
            phoneBook.Add("Sara", "01000000000");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error adding duplicate with Add(): " + ex.Message);
        }

        bool added = phoneBook.TryAdd("Ali", "01000000000");
        Console.WriteLine("TryAdd for Ali succeeded? " + added);

        if (phoneBook.ContainsKey("Khaled"))
        {
            Console.WriteLine("Khaled: " + phoneBook["Khaled"]);
        }
        else
        {
            Console.WriteLine("Khaled not found");
        }

        string result;
        if (phoneBook.TryGetValue("Khaled", out result))
        {
            Console.WriteLine("Khaled: " + result);
        }
        else
        {
            Console.WriteLine("Khaled: Not Found");
        }

        Console.WriteLine("\nNames: ");
        foreach (var name in phoneBook.Keys)
        {
            Console.WriteLine(name + " ");
        }

        Console.WriteLine("Phones: ");
        foreach (var phone in phoneBook.Values)
        {
            Console.WriteLine(phone + " ");
        }
    }
}