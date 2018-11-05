using System.Collections.Generic;
using Axxes.ToyCollector.Core.Contracts.DataStructures;

namespace Axxes.ToyCollector.Core.Contracts.Repositories
{
    public interface IToyRepository
    {
        IEnumerable<Toy> GetAll();
        Toy GetById(int id);
        void Create(Toy value);
        void Update(int id, Toy value);
        void Delete(int id);
    }
}