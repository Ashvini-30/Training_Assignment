#region usings

using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public class IngredientRepository : IIngredientInterface
    {
        private readonly RecipeContext _dbContext;
        public IngredientRepository()
        {
            _dbContext = new RecipeContext();
        }
        public async Task<List<Ingredient>> AddIngredient(Ingredient ingredient)
        {
            _dbContext.Ingredients.Add(ingredient);
            await _dbContext.SaveChangesAsync();
            return await GetAllIngredientList();
        }

        public async Task<List<Ingredient>> GetAllIngredientList()
        {
            return await _dbContext.Ingredients.ToListAsync();
        }
    }
}