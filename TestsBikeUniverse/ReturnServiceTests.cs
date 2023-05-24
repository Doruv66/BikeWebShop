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
            OrderService orderService = new OrderService(new MockOrders());
            Return ret = new Return(1, "not the right product", "it is not the right product", 1, 1);

            // Act
            orderService.AddOrder(new Order(1, "shipped", 1, new List<Item>(), DateTime.Now), new Inventory(new MockBikes()));
            returnService.AddReturn(ret, orderService);

            // Assert
            CollectionAssert.Contains(returnService.GetAllReturns(), ret);
        }

        [TestMethod]
        public void AddReturn_WithInvalidDate_ShouldThrowArgumentException()
        {
            // Arrange
            ReturnService returnService = GetMockService();
            OrderService orderService = new OrderService(new MockOrders());
            Order order = new Order(1, "shipped", 1, new List<Item>(), DateTime.Now.AddDays(-16));
            Return ret = new Return(1, "not the right product", "it is not the right product", 1, 1);
            // Act
            orderService.AddOrder(order, new Inventory(new MockBikes()));

            // Assert
            Assert.ThrowsException<ArgumentException>(() => returnService.AddReturn(ret, orderService));
        }

        [TestMethod]
        public void GetAllReturns_GetsReturnsFromService()
        {
            // Arrange
            ReturnService returnService = GetMockService();
            OrderService orderService = new OrderService(new MockOrders());
            orderService.AddOrder(new Order(1, "shipped", 1, new List<Item>(), DateTime.Now), new Inventory(new MockBikes()));
            var returns = new List<Return>{
            new Return(1, "not the right product", "it is not the right product", 1, 1),
            new Return(2, "not the right product", "it is not the right product", 1, 1),
            new Return(3, "not the right product", "it is not the right product", 1, 1)
            };

            // Act
            foreach (var ret in returns)
            {
                returnService.AddReturn(ret, orderService);
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
