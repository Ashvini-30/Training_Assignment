#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public interface IRecipeRepository
    {
        Task <List<Recipe>> GetAllRecipies();
        Task <List<Recipe>>AddRecipe(Recipe recipe);
        Task<Recipe>GetRecipeById(int id);
        Task<Recipe> UpdateRecipe(int id, Recipe model);
        Task DeleteRecipe(int id);
    }
}
