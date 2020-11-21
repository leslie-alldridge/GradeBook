using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Value_types_are_pass_by_value()
        {
            var x = GetInt();
            SetInt(x);
            Assert.Equal(3, x);
        }

        private void SetInt(int x)
            // Pass by value means that the original variable x above, is unaffected. 
        {
            x = 42;
        }

        [Fact]
        public void Can_reference_int()
        {
            var x = GetInt();
            SetIntRef(ref x);
            Assert.Equal(42, x);
        }

        [Fact]
        public void Score_above_100_rejected()
        {
            var book = new Book("Leslie book");
            book.AddGrade(105);
            Assert.Empty(book.grades);
        }

        private void SetIntRef(ref int x)
        // Using ref will reference the previous variable "x". 
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }
        [Fact]
        public void Get_book_returns_different_objects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");


            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book2, book1);

        }

        [Fact]
        public void Can_set_name_from_reference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void CSharp_is_pass_by_value()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // assert
            Assert.NotEqual("New Name", book1.Name);
            Assert.Equal("Book 1", book1.Name);
        }

        [Fact]
        public void CSharp_can_pass_by_ref()
        {
            // arrange
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");
            // You can also use the "out" parameter instead of ref. Out forces you to initialise the output parameter.

            // assert
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void Two_variables_reference_same_book_object()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;


            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Same(book1, book2);
            Assert.Equal("Book 1", book2.Name);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book1, string name)
        {
            book1.Name = name;
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
        }
    }
}
