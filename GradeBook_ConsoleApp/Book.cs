using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook_ConsoleApp
{
    public class Book
    {
        public Book(string name)
        {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public void GetStatistics()
        {
            var result = 0.0;
            var highGrade = double.MinValue;
            var lowGrade = double.MaxValue;

            foreach (var grade in grades)
            {
                highGrade = Math.Max(grade, highGrade);
                lowGrade = Math.Min(grade, lowGrade);

                result += grade;
            }

            result /= grades.Count;

            Console.WriteLine($"The highest grade is: {highGrade:N2}");
            Console.WriteLine($"The lowest grade is: {lowGrade:N2}");
            Console.WriteLine($"The average of the grades is: {result:N2}");
        }

        private List<double> grades;
        private string name;
    }
}