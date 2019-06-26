using System;
using Xunit;
using GradeBook_ConsoleApp;

namespace GradeBook_xUnitTest
{
    public class TypeTests
    {
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
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

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
