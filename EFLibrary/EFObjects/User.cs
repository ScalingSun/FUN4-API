using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFLibrary
{
    public partial class User 
    {
        public int id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        public decimal Wealth { get; set; }
        public int Active { get; set; }
        [Required]
        [MaxLength(200)]
        public string EmailAddress { get; set; }
        [MaxLength(200)]
        public string Salt { get; set; }
        public User()
        {

        }
        public User(int id, string name, string password, decimal wealth, int active, string emailAddress, string salt)
        {
            this.id = id;
            Name = name;
            Password = password;
            Wealth = wealth;
            Active = active;
            EmailAddress = emailAddress;
            Salt = salt;
        }
    }
}
