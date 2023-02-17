#region usings

using System.ComponentModel.DataAnnotations;

#endregion


namespace WebApplication3.Dto
{
    public class LoginRequestDto
    {
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                           ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [MaxLength(8)]
        public string Password { get; set; }
    }
}