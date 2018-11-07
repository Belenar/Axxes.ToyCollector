using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Axxes.ToyCollector.Core.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.ToyCollector.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        private readonly IToyRepository _repository;
        private readonly IToyCreator _toyCreator;

        public ToyController(IToyRepository repository, IToyCreator toyCreator)
        {
            _repository = repository;
            _toyCreator = toyCreator;
        }

        // GET: api/Toy
        [HttpGet]
        public async Task<ActionResult<List<Toy>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/Toy/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(404)]
        public async Task<ActionResult<Toy>> Get(int id)
        { 
            try
            {
                return await _repository.GetById(id);
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        // POST: api/Toy
        [HttpPost]
        [ProducesResponseType(500)]
        public async Task<ActionResult> Post([FromBody] Toy value)
        {
            try
            {
                await _toyCreator.CreateToy(value);
                return CreatedAtAction(nameof(Get), new {id = value.Id}, value);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        // PUT: api/Toy/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Put(int id, [FromBody] Toy value)
        {
            try
            {
                await _repository.Update(id, value);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _repository.Delete(id);
                return Ok();
            }
            catch (ArgumentException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}
