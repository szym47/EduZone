using ProductDomain.Models;

public interface IRepository
{
    #region Course
    Task<Course> GetCourseAsync(int id);
    Task<Course> AddCourseAsync(Course course);
    Task<Course> UpdateCourseAsync(Course course);  // Dodaj tę metodę
    Task<List<Course>> GetAllCourseAsync();
    #endregion

}
