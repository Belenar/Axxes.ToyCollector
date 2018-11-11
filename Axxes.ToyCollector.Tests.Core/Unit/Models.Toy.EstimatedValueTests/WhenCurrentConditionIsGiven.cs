using Axxes.ToyCollector.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Axxes.ToyCollector.Tests.Core.Unit.Models.Toy.EstimatedValueTests
{
    [TestClass]
    public class WhenCurrentConditionIsGiven
    {
        private readonly ToyCollector.Core.Models.Toy _toy;

        public WhenCurrentConditionIsGiven()
        {
            //Arrange
            _toy = new ToyCollector.Core.Models.Toy
            {
                Msrp = 1000M
            };
        }

        [DataRow(ToyCondition.New, 1000)]
        [DataRow(ToyCondition.Mint, 800)]
        [DataRow(ToyCondition.LightlyUsed, 700)]
        [DataRow(ToyCondition.Used, 600)]
        [DataRow(ToyCondition.HeavilyUsed, 500)]
        [DataRow(ToyCondition.Damaged, 250)]
        [TestMethod]
        public void ThenEstimatedValueShouldBeCorrect(ToyCondition condition, int expectedValue)
        {
            // Act
            _toy.CurrentCondition = condition;
            var estimatedValue = _toy.EstimatedValue;

            //Assert
            Assert.IsNotNull(estimatedValue);
            Assert.AreEqual(expectedValue, estimatedValue.Value);
        }
    }
}