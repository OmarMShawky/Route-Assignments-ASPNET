using System;
using System.Collections;
using System.Collections.Generic;

public class Exercise5
{
    public static void PrintQueueSimulator()
    {
        var printQueue = new Queue<string>();

        printQueue.Enqueue("Report.pdf");
        printQueue.Enqueue("Invoice.pdf");
        printQueue.Enqueue("Letter.docx");
        printQueue.Enqueue("Resume.pdf");
        printQueue.Enqueue("Photo.jpg");

        Console.WriteLine("Queue contents:");
        foreach (var doc in printQueue)
        {
            Console.WriteLine(doc);
        }

        Console.WriteLine("Total documents: " + printQueue.Count);

        Console.WriteLine("Next document to print: " + printQueue.Peek());

        Console.WriteLine("Printing...");
        while (printQueue.Count > 0)
        {
            string current = printQueue.Dequeue();
            Console.WriteLine("Printing: " + current);
        }

        Console.WriteLine("Trying to dequeue from empty queue:");
        bool success = printQueue.TryDequeue(out string result);

        Console.WriteLine("Success? " + success);
        Console.WriteLine("Result: " + (result ?? "null"));
    }
}