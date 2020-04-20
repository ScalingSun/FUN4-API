using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Interfaces;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using FUN4API.Model;

namespace FUN4API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        public DataContext _Db { get; }
        public UserController(IConfiguration config, DataContext db)
        {
            _Db = db;
        }
        [HttpGet("{id}")]
        public string Get(int Id)
        {
            CRUDUser user = new CRUDUser(_Db);
            var alluserdata = user.GetById(Id);
            var result = JsonSerializer.Serialize(alluserdata);
            return result;
        }
        [HttpPost("")]
        [AllowAnonymous]
        public string Add([FromBody] UserModel data)
        {

            CRUDUser CRUD = new CRUDUser(_Db);
            IUser user = new User();
            user.Name = data.Username;
            user.Password = data.Password;
            user.EmailAddress = data.emailaddress;
            user.Wealth = 0;
            user.Active = 1;
            CRUD.Add(user);
            return "User " + user.Name + " has been added.";
        }
        [HttpGet("")]
        public string GetAll()
        {
            CRUDUser user = new CRUDUser(_Db);
            List<User> alluserdata = user.GetAll<User>();
            foreach(User obj in alluserdata.ToList())
            {
                if (obj.Active == 0)
                {
                    alluserdata.Remove(obj);
                }
            }
            var result = JsonSerializer.Serialize(alluserdata);
            return result;
        }
        [HttpDelete("{id}")]
        public string Remove(int Id)
        {
            CRUDUser user = new CRUDUser(_Db);
            IUser check = _Db.Users.Find(Id);
            if (check == null)
            {
                return "user with Id: " + Id + " does not exist.";
            }
            if(check.Active == 2)
            {
                return "You cant delete the admin account.";
            }
            user.DeleteById(Id);
            return "User with Id: " + Id + " has been removed.";
        }
        [HttpPut("")]
        public string Update([FromBody] User input)
        {
            if (input.Name == null || input.Password == null || input.EmailAddress == null ||  input.Name == "" || input.Password == "" || input.EmailAddress == "")
            {
                return "Incorrect data given.";
            }
            if(input.Active == 2)
            {
                return "You cant change data from the ADMIN account.";
            }
            CRUDUser user = new CRUDUser(_Db);
            IUser oldData = user.GetById(input.id);
            IUser updateUser = input;
            user.UpdateById(input.id, updateUser);
            IUser NewData = user.GetById(input.id);
            return "User succesfully updated.";
        }
    }
}