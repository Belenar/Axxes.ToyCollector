using System;
using System.Collections.Generic;
using System.Linq;
using Axxes.ToyCollector.Core.Contracts.DataStructures;
using Axxes.ToyCollector.Core.Contracts.Repositories;
using Axxes.ToyCollector.DataAccess.EF;

namespace Axxes.ToyCollector.DataAccess.Repositories
{
    public class ToyRepository : IToyRepository
    {
        private readonly ToyContext _context;

        public ToyRepository(ToyContext context)
        {
            _context = context;
        }
        public IEnumerable<Toy> GetAll()
        {
            return _context.Toys.ToList();
        }
    }
}
