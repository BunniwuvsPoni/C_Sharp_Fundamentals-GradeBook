using System;
using System.Collections.Generic;

namespace GradeBook_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Bunni's Grade Book");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded -= OnGradeAdded;    //  Can also subtract using subtract equals
            book.GradeAdded += OnGradeAdded;

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

                //  Try/Catch, used to catch exceptions and move on. In this case, Arugement and Format
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally //  Always, always, always run this code, regardless of what happens (catch or does not catch any exceptions)
                {
                    Console.WriteLine("**");
                }
            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is: {stats.Low:N2}");
            Console.WriteLine($"The highest grade is: {stats.High:N2}");
            Console.WriteLine($"The average grade is: {stats.Average:N2}");
            Console.WriteLine($"The average letter grade is: {stats.Letter}");
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}