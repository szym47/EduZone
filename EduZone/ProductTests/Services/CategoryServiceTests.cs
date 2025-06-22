using Product.Application.Services;
using ProductDomain.Models;
using Moq;

namespace ProductTests.Services;    
public class CategoryServiceTests
{
    private readonly Mock<IRepository> _repoMock = new();
    private readonly CategoryService _service;

    public CategoryServiceTests()
    {
        _service = new CategoryService(_repoMock.Object);
    }

    [Fact]
    public async Task GetAllAsync_ReturnsCategories()
    {
        // Arrange
        var categories = new List<Category> { new() { Id = 1, Name = "Test" } };
        _repoMock.Setup(r => r.GetAllCategoriesAsync()).ReturnsAsync(categories);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.Single(result);
        Assert.Equal("Test", result.First().Name);
    }

    [Fact]
    public async Task GetAsync_ReturnsNull_IfNotFound()
    {
        _repoMock.Setup(r => r.GetCategoryAsync(1)).ReturnsAsync((Category?)null);

        var result = await _service.GetAsync(1);

        Assert.Null(result);
    }
}
