using System;
using System.Collections.Generic;

namespace GradeBook_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Bunni's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is: {stats.Low:N2}");
            Console.WriteLine($"The highest grade is: {stats.High:N2}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");
        }
    }
}