#region usings

using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public class CategoryRepository : ICategoryInterface
    {
        private readonly RecipeContext _dbContext;
        public CategoryRepository()
        {
            _dbContext = new RecipeContext();
        }
        public async Task<List<Category>> AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return await GetAllCategoryList();
        }

        public async Task<List<Category>> GetAllCategoryList()
        {
            return await _dbContext.Categories.ToListAsync();
        }
    }
}