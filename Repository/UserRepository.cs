#region usings

using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dto;
using WebApplication3.Models;
using WebApplication3.EncryptedPassword;
using System.Security.Claims;
using System.Security.Authentication;

#endregion

namespace WebApplication3.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RecipeContext _dbContext;

        public UserRepository()
        {
            _dbContext = new RecipeContext();
        }
        public bool IsUniqueUser(string emailId)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == emailId);
            if (user == null)
                return true;
            return false;
        }
        public bool IsLoggedUser(string email, string password)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user == null)
                return false;
            return true;
        }

     


        public async Task<User> Registration(RegistrationRequestDto registrationRequestDto)
        {

            User user = new User()
            {
                FirstName = registrationRequestDto.FirstName,
                LastName = registrationRequestDto.LastName,
                Email = registrationRequestDto.Email,
                MobileNo = registrationRequestDto.MobileNo,
                Gender = registrationRequestDto.Gender,
                Password = EncryptedPassword.EncryptedPassword.Encode(registrationRequestDto.Password)
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var password = EncryptedPassword.EncryptedPassword.Encode(loginRequestDto.Password);
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginRequestDto.Email && u.Password == password);
            if (user == null)
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    Users = null
                };
            }
            else
            {
                var roles = new string[] { "Admin", "User" };
                var jwtSecurityToken = Authentication.GenerateJwtToken(loginRequestDto.Email, roles.ToList());
                LoginResponseDto loginResponseDTO = new LoginResponseDto()
                {
                    Token = jwtSecurityToken,
                    Users = user
                };
                return loginResponseDTO;
            }

        }
        public async Task<User> UpdateProfile(int id, User model)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Gender = model.Gender;
                user.Email = model.Email;
                user.Password = model.Password;
                _dbContext.Users.AddOrUpdate(user);
                _dbContext.SaveChanges();
                return user;

            }
            return null;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}