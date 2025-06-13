using Product.Domain.Repositories;
using ProductDomain.Models;

namespace Product.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _repository.GetAllCategoriesAsync();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await _repository.GetCategoryAsync(id);
        }

        public async Task<Category> AddAsync(Category category)
        {
            return await _repository.AddCategoryAsync(category);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            return await _repository.UpdateCategoryAsync(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteCategoryAsync(id);
        }
        public async Task<Course> RestoreAsync(int id)
        {
            var course = await _repository.GetCourseAsync(id);
            if (course == null) return null;

            course.Deleted = false;
            return await _repository.UpdateCourseAsync(course);
        }

    }
}
