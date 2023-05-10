using BikeLibrary.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TestsBikeUniverse
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Account acc = new Account(1, new byte[] { 1, 1, 1, 1, }, new byte[] { 1, 1 }, "test@test.com");
            
            Assert.AreEqual(1, acc.GetId());
            Assert.AreEqual("test@test.com", acc.GetEmail());
        }
    }
}
