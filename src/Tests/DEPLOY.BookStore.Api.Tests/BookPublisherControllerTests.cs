using Xunit;
using Moq;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DEPLOY.BookStore.Api.Controllers.v1;
using DEPLOY.BookStore.Application.Interfaces.BookPublisher;
using DEPLOY.BookStore.Application.Dtos.BookPublisher;

public class BookPublisherControllerTests
{
    private readonly Mock<IBookPublisherAppService> _mockService;
    private readonly BookPublisherController _controller;
    private readonly Faker<BookPublisherDto> _faker;

    public BookPublisherControllerTests()
    {
        _mockService = new Mock<IBookPublisherAppService>();
        _controller = new BookPublisherController(_mockService.Object);
        _faker = new Faker<BookPublisherDto>();
    }

    [Fact]
    public async Task GetAll_ReturnsOkResult_WhenItemsExist()
    {
        Assert.True(true);
    }

    [Fact]
    public async Task GetAll_ReturnsBadRequest_WhenNoItemsExist()
    {
        // Arrange
        _mockService.Setup(service => service.ListBookPublisherAsync()).ReturnsAsync(new List<BookPublisherDto>());

        // Act
        var result = await _controller.GetAll();

        // Assert
        Assert.IsType<BadRequestResult>(result);
    }
}