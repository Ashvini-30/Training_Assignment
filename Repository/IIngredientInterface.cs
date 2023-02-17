#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public interface IIngredientInterface
    {
        Task<List<Ingredient>> GetAllIngredientList();
        Task<List<Ingredient>> AddIngredient(Ingredient ingredient);

    }
}
