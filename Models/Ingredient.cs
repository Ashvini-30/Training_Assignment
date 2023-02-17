#region usings

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting.Proxies;

#endregion


namespace WebApplication3.Models
{
    public class Ingredient
    {      
        [Key]
        public int IngredientId { get; set; }

        [Required]
        public string IngredientName { get; set; }


    }
}