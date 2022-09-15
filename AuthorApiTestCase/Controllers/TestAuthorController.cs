using Author.Controllers;
using Author.Models;
using Author.Repositories;
using AuthorApiTestCase.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorApiTestCase.Controllers
{
    public class TestAuthorController
    {
        [Fact]
        public async Task SearchBooks_200Status()
        {
            //Arrange
            var authorService = new Mock<IAuthorService>();
            authorService.Setup(r => r.SearchBook(string.Empty, string.Empty, string.Empty, 0, string.Empty, 1)).ReturnsAsync(Book2UserMockData.GetBooks());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(authorService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };
                //Act
                var result = await sut.SearchBooks(string.Empty, string.Empty, string.Empty, 0, string.Empty);

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task SearchBooks_204Status()
        {
            //Arrange
            var authorService = new Mock<IAuthorService>();
            authorService.Setup(r => r.SearchBook(string.Empty, string.Empty, string.Empty, 0, string.Empty, 1)).ReturnsAsync(Book2UserMockData.EmptyBooks());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(authorService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };
                //Act
                var result = await sut.SearchBooks(string.Empty, string.Empty, string.Empty, 0, string.Empty);

                //Assert
                result.GetType().Should().Be(typeof(NoContentResult));
                (result as NoContentResult).StatusCode.Should().Be(204);
            }
        }

        [Fact]
        public async Task CreateBook_200Status()
        {
            //Arrange
            var authorService = new Mock<IAuthorService>();
            var newBook = BookMockData.GetBook();
            authorService.Setup(r => r.CreateBook(newBook));

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(authorService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.CreateBook(newBook);

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task EditBook_200Status()
        {
            //Arrange
            var authorService = new Mock<IAuthorService>();
            var book = BookMockData.GetBook();
            authorService.Setup(r => r.EditBook(book));

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(authorService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.EditBook(book);

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task DeleteBook_200Status()
        {
            //Arrange
            var authorService = new Mock<IAuthorService>();
            authorService.Setup(r => r.DeleteBook(1));

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(authorService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.DeleteBook(1);

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task GetBookById_200Status()
        {
            //Arrange
            var readerService = new Mock<IAuthorService>();
            readerService.Setup(r => r.GetBookById(1)).ReturnsAsync(BookMockData.GetBook());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(readerService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.GetBookById("1");

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task GetBookById_204Status()
        {
            //Arrange
            var readerService = new Mock<IAuthorService>();
            readerService.Setup(r => r.GetBookById(1)).ReturnsAsync(BookMockData.GetEmptyBook());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new AuthorController(readerService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.GetBookById("1");

                //Assert
                result.GetType().Should().Be(typeof(NoContentResult));
                (result as NoContentResult).StatusCode.Should().Be(204);
            }
        }
    }
}
