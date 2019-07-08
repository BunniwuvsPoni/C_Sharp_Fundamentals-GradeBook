using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook_ConsoleApp
{
    //  Adding a delegate for the Grade Added event (Note: is is considered best practice to place this in its own class file)
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        //  Defining properities, gives access to the private string name without allowing public access
        public string Name
        {
            get;
            set;
        }
    }

    //  Interface, cannot implement the functionaly but can define it
    public interface IBook  //  Convention is to always append "I" to the beginning of the name for a interface
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    //  Abstract class
    public abstract class Book : NamedObject, IBook  //  Abstract class, but you can nest inheritance by going one level down
    {
        public Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        //  Every class of a BookBase should have this method, but at this level I cannot determine the logic inside
        public abstract void AddGrade(double grade); //  Abstract method

        public abstract Statistics GetStatistics();   //  "virtual" - a derived class may override this abstract method
    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (var writer = File.AppendText($"{Name}.txt")) //  Using creates and closes the object (i.e. writing to a file, opening sockets) for you so you do not have to close/dispose the object yourself
            {
                writer.WriteLine(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }

            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using(var reader = File.OpenText($"{Name}.txt"))
            {
                var line = reader.ReadLine();

                while(line != null)
                {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }

    public class InMemoryBook : Book    //  C# cannot inherit from multiple classes, can specify multiple interfaces
    {

        public InMemoryBook(string name) : base(name)
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

        public override void AddGrade(double grade) //  Override the class provided in the base class
        {
            if(0 <= grade && grade <= 100)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}, please try again");
            }
        }

        //  Event for subscribing
        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in grades)
            {
                result.Add(grade);
            }

            return result;
        }

        private List<double> grades;

        readonly string category = "Science";   //  Can only be initialized by a constructor, will not be able change this afterwards
        public const string TYPE = "Code"; //  Can never changes this value, public allows access but not change (make all uppercase to follow best practices)
    }
}