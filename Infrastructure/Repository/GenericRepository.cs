using ApplicationCore.Interfaces.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppContextDb _db;
        public GenericRepository(AppContextDb db)
        {
            _db = db;
        }

        public T Add(T elem)
        {
            _db.Set<T>().Add(elem);
            _db.SaveChanges();
            return elem;
        }

        public void Delete(T elem)
        {
            _db.Set<T>().Remove(elem);
            _db.SaveChanges();
        }

        public IEnumerable<T> GetAll(Func<T, bool> where)
        {
            return _db.Set<T>().AsNoTracking().Where(where).ToList<T>();
        }

        public T GetById(Func<T, bool> where)
        {
            return _db.Set<T>().AsNoTracking().FirstOrDefault(where);
        }

        public IEnumerable<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _db.Set<T>();

            foreach (var item in navigationProperties)
                query = query.Include(item);

            return query.AsNoTracking().Where(where).AsQueryable<T>().ToList<T>();
        }

        public void Update(T elem)
        {
            _db.Set<T>().Update(elem);
            _db.SaveChanges();
        }
    }
}
