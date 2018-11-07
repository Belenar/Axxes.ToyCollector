using System.Threading.Tasks;
using Axxes.ToyCollector.Core.Models;

namespace Axxes.ToyCollector.Core.Contracts.Services
{
    public interface IToyCreator
    {
        Task CreateToy(Toy toy);
    }
}