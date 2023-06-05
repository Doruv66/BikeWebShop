using BikeLibrary.BLL.Cupons;
using BikeLibrary.BLL;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BikeWebShop.Helpers
{
    public class CouponConverter : JsonConverter<Coupon>
    {
        //public override Coupon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        //{
        //    using (JsonDocument document = JsonDocument.ParseValue(ref reader))
        //    {
        //        JsonElement element = document.RootElement;

        //        if (!element.TryGetProperty("type", out JsonElement typeElement))
        //        {
        //            throw new JsonException("No 'customType' property found.");
        //        }

        //        CouponType couponType;
        //        if (typeElement.ValueKind == JsonValueKind.String)
        //        {
        //            string typeName = typeElement.GetString();

        //            if (!Enum.TryParse(typeName, out couponType))
        //            {
        //                throw new JsonException($"Invalid coupon type '{typeName}'.");
        //            }
        //        }
        //        else if (typeElement.ValueKind == JsonValueKind.Number)
        //        {
        //            couponType = (CouponType)typeElement.GetInt32();
        //        }
        //        else
        //        {
        //            throw new JsonException("Invalid 'customType' value type.");
        //        }

        //        ICouponStrategy couponStrategy;

        //        switch (couponType)
        //        {
        //            case CouponType.FirstOrderCoupon:
        //                couponStrategy = JsonSerializer.Deserialize<FirstOrderCoupon>(element.GetRawText(), options);
        //                break;
        //            case CouponType.Over1000Coupon:
        //                couponStrategy = JsonSerializer.Deserialize<Over1000Coupon>(element.GetRawText(), options);
        //                break;
        //            default:
        //                throw new JsonException($"Invalid coupon type '{couponType}'.");
        //        }

        //        var code = element.GetProperty("code").GetString();

        //        return new Coupon(code, couponStrategy, couponType);
        //    }
        //}

        //public override void Write(Utf8JsonWriter writer, Coupon value, JsonSerializerOptions options)
        //{
        //    var dto = new CouponDTO
        //    {
        //        Code = value.Code,
        //        Type = value.type,
        //        Strategy = value.strategy
        //    };

        //    JsonSerializer.Serialize(writer, dto, options);
        //}

        public override Coupon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument document = JsonDocument.ParseValue(ref reader))
            {
                JsonElement element = document.RootElement;

                if (!element.TryGetProperty("type", out JsonElement typeElement))
                {
                    throw new JsonException("No 'type' property found.");
                }

                CouponType couponType;
                if (typeElement.ValueKind == JsonValueKind.String)
                {
                    string typeName = typeElement.GetString();

                    if (!Enum.TryParse(typeName, out couponType))
                    {
                        throw new JsonException($"Invalid coupon type '{typeName}'.");
                    }
                }
                else if (typeElement.ValueKind == JsonValueKind.Number)
                {
                    couponType = (CouponType)typeElement.GetInt32();
                }
                else
                {
                    throw new JsonException("Invalid 'type' value type.");
                }

                ICouponStrategy couponStrategy;

                switch (couponType)
                {
                    case CouponType.FirstOrderCoupon:
                        var firstOrderCoupon = JsonSerializer.Deserialize<FirstOrderCoupon>(element.GetRawText(), options);
                        couponStrategy = firstOrderCoupon;
                        break;
                    case CouponType.Over1000Coupon:
                        var over1000Coupon = JsonSerializer.Deserialize<Over1000Coupon>(element.GetRawText(), options);
                        couponStrategy = over1000Coupon;
                        break;
                    default:
                        throw new JsonException($"Invalid coupon type '{couponType}'.");
                }

                var code = element.GetProperty("code").GetString();

                return new Coupon(code, couponStrategy, couponType);
            }
        }

        public override void Write(Utf8JsonWriter writer, Coupon value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            // Write the code property
            writer.WriteString("code", value.Code);

            // Write the type property as string
            writer.WriteString("type", value.type.ToString());

            // Serialize the strategy object
            writer.WritePropertyName("strategy");
            JsonSerializer.Serialize(writer, value.strategy, value.strategy.GetType(), options);

            // Write the discount property
            writer.WriteNumber("discount", value.strategy.GetDiscount());

            writer.WriteEndObject();
        }

    }

}
