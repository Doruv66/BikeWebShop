using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsBikeUniverse
{
    [TestClass]
    public class ReturnTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Return ret = new Return(1, "wrong item", "I have received the wrong item", 2, 3);

            Assert.AreEqual(1, ret.GetId());
            Assert.AreEqual("wrong item", ret.GetReason());
            Assert.AreEqual("I have received the wrong item", ret.GetComment());
            Assert.AreEqual(2, ret.GetBikeId());
            Assert.AreEqual(3, ret.GetOrderId());
        }
    }
}
