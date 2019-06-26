using System;
using Xunit;
using GradeBook_ConsoleApp;

namespace GradeBook_xUnitTest
{
    public class TypeTests
    {
        [Fact]
        public void BookTypeTests()
        {
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");

            Assert.Equal("Book1", book1.Name);
            Assert.Equal("Book2", book2.Name);
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
