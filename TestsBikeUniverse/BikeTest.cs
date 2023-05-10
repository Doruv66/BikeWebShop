using BikeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse
{
    [TestClass]
    public class BikeTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Bike b1 = new Bike(1, "giant", 122.99, 34, new byte[1], BikeType.ElectricBike);

            Assert.AreEqual(1, b1.GetId());
            Assert.AreEqual("giant", b1.GetBrand());
            Assert.AreEqual(122.99, b1.GetPrice());
            Assert.AreEqual(34, b1.GetStock());
            Assert.AreEqual(BikeType.ElectricBike, b1.GetBikeType());
        }
    }
}
