using BikeClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BikeLibrary
{
	// figure out how to load child classes
	public class DBHelper
	{
		private const string connStr = "server=localhost;database=S1_S;uid=sa;password=secret;";

		public DBHelper()
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
						double price = (double)reader["Price"];
						int stock = (int)reader["Stock"];
						byte[] imageData = (byte[])reader["ImageData"];
						bikelist.Add(new Bike(brand, price, stock, imageData));
					}
				}
				
			}
			catch (Exception ex)
			{
			}
			return bikelist;
		}

		public bool UpdateBike(Bike bike)
		{
			try
			{
				using(SqlConnection connection= new SqlConnection(connStr))
				{
					string sql = $"UPDATE Bikes SET Brand={bike.GetBrand()}, Price={bike.GetPrice()}, Stock={bike.GetStock()}, ImageData={bike.GetImageData()} WHERE Id={bike.GetId()};";
					SqlCommand command = new SqlCommand(sql, connection);;

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
					string sql = $"select * from Bikes where id={id}; ";
					SqlCommand cmd = new SqlCommand(sql, conn);
					conn.Open();
					SqlDataReader reader = cmd.ExecuteReader();
					if(reader.Read())
					{
						string brand = (string)reader["Brand"];
						double price = (double)reader["Price"];
						int stock = (int)reader["Stock"];
						byte[] imageData = (byte[])reader["ImageData"];

						bike = new Bike(brand, price, stock, imageData);
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

	}
}
