using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Score_above_100_rejected()
        {
            var book = new Book("Leslie book");
            book.AddGrade(105);
            Assert.Empty(book.grades);
        }

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
            Assert.Equal('B', result.Letter);
        }
        [Fact]
        public void Book_statistics_do_loop()
        {
            var book = new Book("Leslie book");
            book.AddGrade(90);
            book.AddGrade(72.5);
            book.AddGrade(88.5);
            var result = book.GetStatisticsDoLoop();

            Assert.Equal(90, result.High);
            Assert.Equal(72.5, result.Low);
            Assert.Equal(83.7, result.Average, 1);
        }

        [Fact]
        public void Book_statistics_for_loop()
        {
            var book = new Book("Leslie book");
            book.AddGrade(90);
            book.AddGrade(72.5);
            book.AddGrade(88.5);
            var result = book.GetStatisticsForLoop();

            Assert.Equal(90, result.High);
            Assert.Equal(72.5, result.Low);
            Assert.Equal(83.7, result.Average, 1);
        }
    }
}
