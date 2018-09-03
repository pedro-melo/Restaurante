using ApplicationCore.Entity;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Services
{
    public class PratoService : IPratosService
    {
        private readonly IGenericRepository<Prato> _pratoRepository;

        public PratoService(IGenericRepository<Prato> repository)
        {
            _pratoRepository = repository;
        }

        public Prato Add(Prato elem)
        {
            return _pratoRepository.Add(elem);
        }

        public void Delete(Prato elem)
        {
            _pratoRepository.Delete(elem);
        }

        public IEnumerable<Prato> GetAll(Func<Prato, bool> where)
        {
            return _pratoRepository.GetAll(where);
        }

        public IEnumerable<Prato> GetAllPratosByRestaurante(long restauranteId)
        {
            return _pratoRepository.GetList(x => x.RestauranteId == restauranteId);
        }

        public Prato GetById(long id)
        {
            return _pratoRepository.GetById(x => x.Id == id);
        }

        public IEnumerable<Prato> GetByName(string name)
        {
            return _pratoRepository.GetAll(x => x.Name.Contains(name));
        }

        public void Update(Prato elem)
        {
            _pratoRepository.Update(elem);
        }
    }
}
