using Interfaces;
using System;

namespace BusinessRules
{
    public class User : IUser
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Wealth { get; set; }
        public int Active { get; set; }
    }
}
