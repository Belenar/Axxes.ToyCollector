using System;

namespace Axxes.ToyCollector.Core.Contracts.DataStructures
{
    public class Toy
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime AcquiredDate { get; set; }
        public ToyCondition AcquiredCondition { get; set; }
        public ToyCondition CurrentCondition { get; set; }
    }
}