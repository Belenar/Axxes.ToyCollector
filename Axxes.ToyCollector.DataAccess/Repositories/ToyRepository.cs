using System;
using System.Collections.Generic;
using Axxes.ToyCollector.Core.Contracts.DataStructures;
using Axxes.ToyCollector.Core.Contracts.Repositories;

namespace Axxes.ToyCollector.DataAccess.Repositories
{
    public class ToyRepository : IToyRepository
    {
        public IEnumerable<Toy> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
