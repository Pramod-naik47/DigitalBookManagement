using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TokenAuthentication.Controllers;
using TokenAuthentication.Services;
using TokenAuthenticationTestCase.MockData;


namespace TokenAuthenticationTestCase.Controllers
{
    public class TestTokenAuthenticationController
    {
        [Fact]
        public async Task Validate_200Status()
        {
            //Arrange
            var tokenService = new Mock<IAuthorTokenService>();
            var tokenConfiguration = new Mock<IConfiguration>();
            var user = UserMockData.GetUser();
            tokenService.Setup(r => r.ValidateUser(user.UserName, user.Password, user.UserType));

            var sut = new TokenAuthenticationController(tokenService.Object, tokenConfiguration.Object);

            //Act
            var result = await sut.Validate(user);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CheckExistingUser_200Status()
        {
            //Arrange
            var tokenService = new Mock<IAuthorTokenService>();
            var tokenConfiguration = new Mock<IConfiguration>();
            var user = UserMockData.GetUser();
            tokenService.Setup(r => r.CheckExistingUser(user.UserName, user.UserType));

            var sut = new TokenAuthenticationController(tokenService.Object, tokenConfiguration.Object);

            //Act
            var result = await sut.CheckExistingUser(user);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }
    }
}
