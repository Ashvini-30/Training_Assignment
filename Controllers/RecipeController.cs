#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication3.Models;
using WebApplication3.Repository;

#endregion

namespace WebApplication3.Controllers
{
    public class RecipeController : ApiController
    {
        private readonly IRecipeRepository _recipeRepository;
        public RecipeController()
        {
            _recipeRepository = new RecipeRepository();
        }

        [HttpGet]
        public async Task<List<Recipe>>List()
        {
            return await _recipeRepository.GetAllRecipies();
        }
       
        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<List<Recipe>> AddRecipe(Recipe model)
        {
           return await _recipeRepository.AddRecipe(model);
        }
     
        [HttpGet]
        [Route("api/Recipe/GetRecipeById/{id}")]
        public async Task<Recipe> GetRecipeById(int id)
        {
            return await _recipeRepository.GetRecipeById(id);
        }

        //[Authorize(Roles = "User")]
        [HttpPut]
        [Route("api/Recipe/UpdateRecipe/{id}")]
        public async Task<Recipe> UpdateRecipe(int id , Recipe recipe)
        {
            recipe = await _recipeRepository.UpdateRecipe(id, recipe);
            return recipe;
        }

        //[Authorize(Roles = "Admin,User")]
        [HttpDelete]
        [Route("api/Recipe/DeleteRecipe/{id}")]
        public async Task<List<Recipe>> DeleteRecipe(int id)
        {
            var recipe = _recipeRepository.GetRecipeById(id);
            if (recipe == null)
                return null;
               
            await _recipeRepository.DeleteRecipe(id);
            return await _recipeRepository.GetAllRecipies();
        }

    }
}