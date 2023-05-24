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
    public class Over1000Cupon : ICupon
    {
        public double discount { get; set; }


        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonConstructor]
        public Over1000Cupon(double discount)
        {
            Type = "Over1000Cupon";
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

        public string GetCuponType()
        {
            return Type;
        }
    }
}
