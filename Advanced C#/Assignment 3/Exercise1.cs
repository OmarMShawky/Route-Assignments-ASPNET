using System;
using System.Collections.Generic;

public class Exercise1
{
    public static void Grade()
    {
        Console.WriteLine("=== Exercise1 ===\n");

        var grades = new List<int> { 85, 92, 78, 95, 88, 70, 100, 65 };

        Console.WriteLine("Grades: " + string.Join(", ", grades));
        Console.WriteLine("Total grades: " + grades.Count);
        Console.WriteLine("First grade: " + grades[0]);
        Console.WriteLine("Last grade: " + grades[grades.Count - 1]);

        grades.Sort();
        Console.WriteLine("Sorted grades: " + string.Join(", ", grades));

        int highGrade = 0;
        foreach (var grade in grades)
        {
            if (grade > 90)
            {
                highGrade = grade;
                break;
            }
        }
        Console.WriteLine("First grade above 90: " + highGrade);

        var failingGrades = new List<int>();
        foreach (var grade in grades)
        {
            if (grade < 75)
            {
                failingGrades.Add(grade);
            }
        }
        Console.WriteLine("Failing grades: " + string.Join(", ", failingGrades));

        for (int i = grades.Count - 1; i >= 0; i--)
        {
            if (grades[i] < 75)
            {
                grades.RemoveAt(i);
            }
        }
        Console.WriteLine("After removing failing grades: " + string.Join(", ", grades));

        bool hasPerfect = false;
        foreach (var grade in grades)
        {
            if (grade == 100)
            {
                hasPerfect = true;
                break;
            }
        }
        Console.WriteLine("Has perfect score (100)? " + hasPerfect);

        Console.WriteLine("Grades as text:");
        foreach (var grade in grades)
        {
            Console.WriteLine("Grade: " + grade);
        }
    }
}