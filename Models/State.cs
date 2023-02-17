#region usings

using System.ComponentModel.DataAnnotations;

#endregion


namespace WebApplication3.Models
{
    public class State
    {
        [Key]
        public int StateId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StateName { get; set; }
       
    }
}