using BikeClassLibrary;
using BikeClassLibrary.DBL;
using System.Data.SqlClient;
namespace BikeUniverseTests
{
    [TestClass]
    public class InventoryTests
    {
        private Inventory inventory;

        [TestInitialize]
        public void TestInitialize()
        {
            //Arrange
            inventory = new Inventory();
        }


        [TestMethod]
        public void GetBike_ReturnsBikeWithMatchingId()
        {
            // Arrange
            var bike1 = new MountainBike("Brand1", 1000, 1, new byte[] { 0 }, BikeType.MountainBike, 2);
            var bike2 = new CityBike("Brand2", 2000, 1, new byte[] { 0 }, BikeType.CityBike, true);
            inventory.AddBike(bike1);
            inventory.AddBike(bike2);

            // Act
            var result = inventory.GetBike(bike2.GetId());

            // Assert
            Assert.AreEqual(result, bike2);
        }

    }
}