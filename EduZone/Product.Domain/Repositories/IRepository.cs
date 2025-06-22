using ProductDomain.Models;

public interface IRepository
{
    #region Course
    Task<Course> GetCourseAsync(int id);
    Task<Course> AddCourseAsync(Course course);
    Task<Course> UpdateCourseAsync(Course course);  // Dodaj tę metodę
    Task<List<Course>> GetAllCourseAsync();
    Task<bool> DeleteCourseAsync(int id);
    Task<Course?> RestoreCourseAsync(int id);

    #endregion

    #region Category
    Task<List<Category>> GetAllCategoriesAsync();
    Task<Category?> GetCategoryAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<bool> DeleteCategoryAsync(int id);
    Task<Category?> RestoreCategoryAsync(int id);

    #endregion

}
