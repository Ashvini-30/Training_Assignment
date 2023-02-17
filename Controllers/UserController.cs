#region usings

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApplication3.Dto;
using WebApplication3.Models;
using WebApplication3.Repository;

#endregion

namespace WebApplication3.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserRepository _userRepository;
        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public async Task<List<User>> List()
        {
            return await _userRepository.GetAllUsers();
        }

        [HttpPost]
        [Route("api/User/Register")]
       
        public async Task<User>Register(RegistrationRequestDto registrationRequestDto)
        {
            bool isUniqueUser = _userRepository.IsUniqueUser(registrationRequestDto.Email);
            if (!isUniqueUser)
            {
                return null;
            }

            var user = await _userRepository.Registration(registrationRequestDto);
            return user;
        }
      

        [HttpPost]
        [Route("api/User/login")]
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var login = await _userRepository.Login(loginRequestDto);
            if (login == null)
                return null;
            else
                return login;
        }        

        [HttpPut]
        [Route("api/User/{id}")]
        public async Task<User> UpdateProfile(int id, User model)
        {
            var loggedIn = _userRepository.IsLoggedUser(model.Email, model.Password);
            if (loggedIn)
            {
                var user = await _userRepository.UpdateProfile(id, model);
                return user;
            }
            else
                return null;
        }

    }
}






