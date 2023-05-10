using CloudCustomers.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace CloudCustomers.UnitTests.Systems.Controllers;

public class TestUsersController
{
    [Fact]
    public async Task Get_OnSuccess_ReturnsStatusCode200()
    {
        //Arrange
        var sut = new UsersController();

        //Act
        var result = (OkObjectResult) await sut.Get();

        //Assert
        result.StatusCode.Should().Be(200);
    }
}