#region usings

using System.ComponentModel.DataAnnotations;
using WebApplication3.CustomValidation;

#endregion


namespace WebApplication3.Dto
{
    public class RegistrationRequestDto
    {
        //[Required(ErrorMessage = "First Name is Required")]
        //[MaxLength(10)]
        [MyCustomValidation]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        [MaxLength(10)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                                 ErrorMessage = "Please enter a valid email address")]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(10)]
        public string MobileNo { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password must be between 6 and 20 characters and contain one uppercase letter, one lowercase letter, one digit and one special character.")]
        public string Password { get; set; }
    }
}