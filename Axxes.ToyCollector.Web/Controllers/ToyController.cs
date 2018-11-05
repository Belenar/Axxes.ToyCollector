using System.Collections.Generic;
using Axxes.ToyCollector.Core.Contracts.DataStructures;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.ToyCollector.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToyController : ControllerBase
    {
        private readonly IToyRepository _repository;

        public ToyController(IToyRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Toy
        [HttpGet]
        public IEnumerable<Toy> Get()
        {
            return _repository.GetAll();
        }

        // GET: api/Toy/5
        [HttpGet("{id}", Name = "Get")]
        public Toy Get(int id)
        {
            return _repository.GetById(id);
        }

        // POST: api/Toy
        [HttpPost]
        public void Post([FromBody] Toy value)
        {
            _repository.Create(value);
        }

        // PUT: api/Toy/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Toy value)
        {
            _repository.Update(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
