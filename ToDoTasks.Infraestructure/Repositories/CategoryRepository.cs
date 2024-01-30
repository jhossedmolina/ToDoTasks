using Microsoft.EntityFrameworkCore;
using ToDoTasks.Core.Entities;
using ToDoTasks.Core.Interfaces;
using ToDoTasks.Infraestructure.Data;

namespace ToDoTasks.Infraestructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoTasksInMemoryContext _context;

        public CategoryRepository(ToDoTasksInMemoryContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            var currentCategory = await GetCategoryById(category.Id);
            currentCategory.Code = category.Code;
            currentCategory.Name = category.Name;

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var currentCategory = await GetCategoryById(id);
            _context.Categories.Remove(currentCategory);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
