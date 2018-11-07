using Axxes.ToyCollector.Core.Models;

namespace Axxes.ToyCollector.Core.Contracts.Services
{
    public interface IToyCreatorCustomLogic
    {
        void Execute(Toy newToy);
    }

    public interface IToyCreatorCustomLogic<T> : IToyCreatorCustomLogic
        where T: Toy
    {        
    }
}