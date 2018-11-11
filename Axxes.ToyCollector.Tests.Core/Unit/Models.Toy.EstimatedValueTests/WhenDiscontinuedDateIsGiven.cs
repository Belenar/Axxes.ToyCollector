using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Axxes.ToyCollector.Tests.Core.Unit.Models.Toy.EstimatedValueTests
{
    [TestClass]
    public class WhenDiscontinuedDateIsGiven
    {
        private readonly ToyCollector.Core.Models.Toy _toy;

        public WhenDiscontinuedDateIsGiven()
        {
            //Arrange
            _toy = new ToyCollector.Core.Models.Toy
            {
                Msrp = 1000M
            };
        }

        [TestMethod]
        public void ThenThenValueShouldDoubleIn10Years()
        {
            // Act
            _toy.DiscontinuedDate = DateTime.Today.AddDays(-3650);
            var estimatedValue = _toy.EstimatedValue;


            //Assert
            Assert.IsNotNull(estimatedValue);
            Assert.AreEqual(2000M, estimatedValue.Value);
        }

        [TestMethod]
        public void ThenThenValueShouldRemainStableForAYear()
        {
            // Act
            _toy.DiscontinuedDate = DateTime.Today.AddDays(-364);
            var estimatedValue = _toy.EstimatedValue;


            //Assert
            Assert.IsNotNull(estimatedValue);
            Assert.AreEqual(1000M, estimatedValue.Value);
        }
    }
}