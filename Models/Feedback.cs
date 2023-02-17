#region usings

using System.ComponentModel.DataAnnotations;

#endregion

namespace WebApplication3.Models
{
    public class Feedback
    {      
        [Key]
        public int FeedbackId { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }

        [Required]
        public int Ratings { get; set; }
        public string ReviewText { get; set; }
        public virtual Recipe Recipe { get; set; } 
        public virtual User User { get; set; } 
    }
}