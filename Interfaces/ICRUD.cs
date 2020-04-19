using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface ICRUD
    {
        List<T> GetAll<T>() where T : class;
        public IDatabaseObject<T> GetById<T>(int Id) where T : class;
        void DeleteById(int Id);
        void UpdateById<T>(int Id, T test) where T : class;
        void Add<T>(T obj) where T : class;

    }
}
