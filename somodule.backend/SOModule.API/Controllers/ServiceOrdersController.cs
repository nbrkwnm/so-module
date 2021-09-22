using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SOModule.Application.Dtos;
using SOModule.Application.Interfaces;

namespace SOModule.API.Controllers
{
    [ApiController]
    [Route("so/")]
    public class ServiceOrdersController : Controller
    {
        private readonly IServiceOrderApplicationService _applicationservice;

        public ServiceOrdersController(IServiceOrderApplicationService applicationservice)
        {
            _applicationservice = applicationservice;
        }

        // GET
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_applicationservice.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_applicationservice.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ServiceOrderDto serviceOrderDto)
        {
            try
            {
                if (serviceOrderDto == null)
                    return NotFound();

                _applicationservice.Add(serviceOrderDto);
                
                return Ok("Ordem de Serviço cadastrado com sucesso!");
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ServiceOrderDto serviceOrderDto)
        {
            try
            {
                if (serviceOrderDto == null)
                    return NotFound();
                
                _applicationservice.Update(serviceOrderDto);
                    
                return Ok("Ordem de Serviço atualizado com sucesso!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                    return NotFound();
                
                _applicationservice.Remove(id);
                return Ok("Ordem de Serviço removido com sucesso");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}