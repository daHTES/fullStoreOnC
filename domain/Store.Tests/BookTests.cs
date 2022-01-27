using System;
using Xunit;

namespace Store.Tests
{
    public class BookTests
    {
        [Fact]
        public void IsIsbn_WithNull_ReturnFalse()
        {
            bool actual = Book.IsIsbn(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithBlankString_ReturnFalse() 
        {
            bool actual = Book.IsIsbn("   ");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithInvalidIsbn_ReturnFalse() 
        {
            bool actual = Book.IsIsbn("ISBN 1432");

            Assert.False(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn10_ReturnTrue() 
        {
            bool actual = Book.IsIsbn("Isbn 123-543-675 0");
            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithIsbn13_ReturnTrue()
        {
            bool actual = Book.IsIsbn("Isbn 123-567-343 0343");
            Assert.True(actual);
        }

        [Fact]
        public void IsIsbn_WithTrash_ReturnFalse() 
        {
            bool actual = Book.IsIsbn("xxx. Isbn 123-544-877 0123 iuuy");
            Assert.False(actual);
        }

    }
}
