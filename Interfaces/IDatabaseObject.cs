using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IDatabaseObject<T> where T : class
    {
        List<T> GetAll();
        T GetById(int Id);
        void DeleteById(int Id);
        void UpdateById(int Id, IDatabaseObject<T> O);
    }
}
