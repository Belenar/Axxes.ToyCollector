using Axxes.ToyCollector.Core.Contracts.DataStructures;

namespace Axxes.ToyCollector.Plugins.Marbles.Models
{
    public class Marble : Toy
    {
        public int Diameter { get; set; }
        public bool SeeThrough { get; set; }
    }
}
