using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;

namespace Store.Tests
{
    public class BookServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllByIsbn() 
        {
            var bookRepository = new Mock<IBookRepository>();
            bookRepository.Setup(x => x.GetAllIsbn(
                It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });
            bookRepository.Setup(x => x.GetAllTitleOrAuthor(
                It.IsAny<string>())).Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepository.Object);

            var validIsbn = "ISBN 12345-54567";

            var actual = bookService.GetAllByQuery(validIsbn);

            Assert.Collection(actual, book => Assert.Equal(1, book.ID));
        }

        [Fact]
        public void GetAllByQuery_WithIsbn_CallsGetAllTitleOrAuthor() 
        {
            var bookRepositary = new Mock<IBookRepository>();
            bookRepositary.Setup(x => x.GetAllIsbn(
                It.IsAny<string>()))
                .Returns(new[] { new Book(1, "", "", "") });

            bookRepositary.Setup(x => x.GetAllTitleOrAuthor(
                It.IsAny<string>()))
                .Returns(new[] { new Book(2, "", "", "") });

            var bookService = new BookService(bookRepositary.Object);

            var invalidIsbn = "12456-65766";
            var actual = bookService.GetAllByQuery(invalidIsbn);

            Assert.Collection(actual, book => Assert.Equal(2, book.ID));

        }
    }
}
