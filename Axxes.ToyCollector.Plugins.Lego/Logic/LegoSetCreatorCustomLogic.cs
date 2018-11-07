using System;
using Axxes.ToyCollector.Core.Contracts.Services;
using Axxes.ToyCollector.Core.Models;
using Axxes.ToyCollector.Plugins.Lego.Models;

namespace Axxes.ToyCollector.Plugins.Lego.Logic
{
    public class LegoSetCreatorCustomLogic : IToyCreatorCustomLogic<LegoSet>
    {
        public void Execute(Toy newToy)
        {
            if (newToy is LegoSet set)
            {
                Console.WriteLine($"Custom LegoSet logic for {set.Description}.");
            }
        }
    }
}
