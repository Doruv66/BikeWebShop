using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeClassLibrary;
using System.Data.SqlClient;


namespace BikeClassLibrary.DBL
{
	public class DBBikes
	{
		private const string connStr = "Data Source=mssqlstud.fhict.local; Initial Catalog=dbi507644_managestu;User ID=dbi507644_managestu;Password=Otilia_1995";

		public DBBikes()
		{
		}

		public List<Bike> GetAllBikes()
		{
			var bikelist = new List<Bike>();
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					string sql = "Select * from Bikes;";
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();

					SqlDataReader reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						int id = (int)reader["Id"];
						string brand = (string)reader["Brand"];
						double price = (double)Convert.ToDouble(reader["Price"]);
						int stock = (int)reader["Stock"];
						byte[] imageData = reader.GetSqlBytes(reader.GetOrdinal("ImageData")).Buffer;
						BikeType bikeType = (BikeType)Enum.Parse(typeof(BikeType), reader["Type"].ToString());

						Bike bike;
						switch (bikeType)
						{
							case BikeType.CityBike:
								bool lights = (bool)reader["Lights"];
								bike = new CityBike(brand, price, stock, imageData, bikeType, lights);
								bike.SetId(id);
								break;
							case BikeType.ElectricBike:
								int batteryCapacity = (int)reader["BatteryCapacity"];
								bike = new ElectricBike(brand, price, stock, imageData, bikeType, batteryCapacity);
								bike.SetId(id);
								break;
							case BikeType.TouringBike:
								int nrBags = (int)reader["NrBags"];
								bike = new TouringBike(brand, price, stock, imageData, bikeType, nrBags);
								bike.SetId(id);
								break;
							case BikeType.MountainBike:
								int suspension = (int)reader["Suspension"];
								bike = new MountainBike(brand, price, stock, imageData, bikeType, suspension);
								bike.SetId(id);
								break;
							default:
								bike = new Bike(brand, price, stock, imageData, bikeType);
								bike.SetId(id);
								break;
						}

						bikelist.Add(bike);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return bikelist;

		}

		public bool UpdateBike(int id, double price, int stock, byte[] imgData)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connStr))
				{
					string sql = "UPDATE Bikes SET Price=@Price, Stock=@Stock, ImageData=@ImageData WHERE Id=@Id;";
					SqlCommand command = new SqlCommand(sql, connection);

					command.Parameters.AddWithValue("@Price", price);
					command.Parameters.AddWithValue("@Stock", stock);
					command.Parameters.AddWithValue("@ImageData", imgData);
					command.Parameters.AddWithValue("@Id", id);

					connection.Open();
					int rowsAffected = command.ExecuteNonQuery();
					return rowsAffected > 0;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool DeleteBike(int id)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					string sql = $"Delete from Bikes where Id={id};";
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();
					int rowsAffected = cmd.ExecuteNonQuery();
					return rowsAffected > 0;
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public Bike GetBike(int id)
		{
			Bike bike;
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					string sql = $"select * from Bikes where id={id};";
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.Read())
					{
						string brand = (string)reader["Brand"];
						double price = (double)reader["Price"];
						int stock = (int)reader["Stock"];
						byte[] imageData = (byte[])reader["ImageData"];
						BikeType type = (BikeType)Enum.Parse(typeof(BikeType), reader["Type"].ToString());

						switch (type)
						{
							case BikeType.CityBike:
								bool lights = (bool)reader["Lights"];
								bike = new CityBike(brand, price, stock, imageData, type, lights);
								bike.SetId(id);
								break;
							case BikeType.ElectricBike:
								int batteryCapacity = (int)reader["BatteryCapacity"];
								bike = new ElectricBike(brand, price, stock, imageData, type, batteryCapacity);
								bike.SetId(id);
								break;
							case BikeType.TouringBike:
								int nrBags = (int)reader["NrBags"];
								bike = new TouringBike(brand, price, stock, imageData, type, nrBags);
								bike.SetId(id);
								break;
							case BikeType.MountainBike:
								int suspension = (int)reader["Suspension"];
								bike = new MountainBike(brand, price, stock, imageData, type, suspension);
								bike.SetId(id);
								break;
							default:
								bike = new Bike(brand, price, stock, imageData, type);
								bike.SetId(id);
								break;
						}

						return bike;
					}
					else
					{
						return null;
					}
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		public bool AddNewBike(Bike bike)
		{
			try
			{
				using (SqlConnection connection = new SqlConnection(connStr))
				{
					string sql = "";
					switch (bike)
					{
						case CityBike cityBike:
							sql = "INSERT INTO Bikes (Brand, Price, Stock, ImageData, Type, Lights) VALUES (@Brand, @Price, @Stock, @ImageData, @Type, @Lights)";
							break;
						case ElectricBike electricBike:
							sql = "INSERT INTO Bikes (Brand, Price, Stock, ImageData, Type, BatteryCapacity) VALUES (@Brand, @Price, @Stock, @ImageData, @Type, @BatteryCapacity)";
							break;
						case TouringBike touringBike:
							sql = "INSERT INTO Bikes (Brand, Price, Stock, ImageData, Type, NrBags) VALUES (@Brand, @Price, @Stock, @ImageData, @Type, @NrBags)";
							break;
						case MountainBike mountainBike:
							sql = "INSERT INTO Bikes (Brand, Price, Stock, ImageData, Type, Suspension) VALUES (@Brand, @Price, @Stock, @ImageData, @Type, @Suspension)";
							break;
						default:
							sql = "INSERT INTO Bikes (Brand, Price, Stock, ImageData, Type) VALUES (@Brand, @Price, @Stock, @ImageData, @Type)";
							break;
					}
					using (SqlCommand command = new SqlCommand(sql, connection))
					{
						connection.Open();
						command.Parameters.AddWithValue("@Brand", bike.GetBrand());
						command.Parameters.AddWithValue("@Price", bike.GetPrice());
						command.Parameters.AddWithValue("@Stock", bike.GetStock());
						command.Parameters.AddWithValue("@ImageData", bike.GetImageData());
						command.Parameters.AddWithValue("@Type", bike.GetBikeType());
						if (bike is CityBike cityBike)
						{
							command.Parameters.AddWithValue("@Lights", cityBike.GetLights());
						}
						else if (bike is ElectricBike electricBike)
						{
							command.Parameters.AddWithValue("@BatteryCapacity", electricBike.GetBatteryCapacity());
						}
						else if (bike is TouringBike touringBike)
						{
							command.Parameters.AddWithValue("@NrBags", touringBike.getNrBags());
						}
						else if (bike is MountainBike mountainBike)
						{
							command.Parameters.AddWithValue("@Suspension", mountainBike.GetSuspension());
						}
						int rowsAffected = command.ExecuteNonQuery();
						return rowsAffected > 0;
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
