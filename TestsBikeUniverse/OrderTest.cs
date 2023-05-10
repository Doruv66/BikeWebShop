using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Order o = new Order(1, "shipped", 2, new List<Item>(), DateTime.Now);

            Assert.AreEqual(1, o.GetId());
            Assert.AreEqual("shipped", o.GetStatus());
            Assert.AreEqual(2, o.GetAccid());
        }
    }
}
