using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Reader.Controllers;
using Reader.Repsitories;
using ReaderApiTestCase.Helper;
using ReaderApiTestCase.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReaderApiTestCase.Controllers
{
    public class TestReaderController
    {
        [Fact]
        public async Task SearchBooks_200Status()
        {
            //Arrange
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.SearchBook(string.Empty, string.Empty, string.Empty, 0, string.Empty)).ReturnsAsync(Book2UserMockData.GetBooks());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
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
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.SearchBook(string.Empty, string.Empty, string.Empty, 0, string.Empty)).ReturnsAsync(Book2UserMockData.EmptyBooks());
            
            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
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
        public async Task GetPaymentHistory_200Status()
        {
            //Arrange
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.GetPaymentHistory(1)).ReturnsAsync(PaymentMockData.GetPaymentHistory());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };
                //Act
                var result = await sut.GetPaymentHistory();

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task GetPaymentHistory_204Status()
        {
            //Arrange
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.GetPaymentHistory(1)).ReturnsAsync(PaymentMockData.EmptyPaymentHistory());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };
                //Act
                var result = await sut.GetPaymentHistory();

                //Assert
                result.GetType().Should().Be(typeof(NoContentResult));
                (result as NoContentResult).StatusCode.Should().Be(204);
            }
        }

        [Fact]
        public async Task GetBookById_200Status()
        {
            //Arrange
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.GetBookById(1)).ReturnsAsync(BookMockData.GetBook());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
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
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.GetBookById(1)).ReturnsAsync(BookMockData.GetEmptyBook());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
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

        [Fact]
        public async Task GetBookByIdForPayment_200Status()
        {
            //Arrange
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.GetBookByIdForPayment(1)).ReturnsAsync(PaymentMockData.GetBook());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.GetBookByIdForPayment("1");

                //Assert
                result.GetType().Should().Be(typeof(OkObjectResult));
                (result as OkObjectResult).StatusCode.Should().Be(200);
            }
        }

        [Fact]
        public async Task GetBookByIdForPayment_204Status()
        {
            //Arrange
            var readerService = new Mock<IReaderService>();
            readerService.Setup(r => r.GetBookByIdForPayment(1)).ReturnsAsync(PaymentMockData.GetEmptyBook());

            var httpContext = MockHttpContext.DefaultMockHttpContext();
            if (httpContext != null)
            {
                var sut = new ReaderController(readerService.Object)
                {
                    ControllerContext = new ControllerContext()
                    {
                        HttpContext = httpContext
                    }
                };

                //Act
                var result = await sut.GetBookByIdForPayment("1");

                //Assert
                result.GetType().Should().Be(typeof(NoContentResult));
                (result as NoContentResult).StatusCode.Should().Be(204);
            }
        }
    }
}
