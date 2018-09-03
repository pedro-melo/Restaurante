using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T Add(T elem);
        void Update(T elem);
        void Delete(T elem);
        IEnumerable<T> GetAll(Func<T, bool> where); //(params Expression<Func<T, object>>[] navigationProperties);
        IEnumerable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);

        T GetById(Func<T, bool> where);
    }
}
