using EFLibrary;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FUN4API
{
    public class CRUDUser : ICRUD
    {
        User user = null;

        public CRUDUser(DataContext db)
        {
            user = new User(db);
        }
        public void DeleteById(int Id)
        {
            user.DeleteById(Id);
        }

        public List<T> GetAll<T>() where T : class
        {
            return user.GetAll<T>();
        }

        public IUser GetById(int Id)
        {
            return user.GetById(Id);
        }
        public void UpdateById<T>(int Id, T item) where T : class
        {
            user.UpdateById(Id, item);
        }

        public IDatabaseObject<T> GetById<T>(int Id) where T : class
        {
            return user.GetById(Id) as IDatabaseObject<T>;
        }

        public void Add<T>(T obj) where T : class
        {
            user.Add(obj);
        }
    }
}
