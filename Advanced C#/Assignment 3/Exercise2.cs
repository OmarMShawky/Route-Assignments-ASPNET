using System;
using System.Collections.Generic;

public class Exercise2
{
    public static void LeaderBoard()
    {
        var leaderboard = new SortedList<int, string>();

        leaderboard.Add(500, "Ahmed");
        leaderboard.Add(200, "Sara");
        leaderboard.Add(800, "Ali");
        leaderboard.Add(350, "Mona");

        Console.WriteLine("Leaderboard:");

        foreach (var item in leaderboard)
            Console.WriteLine(item.Key + " - " + item.Value);
        

        Console.WriteLine("First score: " + leaderboard.Keys[0]);
        Console.WriteLine("First player: " + leaderboard.Values[0]);

        Console.WriteLine("\nScore 500 exists? " + leaderboard.ContainsKey(500));

        if (leaderboard.TryGetValue(999, out string player))

            Console.WriteLine("Player with score 999: " + player);
        else
            Console.WriteLine("Score 999 not found");

        leaderboard.Remove(200);

        Console.WriteLine("After removing score 200:");
        foreach (var item in leaderboard)
            Console.WriteLine(item.Key + " - " + item.Value);
    }
}