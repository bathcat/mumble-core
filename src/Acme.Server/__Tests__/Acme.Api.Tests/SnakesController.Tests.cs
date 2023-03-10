using Acme.Core;
using Acme.Web;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Acme.Api.Tests;

public class SnakesController_Tests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public async Task Get_Should_Return_Unchanged()
    {
        //Arrange
        var expected = new SnakeInfo
        {
            ID = Guid.NewGuid(),
            MeannessLevel = 0,
            Name = "Sergio",
            Color = "Green"
        };
        var mock = new Mock<ISnakeService>();
        mock.Setup(repo => repo.Get(expected.ID)).ReturnsAsync(expected);
        var repo = mock.Object;

        //Act
        var subject = new SnakesController(repo);
        var actual = await repo.Get(expected.ID);

        //Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
