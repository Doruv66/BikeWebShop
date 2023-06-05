using BikeLibrary.BLL.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.DBL.Interfaces
{
	public interface ICouponRepository
	{
		void AddCoupon(Coupon coupon);

		Coupon GetCouponByCode(string code);
	}
}
