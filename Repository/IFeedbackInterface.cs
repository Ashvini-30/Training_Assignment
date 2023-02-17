#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public interface IFeedbackInterface
    {
        Task<List<Feedback>> GetAllFeedback();
        Task<Feedback> GetFeedbackById(int id);
        Task<List<Feedback>> AddFeedback(Feedback feedback);
        Task<Feedback> UpdateFeedback(int id, Feedback model);
        Task DeleteFeedback(int id);
    }
}
