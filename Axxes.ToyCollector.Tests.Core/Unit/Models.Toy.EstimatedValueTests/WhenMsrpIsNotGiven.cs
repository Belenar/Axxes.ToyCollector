using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Axxes.ToyCollector.Tests.Core.Unit.Models.Toy.EstimatedValueTests
{
    [TestClass]
    public class WhenMsrpIsNotGiven
    {
        private readonly ToyCollector.Core.Models.Toy _toy;

        public WhenMsrpIsNotGiven()
        {
            //Arrange
            _toy = new ToyCollector.Core.Models.Toy
            {
                Msrp = null
            };
        }

        [TestMethod]
        public void ThenEstimatedValueShouldBeNull()
        {
            // Act
            var estimatedValue = _toy.EstimatedValue;

            //Assert
            Assert.IsNull(estimatedValue);
        }
    }
}