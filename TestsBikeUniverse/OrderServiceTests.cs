using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Interfaces;
using BikeLibrary.DBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBikeUniverse.MockData;

namespace TestsBikeUniverse
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void GetOrders_ShouldReturnListOfOrders()
        {
            // Arrange
            OrderService orderService = GetMockService();
            Inventory inventory = new Inventory(new MockBikes());
            var orders = new List<Order>{
            new Order(1, "placed", 2, new List<Item>(), DateTime.Now),
            new Order(2, "Shipped", 3, new List<Item>(), DateTime.Now),
            new Order(3, "placed", 4, new List<Item>(), DateTime.Now),
            };

            // Act
            foreach(var order in orders)
            {
                orderService.AddOrder(order, inventory);
            }
            var result = orderService.GetOrders();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result[0].GetId());
            Assert.AreEqual("Shipped", result[1].GetStatus());
        }

        [TestMethod]
        public void GetOrder_ShouldReturnOrder()
        {
            // Arrange
            OrderService orderService = GetMockService();
            Inventory inventory = new Inventory(new MockBikes());
            Order order = new Order(1, "shipped", 2, new List<Item>(), DateTime.Now);

            // Act
            orderService.AddOrder(order, inventory);
            var result = orderService.GetOrder(order.GetId());

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(order, result);
        }

        [TestMethod]
        public void AddOrder_ShouldAddOrderAndUpdateInventory()
        {
            // Arrange
            OrderService orderService = GetMockService();
            var order = new Order(1, "placed", 3, new List<Item> { new Item(1, 2, null), new Item(2, 4, null) }, DateTime.Now);
            Inventory inventory = new Inventory(new MockBikes());
            inventory.AddBike(new Bike(1, "giant", 99.99, 34, new byte[2], BikeType.ElectricBike));
            inventory.AddBike(new Bike(2, "giant", 99.99, 20, new byte[2], BikeType.ElectricBike));
            // Act
            orderService.AddOrder(order, inventory);

            // Assert
            var bike1 = inventory.GetBike(1);
            var bike2 = inventory.GetBike(2);
            Assert.IsNotNull(bike1);
            Assert.IsNotNull(bike2);
            Assert.AreNotEqual(3, bike1.GetStock());
            Assert.AreNotEqual(2, bike2.GetStock());
            Assert.AreEqual(32, bike1.GetStock());
            Assert.AreEqual(16, bike2.GetStock());

        }

        [TestMethod]
        public void UpdateStatus_ShouldUpdateOrderStatus()
        {
            // Arrange
            OrderService orderService = GetMockService();
            Inventory inventory = new Inventory(new MockBikes());
            var order = new Order(1, "placed", 2, new List<Item>(), DateTime.Now);

            // Act
            orderService.AddOrder(order, inventory);
            orderService.UpdateStatus(order.GetId(), "shipped");

            // Assert
            Assert.AreEqual("shipped", orderService.GetOrder(order.GetId()).GetStatus());
        }

        [TestMethod]
        public void GetUserOrders_ShouldReturnAListOfOrders()
        {
            // Arrange
            OrderService orderService = GetMockService();
            Inventory inventory= new Inventory(new MockBikes());
            var orders = new List<Order>{
            new Order(1, "placed", 3, new List<Item>(), DateTime.Now),
            new Order(2, "Shipped", 3, new List<Item>(), DateTime.Now),
            new Order(3, "placed", 3, new List<Item>(), DateTime.Now),
            };

            // Act
            foreach (var order in orders)
            {
                orderService.AddOrder(order, inventory);
            }
            var result = orderService.GetUserOrders(3);

            // Assert
            CollectionAssert.AreEquivalent(result, orders);


        }

        public OrderService GetMockService()
        {
            return new OrderService(new MockOrders());
        }
    }
}
