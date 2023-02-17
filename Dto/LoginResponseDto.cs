#region usings

using WebApplication3.Models;

#endregion

namespace WebApplication3.Dto
{
    public class LoginResponseDto
    {
        public User Users { get; set; }
        public string Token { get; set; }
    }
}