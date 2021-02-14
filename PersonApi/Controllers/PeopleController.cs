using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonApi.Interfaces;
using PersonApi.Models;

namespace PersonApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetAll()
        {
            return await _personService.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> Get(string id)
        {
            Person p = await _personService.Get(id);
            if(p== null)
            {
                return NotFound();
            }
            return p;
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            Person p = await _personService.Get(person.id);
            if (p == null)
            {
                Person ps = await _personService.Create(person);
                if (person == null)
                {
                    return NotFound();
                }
                return ps;
            }
            else
            {
                return Conflict();
            }
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person person)
        {
            Person p = await _personService.Update(person);
            if (p == null)
            {
                return NoContent();
            }
            return p;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            bool p = await _personService.Delete(id);
            if (!p)
            {
                return NotFound();
            }
            return Ok(p);
        }

    }
}
