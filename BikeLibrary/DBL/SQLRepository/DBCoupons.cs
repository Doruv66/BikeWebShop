using BikeLibrary.BLL;
using BikeLibrary.BLL.Cupons;
using BikeLibrary.DBL.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeLibrary.DBL.SQLRepository
{
	public class DBCoupons : ICouponRepository
	{
		private readonly string connStr;

		public DBCoupons(string conn)
		{
			connStr = conn;
		}

		public void AddCoupon(Coupon coupon)
		{
			try
			{
				string strategyJson = JsonConvert.SerializeObject(coupon.strategy);

				using (SqlConnection connection = new SqlConnection(connStr))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand("INSERT INTO Coupons (Code, Type, discount) VALUES (@Code, @Type, @Discount)", connection))
					{
						command.Parameters.AddWithValue("@Code", coupon.Code);
						command.Parameters.AddWithValue("@Type",Convert.ToInt16(coupon.type));
						command.Parameters.AddWithValue("@Discount", coupon.strategy.GetDiscount());
						command.ExecuteNonQuery();
					}
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			}
		}

		
		public Coupon GetCouponByCode(string code)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connStr))
				{
					connection.Open();

					using (SqlCommand command = new SqlCommand("SELECT * FROM Coupons WHERE Code = @Code", connection))
					{
						command.Parameters.AddWithValue("@Code", code);
						SqlDataReader reader = command.ExecuteReader();
						if (reader.Read())
						{
							string couponType = reader["Type"].ToString();
							CouponType type = (CouponType)Enum.Parse(typeof(CouponType), couponType);
							string coupcode = reader["code"].ToString();
							double discount= Convert.ToDouble(reader["discount"]);
							switch (type)
							{
								case CouponType.Over1000Coupon:
									return new Coupon(coupcode, new Over1000Coupon(discount), type);
                                case CouponType.FirstOrderCoupon:
                                    return new Coupon(coupcode, new FirstOrderCoupon(discount), type);
                                default:
                                    throw new ArgumentException("Invalid coupon type.");
                            }
						}
					}
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return null;
		}
	}
}
