#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication3.Models;
using WebApplication3.Repository;

#endregion

namespace WebApplication3.Controllers
{
    public class StateController : ApiController
    {
        private readonly StateRepository _stateRepository;
        public StateController()
        {
            _stateRepository = new StateRepository();
        }

        [HttpGet]
        public async Task<List<State>> List()
        {
            return await _stateRepository.GetAllStateList();
        }

        [HttpPost]
        public async Task<List<State>> AddIngredient(State model)
        {
            return await _stateRepository.AddState(model);
        }
    }
}