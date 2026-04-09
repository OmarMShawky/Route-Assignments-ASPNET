using System;
using System.Collections.Generic;

public class Exercise6
{
    public static void BrowserHistory()
    {
        var history = new Stack<string>();

        history.Push("google.com");
        history.Push("github.com");
        history.Push("stackoverflow.com");
        history.Push("youtube.com");
        history.Push("claude.ai");

        Console.WriteLine("Current page: " + history.Peek());

        Console.WriteLine("Going back...");
        for (int i = 0; i < 3; i++)
        {
            string leftPage = history.Pop();
            Console.WriteLine("Leaving: " + leftPage);
        }

        Console.WriteLine("\nCurrent page now: " + history.Peek());

        while (history.Count > 0)
        {
            history.Pop();
        }

        Console.WriteLine("Trying TryPop on empty stack:");
        bool success = history.TryPop(out string result);

        Console.WriteLine("Success? " + success);
        Console.WriteLine("Result: " + (result ?? "null"));
    }
}