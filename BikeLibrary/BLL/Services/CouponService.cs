using BikeLibrary.BLL.Cupons;
using BikeLibrary.DBL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Services
{
	public class CouponService
	{
		private ICouponRepository coupondb;

		public CouponService(ICouponRepository _coupondb)
		{
			this.coupondb = _coupondb;
		}

		public void AddCoupon(Coupon coupon)
		{
			coupondb.AddCoupon(coupon);
		}

		public Coupon ValidateCoupon(string code)
		{
			var coupon = coupondb.GetCouponByCode(code);
			if (coupon != null)
			{
				return coupon;
			}
			throw new ArgumentException("coupon code is invalid");
		}

		public Coupon GetCouponByCode(string code)
		{
			return coupondb.GetCouponByCode(code);
		}
	}
}
