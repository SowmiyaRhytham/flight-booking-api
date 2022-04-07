using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Repository;
using FlightBookingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : Controller
    {
       
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        //[HttpGet]
        //public async Task<IEnumerable<User>> GetUsers()
        //{
        //    return await _userRepository.Get();
        //}

        [AllowAnonymous]
        [HttpPost]
        [Route("GetLogin")]
        public string GetLogin(Login login)
        {
            //return _userRepository.GetLogin(login);

            IActionResult response = Unauthorized();
            var user = _userRepository.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = _userRepository.GenerateJSONWebToken(login);
                response = Ok(new { token = tokenString });
            }

            return user;
        }


        [HttpPost]
        [Route("GetUserDetail")]
        public string GetUserDetail(User user)
        {
            user.Password = Guid.NewGuid().ToString().Substring(1, 8);
            user.Role = "User";
            user.Status = "Active";
            return _userRepository.GetUserRegisterdtl(user);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
