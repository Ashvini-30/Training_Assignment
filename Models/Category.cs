#region usings

using System.ComponentModel.DataAnnotations;

#endregion


namespace WebApplication3.Models
{
    public class Category
    {       
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryType { get; set; } 

    }
}