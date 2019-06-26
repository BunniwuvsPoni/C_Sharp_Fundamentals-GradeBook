using System;
using Xunit;
using C_Sharp_Fundamentals_GradeBook_ConsoleApp;

namespace GradeBook_xUnitTest
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {
            //  Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //  Act
            book.ShowStatistics();

            //  Assert

        }
    }
}
