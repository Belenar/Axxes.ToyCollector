using System.Collections.Generic;
using Axxes.ToyCollector.Core.Contracts.DataStructures;

namespace Axxes.ToyCollector.Core.Contracts.Repositories
{
    public interface IToyRepository
    {
        IEnumerable<Toy> GetAll();
    }
}