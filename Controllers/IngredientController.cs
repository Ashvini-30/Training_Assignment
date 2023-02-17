#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication3.Models;
using WebApplication3.Repository;

#endregion

namespace WebApplication3.Controllers
{
    public class IngredientController : ApiController
    {
        private readonly IngredientRepository _ingredientRepository;
        public IngredientController()
        {
            _ingredientRepository = new IngredientRepository();
        }

        [HttpGet]
        public async Task<List<Ingredient>> List()
        {
            return await _ingredientRepository.GetAllIngredientList();
        }

        [HttpPost]
        public async Task<List<Ingredient>> AddIngredient(Ingredient model)
        {
            return await _ingredientRepository.AddIngredient(model);
        }
    }
}