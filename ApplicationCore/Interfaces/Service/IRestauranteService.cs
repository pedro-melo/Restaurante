using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces.Service
{
    public interface IRestauranteService
    {
        Restaurante Add(Restaurante elem);
        void Update(Restaurante elem);
        void Delete(Restaurante elem);
        IEnumerable<Restaurante> GetAll(Func<Restaurante, bool> where);

        Restaurante GetById(long id);
        IEnumerable<Restaurante> GetByName(string name);
    }
}
