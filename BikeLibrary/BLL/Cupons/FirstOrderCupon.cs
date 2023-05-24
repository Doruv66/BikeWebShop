using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BikeLibrary.BLL.Cupons
{
    public class FirstOrderCupon : ICupon
    {
        public double discount { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; }

        [JsonConstructor]
        public FirstOrderCupon(double discount)
        {
            Type = "FirstOrderCupon";
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

        public string GetCuponType()
        {
            return Type;
        }
    }
}
