#region usings

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication3.Models;
using WebApplication3.Repository;

#endregion

namespace WebApplication3.Controllers
{
    public class FeedbackController : ApiController
    {
        private readonly FeedbackRepository _feedbackRepository;
        public FeedbackController()
        {
            _feedbackRepository = new FeedbackRepository();
        }

        [HttpPost]
        public async Task<List<Feedback>> AddFeedback(Feedback model)
        {
            return await _feedbackRepository.AddFeedback(model);
        }

        [HttpGet]
        public async Task<List<Feedback>> List()
        {
            return await _feedbackRepository.GetAllFeedback();
        }

        [HttpGet]
        [Route("api/Feedback/GetFeedbackById/{id}")]
        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _feedbackRepository.GetFeedbackById(id);
        }

        [HttpPut]
        [Route("api/Feedback/UpdateFeedback/{id}")]
        public async Task<Feedback> UpdateFeedback(int id, Feedback feedback)
        {
           feedback = await _feedbackRepository.UpdateFeedback(id, feedback);
           return feedback;
        }

        [HttpDelete]
        [Route("api/Feedback/DeleteFeedback/{id}")]
        public async Task<List<Feedback>> DeleteFeedback(int id)
        {
            var recipe = _feedbackRepository.GetFeedbackById(id);
            if (recipe == null)
                return null;

            await _feedbackRepository.DeleteFeedback(id);
            return await _feedbackRepository.GetAllFeedback();
        }

    }
}