using System;

namespace Axxes.ToyCollector.Core.Models
{
    public class Toy
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime AcquiredDate { get; set; }
        public ToyCondition AcquiredCondition { get; set; }
        public ToyCondition CurrentCondition { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public decimal? Msrp { get; set; }
        public decimal? EstimatedValue => CalculateEstimatedValue();

        public virtual decimal? CalculateEstimatedValue()
        {
            var conditionFactor = GetConditionFactor();
            var discontinuedFactor = GetDiscontinuedFactor();

            return Msrp * conditionFactor * discontinuedFactor;
        }

        protected decimal GetConditionFactor()
        {
            switch (CurrentCondition)
            {
                case ToyCondition.New:
                    return 1.0M;
                case ToyCondition.Mint:
                    return 0.8M;
                case ToyCondition.LightlyUsed:
                    return 0.7M;
                case ToyCondition.Used:
                    return 0.6M;
                case ToyCondition.HeavilyUsed:
                    return 0.5M;
                case ToyCondition.Damaged:
                    return 0.25M;
                default:
                    throw new Exception("Should never be reached");
            }
        }

        protected decimal GetDiscontinuedFactor()
        {
            if (DiscontinuedDate == null)
                return 1.0M;

            var years = (DateTime.Today - DiscontinuedDate.Value).TotalDays / 365;

            if (years < 1)
                return 1.0M;

            return 1.0M + (decimal)Math.Log10(years);
        }
    }
}