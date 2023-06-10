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
    public class InventoryTests
    {
        [TestMethod]
        public void AddBike_ValidBikeData_AddsNewBikeToInventory()
        {
            //Arrange
            Inventory inventory = GetMockInvenotry();
            Bike bike = new Bike(1, "giant", 299.99, 34, new byte[1], BikeType.MountainBike);

            //Act
            inventory.AddBike(bike);

            //Assert
            Assert.AreEqual(bike, inventory.GetBike(1));
        }


        [DataTestMethod]
        [DataRow(1, null, 500, 5)]
        [DataRow(2, "Brand", -500, 5)]
        [DataRow(3, "Brand", 500, -5)]
        public void AddBike_InvalidBikeData_ThrowsArgumentException(int id, string brand, double price, int stock)
        {
            //Arrange
            Inventory inventory= GetMockInvenotry();
            Bike bike = new Bike(id, brand, price, stock, new byte[1], BikeType.MountainBike);

            //Assert
            Assert.ThrowsException<ArgumentException>(() => inventory.AddBike(bike));
        }

        [TestMethod]
        public void RemoveBike_ValidBikeId_DeletesBikeFromInventory()
        {
            //Arrange
            Inventory inventory = GetMockInvenotry();
            Bike bike = new Bike(1, "giant", 299.99, 34, new byte[1], BikeType.MountainBike);
            inventory.AddBike(bike);

            //Act
            inventory.RemoveBike(1);

            //Assert
            Assert.AreNotEqual(bike, inventory.GetBike(1));
        }

        [TestMethod]
        public void RemoveBike_InvalidBikeId_ThrowsArgumentException()
        {
            //Arrange
            int bikeId = 1;
            Inventory inventory = GetMockInvenotry();

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => inventory.RemoveBike(bikeId));
        }

        [TestMethod]
        public void GetBike_ValidBikeId_CallsGetBikeMethod()
        {
            //Arrange
            Inventory inventory = GetMockInvenotry();
            int bikeId = 1;
            Bike bike = new Bike(1, "giant", 299.99, 34, new byte[1], BikeType.MountainBike);
            inventory.AddBike(bike);
            
            //Act
            var result = inventory.GetBike(bikeId);

            //Assert
            Assert.AreEqual(result, bike);

        }

        [TestMethod]
        public void UpdateBike_ValidData_ShouldUpdateBikeData()
        {
            //Arrange
            Inventory inventory = GetMockInvenotry();
            Bike bike = new Bike(1, "giant", 299.99, 34, new byte[1], BikeType.MountainBike);
            int stock = 12;
            double price = 3445.23;
            byte[] img = new byte[1];
            inventory.AddBike(bike);

            //Act
            inventory.UpdateBike(bike.GetId(), price, stock, img);
            var result = inventory.GetBike(bike.GetId());

            //Assert
            Assert.AreEqual(result.GetPrice(), price);
            Assert.AreEqual(result.GetStock(), stock);
            Assert.AreEqual(result.GetImageData(), img);

        }

        [TestMethod]
        [DataRow(1, 0, 5, new byte[] { 1, 2, 3 })]
        [DataRow(1, 500, -5, new byte[] { 1, 2, 3 })]
        [DataRow(1, -500, -5, new byte[] { 1, 2, 3 })]
        public void UpdateBike_InvalidData_ShouldThrowArgumentException(int id, double price, int stock, byte[] img)
        {
            //Arrange
            Inventory inventory = GetMockInvenotry();
            Bike bike = new Bike(id, "giant", 299.99, 34, new byte[1], BikeType.MountainBike);
            inventory.AddBike(bike);

            //Act & Assert
            Assert.ThrowsException<ArgumentException>(() => inventory.UpdateBike(bike.GetId(), price, stock, img));
        }

        [TestMethod]
        public void GetAll_ShouldReturnAllBikes()
        {
            // Arrange
            Inventory inventory = GetMockInvenotry();
            var bikes = new List<Bike>{
            new Bike(1, "giant", 299.99, 34, new byte[1], BikeType.MountainBike),
            new Bike(2, "giant", 299.99, 34, new byte[1], BikeType.MountainBike),
            new Bike(3, "giant", 299.99, 34, new byte[1], BikeType.MountainBike),
            };

            foreach(var b in bikes)
            {
                inventory.AddBike(b);
            }

            // Act
            var result = inventory.GetBikes();

            // Assert
            CollectionAssert.AreEquivalent(bikes, result);
        }

        private Inventory GetMockInvenotry()
        {
            return new Inventory(new MockBikes());
        } 
    }
}
