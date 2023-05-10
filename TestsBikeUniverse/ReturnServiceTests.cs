using BikeClassLibrary;
using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBikeUniverse.MockData;

namespace TestsBikeUniverse
{
    [TestClass]
    public class ReturnServiceTests
    {
        [TestMethod]
        public void AddReturn_ValidReturn_AddsReturnToService()
        {
            // Arrange
            ReturnService returnService = GetMockService();
            Return ret = new Return(1, "not the right product", "it is not the right product", 1, 1);

            // Act
            returnService.AddReturn(ret);

            // Assert
            CollectionAssert.Contains(returnService.GetAllReturns(), ret);

        }

        [TestMethod]
        public void GetAllReturns_GetsReturnsFromService()
        {
            // Arrange
            ReturnService returnService = GetMockService();
            var returns = new List<Return>{
            new Return(1, "not the right product", "it is not the right product", 1, 1),
            new Return(2, "not the right product", "it is not the right product", 1, 1),
            new Return(3, "not the right product", "it is not the right product", 1, 1)
            };

            // Act
            foreach (var ret in returns)
            {
                returnService.AddReturn(ret);
            }
            var result = returnService.GetAllReturns();

            // Assert
            CollectionAssert.AreEquivalent(result, returns);
        }
        





        private ReturnService GetMockService()
        {
            return new ReturnService(new MockReturns());
        }
    }
}
