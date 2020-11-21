using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Book_calculates_an_average_grade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(90.5, result.High);
            Assert.Equal(77.3, result.Low);
            Assert.Equal(85.6, result.Average, 1);
        }
        [Fact]
        public void Strings_behave_like_value_types()
        {
            string name = "Leslie";
            var upper = MakeUpperCase(name);
            Assert.Equal("LESLIE", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }
    }
}
