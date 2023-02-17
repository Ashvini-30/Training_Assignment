#region usings

using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public class StateRepository : IStateInterface
    {
        private readonly RecipeContext _dbContext;
        public StateRepository()
        {
            _dbContext = new RecipeContext();
        }
        public async Task<List<State>> AddState(State state)
        {
            _dbContext.States.Add(state);
            await _dbContext.SaveChangesAsync();
            return await GetAllStateList();
        }

        public async Task<List<State>> GetAllStateList()
        {
            return await _dbContext.States.ToListAsync();
        }
    }
}