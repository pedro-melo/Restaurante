using ApplicationCore.Entity;
using ApplicationCore.Interfaces.Repository;
using ApplicationCore.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ApplicationCore.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly IGenericRepository<Restaurante> _restauranteRepository;

        public RestauranteService(IGenericRepository<Restaurante> repository)
        {
            _restauranteRepository= repository;
        }

        public Restaurante Add(Restaurante elem)
        {
            return _restauranteRepository.Add(elem);
        }

        public void Delete(Restaurante elem)
        {
            _restauranteRepository.Delete(elem);
        }

        public IEnumerable<Restaurante> GetAll(Func<Restaurante, bool> where)
        {
            return _restauranteRepository.GetAll(where);
        }

        public Restaurante GetById(long id)
        {
            return _restauranteRepository.GetById(x => x.Id == id);
        }

        public IEnumerable<Restaurante> GetByName(string name)
        {
            return _restauranteRepository.GetAll(x => x.Name.ToLower().Contains(name.ToLower()));
        }

        public void Update(Restaurante elem)
        {
            _restauranteRepository.Update(elem);
        }
    }
}
