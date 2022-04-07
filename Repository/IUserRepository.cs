using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightBookingAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlightBookingAPI.Repository
{
    public interface IUserRepository
    {
      //  Task<IEnumerable<User>> Get();
        public string GetLogin(User login);

       public string AuthenticateUser(Login login);
        public string GenerateJSONWebToken(Login userInfo);
        public string GetUserRegisterdtl(User register);
    }
}
