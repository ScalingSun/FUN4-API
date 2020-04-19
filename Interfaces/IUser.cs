using System;

namespace Interfaces
{
    public interface IUser
    {
        int id { get; }
        string Name { get; set; }
        string Password { get; set; }
        decimal Wealth { get; set; }
        int Active { get; set; }
        string EmailAddress { get; set; }
    }
}
