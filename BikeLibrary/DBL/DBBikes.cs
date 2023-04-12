using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeClassLibrary;
using System.Data.SqlClient;
using BikeLibrary.DBL;

namespace BikeClassLibrary.DBL
{
	public class DBBikes : IBikeRepository
	{
		private readonly string connStr;

		public DBBikes(string connstr)
		{
			this.connStr = connstr;
		}

        public List<Bike> GetAllBikes()
        {
            var bikeList = new List<Bike>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = "SELECT * FROM AllBikes LEFT JOIN CityBikes ON AllBikes.Id = CityBikes.Id LEFT JOIN ElectricBikes ON AllBikes.Id = ElectricBikes.Id LEFT JOIN TouringBikes ON AllBikes.Id = TouringBikes.Id LEFT JOIN MountainBikes ON AllBikes.Id = MountainBikes.Id;";
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
                                bikeList.Add(bike);
                                break;
                            case BikeType.ElectricBike:
                                int batteryCapacity = (int)reader["BatteryCapacity"];
                                bike = new ElectricBike(brand, price, stock, imageData, bikeType, batteryCapacity);
                                bike.SetId(id);
                                bikeList.Add(bike);
                                break;
                            case BikeType.TouringBike:
                                int nrBags = (int)reader["NrBags"];
                                bike = new TouringBike(brand, price, stock, imageData, bikeType, nrBags);
                                bike.SetId(id);
                                bikeList.Add(bike);
                                break;
                            case BikeType.MountainBike:
                                int suspension = Convert.ToInt16(reader["Suspension"]);
                                bike = new MountainBike(brand, price, stock, imageData, bikeType, suspension);
                                bike.SetId(id);
                                bikeList.Add(bike);
                                break;
                            default:
                                bike = new Bike(brand, price, stock, imageData, bikeType);
                                bike.SetId(id);
                                bikeList.Add(bike);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return bikeList;
        }

        public bool UpdateBike(int id, double price, int stock, byte[] imgData)
		{
			try
			{
				using (SqlConnection conn = new SqlConnection(connStr))
				{
					string sql = "UPDATE AllBikes SET Price=@Price, Stock=@Stock, ImageData=@ImageData WHERE Id=@Id;";
					SqlCommand cmd = new SqlCommand(sql, conn);

					cmd.Parameters.AddWithValue("@Price", price);
					cmd.Parameters.AddWithValue("@Stock", stock);
					cmd.Parameters.AddWithValue("@ImageData", imgData);
					cmd.Parameters.AddWithValue("@Id", id);

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

        public bool DeleteBike(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string sql = @"
                    BEGIN TRAN;
                    DELETE FROM MountainBikes WHERE Id = @id;
                    DELETE FROM CityBikes WHERE Id = @id;
                    DELETE FROM TouringBikes WHERE Id = @id;
                    DELETE FROM ElectricBikes WHERE Id = @id;
                    DELETE FROM AllBikes WHERE Id = @id;
                    COMMIT TRAN;";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
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
                    connection.Open();

                    // create command to insert bike into Bikes table
                    string insertBikeSql = "INSERT INTO AllBikes (Brand, Price, Stock, ImageData, Type) VALUES (@Brand, @Price, @Stock, @ImageData, @Type); SELECT SCOPE_IDENTITY();";
                    SqlCommand insertBikeCmd = new SqlCommand(insertBikeSql, connection);
                    insertBikeCmd.Parameters.AddWithValue("@Brand", bike.GetBrand());
                    insertBikeCmd.Parameters.AddWithValue("@Price", bike.GetPrice());
                    insertBikeCmd.Parameters.AddWithValue("@Stock", bike.GetStock());
                    insertBikeCmd.Parameters.AddWithValue("@ImageData", bike.GetImageData());
                    insertBikeCmd.Parameters.AddWithValue("@Type", bike.GetBikeType());

                    // execute the insert command and get the newly inserted bike's ID
                    int newBikeId = Convert.ToInt32(insertBikeCmd.ExecuteScalar());

                    // create commands to insert bike into the corresponding child table based on its type
                    switch (bike)
                    {
                        case CityBike cityBike:
                            SqlCommand insertCityBikeCmd = new SqlCommand("INSERT INTO CityBikes (Id, Lights) VALUES (@Id, @Lights);", connection);
                            insertCityBikeCmd.Parameters.AddWithValue("@Id", newBikeId);
                            insertCityBikeCmd.Parameters.AddWithValue("@Lights", cityBike.GetLights());
                            insertCityBikeCmd.ExecuteNonQuery();
                            break;
                        case ElectricBike electricBike:
                            SqlCommand insertElectricBikeCmd = new SqlCommand("INSERT INTO ElectricBikes (Id, BatteryCapacity) VALUES (@Id, @BatteryCapacity);", connection);
                            insertElectricBikeCmd.Parameters.AddWithValue("@Id", newBikeId);
                            insertElectricBikeCmd.Parameters.AddWithValue("@BatteryCapacity", electricBike.GetBatteryCapacity());
                            insertElectricBikeCmd.ExecuteNonQuery();
                            break;
                        case TouringBike touringBike:
                            SqlCommand insertTouringBikeCmd = new SqlCommand("INSERT INTO TouringBikes (Id, NrBags) VALUES (@Id, @NrBags);", connection);
                            insertTouringBikeCmd.Parameters.AddWithValue("@Id", newBikeId);
                            insertTouringBikeCmd.Parameters.AddWithValue("@NrBags", touringBike.getNrBags());
                            insertTouringBikeCmd.ExecuteNonQuery();
                            break;
                        case MountainBike mountainBike:
                            SqlCommand insertMountainBikeCmd = new SqlCommand("INSERT INTO MountainBikes (Id, Suspension) VALUES (@Id, @Suspension);", connection);
                            insertMountainBikeCmd.Parameters.AddWithValue("@Id", newBikeId);
                            insertMountainBikeCmd.Parameters.AddWithValue("@Suspension", mountainBike.GetSuspension());
                            insertMountainBikeCmd.ExecuteNonQuery();
                            break;
                    }
                    return true;
                }
            }
            catch 
            {
                return false;
            }
        }
    }
}
