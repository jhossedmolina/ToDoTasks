using ToDoTasks.Core.Entities;

namespace ToDoTasks.Core.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();

        Task<Category> GetCategoryById(int id);

        Task CreateCategory(Category category);

        Task<bool> UpdateCategory(Category category);

        Task<bool> DeleteCategory(int id);
    }
}
