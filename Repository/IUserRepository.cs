#region usings

using System.Collections.Generic;
using System.Security.Authentication;
using System.Threading.Tasks;
using WebApplication3.Dto;
using WebApplication3.Models;

#endregion

namespace WebApplication3.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        bool IsUniqueUser(string email);
        bool IsLoggedUser(string email, string password);
        Task<User> Registration(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
        Task<User> UpdateProfile(int id, User model);
    }
}