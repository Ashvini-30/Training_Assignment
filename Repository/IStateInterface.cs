using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Repository
{
    public interface IStateInterface
    {
        Task<List<State>> GetAllStateList();
        Task<List<State>> AddState(State state);
    }
}
