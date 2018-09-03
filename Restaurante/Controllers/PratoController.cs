using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Interfaces.Service;

namespace Restaurante.Controllers
{
    [Produces("application/json")]
    [Route("api/Prato")]
    public class PratoController : Controller
    {
        private readonly IPratosService _pratoService;
        private readonly IRestauranteService _restauranteService;

        public PratoController(IPratosService service, IRestauranteService restauranteService)
        {
            _pratoService = service;
            _restauranteService = restauranteService;
        }

        [HttpPost]
        public IActionResult Save([FromBody]ApplicationCore.Entity.Prato prato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pratoService.Add(prato);
                    return new OkObjectResult(prato);
                }
                return BadRequest(ModelState.ValidationState);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _pratoService.GetAll(x => x.Id > 0);
            foreach(var item in data)
            {
                item.Restaurante = _restauranteService.GetById(item.RestauranteId);
            }
            return new OkObjectResult(data);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]ApplicationCore.Entity.Prato prato, int id)
        {
            try
            {
                if (prato.Id != id)
                    return BadRequest();
                _pratoService.Update(prato);
                return new OkObjectResult(prato);
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var prato = _pratoService.GetById(id);
                if (prato == null)
                    return NotFound();
                _pratoService.Delete(prato);
                return new OkObjectResult("Removido com sucesso!");
            }
            catch (Exception e)
            {
                return new BadRequestResult();
            }
        }
    }
}