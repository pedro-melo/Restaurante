using ApplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApplicationCore.Interfaces.Service
{
    public interface IPratosService
    {
        Prato Add(Prato elem);
        void Update(Prato elem);
        void Delete(Prato elem);
        IEnumerable<Prato> GetAll(Func<Prato, bool> where);

        Prato GetById(long id);
        IEnumerable<Prato> GetByName(string name);
        IEnumerable<Prato> GetAllPratosByRestaurante(long restauranteId);
    }
}
