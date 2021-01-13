using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade personFacade;

        public PersonController(IPersonFacade facade)
        {
            personFacade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get()
        {
            return  Response(await personFacade.FindAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonResponse>> Get(int id)
        {
            return Response(await personFacade.FindById(id));
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] PersonDto person)
        {
            var response = await personFacade.Add(person);
            return Response(response.PersonObjects.FirstOrDefault()?.BusinessEntityID , response.PersonObjects);
        }

        [HttpPut()]
        public async Task<IActionResult> Put([FromBody] PersonDto person)
        {
            var response = await personFacade.Update(person);
            return Response(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await personFacade.Remove(id);
            return Response(response);
        }
    }
}
