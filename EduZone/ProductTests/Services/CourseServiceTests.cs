using Microsoft.Extensions.Caching.Memory;
using Product.Application.Services;
using ProductDomain.Models;
using StackExchange.Redis;
using Moq;
using System.Text.Json;

namespace ProductTests.Services;

public class CourseServiceTests
{
    private readonly Mock<IRepository> _repoMock = new();
    private readonly Mock<IMemoryCache> _memoryCache = new();
    private readonly Mock<IDatabase> _redisDb = new();
    private readonly CourseService _service;

    public CourseServiceTests()
    {
        // używamy konstruktoru z Redis mockiem ręcznie
        _service = new CourseService(_repoMock.Object, _memoryCache.Object);

        typeof(CourseService)
            .GetField("_redisDb", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .SetValue(_service, _redisDb.Object);
    }

    [Fact]
    public async Task GetAsync_ReturnsCourse_FromRepository_IfNotInRedis()
    {
        // Arrange
        var fakeCourse = new Course { Id = 1, Name = "TestCourse" };
        string serializedCourse = JsonSerializer.Serialize(fakeCourse);

        _redisDb.Setup(r => r.StringGetAsync("Course:1", It.IsAny<CommandFlags>()))
                .ReturnsAsync(serializedCourse);

        _repoMock.Setup(r => r.GetCourseAsync(1)).ReturnsAsync(fakeCourse);
        _redisDb.Setup(r => r.StringSetAsync(
                It.IsAny<RedisKey>(),
                It.IsAny<RedisValue>(),
                It.IsAny<TimeSpan?>(),
                It.IsAny<When>(),
                It.IsAny<CommandFlags>()
            )).ReturnsAsync(true);


        // Act
        var result = await _service.GetAsync(1);

        // Assert
        Assert.Equal("TestCourse", result.Name);
    }
}
