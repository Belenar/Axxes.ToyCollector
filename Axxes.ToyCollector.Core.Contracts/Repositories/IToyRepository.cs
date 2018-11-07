using System.Collections.Generic;
using System.Threading.Tasks;
using Axxes.ToyCollector.Core.Models;

namespace Axxes.ToyCollector.Core.Contracts.Repositories
{
    public interface IToyRepository
    {
        Task<List<Toy>> GetAll();
        Task<Toy> GetById(int id);
        Task Create(Toy value);
        Task Update(int id, Toy value);
        Task Delete(int id);
    }
}