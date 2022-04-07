using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace FlightBookingAPI.Repository
    
{
    public class UserRepository : IUserRepository
    {
        
        private IConfiguration _config;

        //public UserRepository(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly FlightDBContext _context;

        public UserRepository(FlightDBContext context,IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        //public async Task<IEnumerable<User>> Get()
        //{
            
        //    return await _context.users.ToListAsync();
            
        //}


        public string GetLogin(User login)
        {
            string role = "default";
            bool isUser = login.Emailid == _context.User.Where(ui => ui.Emailid == login.Emailid).Select(ui => ui.Password).FirstOrDefault();
            if (isUser)
            {
                role = _context.User.Where(ui => ui.Emailid == login.Emailid).Select(ui => ui.Emailid).FirstOrDefault();
            }
            else
            {
                return "Username or Password Is Incorrect!!! Please check!!!";
            }
            return role;
        }


        public string AuthenticateUser(Login login)
        {

            string role = "default";
            //bool isUser = login.Emailid == _context.User.Where(ui => ui.Emailid == login.Emailid).Select(ui => ui.Password).FirstOrDefault();

            bool isUser = _context.User.Where(u => u.Emailid == login.Emailid && u.Password == login.Password).Any();
            if (isUser)
            {
                role = _context.User.Where(ui => ui.Emailid == login.Emailid).Select(ui => ui.Role).FirstOrDefault();
            }
            else
            {
                return "Username or Password Is Incorrect!!! Please check!!!";
            }
            return role;
        }

        public string GenerateJSONWebToken(Login userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Password),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Emailid),
              //  new Claim("DateOfJoing", userInfo.DateOfJoing.ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

     

        public string GetUserRegisterdtl(User user)
        {
            bool isUser = _context.User.Any(ui => ui.Emailid == user.Emailid);
            
            if (isUser)
            {
                return "User Already Exist";
            }

           _context.User.Add(user);
           var result = _context.SaveChanges();
            
            return "User Registered Successfully!!!";
        }


    }
}
