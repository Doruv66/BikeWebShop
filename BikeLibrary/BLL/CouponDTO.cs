using BikeLibrary.BLL.Cupons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace BikeLibrary.BLL
{
    public class CouponDTO
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("type")]
        public CouponType Type { get; set; }

        [JsonPropertyName("strategy")]
        public object Strategy { get; set; }
    }
}
