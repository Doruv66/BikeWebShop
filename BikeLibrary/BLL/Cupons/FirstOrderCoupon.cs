using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Cupons
{
    public class FirstOrderCoupon : ICouponStrategy
    {
        public double discount { get; set; }

        [JsonConstructor]
        public FirstOrderCoupon(double discount)
        {
            this.discount = discount;
        }

        public double applyCupon(double totalPrice)
        {
            if(totalPrice > discount)
            {
                return totalPrice - discount;
            }
            return totalPrice;
        }

        public double GetDiscount()
        {
            return discount;
        }
    }
}
