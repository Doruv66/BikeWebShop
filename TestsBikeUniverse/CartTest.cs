using BikeClassLibrary;
using BikeLibrary.BLL;
using BikeLibrary.BLL.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsBikeUniverse.MockData;

namespace TestsBikeUniverse
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Add_AddsItemToCart()
        {
            // Arrange
            Cart cart = new Cart();

            // Act
            cart.Add(1);
            var result = cart.items.First();

            // Assert
            Assert.AreEqual(1, result.bikeid);
        }

        [TestMethod]
        public void SetCoupon_SetsTheCouponForTheCart()
        {
            // Arrange
            var cart = new Cart();
            var coup = new Coupon("ASJDA", new Over1000Coupon(11), CouponType.Over1000Coupon);

            // Act
            cart.SetCoupon(coup);

            // Assert
            Assert.AreEqual(coup, cart.coupon);
        }


        [TestMethod]
        public void GetTotalPrice_WithoutCoupon()
        {
            // Arrange
            var cart = new Cart();
            var inventory = new Inventory(new MockBikes());
            inventory.AddBike(new Bike(1, "giant", 200, 34, new byte[1], BikeType.MountainBike));
            inventory.AddBike(new Bike(2, "giant", 300, 34, new byte[1], BikeType.MountainBike));
            cart.Add(1);
            cart.Add(2);

            // Act
            var result = cart.GetTotalPrice(inventory);

            //Assert
            Assert.AreEqual(500, result);
        }

        [TestMethod]
        public void GetTotalPrice_WithCoupon()
        {
            // Arrange
            var cart = new Cart();
            var inventory = new Inventory(new MockBikes());
            inventory.AddBike(new Bike(1, "giant", 1000, 34, new byte[1], BikeType.MountainBike));
            inventory.AddBike(new Bike(2, "giant", 1000, 34, new byte[1], BikeType.MountainBike));
            cart.Add(1);
            cart.Add(2);
            cart.SetCoupon(new Coupon("ASJDA", new Over1000Coupon(10), CouponType.Over1000Coupon));

            // Act
            var result = cart.GetTotalPrice(inventory);

            //Assert
            Assert.AreEqual(1800, result);
        }

        [TestMethod]
        public void Clear_ClearsItemsAndCouponsApplied()
        {
            // Arrange
            var cart = new Cart();
            cart.Add(1);
            cart.Add(2);
            cart.SetCoupon(new Coupon("ASAAS", new Over1000Coupon(10), CouponType.Over1000Coupon));

            // Act
            cart.Clear();

            // Assert
            Assert.AreEqual(0, cart.Getitems().Count);
            Assert.AreEqual(null, cart.coupon);

        }



    }
}
