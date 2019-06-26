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

            book.GetStatistics();
        }
    }
}