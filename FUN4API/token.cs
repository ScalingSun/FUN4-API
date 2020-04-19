using EFLibrary;
using FUN4API.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace FUN4API
{
    public class Token
    {
        private IConfiguration _config;
        private DataContext _db;
        public Token(IConfiguration config, DataContext db)
        {
            _config = config;
            _db = db;
        }
        public string GenerateJSONWebToken(UserModel userinfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.Username),
            new Claim(JwtRegisteredClaimNames.Email, userinfo.emailaddress),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience:_config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials:credentials);

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
        public UserModel AuthenticateUser(UserModel login)
        {
            //hier checken met DB of credentials kloppen!
            if(login.emailaddress == null || login.Password == null)
            {
                return null;
            }
            var getSalt = _db.Users.FirstOrDefault(u => u.EmailAddress == login.emailaddress);
            if(getSalt == null)
            {
                return null;
            }
            var Salt = getSalt.Salt;
            var Hash = login.Password + Salt;
            var myUser = _db.Users.FirstOrDefault(u => u.EmailAddress == login.emailaddress && u.Password == Hash);
            UserModel user = null;
            if (myUser != null)
            {
                user = new UserModel
                {
                    Username = myUser.Name,
                    Password = myUser.Password,
                    emailaddress = myUser.EmailAddress
                    
                };
            }
            return user;
        }
    }
}
