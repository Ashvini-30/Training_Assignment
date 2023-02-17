#region usings

using System.ComponentModel.DataAnnotations;

#endregion


namespace WebApplication3.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(50)]
        public string RollName { get; set; }

    }
}