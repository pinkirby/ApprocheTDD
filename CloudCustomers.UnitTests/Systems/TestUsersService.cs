using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudCustomers.API.Services;
using CloudCustomers.UnitTests.Helpers;
using CloudCustomers.API.Models;
using CloudCustomers.UnitTests.Fixtures;
using Moq.Protected;
using Moq;
using FluentAssertions;

namespace CloudCustomers.UnitTests.Systems
{
    public class TestUsersService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest() {

            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UsersService(httpClient);

            //Act
            await sut.GetAllUsers();

            //Assert
            handlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    Times.Exactly(1),
                    ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                    ItExpr.IsAny<CancellationToken>()
                );

        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListOfUsers() {

            //Arrange
            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new UsersService(httpClient);

            //Act
            var result = await sut.GetAllUsers();

            //Assert
            result.Should().BeOfType<List<User>>();

        }
    }
}