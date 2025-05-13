using ProductDomain.Models;

namespace Product.Application.Services;

public interface ICourseService
{
    public Task<List<Course>> GetAllAsync();
    Task<Course> GetAsync(int id);
    Task<Course> UpdateAsync(Course course);
    Task<Course> AddAsync(Course course);
    Course Add(Course course);
}

