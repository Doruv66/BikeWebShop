using BikeLibrary.BLL.Cupons;
using BikeLibrary.BLL;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BikeWebShop.Helpers
{
    public class CouponConverter : JsonConverter<ICupon>
    {
        public override ICupon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                JsonElement element = document.RootElement;

                if (!element.TryGetProperty("type", out JsonElement typeElement))
                {
                    throw new JsonException("No 'type' property found.");
                }

                string typeName = typeElement.GetString();
                ICupon coupon;

                switch (typeName)
                {
                    case nameof(FirstOrderCupon):
                        coupon = JsonSerializer.Deserialize<FirstOrderCupon>(element.GetRawText(), options);
                        break;
                    case nameof(Over1000Cupon):
                        coupon = JsonSerializer.Deserialize<Over1000Cupon>(element.GetRawText(), options);
                        break;
                    default:
                        throw new JsonException($"Invalid coupon type '{typeName}'.");
                }
                return coupon;
            }
        }

        public override void Write(Utf8JsonWriter writer, ICupon value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }

}
