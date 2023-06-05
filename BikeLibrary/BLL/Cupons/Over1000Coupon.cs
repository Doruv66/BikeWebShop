using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Cupons
{
    public class Over1000Coupon : ICouponStrategy
    {
        public double discount { get; set; }

        [JsonConstructor]
        public Over1000Coupon(double discount)
        {
            this.discount = discount;
        }

        public double applyCupon(double totalPrice)
        {
            if(totalPrice > 1000)
            {
                return totalPrice * (1 - discount / 100);
            }
            return totalPrice;
        }

        public double GetDiscount()
        {
            return discount;
        }
    }
}
