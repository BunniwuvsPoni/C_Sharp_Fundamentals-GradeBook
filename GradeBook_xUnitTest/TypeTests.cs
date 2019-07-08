using System;
using Xunit;
using GradeBook_ConsoleApp;

namespace GradeBook_xUnitTest
{
    //  Delegate used for events
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTests
    {
        //  Start delegate unit test
        int count = 0;

        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;

            //  Can invoke multiple methods, in this case we use the same method
            //  Only requirement is the return and input type and number
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        string IncrementCount(string message)
        {
            count++;
            return message;
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        //  End delegate unit test

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            var upper = MakeUppercase(name);

            //  Strings are a class, a.k.a a reference type, but acts like a value type.
            //  Because strings are immuateable, you must make a copy of the string.
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper(); //  Makes a *copy*
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(out x);

            //  Value is still 3 because even though x is a value and not a reference, C# always uses pass by value (valued is copied)
            //  Value is now 42 beacuse we are now using out to pass by reference
            Assert.Equal(42, x);
        }

        private void SetInt(out int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(out book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetName(out InMemoryBook book, string name) //  Can use ref or out, out assumes that the incomming paramater has not been initialized.
        {
            book = new InMemoryBook(name);  //  Out forces you to initialize the output parameter
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;  //  Not a copy of the data, but rather a reference

            Assert.Same(book1, book2);  //   Tests if the two objects are the same instance (reference)
            Assert.True(object.ReferenceEquals(book1, book2));  //  Assert.Same is basically what is happening on the left, checks if the two objects are the same instance
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
