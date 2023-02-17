#region usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace WebApplication3.Models
{
    public class Recipe
    {
        
        [Key]
        public int RecipeId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RecipeName { get; set; } 
        public int CategoryId { get; set; }
        public int StateId { get; set; }
        public int IngredientId { get; set; }
        public int QuantityId { get; set; }
        public int MeasurmentId { get; set; }
        public int Id { get; set; }
        public string RecipeDescription { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; }
        public virtual Ingredient Ingredient { get; set; }
        public virtual State State { get; set; } 
        public virtual User User { get; set; } 
        public virtual Quantity Quantity { get; set; }
        public virtual Measurment Measurment { get; set; }


    }

}