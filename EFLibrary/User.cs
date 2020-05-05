using Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFLibrary
{
    public partial class User : IUser
    {
        private DataContext _db;
        public User(DataContext db)
        {
            _db = db;
        }
        public void DeleteById(int Id)
        {
            var result = _db.Users.SingleOrDefault(b => b.id == Id);
            if (result.Active != 2)
            {
                if (result != null)
                {
                    result.Active = 0;
                    _db.SaveChanges();
                }
            }
           
        }

        public List<T> GetAll<T>() where T : class
        {
            var users = _db.Users.ToList();
            List<T> result = new List<T>();
            foreach(User user in users)
            {
                result.Add(user as T);
            }
            return result;
        }

        public IUser GetById(int Id)
        {
            return _db.Users.Where(b => b.id == Id).Include(b => b.transactions).FirstOrDefault();
        }
        public int GetIdByEmailAddress(string Email)
        {
            
            return _db.Users.Where(m => m.EmailAddress == Email).Select(m => m.id).SingleOrDefault();
        }

        public void UpdateById<T>(int Id, T User) where T : class
        
        {
            IUser newversion = User as IUser;
            var result = _db.Users.Include(b => b.transactions).SingleOrDefault(b => b.id == Id);
            if (result != null)
            {
                result.Name = newversion.Name;
                result.Password = newversion.Password;
                result.EmailAddress = newversion.EmailAddress;
                result.Wealth = newversion.Wealth;
                result.Active = newversion.Active;
                result.transactions = newversion.Transactions;
                _db.SaveChanges();
            }
        }
        public void Add<T>(T thing) where T : class
        {
            User user = thing as User;
            string salt = Guid.NewGuid().ToString();
            string hash = user.Password + salt;
            user.Password = hash;
            user.Salt = salt;
            _db.Users.Add(user);
            _db.SaveChanges();
        }
    }
}
