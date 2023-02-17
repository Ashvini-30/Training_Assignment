#region usings

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeContext _dbContext;
        public RecipeRepository()
        {
            _dbContext = new RecipeContext();
        }
        public async Task <List<Recipe>> GetAllRecipies()
        {
            return await _dbContext.Recipes.ToListAsync(); 
        }
       
        public async Task<List<Recipe>> AddRecipe(Recipe recipe)
        {
            _dbContext.Recipes.Add(recipe);
            await _dbContext.SaveChangesAsync();
            return await GetAllRecipies();
        }

        public async Task<Recipe> GetRecipeById(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(e => e.RecipeId == id);
            if (recipe == null)
                return null;
            else
                return recipe;          
        }
        public async Task<Recipe> UpdateRecipe(int id, Recipe model)
        {
            var recipe= await _dbContext.Recipes.FirstOrDefaultAsync(u => u.RecipeId == id);
            if (recipe != null)
            {
               recipe.RecipeName = model.RecipeName;
               recipe.IngredientId = model.IngredientId;
               recipe.State =model.State;
               recipe.Category=model.Category;
               recipe.RecipeDescription = model.RecipeDescription;
               _dbContext.Recipes.AddOrUpdate(recipe);
               _dbContext.SaveChanges();
               return recipe;

            }
            return null;
        }
      
        public async Task DeleteRecipe(int id)
        {
            var recipe = _dbContext.Recipes.FirstOrDefault(u=>u.RecipeId==id);
            _dbContext.Recipes.Remove(recipe);
            await _dbContext.SaveChangesAsync();
        }

    }
}