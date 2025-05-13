using ProductDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace Product.Domain.Repositories
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext dataContext)
        {
            _context = dataContext;
        }

        #region Course

        public async Task<Course> AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseAsync(int id)
        {
            return await _context.Courses.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        #endregion

    }
}
