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
    public class FeedbackRepository : IFeedbackInterface
    {
        private readonly RecipeContext _dbContext;
        public FeedbackRepository()
        {
            _dbContext = new RecipeContext();
        }
        public async Task<List<Feedback>> AddFeedback(Feedback feedback)
        {
            _dbContext.Feedbacks.Add(feedback);
             await _dbContext.SaveChangesAsync();

            return await GetAllFeedback();
        }
      
        public async Task DeleteFeedback(int id)
        {
            var feedback = _dbContext.Feedbacks.FirstOrDefault(u => u.FeedbackId == id);
            _dbContext.Feedbacks.Remove(feedback);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Feedback>> GetAllFeedback()
        {
            return await _dbContext.Feedbacks.ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(e => e.FeedbackId == id);
            if (feedback == null)
                return null;
            else
                return feedback;
        }

        public async Task<Feedback> UpdateFeedback(int id, Feedback model)
        {
            var feedback = await _dbContext.Feedbacks.FirstOrDefaultAsync(u => u.FeedbackId == id);
            if (feedback != null)
            {
                feedback.RecipeId = model.RecipeId;
                feedback.UserId = model.UserId;
                feedback.Ratings = model.Ratings;
                feedback.ReviewText = model.ReviewText;
                
                _dbContext.Feedbacks.AddOrUpdate(feedback);
                _dbContext.SaveChanges();
                return feedback;
            }

            return null;
        }
      
    }
}