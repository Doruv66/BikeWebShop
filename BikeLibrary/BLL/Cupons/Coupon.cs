using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Cupons
{
	public class Coupon
	{
		public string Code { get; set; }
		public CouponType type { get; set; }
		
		public ICouponStrategy strategy { get; set; }

		public Coupon(string code, ICouponStrategy strategy, CouponType type)
		{
			Code = code;
			this.strategy = strategy;
			this.type = type;
		}

		public double Apply(double amount)
		{
			return strategy.applyCupon(amount);
		}
	}
}
