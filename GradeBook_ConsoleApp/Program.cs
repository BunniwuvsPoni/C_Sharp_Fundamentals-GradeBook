using System;
using System.Collections.Generic;

namespace GradeBook_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Bunni's Grade Book");

            //  Instructions
            Console.WriteLine("Please input your grades, input 'q' to compute the statistics");

            while(true)
            {
                //  Accepts user input
                var input = Console.ReadLine();

                //  Checks if user input is 'q', exit if true
                if (input == "q")
                {
                    break;
                }

                //  Try/Catch, used to catch exception and move on
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is: {stats.Low:N2}");
            Console.WriteLine($"The highest grade is: {stats.High:N2}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");
        }
    }
}