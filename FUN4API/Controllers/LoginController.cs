using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EFLibrary;
using FUN4API.Model;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace FUN4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LoginController : ControllerBase
    {
        private Token _token = null;
        public DataContext _Db { get; }
        
        public LoginController(IConfiguration config,DataContext db)
        {
            _token = new Token(config,db);
            _Db = db;
        }
        [AllowAnonymous]
        [HttpPost("")]
        public IActionResult Login(UserModel thing)
        {
            IActionResult response = Unauthorized();
            User userID = new User(_Db);
            int id = userID.GetIdByEmailAddress(thing.emailaddress);
            var user = _token.AuthenticateUser(thing);
            if(user != null)
            {
                var tokenStr = _token.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr, userId = id });
            }
            return response;
        }
    }
}