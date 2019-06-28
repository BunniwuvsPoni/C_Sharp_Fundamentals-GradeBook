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
            Name = name;
        }

        public void AddGrade(char letter)   // Method overload, using the same method name as AddGrade below. Based on the method signature (Method name + input type, does not care for the return type)
        {
            switch(letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public void AddGrade(double grade)
        {
            if(0 <= grade && grade <= 100)
            {
                grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}, please try again");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade, result.Low);

                result.Average += grade;
            }

            result.Average /= grades.Count;
            
            switch(result.Average)
            {
                case var d when d >= 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.Letter = 'C';
                    break;

                case var d when d >= 60.0:
                    result.Letter = 'D';
                    break;

                default:
                    result.Letter = 'F';
                    break;
            }


            return result;
        }

        private List<double> grades;

        //  Defining properities, gives access to the private string name without allowing public access
        public string Name
        {
            get;
            private set;
        }

        readonly string category = "Science";   //  Can only be initialized by a constructor, will not be able change this afterwards
        public const string TYPE = "Code"; //  Can never changes this value, public allows access but not change (make all uppercase to follow best practices)
    }
}