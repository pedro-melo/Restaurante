using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Entity;
using ApplicationCore.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Restaurante.Controllers
{
    [Produces("application/json")]
    [Route("api/Restaurante")]
    public class RestauranteController : Controller
    {
        private readonly IRestauranteService _restauranteService;
        public RestauranteController(IRestauranteService service)
        {
            _restauranteService = service;
        }

        [HttpPost]
        public IActionResult Save([FromBody]ApplicationCore.Entity.Restaurante restaurante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _restauranteService.Add(restaurante);
                    return new OkObjectResult(restaurante);
                    //return new CreatedAtRouteResult("Sucesso!", new { id = restaurante.Id });
                }
                return BadRequest(ModelState.ValidationState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]ApplicationCore.Entity.Restaurante restaurante, int id)
        {
            try
            {
                if (restaurante.Id != id)
                    return BadRequest();
                _restauranteService.Update(restaurante);
                return new OkObjectResult(restaurante);
                //return Ok("Atualizado!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var restaurante = _restauranteService.GetById(id);
                if (restaurante == null)
                    return NotFound();
                _restauranteService.Delete(restaurante);
                return Ok("Removido!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IEnumerable<ApplicationCore.Entity.Restaurante> Get()
        {
            var data = _restauranteService.GetAll(x => x.Id > 0);
            return data;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var restaurante = _restauranteService.GetById(id);
                if (restaurante == null)
                    return NotFound("Restaurante não encontrado");
                return Ok(restaurante);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var data = _restauranteService.GetByName(name);
            return new OkObjectResult(data);
            //return data;
        }
    }
}